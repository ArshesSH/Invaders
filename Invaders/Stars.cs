using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Invaders
{
    public class Stars
    {
        #region Inner Class
        private struct Star
        {
            #region Constructor
            public Star(Point point, Brush brush)
            {
                Pos = point;
                ColorBrush = brush;
            }
            #endregion

            #region Public Fields
            public Point Pos;
            public Brush ColorBrush;
            #endregion
        }
        private enum StarColor
        {
            Blue,
            LightBlue,
            White,
            Yellow,
            Orange,
            Red,
            Size
        }
        #endregion

        #region Constructor
        public Stars(Random random, Rectangle clientRect)
        {
            this.clientRect = clientRect;
            for(var i = 0; i < StarCnt; ++i)
            {
                AddStar(random);
            }
        }
        #endregion

        #region Private Fields
        const int StarCnt = 300;
        const int TwinkleCnt = 5;
        List<Star> stars = new List<Star>();
        Rectangle clientRect;
        #endregion


        #region Public Methods
        public void Draw(Graphics g, Random random)
        {
            foreach (var star in stars)
            {
                g.FillRectangle(star.ColorBrush, star.Pos.X, star.Pos.Y, 1, 1);
            }
        }

        public void Twinkle(Random random)
        {
            stars.RemoveRange(0, TwinkleCnt);
            for(var i = 0; i < TwinkleCnt; ++i)
            {
                AddStar(random);
            }
        }
        #endregion


        #region Private Methods
        Brush GetRandomColor(Random random)
        {
            Brush colorBrush = null;
            StarColor starColor = (StarColor)random.Next(0, (int)StarColor.Size);
            switch(starColor)
            {
                case StarColor.Blue:
                {
                    colorBrush = Brushes.Blue;
                }
                break;
                case StarColor.LightBlue:
                {
                    colorBrush = Brushes.DodgerBlue;
                }
                break;
                case StarColor.White:
                {
                    colorBrush = Brushes.White;
                }
                break;
                case StarColor.Yellow:
                {
                    colorBrush = Brushes.Yellow;
                }
                break;
                case StarColor.Orange:
                {
                    colorBrush = Brushes.Orange;
                }
                break;
                case StarColor.Red:
                {
                    colorBrush = Brushes.OrangeRed;
                }
                break;
                default:
                {
                    MessageBox.Show("Star Color Create Error!");
                }
                break;
            }
            return colorBrush;
        }
        void AddStar(Random random)
        {
            Point randomPos = new Point(random.Next(0, clientRect.Width), random.Next(0, clientRect.Height));
            stars.Add(new Star(randomPos, GetRandomColor(random)));
        }
        #endregion
    }
}
