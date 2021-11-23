using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenGL.Net
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DDA.dda(40,40,405,405);
    }

        private void button2_Click(object sender, EventArgs e)
        {
            Bresenham.bresenham(40, 40, 405, 405);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Krug.krugBres();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Krug2.krug2();
        }
    }
}
