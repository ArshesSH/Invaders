using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Invaders
{
    class Invader : SpaceShip
    {
        #region Enumeration Types
        public enum Type
        {
            Bug = 1,
            Saucer,
            Satellite,
            SpaceShip,
            Star,
            Count
        }
        #endregion

        #region Constructor
        public Invader(Type invaderType, Point location, int score)
            :
            base(location, InvaderSize, VerticalInterval, HorizontalInterval)
        {
            InvaderType = invaderType;
            Score = score;

            CreateImages();
            image = InvaderImage(0);
        }
        #endregion


        #region Public Fields
        public Type InvaderType
        {
            get; private set;
        }
        public int Score
        {
            get; private set;
        }
        #endregion


        #region Private Fields
        const int HorizontalInterval = 10;
        const int VerticalInterval = 40;
        const int InvaderSize = 50;

        Bitmap[] images;
        #endregion


        #region Public Methods
        public override void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                {
                    Location = new Point(Location.X - horizontalInterval, Location.Y);
                }
                break;
                case Direction.Right:
                {
                    Location = new Point(Location.X + horizontalInterval, Location.Y);
                }
                break;
                case Direction.Down:
                {
                    Location = new Point(Location.X, Location.Y + verticalInterval);
                }
                break;
            }
        }

        public override void Draw(Graphics g, int animationCell)
        {
            if( image != null)
            {
                image = images[animationCell];//InvaderImage(animationCell);
                g.DrawImage(image, Location);
            }
        }
        #endregion


        #region Private Methods
        Bitmap InvaderImage(int animationCell)
        {
            return images[animationCell];
        }
        void CreateImages()
        {
            images = new Bitmap[4];
            switch (InvaderType)
            {
                case Type.Bug:
                    images[0] = Properties.Resources.bug1;
                    images[1] = Properties.Resources.bug2;
                    images[2] = Properties.Resources.bug3;
                    images[3] = Properties.Resources.bug4;
                    break;
                case Type.Saucer:
                    images[0] = Properties.Resources.flyingsaucer1;
                    images[1] = Properties.Resources.flyingsaucer2;
                    images[2] = Properties.Resources.flyingsaucer3;
                    images[3] = Properties.Resources.flyingsaucer4;
                    break;
                case Type.Satellite:
                    images[0] = Properties.Resources.satellite1;
                    images[1] = Properties.Resources.satellite2;
                    images[2] = Properties.Resources.satellite3;
                    images[3] = Properties.Resources.satellite4;
                    break;
                case Type.SpaceShip:
                    images[0] = Properties.Resources.spaceship1;
                    images[1] = Properties.Resources.spaceship2;
                    images[2] = Properties.Resources.spaceship3;
                    images[3] = Properties.Resources.spaceship4;
                    break;
                case Type.Star:
                    images[0] = Properties.Resources.star1;
                    images[1] = Properties.Resources.star2;
                    images[2] = Properties.Resources.star3;
                    images[3] = Properties.Resources.star4;
                    break;
            }
        }
        #endregion
    }
}
