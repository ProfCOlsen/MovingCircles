// Altaf Ahmad CIS 345 Fall 2017
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

        int circleX = 300;
        int circleY = 0;
        int lastX = 300;
        int lastY = 0;
        //Add line from ProfCOlsen
        string name = "Chris";


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
            if (circleY > (this.Size.Height - 100))
            {
                circleDirection = false;       
            }
            else if (circleY < 0)
            {
                circleDirection = true;
            }
            if (circleDirection)
            {
                circleY += 10;
            }
            else
            {
                circleY -= 10;
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

        private void button1_Click(object sender, EventArgs e)
        {
            // test event handler
            int x = 0;
            if (x == 0)
                x = 4;
            int y = 56;
            if (y != 100)
                MessageBox.Show("y is not 100");

        }
    }
}
