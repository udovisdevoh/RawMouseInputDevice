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
    public partial class MainWindow : Form, IMessageFilter
    {
        private int previousX = 0;

        private int previousY = 0;

        private RawMouseHandler mouseHandler;

        //  Initialization
        public MainWindow()
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
            int x;
            int y;
            mouseHandler.GetMouseMovement(message, out x, out y);

            if (x != previousX || y != previousY)
            {
                System.Diagnostics.Debug.WriteLine(x + ", " + y);
            }

            this.previousX = x;
            this.previousY = y;

            return false;
        }
    }
}