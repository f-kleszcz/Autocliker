using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoclicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwdata, int dwextrainfo);

        public enum Mouseeventflags
        {
               LeftDown = 2,
               LeftUp = 4,

        }
        public void Leftclick(Point p)
        {

            mouse_event((int)(Mouseeventflags.LeftDown), p.X, p.Y,0,0);
            mouse_event((int)(Mouseeventflags.LeftUp), p.X, p.Y,0, 0);
        }
        bool stop = true;
        private void button1_Click(object sender, EventArgs e)
        {
            stop = (stop) ? false : true;
            timer1.Interval = (int)numericUpDown1.Value;
            timer1.Enabled = true;
            if (!stop) timer1.Start();
            if (stop) timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Leftclick(new Point(MousePosition.X, MousePosition.Y));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                stop = (stop) ? false : true;
                timer1.Interval = (int)numericUpDown1.Value;
                timer1.Enabled = true;
                if (!stop) timer1.Start();
                if (stop) timer1.Stop();
            }
        }
    }
}
