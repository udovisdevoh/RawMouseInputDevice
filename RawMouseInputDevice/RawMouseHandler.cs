using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RawMouseInputDevice
{
    public class RawMouseHandler
    {
        #region Constants
        private const int RID_INPUT = 0x10000003;

        private const int RIDEV_INPUTSINK = 0x00000100;
        #endregion

        #region Members
        public bool LockForBuzzersOnly = true;

        public List<int> BuzzerDevices = new List<int>();
        #endregion

        #region Constructors
        public RawMouseHandler(IntPtr hwnd)
        {
            RawInputDevice[] rid = new RawInputDevice[1];

            rid[0].usUsagePage = 0x01;
            rid[0].usUsage = 0x02;
            rid[0].dwFlags = RIDEV_INPUTSINK;
            rid[0].hwndTarget = hwnd;

            if (!RegisterRawInputDevices(rid, (uint)rid.Length, (uint)Marshal.SizeOf(rid[0])))
            {
                throw new ApplicationException("Failed to register raw input device(s).");
            }
        }
        #endregion

        [DllImport("user32.dll", SetLastError = true)]
        extern static uint GetRawInputDeviceInfo(IntPtr hDevice, uint uiCommand, IntPtr pData, ref uint pcbSize);

        [DllImport("User32.dll")]
        extern static uint GetRawInputData(IntPtr hRawInput, uint uiCommand, IntPtr pData, ref uint pcbSize, uint cbSizeHeader);

        [DllImport("User32.dll")]
        extern static bool RegisterRawInputDevices(RawInputDevice[] pRawInputDevice, uint uiNumDevices, uint cbSize);

        public void GetMouseMovement(Message message, out int xRelative, out int yRelative)
        {
            uint dwSize = 0;

            GetRawInputData(
                message.LParam,
                RID_INPUT,
                IntPtr.Zero,
                ref dwSize,
                (uint)Marshal.SizeOf(typeof(RawInputHeader))
            );

            IntPtr buffer = Marshal.AllocHGlobal((int)dwSize);

            xRelative = 0;
            yRelative = 0;

            RawInput raw = (RawInput)Marshal.PtrToStructure(buffer, typeof(RawInput));
            Marshal.FreeHGlobal(buffer);

            if (raw.Header.Type == RawInputType.Mouse)
            {
                xRelative = raw.Mouse.LastX;
                yRelative = raw.Mouse.LastY;
            }   
        }
    }
}
