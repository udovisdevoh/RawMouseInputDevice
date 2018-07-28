using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RawMouseInputDevice
{
    public partial class Form1 : Form, IMessageFilter
    {
        private RawMouseHandler mouseHandler;

        //  Initialization
        public Form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            mouseHandler = new RawMouseHandler(this.Handle);
        }

        private void frmQuizMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.RemoveMessageFilter(this);
        }

        public bool PreFilterMessage(ref Message message)
        {
            int HardID = mouseHandler.GetDeviceID(message);

            if (HardID > 0)
            {
                System.Diagnostics.Debug.WriteLine("Device ID : " + HardID.ToString());
                //Return true here if you want to supress the mouse click
                //bear in mind that mouse down and up messages will still pass through, so you will need to filter these out and return true also.
            }

            return false;
        }
    }
}