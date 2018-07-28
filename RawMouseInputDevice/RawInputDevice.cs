using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RawMouseInputDevice
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct RawInputDevice
    {
        [MarshalAs(UnmanagedType.U2)]
        public ushort usUsagePage;

        [MarshalAs(UnmanagedType.U2)]
        public ushort usUsage;

        [MarshalAs(UnmanagedType.U4)]
        public int dwFlags;

        public IntPtr hwndTarget;
    }
}
