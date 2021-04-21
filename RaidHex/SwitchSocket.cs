using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RaidHex
{
    class SwitchSocket
    {
        protected Socket Connection;
        private string IP;
        private int Port;
        public bool Connected { get; protected set; }

        public int MaximumTransferSize { get; set; } = 0x1C0;

        public SwitchSocket(string ip, int port)
        {
            Connection = new Socket(SocketType.Stream,  ProtocolType.Tcp);
        }

        public void Connect()
        {
            if (Connected) return;
            IPAddress address = IPAddress.Parse(IP);
            IPEndPoint point = new IPEndPoint(address, Port);

            try
            {
                Connection.Connect(point);
                Connected = true;
                return;
            }
            catch (Exception)
            {
                throw new ApplicationException($"open {IP}:{Port} fail");
            }
        }

        public void Disconnect()
        {
            if (!Connected) return;
            Connection.Disconnect(false);
            Connected = false;
        }

        public void Reset()
        {
            Disconnect();
            Connect();
        }

        private void SendMsg(string msg)
        {
            msg += "\r\n";
            try
            {
                Connection.Send(Encoding.UTF8.GetBytes(msg));
            }
            catch (Exception)
            {
                throw new ApplicationException($"Send msg:{msg} failed");
            }
        }
        // get sysbot result to big-endian bytearray
        private byte[] ReceiveMsg(int bufferLength)
        {
            byte[] result = null;
            try
            {
                byte[] receiveBytes = new byte[(bufferLength * 2) + 1];
                int length = Connection.Receive(receiveBytes);
                var receiveRawString = Encoding.UTF8.GetString(receiveBytes, 0, length - 1);
                result = Enumerable.Range(0, receiveRawString.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(receiveRawString.Substring(x, 2), 16))
                     .ToArray();
            }
            catch (Exception)
            {
                throw new ApplicationException($"Receive msg failed");
            }
            return result;
        }

        public enum MemoryRegion { 
            /// <summary>
            /// Heap base offset
            /// </summary>
            Heap,

            /// <summary>
            /// Main NSO base offset
            /// </summary>
            Main,

            /// <summary>
            /// Raw offset (arbitrary)
            /// </summary>
            Absolute,
        }

        private byte[] Read(MemoryRegion region, ulong offset, int length)
        {
            if (length <= MaximumTransferSize)
            {
                SendMsg($"{GetReadInstruction(region)} {offset} {length} \r\n");
                return ReceiveMsg(MaximumTransferSize);
            } else
            {
                byte[] result = new byte[length];
                for(var i = 0; i < length; i += MaximumTransferSize)
                {
                    
                    int len = MaximumTransferSize;
                    int delta = length - i;
                    if (delta < MaximumTransferSize)
                        len = delta;

                    SendMsg($"{GetReadInstruction(region)} {offset + (ulong)i} {i} \r\n");
                    var bytes = ReceiveMsg(len);
                    bytes.CopyTo(result, i);
                }
                return result;
            }
        }

        private void Write(MemoryRegion region, ulong offset, byte[] data)
        {
            if (data.Length <= MaximumTransferSize)
            {
                SendMsg($"{GetWriteInstruction(region)} 0x{offset:X8} 0x{string.Concat(data.Select(z => $"{z:X2}"))} \r\n");
                return;
            }
            int byteCount = data.Length;
            for (int i = 0; i < byteCount; i += MaximumTransferSize)
            {
                var slice = SliceSafe(data, i, MaximumTransferSize);
                SendMsg($"{GetWriteInstruction(region)} 0x{offset + (uint)i:X8} 0x{string.Concat(slice.Select(z => $"{z:X2}"))} \r\n");
            }
        }

        private static byte[] SliceSafe(byte[] src, int offset, int length)
        {
            var delta = src.Length - offset;
            if (delta < length)
                length = delta;

            byte[] data = new byte[length];
            Buffer.BlockCopy(src, offset, data, 0, data.Length);
            return data;
        }

        private string GetReadInstruction(MemoryRegion region)
        {
            switch (region)
            {
                case MemoryRegion.Main:
                    return "peekMain";
                case MemoryRegion.Absolute:
                    return "peekAbsolute";
                case MemoryRegion.Heap:
                    return "peek";
                default:
                    throw new IndexOutOfRangeException("Invalid region type.");
            }
        }

        private string GetWriteInstruction(MemoryRegion region)
        {
            switch (region)
            {
                case MemoryRegion.Main:
                    return "pokeMain";
                case MemoryRegion.Absolute:
                    return "pokeAbsolute";
                case MemoryRegion.Heap:
                    return "poke";
                default:
                    throw new IndexOutOfRangeException("Invalid region type.");
            }
        }

        public ushort Peeku8(MemoryRegion region, ulong offset)
        {
            return Read(region, offset, 1)[0];
        }
        public ushort Peeku16(MemoryRegion region, ulong offset)
        {
            return BitConverter.ToUInt16(Read(region, offset, 2), 0);
        }
        public uint Peeku32(MemoryRegion region, ulong offset)
        {
            return BitConverter.ToUInt32(Read(region, offset, 4), 0);
        }
        public ulong Peeku64(MemoryRegion region, ulong offset)
        {
            return BitConverter.ToUInt32(Read(region, offset, 8), 0);
        }
    }
}
