//-----------------------------------------------------------------------------------------------------
//
// Name: Tellon Smith
//
// Course: CS 4143 - Contemporary Programming Lang, Fall 16, Dr. Stringfellow
//
// Program Assignment : #8
//
// Due Date: Tuesday, Nov. 29th, 2016, 11AM
//
// Purpose: This program is demonstrates the use of graphcis concepts. Methods such as FillEllipse,
//          FillRectange, DrawString, among others are demonstrated.
//
//-----------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program8_Graphics
{
    public partial class GraphicsForm : Form
    {
        //variables

        //commonly used pens and brushes
        private Pen black = new Pen(Color.Black);
        private Pen brown = new Pen(Color.Brown);
        private SolidBrush whiteBr = new SolidBrush(Color.White);
        private SolidBrush blackBr = new SolidBrush(Color.Black);
        private SolidBrush yellowBr = new SolidBrush(Color.Yellow);
        private SolidBrush greenBr = new SolidBrush(Color.Green);
        private SolidBrush brownBr = new SolidBrush(Color.Brown);

        //point array for        
        private Point[] treePoints;
        private Point[] mt1Points;
        private Point[] mt2Points;
        private Point[] mt3Points;
        private Point[] mt4Points;
        private Point[] mt5Points;

        //string message
        private String message = "Happy Holidays!";

        //arrays to store random numbers for snow movement
        private int[] x;
        private int[] y;
        private int[] v;
        private int[] s;

        private const int SNOW_OBJS = 5000; //snow objects
        private Random random = new Random(); //random number generator
        Bitmap bitmap; //bitmap to save drawn picture
        Bitmap bitmap2;

        bool showFirst = true;

        public GraphicsForm()
        {
            InitializeComponent();
            addObectjPoints(); //add points to the arras for the tree and mountains
            randomizeSnow(); //randomized coordinates for drawing snow
            drawBitmap(); //draw immage to bitmap
            drawBlankBitmap(); //draw a blank immage to bitmap2
        }


        //Purpose: adds the points for objects that uses an array (tree & mountains)
        //Requires: none
        //Returns: none
        private void addObectjPoints()
        {
            //temp array list
            ArrayList tree = new ArrayList();
            ArrayList mountaint1 = new ArrayList();
            ArrayList mountaint2 = new ArrayList();
            ArrayList mountaint3 = new ArrayList();
            ArrayList mountaint4 = new ArrayList();
            ArrayList mountaint5 = new ArrayList();

            //add points for tree
            tree.Add(new Point(435, 240));
            tree.Add(new Point(385, 310));
            tree.Add(new Point(400, 310));
            tree.Add(new Point(365, 350));
            tree.Add(new Point(380, 350));
            tree.Add(new Point(345, 390));
            tree.Add(new Point(525, 390));
            tree.Add(new Point(490, 350));
            tree.Add(new Point(505, 350));
            tree.Add(new Point(470, 310));
            tree.Add(new Point(485, 310));
            //add points for tree in drawing functions
            treePoints = (Point[])tree.ToArray(tree[0].GetType());

            //add points for mountain 1
            mountaint1.Add(new Point(100, 400));
            mountaint1.Add(new Point(200, 250));
            mountaint1.Add(new Point(300, 400));
            //add points for mountain 1 in drawing functions
            mt1Points = (Point[])mountaint1.ToArray(mountaint1[0].GetType());

            //add points for mountain 2
            mountaint2.Add(new Point(300, 400));
            mountaint2.Add(new Point(400, 250));
            mountaint2.Add(new Point(500, 400));
            //add points for mountain 2 in drawing functions
            mt2Points = (Point[])mountaint2.ToArray(mountaint2[0].GetType());

            //add points for mountain 3
            mountaint3.Add(new Point(400, 400));
            mountaint3.Add(new Point(550, 200));
            mountaint3.Add(new Point(700, 400));
            //add points for mountain 3 in drawing functions
            mt3Points = (Point[])mountaint3.ToArray(mountaint3[0].GetType());

            //add points for mountain 4
            mountaint4.Add(new Point(200, 400));
            mountaint4.Add(new Point(325, 180));
            mountaint4.Add(new Point(450, 400));
            //add points for mountain 4 in drawing functions
            mt4Points = (Point[])mountaint4.ToArray(mountaint4[0].GetType());

            //add points for mountain 5
            mountaint5.Add(new Point(-50, 400));
            mountaint5.Add(new Point(90, 210));
            mountaint5.Add(new Point(230, 400));
            //add points for mountain 5 in drawing functions
            mt5Points = (Point[])mountaint5.ToArray(mountaint4[0].GetType());
        }

        //Purpose: randomizes the coordinates for the snow
        //Requires: none 
        //Returns: none
        private void randomizeSnow()
        {
            x = new int[SNOW_OBJS];
            y = new int[SNOW_OBJS];
            v = new int[SNOW_OBJS];
            s = new int[SNOW_OBJS];

            for (var i = 0; i < SNOW_OBJS; i++)
            {
                assignRandomNumbers(i);
            }
        }

        //Purpose: assigns random numbers with the width and height of the panel
        //Requires: none 
        //Returns: none
        private void assignRandomNumbers(int i)
        {
            x[i] = random.Next(0, db_panel.Width - 1);
            y[i] = random.Next(0, db_panel.Height * 5 / 7);
            v[i] = random.Next(5, 20);
            s[i] = (random.Next(1, 3) * 100 + random.Next(50, 200)) / 100;
        }

        //paint event for custom (double buffered pannel)
        //NOTE: After extensive researh and testing, it has been conluded that the Onpaint is not
        //      suitable for drawing on a panel unless all the code and variables are moved into
        //      a custom panel derived from the panel class in its OnPaint method as the
        //      panel.CreateGraphics method draws to the screen (on top the panel) and not to 
        //      the panel causing redraws and heavy flickering  
        private void db_panel_Paint(object sender, PaintEventArgs e)
        {
            //graphics object
            Graphics g = e.Graphics;

            if (showFirst)
            {
                g.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height); 
            }
            else
            {
                g.DrawImage(bitmap2, 0, 0, bitmap.Width, bitmap.Height);
            }

            //draw snow
            for (var i = 0; i < SNOW_OBJS; i++)
            {
                g.FillEllipse(Brushes.White, x[i], y[i], s[i], s[i]);
            }
        }
        //Purpose: draws the picture to a bitmap
        //Requires: bitmap
        //Returns: none
        private void drawBitmap()
        {
            Graphics g;
            bitmap = new Bitmap(db_panel.Width, db_panel.Height,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            g = Graphics.FromImage(bitmap);

            //sky/background
            g.FillRectangle(Brushes.SkyBlue, 0, 0, 640, 480);

            //draw ground (snow filled)
            g.FillRectangle(whiteBr, 0, 400, 640, 80); //whilte ground
            g.DrawLine(black, new Point(0, 400), new Point(640, 400)); //black outline

            //draw mountains
            g.FillPolygon(whiteBr, mt1Points); //mountain 1
            g.DrawPolygon(black, mt1Points); //black outline
            g.FillPolygon(whiteBr, mt2Points); //mountain 2
            g.DrawPolygon(black, mt2Points); //black outline
            g.FillPolygon(whiteBr, mt3Points); //mountain 3
            g.DrawPolygon(black, mt3Points); //black outline
            g.FillPolygon(whiteBr, mt4Points); //mountain 4
            g.DrawPolygon(black, mt4Points); //black outline
            g.FillPolygon(whiteBr, mt5Points); //mountain 5
            g.DrawPolygon(black, mt5Points); //black outline

            //sun
            g.FillEllipse(yellowBr, 0, 0, 80, 80); //sun

            //Draw snowman
            g.FillEllipse(whiteBr, 50, 405, 100, 60); //bottom 
            g.DrawEllipse(black, 50, 405, 100, 60); //black outline
            g.FillEllipse(whiteBr, 65, 360, 70, 50); //top 
            g.DrawEllipse(black, 65, 360, 70, 50); //black outline
            g.FillEllipse(whiteBr, 80, 325, 40, 40); //head
            g.DrawEllipse(black, 80, 325, 40, 40); //black outline
            g.FillEllipse(blackBr, 90, 335, 5, 5); //left eye
            g.FillEllipse(blackBr, 105, 335, 5, 5); //right eye
            g.DrawArc(black, 90, 345, 20, 10, -190, -160); //smile
            g.DrawLine(brown, 75, 385, 50, 365); //left arm
            g.DrawLine(brown, 125, 385, 150, 385); //right arm
            g.DrawLine(black, 80, 330, 120, 330); //hat top 
            g.FillRectangle(blackBr, 85, 305, 30, 25); //hat brim

            //Draw tree
            g.FillPolygon(greenBr, treePoints); //tree
            g.DrawPolygon(black, treePoints); //black outline
            g.FillRectangle(brownBr, 420, 390, 25, 25); //tree stem
            g.DrawRectangle(black, 420, 390, 25, 25);  //black outline

            //draw string
            g.DrawString(message, new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular),
            new SolidBrush(Color.Red), 230, 50);

            g.Dispose(); //dispose graphics object
        }

        //Purpose: draws a blank picture to a bitmap
        //Requires: bitmap
        //Returns: none
        private void drawBlankBitmap()
        {
            Graphics g;
            bitmap2 = new Bitmap(db_panel.Width, db_panel.Height,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            g = Graphics.FromImage(bitmap2);

            g.FillRectangle(whiteBr, 0, 0, db_panel.Width, db_panel.Height);

            g.Dispose(); //dispose graphics object
        }

        //click event for start/stop button which enables and disables the timer
       private void start_stopButton_Click(object sender, EventArgs e)
        {
            if (start_stopButton.Text == "START")
            {
                //enable timer and change text
                timer1.Enabled = true;
                start_stopButton.Text = "STOP";
            }
            else
            {
                //disable timer and change text
                timer1.Enabled = false;
                start_stopButton.Text = "START";
            }
        }

        //timer event which controls the animation
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (var i = 0; i < SNOW_OBJS; i++)
            {
                y[i] = y[i] + v[i];
                if (y[i] >= db_panel.Height) //if y os greater out if bound
                {
                    assignRandomNumbers(i); //reassign number
                }
            }
            db_panel.Invalidate(); //invalidate panel
        }

        //timer event which controls the flashing of images
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (showFirst == false)
            {
                showFirst = true;
            }
            else
            {
                showFirst = false;
            }
        }

        //envent to enable flashing when the animation is started
        private void flash_imageCheckBox_Click(object sender, EventArgs e)
        {
            if (flash_imageCheckBox.Checked == true)
            {
                timer2.Enabled = true;
            }
            else
            {
                timer2.Enabled = false;
            }
        }
    }
}
