using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Invaders
{
    class PlayerShip : SpaceShip
    {
        #region Constructor
        public PlayerShip(Point location)
            :
            base(location)
        {

        }
        #endregion

        #region Public Fields
        public bool IsAlive;
        #endregion

        #region Private Fields
        bool isAlive = false;
        int deadShipHeight;
        DateTime time;
        #endregion

        #region Public Methods
        public override void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                {
                    Location = new Point(Location.X + horizontalInterval, Location.Y);
                }
                break;
                case Direction.Right:
                {
                    Location = new Point(Location.X - horizontalInterval, Location.Y);
                }
                break;
            }
        }

        public override void Draw(Graphics g, int animationCell)
        {
            if(IsAlive)
            {
                g.DrawImage(image, Location);
            }
            else
            {
            }
        }

        #endregion

        #region Private Methods
        #endregion
    }
}
