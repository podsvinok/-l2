using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
namespace qwe12
{
    class Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    };
    class Circle
    {
        Random random = new Random();
        public int width;
        public int selected;
        public Point point;
        public float radius;
        public Circle()
        {
            selected = -1;
            width = 2;
            point = new Point(random.Next(100, 350), random.Next(100, 350));
            radius = 200;
        }
        public int IsSelected(int x, int y)
        {
            selected = -1;

            if (Math.Pow(x - point.x, 2) + Math.Pow(y - point.y, 2) <= Math.Pow(radius / 2, 2) + radius &&
                Math.Pow(x - point.x, 2) + Math.Pow(y - point.y, 2) >= Math.Pow(radius / 2, 2) - radius)
            {
                selected = 1;
                return 1;
            }
            else if (Math.Pow(x - point.x, 2) + Math.Pow(y - point.y, 2) <= Math.Pow(radius / 2, 2))
            {
                selected = 1;
                return 0;
            }
            return -1;
        }
        public void ChangeXY(int x, int y)
        {
            if (selected != -1)
            {
                point.x = x;
                point.y = y;
            }
        }
        public void ChangeRadius(int q, int w)
        {
            radius = Convert.ToSingle(Math.Pow(Math.Pow(point.x - q, 2) + Math.Pow(point.y - w, 2), 0.5) * 2);
        }
        public void Repaint(ref PictureBox picture, Color color)
        {
            Graphics g = picture.CreateGraphics();

            Pen p = new Pen(color, width + 4);
            Pen pv = new Pen(color == Color.White ? Color.White : Color.Black, width);
            g.DrawEllipse(pv, point.x - radius / 2, point.y - radius / 2, radius, radius);
            //g.FillEllipse(new SolidBrush(color), new RectangleF(point.x - radius / 2, point.y - radius / 2, radius, radius));
            g.Dispose();
            p.Dispose();
            pv.Dispose();
        }
    }
}