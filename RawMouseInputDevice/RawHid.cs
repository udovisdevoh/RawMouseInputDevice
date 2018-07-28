using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RawMouseInputDevice
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RawHid
    {
        [MarshalAs(UnmanagedType.U4)]
        public int dwSizHid;

        [MarshalAs(UnmanagedType.U4)]
        public int dwCount;
    }
}
