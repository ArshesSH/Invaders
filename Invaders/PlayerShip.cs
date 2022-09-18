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
        public PlayerShip(Point location, Rectangle boundaries)
            :
            base(location,PlayerShipSize, MoveSpeed, MoveSpeed)
        {
            image = Properties.Resources.player;
            isAlive = true;
            shipHeight = 1.0f;
            Boundaries = boundaries;
        }

        #region Public Fields
        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
            set
            {
                isAlive = value;
                if (!value)
                {
                    time = DateTime.Now;
                }
            }
        }
        public Rectangle Boundaries
        {
            get; protected set;
        }
        public static int PlayerShipSize
        {
            get { return playerShipSize; }
        }
        #endregion


        #region Private Fields
        const int playerShipSize = 50;
        const int MoveSpeed = 10;
        const float DeadTime = 3.0f;
        bool isAlive;
        float shipHeight;
        DateTime time;

        #endregion


        #region Public Methods
        public override void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                {
                    Point nextPos = new Point(Location.X - horizontalInterval, Location.Y);
                    if( nextPos.X > PlayerShipSize )
                    {
                        Location = nextPos;
                    }
                }
                break;
                case Direction.Right:
                {
                    Point nextPos = new Point(Location.X + horizontalInterval, Location.Y);
                    if (nextPos.X < Boundaries.Width - PlayerShipSize)
                    {
                        Location = nextPos;
                    }
                }
                break;
            }
        }

        public override void Draw(Graphics g, int animationCell = 0)
        {
            if(IsAlive)
            {
                g.DrawImage(image, Location);
            }
            else
            {
                TimeSpan curTimeSpan = (DateTime.Now - time);
                float curTime = (float)curTimeSpan.TotalSeconds;
                float normalizedTime = curTime / 3.0f;
                shipHeight = 1.0f - normalizedTime;

                g.DrawImage(image, Location.X, Location.Y, image.Width, image.Height * shipHeight);
                if(curTime >= 3.0f)
                {
                    isAlive = true;
                }
            }
        }

        #endregion

        #region Private Methods
        #endregion
    }
}
