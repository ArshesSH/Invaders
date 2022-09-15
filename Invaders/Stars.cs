using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Invaders
{
    public class Stars
    {
        #region Inner Class
        private struct Star
        {
            #region Constructor
            public Star(Point point, Pen pen)
            {
                Pos = point;
                ColorPen = pen;
            }
            #endregion

            #region Public Fields
            public Point Pos;
            public Pen ColorPen;
            #endregion
        }
        #endregion

        #region Private Fields
        List<Star> stars;
        #endregion


        #region Public Methods
        public void Draw(Graphics g, Random random)
        {
            foreach(var star in stars)
            {
            }
        }
        #endregion
    }
}
