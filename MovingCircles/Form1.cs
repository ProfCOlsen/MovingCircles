using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovingCircles
{
    public partial class Form1 : Form
    {
        bool circleDirection = true;
        int circleX = 0;
        int circleY = 200;
        int lastX = 0;
        int lastY = 200;


        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //Create a pen for color of shape
            Pen blackPen = new Pen(Color.Black);
            //Create grapichs object called g
            Graphics g = this.CreateGraphics();
            //Draw shape using pen
            g.DrawEllipse(blackPen, new Rectangle(0, 0, 100, 100));
            //Dispose of pen object to free memeory
            blackPen.Dispose();
            //Dispose of graphics object to free memeory
            g.Dispose();
            this.Refresh();
        }

        private void moveTimer_Tick(object sender, EventArgs e)
        {
            PrintSquareToScreen(lastX, lastY);
            PrintCircleToScreen(circleX, circleY);

            //To erase old circle we need to store its printed position
            lastX = circleX;
            lastY = circleY;

            //Stop moving right when circle hits edge
            //-50 accounts for width of the circle
            if (circleX > (this.Size.Width - 70))
            {
                circleDirection = false;       
            }
            else if (circleX < 0)
            {
                circleDirection = true;
            }
            if (circleDirection)
            {
                circleX += 10;
            }
            else
            {
                circleX -= 10;
            }
        }

        private void PrintCircleToScreen(int x, int y)
        {
            Graphics formGraphics;
            formGraphics = this.CreateGraphics();

            formGraphics.FillEllipse(Brushes.Black, new Rectangle(x, y, 50, 50));
            formGraphics.Dispose();
        }

        private void PrintSquareToScreen(int x, int y)
        {
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(Brushes.WhiteSmoke, new Rectangle(x, y, 60, 60));
            formGraphics.Dispose();
        }
    }
}
