using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RawMouseInputDevice
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct RawInput
    {
        /// <summary>Header for the data.</summary>
        [FieldOffset(0)]
        public RawInputHeader Header;

        /// <summary>Mouse raw input data.</summary>
        [FieldOffset(16)]
        public RawMouse Mouse;

        /// <summary>Keyboard raw input data.</summary>
        [FieldOffset(16)]
        public RawKeyboard Keyboard;

        /// <summary>HID raw input data.</summary>
        [FieldOffset(16)]
        public RawHid Hid;
    }
}
