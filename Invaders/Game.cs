using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Invaders
{
    public class Game
    {
        #region Constructor
        public Game(Random random, Rectangle clientRect)
        {
            this.random = random;
            boundaries = clientRect;
        }
        #endregion

        #region Public Fields
        public event EventHandler GameOver;
        #endregion

        #region Private Fields
        private int score = 0;
        private int life = 2;
        private int wave = 0;
        private int skippedFrame = 0;

        private Rectangle boundaries;
        private Random random;
        
        private Direction invaderDirection;
        private List<Invader> invaders;

        private PlayerShip playerShip;
        private List<Shot> playerShots;
        private List<Shot> invaderShots;

        private Stars stars;
        #endregion


        #region Public Methods
        public void Go()
        {
            
        }
        public void Draw(Graphics g, int animationCell)
        {
            g.FillRectangle(Brushes.Black, boundaries);

        }
        public void Twinkle()
        {
            //stars.Twinkle();
        }
        public void MovePlayer(Direction dir)
        {
            if(life <= 0)
            {
                return;
            }
            //playerShip.Move();
        }
        public void FireShot()
        {
            if(playerShots.Count <= 2)
            {
                //playerShots.Add(new Shot());
            }
        }
        #endregion

        #region Private Methods
        void NextWave()
        {

        }
        #endregion
    }
}
