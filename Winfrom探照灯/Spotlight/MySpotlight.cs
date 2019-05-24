using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Spotlight
{
    class MySpotlight
    {

        /// <summary>
        /// 当鼠标落下时的X坐标
        /// </summary>
        private int intDownX;

        /// <summary>
        /// 当鼠标落下时的Y坐标
        /// </summary>
        private int intDownY;

        private int intUpX;
        private int intUpY;









        //边框 画笔的颜色 大小
        private Color colorPen;
        private int intPenSize;

        // 形状的 X/Y坐标  长度 高度
        private int intShapeLocationX;
        private int intShapeLocationY;
        private int intShapeWidth;
        private int intShapeHeight;

        //获取当前 窗体的 宽 高 最大值
        private int intFormMaxWidth = Screen.PrimaryScreen.Bounds.Width;
        private int intFormMaxHeight = Screen.PrimaryScreen.Bounds.Height;

        private string myShape;

        private bool booDrawPath; //是否绘制路径的边框


        //改变时掏空 图形的最小宽度和高度
        private int intMinWidth;
        private int intMinHeight;

        private Point pointDownP;

        //判断鼠标的位置
        private bool booTopLeft;
        private bool booTopRight;
        private bool booBottomLeft;
        private bool booBottomRight;

        private bool booIsChangeSize;
        private bool booSetAll = true;

        public bool BooIsChangeSize
        {
            get { return booIsChangeSize; }
            set
            {
                booIsChangeSize = value;
            }
        }
        public Color ColorPen
        {
            get { return colorPen; }
            set { colorPen = value; }
        }
        public int IntPenSize
        {
            get { return intPenSize; }
            set { intPenSize = value; }
        }
        public int IntDownX
        {
            get { return intDownX; }
            set { intDownX = value; }
        }
        public int IntDownY
        {
            get { return intDownY; }
            set { intDownY = value; }

        }
        public int IntUpX
        {
            get { return intUpX; }
            set { intUpX = value; }
        }
        public int IntUpY
        {
            get { return intUpY; }
            set { intUpY = value; }
        }
        public int IntShapeLocationX
        {
            get { return intShapeLocationX; }
            set { intShapeLocationX = value; }
        }
        public int IntShapeLocationY
        {
            get { return intShapeLocationY; }
            set { intShapeLocationY = value; }
        }
        public int IntShapeWidth
        {
            get { return intShapeWidth; }
            set { intShapeWidth = value; }
        }
        public int IntShapeHeight
        {
            get { return intShapeHeight; }
            set { intShapeHeight = value; }
        }
        public string MyShape
        {
            get { return myShape; }
            set { myShape = value; }
        }
        public int IntFormMaxWidth
        {
            get { return intFormMaxWidth; }
            set { intFormMaxWidth = value; }
        }
        public int IntFormMaxHeight
        {
            get { return intFormMaxHeight; }
            set { intFormMaxHeight = value; }
        }
        public bool BooDrawPath
        {
            get { return booDrawPath; }
            set { booDrawPath = value; }
        }

        public int IntMinWidth
        {
            get { return intMinWidth; }
            set { intMinWidth = value; }
        }

        public int IntMinHeight
        {
            get { return intMinHeight; }
            set { intMinHeight = value; }
        }


        public Point PointDownP
        {
            get { return pointDownP; }
            set { pointDownP = value; }
        }


        public bool BooTopLeft
        {
            get { return booTopLeft; }
            set
            {
                booTopLeft = value;
                if (value)
                {
                    booTopRight = false;
                    booBottomLeft = false;
                    booBottomRight = false;
                }

            }
        }
        public bool BooTopRight
        {
            get { return booTopRight; }
            set
            {
                booTopRight = value;
                if (value)
                {
                    booTopLeft = false;
                    booBottomLeft = false;
                    booBottomRight = false;
                }
            }
        }
        public bool BooBottomLeft
        {
            get { return booBottomLeft; }
            set
            {
                booBottomLeft = value;
                if (value)
                {
                    booTopLeft = false;
                    booTopRight = false;
                    booBottomRight = false;
                }
            }
        }
        public bool BooBottomRight
        {
            get { return booBottomRight; }
            set
            {
                booBottomRight = value;
                if (value)
                {
                    booTopLeft = false;
                    booTopRight = false;
                    booBottomLeft = false;
                }
            }
        }

        public bool BooSetAll
        {
            get { return booSetAll; }
            set
            {
                if (value)
                {
                    booTopLeft = false;
                    booTopRight = false;
                    booBottomLeft = false;
                    booBottomRight = false;
                }
            }
        }

        /// <summary>
        /// 定义掏空的形状的路径
        /// </summary>
        /// <returns>形状路径</returns>
        public GraphicsPath MyDefiningShape()
        {

            GraphicsPath gPath = new GraphicsPath();
            Rectangle rec = new Rectangle(intShapeLocationX, intShapeLocationY, intShapeWidth, intShapeHeight);
            switch (myShape)
            {
                case "strRectangle":
                    gPath.AddRectangle(rec);
                    break;

                case "strEillpse":
                    gPath.AddEllipse(rec);
                    break;
                case "shan":
                    gPath.AddPie(rec, 34, 90);
                    break;
                default:
                    break;
            }
            return gPath;
        }

        /// <summary>
        /// 定义掏空的形状
        /// </summary>
        /// <returns>形状路径</returns>
        private GraphicsPath ss()
        {
            GraphicsPath gPath = new GraphicsPath();

            //解释一下  只是为了让掏空的部分正和在边框的里面
            Rectangle rec = new Rectangle(intShapeLocationX + IntPenSize - 1, intShapeLocationY + IntPenSize - 1, intShapeWidth - IntPenSize * 2 + 2, intShapeHeight - IntPenSize * 2 + 2);
            switch (myShape)
            {
                case "strRectangle":
                    gPath.AddRectangle(rec);
                    break;

                case "strEillpse":
                    gPath.AddEllipse(rec);
                    break;

                case "shan":  //扇形
                    gPath.AddPie(rec, 55, 130);
                    break;
                default:
                    break;
            }
            return gPath;
        }

        /// <summary>
        /// 改变修改的形状
        /// </summary>
        public void ChangeShape(Form f)
        {
            Region region = new Region();
            region.Exclude(ss());

            f.Region = region;
            region.Dispose();
            f.Invalidate();

        }

        /// <summary>
        /// 根据鼠标所在不同的位置改变大小
        /// </summary>
        /// <param name="e"></param>
        public void ChangeSize(MouseEventArgs e)
        {
            if (BooBottomRight)
            {
                if (!(IntShapeWidth - (IntDownX - e.X) < IntMinWidth))
                {
                    IntShapeWidth = IntShapeWidth - (IntDownX - e.X);
                    IntDownX = e.X;

                }
                if (!(IntShapeHeight - (IntDownY - e.Y) < IntMinHeight))
                {
                    IntShapeHeight = IntShapeHeight - (IntDownY - e.Y);
                    IntDownY = e.Y;
                }
            }
            else if (BooBottomLeft)
            {
                if (!(IntShapeWidth + (IntDownX - e.X) < IntMinWidth))
                {

                    IntShapeLocationX = IntShapeLocationX - (IntDownX - e.X);
                    IntShapeWidth = IntShapeWidth + (IntDownX - e.X);
                    IntDownX = e.X;
                }
                if (!(IntShapeHeight - (IntDownY - e.Y) < IntMinHeight))
                {
                    IntShapeHeight = IntShapeHeight - (IntDownY - e.Y);
                    IntDownY = e.Y;
                }
            }
            else if (BooTopLeft)
            {
                if (IntShapeWidth + (IntDownX - e.X) > IntMinWidth)
                {
                    IntShapeLocationX = IntShapeLocationX - (IntDownX - e.X);
                    IntShapeWidth = IntShapeWidth + (IntDownX - e.X);
                    IntDownX = e.X;

                }
                if (!(IntShapeHeight + (IntDownY - e.Y) < IntMinHeight))
                {
                    IntShapeLocationY = IntShapeLocationY - (IntDownY - e.Y);
                    IntShapeHeight = IntShapeHeight + (IntDownY - e.Y);
                    IntDownY = e.Y;
                }
            }
            else if (BooTopRight)
            {
                if (IntShapeWidth - (IntDownX - e.X) > IntMinWidth)
                {
                    IntShapeWidth = IntShapeWidth - (IntDownX - e.X);
                    IntDownX = e.X;

                }
                if (!(IntShapeHeight + (IntDownY - e.Y) < IntMinHeight))
                {
                    IntShapeLocationY = IntShapeLocationY - (IntDownY - e.Y);
                    IntShapeHeight = IntShapeHeight + (IntDownY - e.Y);
                    IntDownY = e.Y;
                }
            }



        }

        /// <summary>
        /// 判断鼠标是否点在路径里面
        /// </summary>
        /// <param name="p">坐标</param>
        public void MoveOrChangeSize(Point p)
        {
            if (MyDefiningShape().IsVisible(p))
            {
                BooIsChangeSize = true;

                int intX = Math.Abs(IntDownX - IntShapeLocationX);
                int intY = Math.Abs(IntDownY - IntShapeLocationY);
                //表左上角
                if (intX < IntShapeWidth / 2 && intY < IntShapeHeight / 2)
                {
                    BooTopLeft = true;
                }
                //表示右上角
                else if (intX > IntShapeWidth / 2 && intY < IntShapeHeight / 2)
                {
                    BooTopRight = true;
                }
                //表示左下角
                else if (intX < IntShapeWidth / 2 && intY > IntShapeHeight / 2)
                {
                    BooBottomLeft = true;
                }
                //表示右下角
                else if (intX > IntShapeWidth / 2 && intY > IntShapeHeight / 2)
                {
                    BooBottomRight = true;
                }
                else
                {
                    BooSetAll = true;
                }
            }

            else
                BooIsChangeSize = false;
        }

        /// <summary>
        /// 移动形状  防止 形状越界
        /// </summary>
        public void MoveShape(MouseEventArgs e)
        {
            Point pointLocation = new Point(IntShapeLocationX - (IntDownX - e.X), IntShapeLocationY - (IntDownY - e.Y));
            if (pointLocation.X < 0 - IntShapeWidth / 2)
            {
                pointLocation.X = 0 - IntShapeWidth / 2;
            }
            if (pointLocation.Y < 0 - IntShapeHeight / 2)
            {
                pointLocation.Y = 0 - IntShapeHeight / 2;
            }
            if (pointLocation.X + IntShapeWidth > IntFormMaxWidth + IntShapeWidth / 2)
            {
                pointLocation.X = IntFormMaxWidth + IntShapeWidth / 2 - IntShapeWidth;
            }
            if (pointLocation.Y + IntShapeHeight > IntFormMaxHeight + IntShapeHeight / 2)
            {
                pointLocation.Y = IntFormMaxHeight + IntShapeHeight / 2 - IntShapeHeight;
            }

            IntShapeLocationX = pointLocation.X;
            IntShapeLocationY = pointLocation.Y;
            IntDownX = e.X;
            IntDownY = e.Y;

        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public MySpotlight()
        {

            IntShapeHeight = 230;
            IntShapeWidth = 230;
            IntShapeLocationX = Screen.PrimaryScreen.Bounds.Width / 2 - 230 / 2;
            IntShapeLocationY = Screen.PrimaryScreen.Bounds.Height / 2 - 230 / 2;

            IntMinWidth = 80;
            IntMinHeight = 80;
        }


        /// <summary>
        /// 代餐构造函数 
        /// </summary>
        /// <param name="x">形状的X坐标</param>
        /// <param name="y">形状的Y坐标</param>
        /// <param name="width">形状的宽度</param>
        /// <param name="height">形状的高度</param>
        /// <param name="minWidth">形状的最小宽度</param>
        /// <param name="minHeight">形状的最小高度</param>
        public MySpotlight(int x, int y, int width, int height, int minWidth, int minHeight)
        {
            IntShapeHeight = width;
            IntShapeWidth = height;
            IntShapeLocationX = x;
            IntShapeLocationY = y;

            IntMinWidth = minWidth;
            IntMinHeight = minHeight;
        }
    }
}
