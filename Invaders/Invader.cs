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
            Bug,
            Saucer,
            Satellite,
            SpaceShip,
            Star
        }
        #endregion

        #region Constructor
        //public Invader(Type invaderType, Point location, int score)
        //{
        //    InvaderType = invaderType;
        //    Location = location;
        //    Score = score;
        //    image = InvaderImage(0);
        //}
        public Invader(Type invaderType, Point location, int score)
            :
            base(location, VerticalInterval, HorizontalInterval)
        {
            InvaderType = invaderType;
            Score = score;
            image = InvaderImage(0);
        }


        #endregion


        #region Public Fields
        //public Point Location
        //{
        //    get; private set;
        //}
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
        #endregion


        #region Public Methods
        public override void Move(Direction dir)
        {
            switch(dir)
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
                case Direction.Down:
                {
                    Location = new Point(Location.X, Location.Y + verticalInterval);
                }
                break;
            }
        }

        public override void Draw(Graphics g, int animationCell)
        {

        }

        private Bitmap InvaderImage(int animationCell)
        {
            return null;
        }


        #endregion


        #region Private Methods
        #endregion
    }
}
