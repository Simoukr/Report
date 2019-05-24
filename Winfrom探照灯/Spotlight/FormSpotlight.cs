using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading;

namespace Spotlight
{
    public partial class FormSpotlight : Form
    {
        public FormSpotlight()
        {
            InitializeComponent();
            mySpotlight = new MySpotlight();
        }


        MySpotlight mySpotlight;


        private void FormSpotlight_Load(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = true;
            this.Opacity = 0.9;
            椭圆ToolStripMenuItem.Checked = true;
            黄色ToolStripMenuItem.Checked = true;
            mySpotlight.ColorPen = Color.Yellow;

            mySpotlight.IntPenSize = 20;
            mySpotlight.MyShape = "strEillpse";
            mySpotlight.BooDrawPath = true;
            mySpotlight.ChangeShape(this);
            BtnLocation();
        }



        private void FormSpotlight_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            Pen myPen = new Pen(mySpotlight.ColorPen, mySpotlight.IntPenSize);
            myPen.Alignment = PenAlignment.Inset;
            if (mySpotlight.BooDrawPath)
            {
                e.Graphics.DrawPath(myPen, mySpotlight.MyDefiningShape());
            }

        }

        private void FormSpotlight_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mySpotlight.IntDownX = e.X;
                mySpotlight.IntDownY = e.Y;
                mySpotlight.MoveOrChangeSize(new Point(e.X, e.Y));
                mySpotlight.BooDrawPath = false;

            }
        }

        private void FormSpotlight_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                //定义鼠标改变形状大小
                if (mySpotlight.BooIsChangeSize)
                {
                    mySpotlight.ChangeSize(e);
                    mySpotlight.ChangeShape(this);
                }
                else //移动
                {
                    mySpotlight.MoveShape(e);
                    mySpotlight.ChangeShape(this);
                }
                BtnLocation();
                this.Invalidate();
            }

        }

        private void FormSpotlight_MouseUp(object sender, MouseEventArgs e)
        {

            mySpotlight.BooDrawPath = true;


            mySpotlight.BooSetAll = true;
            mySpotlight.BooIsChangeSize = false;
            if (e.Button == MouseButtons.Left)
            {
                mySpotlight.IntUpX = e.X;
                mySpotlight.IntUpY = e.Y;

            }
        }

        #region 设置菜单

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            this.contextMenuStrip1.Show(button1, new Point(0, 0));
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            toolStripMenuItem5.Checked = true;

            不透明ToolStripMenuItem.Checked = false;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            this.Opacity = 0.25;
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            toolStripMenuItem4.Checked = true;

            不透明ToolStripMenuItem.Checked = false;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem5.Checked = false;
            this.Opacity = 0.5;
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            toolStripMenuItem3.Checked = true;

            不透明ToolStripMenuItem.Checked = false;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            this.Opacity = 0.75;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = true;

            不透明ToolStripMenuItem.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            this.Opacity = 0.9;
        }
        private void 不透明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            不透明ToolStripMenuItem.Checked = true;

            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            this.Opacity = 1;
        }
        private void 矩形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            椭圆ToolStripMenuItem.Checked = false;
            矩形ToolStripMenuItem.Checked = true;
            mySpotlight.MyShape = "strRectangle";
            mySpotlight.ChangeShape(this);
        }

        private void 椭圆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            椭圆ToolStripMenuItem.Checked = true;
            矩形ToolStripMenuItem.Checked = false;
            mySpotlight.MyShape = "strEillpse";
            mySpotlight.ChangeShape(this);

        }
        private void 无色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            无色ToolStripMenuItem.Checked = true;
            橙色ToolStripMenuItem.Checked = false;
            黄色ToolStripMenuItem.Checked = false;
            红色ToolStripMenuItem.Checked = false;
            蓝色ToolStripMenuItem.Checked = false;
            mySpotlight.ColorPen = Color.Black;
            mySpotlight.ChangeShape(this);
        }
        private void 黄色ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            黄色ToolStripMenuItem.Checked = true;
            橙色ToolStripMenuItem.Checked = false;
            无色ToolStripMenuItem.Checked = false;
            红色ToolStripMenuItem.Checked = false;
            蓝色ToolStripMenuItem.Checked = false;
            mySpotlight.ColorPen = Color.Yellow;
            mySpotlight.ChangeShape(this);
        }

        private void 红色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            红色ToolStripMenuItem.Checked = true;
            橙色ToolStripMenuItem.Checked = false;
            无色ToolStripMenuItem.Checked = false;
            蓝色ToolStripMenuItem.Checked = false;
            黄色ToolStripMenuItem.Checked = false;
            mySpotlight.ColorPen = Color.Red;
            mySpotlight.ChangeShape(this);
        }

        private void 蓝色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            蓝色ToolStripMenuItem.Checked = true;
            橙色ToolStripMenuItem.Checked = false;
            无色ToolStripMenuItem.Checked = false;
            红色ToolStripMenuItem.Checked = false;
            黄色ToolStripMenuItem.Checked = false;
            mySpotlight.ColorPen = Color.Blue;
            mySpotlight.ChangeShape(this);
        }

        private void 橙色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            橙色ToolStripMenuItem.Checked = true;
            蓝色ToolStripMenuItem.Checked = false;
            无色ToolStripMenuItem.Checked = false;
            红色ToolStripMenuItem.Checked = false;
            黄色ToolStripMenuItem.Checked = false;
            mySpotlight.ColorPen = Color.Orange;
            mySpotlight.ChangeShape(this);
        }

        #endregion
        /// <summary>
        ///设置 按钮坐标
        /// </summary>
        public void BtnLocation()
        {
            //button1 X 轴坐标
            int btnX = mySpotlight.IntShapeLocationX + mySpotlight.IntShapeWidth;
            //button1 Y 轴坐标
            int btnY = mySpotlight.IntShapeLocationY + mySpotlight.IntShapeHeight;
            Point pointLocation = new Point(btnX, btnY);
            if (pointLocation.X > mySpotlight.IntFormMaxWidth && mySpotlight.IntShapeLocationY - button1.Height < 0)
            {
                pointLocation.X = mySpotlight.IntShapeLocationX - button1.Width;
                pointLocation.Y = mySpotlight.IntShapeLocationY + mySpotlight.IntShapeHeight;
            }
            else if (pointLocation.Y + button1.Height > mySpotlight.IntFormMaxHeight && mySpotlight.IntShapeLocationX - button1.Width < 0)
            {
                pointLocation.X = mySpotlight.IntShapeLocationX + mySpotlight.IntShapeWidth;
                pointLocation.Y = mySpotlight.IntShapeLocationY - button1.Height;
            }
            else if (pointLocation.X + button1.Width > mySpotlight.IntFormMaxWidth)
            {
                pointLocation.X = mySpotlight.IntShapeLocationX - button1.Width;
                pointLocation.Y = mySpotlight.IntShapeLocationY - button1.Height;
            }
            else if (pointLocation.Y + button1.Height > mySpotlight.IntFormMaxHeight)
            {
                pointLocation.X = mySpotlight.IntShapeLocationX - button1.Width;
                pointLocation.Y = mySpotlight.IntShapeLocationY - button1.Height;
            }

            else
            {
                this.button1.Location = pointLocation;
            }
            this.button1.Location = pointLocation;
        }




    }
}
