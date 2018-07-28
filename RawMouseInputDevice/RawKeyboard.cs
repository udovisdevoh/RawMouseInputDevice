using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RawMouseInputDevice
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct RawKeyboard
    {
        [MarshalAs(UnmanagedType.U2)]
        public ushort MakeCode;

        [MarshalAs(UnmanagedType.U2)]
        public ushort Flags;

        [MarshalAs(UnmanagedType.U2)]
        public ushort Reserved;

        [MarshalAs(UnmanagedType.U2)]
        public ushort VKey;

        [MarshalAs(UnmanagedType.U4)]
        public uint Message;

        [MarshalAs(UnmanagedType.U4)]
        public uint ExtraInformation;
    }
}
