using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qwe12
{
    public partial class Form1 : Form
    {
        Circle qwe123;
        bool state = true;
        int mouseDown = -1;
        int x0, y0;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
            qwe123 = new Circle();
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == 0)
            {
                qwe123.Repaint(ref pictureBox1, Color.White);
                qwe123.ChangeXY(qwe123.point.x + e.X - x0, qwe123.point.y + e.Y - y0);
                qwe123.Repaint(ref pictureBox1, Color.Black);
                x0 = e.X; y0 = e.Y;
            }
            else if (mouseDown == 1)
            {
                qwe123.Repaint(ref pictureBox1, Color.White);
                qwe123.ChangeRadius(e.X, e.Y);
                qwe123.Repaint(ref pictureBox1, Color.Black);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = -1;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (state) { qwe123.selected = 1; qwe123.ChangeXY(e.X, e.Y); qwe123.Repaint(ref pictureBox1, Color.Black); qwe123.selected = -1; state = false; }
            x0 = e.X; y0 = e.Y;
            mouseDown = qwe123.IsSelected(e.X, e.Y);
        }

    }
}