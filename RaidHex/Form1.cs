using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaidHex
{
    public partial class Form1 : Form
    {
        Socket socketClient = null;
        int denId = 0;
        Den den;

        private static int denOffset = 0x450c8a70;//0x450C0A80;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            InitComboBox();

        }

        private void InitComboBox()
        {
            denIdComboBox.ValueMember = "Value";
            denIdComboBox.DisplayMember = "Text";
            denIdComboBox.DataSource = GameDataSource.GetDenDataSource();
            denIdComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            denIdComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            denIdComboBox.SelectedIndexChanged += new EventHandler(denIdComboBox_SelectedIndexChanged);

            typeComboBox.ValueMember = "Value";
            typeComboBox.DisplayMember = "Text";
            typeComboBox.DataSource = GameDataSource.GetDenTypeSource();
        }

        void denIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            readFromRaid();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string ip = ipTextBox.Text;
            string portStr = portTextBox.Text;
            IPAddress address = IPAddress.Parse(ip);
            IPEndPoint point = new IPEndPoint(address, Convert.ToInt32(portStr));

            try
            {
                socketClient.Connect(point);
            }
            catch (Exception)
            {
                MessageBox.Show($"open {ip}:{portStr} fail");
                return;
            }
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            //MessageBox.Show($"open {ip}:{portStr} success");
            readFromRaid();
        }

        private int getDenId()
        {
            try
            {
                denId = Convert.ToInt32(denIdComboBox.SelectedValue);
            }
            catch (Exception)
            {
                MessageBox.Show($"Raid Num:{denIdComboBox.SelectedValue} is invalid");
                return 0;
            }
            if (denId >= 0 && denId < 276)
            {
                if (denId >= 190) denId += 32;
                else if (denId >= 100) denId += 11;
                return denId;
            }
            else
            {
                MessageBox.Show($"Raid Num:{denIdComboBox.SelectedValue} is invalid");
                return 0;
            }
        }
        private void readFromRaid()
        {
            getDenId();
            int address = denOffset + 0x18 * denId;
            SendMsg($"peek {address} 0x18");
            byte[] receiveBytes = ReceiveMsg();
            if (receiveBytes != null)
                set2Panel(receiveBytes);
            else
                MessageBox.Show("Read Failed");
        }

        private void SendMsg(string msg)
        {
            msg += "\r\n";
            try
            {
                socketClient.Send(Encoding.UTF8.GetBytes(msg));
            }
            catch (Exception)
            {
                MessageBox.Show($"Send msg:{msg} failed");
            }
        }

        private byte[] ReceiveMsg()
        {
            byte[] result = null;
            try
            {
                byte[] receiveBytes = new byte[1024];
                int length = socketClient.Receive(receiveBytes);
                var receiveRawString = Encoding.UTF8.GetString(receiveBytes, 0, length - 1);
                result = Enumerable.Range(0, receiveRawString.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(receiveRawString.Substring(x, 2), 16))
                     .ToArray();
            }
            catch (Exception)
            {
                MessageBox.Show($"Receive msg failed");
            }
            return result;
        }

        private void ReadDataButton_Click(object sender, EventArgs e)
        {
            readFromRaid();
        }

        private void set2Panel(byte[] data)
        {
            //Debug.WriteLine($"seed:{0}", BitConverter.ToString(data));
            den = new Den(data);
            seedTextBox.Text = den.Seed;
            starDisplayComboBox.SelectedIndex = den.Stars;
            randRollTextBox.Text = Convert.ToString(den.RandRoll);
            typeComboBox.SelectedIndex = den.DenType;
            flagsTextBox.Text = Convert.ToString(den.Flags);
        }

        private void setData()
        {
            int address = denOffset + 0x18 * denId;

            if (den == null)
            {
                MessageBox.Show("den data is empty");
                return;
            }
            string content = BitConverter.ToString(den.getBytes()).Replace("-", "");
            //MessageBox.Show($"poke {address} 0x{content}");
            SendMsg($"poke {address} 0x{content}");
            MessageBox.Show("Success");
        }

        private void WriteDataButton_Click(object sender, EventArgs e)
        {
            den.Seed = seedTextBox.Text;
            den.Stars = (byte)starDisplayComboBox.SelectedIndex;
            den.RandRoll = Convert.ToByte(randRollTextBox.Text);
            den.DenType = (byte)typeComboBox.SelectedIndex;
            den.Flags = Convert.ToByte(flagsTextBox.Text);
            setData();
        }
    }
}
