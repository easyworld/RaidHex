using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidHex
{
    class Den
    {
        public static int bytesOfDen = 0x18;
        public static int seedOffset = 0x8;
        public static int seedSize = 0x8;
        public static int starsOffset = 0x10;
        public static int randRollOffset = 0x11;
        public static int typeOffset = 0x12;
        public static int flagOffset = 0x13;

        public Den(byte[] bytes)
        {
            if (bytes == null || bytes.Length != bytesOfDen)
                this.bytes = new byte[bytesOfDen];
            else
                this.bytes = bytes;
        }

        public byte[] getBytes()
        { return bytes; }

        private byte[] bytes;

        public string Seed 
        { 
            get 
            { 
                return BitConverter.ToString(bytes.Skip(seedOffset).Take(seedSize).Reverse().ToArray()).Replace("-", "");
            }
            set
            {
                var littleEndianBytes = Enumerable.Range(0, value.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(value.Substring(x, 2), 16))
                     .ToArray().Reverse().ToArray();
                for (int i = seedOffset,j=0; i < seedOffset + seedSize; i++,j++)
                {
                    bytes[i] = littleEndianBytes[j];
                }
            }
        }
        public byte Stars { get { return bytes[starsOffset]; } set { bytes[starsOffset] = value; } }
        public byte StarsDisplay { get { return (byte)(bytes[starsOffset] + 1); } set { bytes[starsOffset] = (byte)(value - 1); } }
        public byte RandRoll { get { return bytes[randRollOffset]; } set { bytes[randRollOffset] = value; } }
        public byte DenType { get { return bytes[typeOffset]; } set { bytes[typeOffset] = value; } }
        public byte Flags { get { return bytes[flagOffset]; } set { bytes[flagOffset] = value; } }
        public bool IsRare { get { return bytes[typeOffset] > 0 && (bytes[typeOffset] & 1) == 0; } set{ bytes[typeOffset] = (byte)(value ? bytes[typeOffset] & 1 : bytes[typeOffset] & 0); } }
        public bool HasWatts { get { return (bytes[flagOffset] & 1) == 0; }set { bytes[flagOffset] = (byte)(value ? bytes[flagOffset] & 1 : bytes[flagOffset] & 0); } }
    }
}
