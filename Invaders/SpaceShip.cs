﻿using System;
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
        public SpaceShip(Point location)
        {
            Location = location;
        }
        public SpaceShip(Point location, int _horizontalInterval, int _verticalInterval)
        {
            Location = location;
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
        #endregion

        #region Protected Fields
        protected readonly int horizontalInterval = 40;
        protected readonly int verticalInterval = 10;
        protected Bitmap image;
        #endregion


        #region Public Methods
        public abstract void Move(Direction dir);
        public abstract void Draw(Graphics g, int animationCell);
        #endregion

    }
}
