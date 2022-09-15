using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Invaders
{
    class Shot
    {
        #region Constructor
        public Shot(Point location, Direction direction, Rectangle boundaries)
        {
            Location = location;
            this.direction = direction;
            this.boundaries = boundaries;
        }
        #endregion

        #region Public Fields
        public Point Location
        {
            get;
            private set;
        }
        #endregion

        #region Private Fields
        const int moveSpeed = 20;
        const int width = 5;
        const int height = 15;

        Direction direction;
        Rectangle boundaries;
        #endregion

        #region Public Methods
        public void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Yellow, new Rectangle(Location, new Size(width, height)));
        }
        #endregion

    }
}
