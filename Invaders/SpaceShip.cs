using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Invaders
{
    abstract class SpaceShip
    {
        #region Constructors
        public SpaceShip(Point location, int imageSize, int _horizontalInterval, int _verticalInterval)
        {
            Location = location;
            ImageSize = imageSize;
            horizontalInterval = _horizontalInterval;
            verticalInterval = _verticalInterval;
        }
        #endregion

        #region Public Fields
        public Point Location
        {
            get; protected set;
        }
        public Rectangle Area
        {
            get
            {
                return new Rectangle(Location, image.Size);
            }
        }
        public int ImageSize
        {
            get; protected set;
        }
        #endregion

        #region Protected Fields
        protected readonly int horizontalInterval = 40;
        protected readonly int verticalInterval = 10;
        protected Bitmap image;
        #endregion


        #region Public Methods
        public abstract void Move(Direction dir);
        public abstract void Draw(Graphics g, int animationCell = 0);
        #endregion

    }
}
