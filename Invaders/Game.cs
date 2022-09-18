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

            stars = new Stars(random, boundaries);
            playerStartPos = new Point(boundaries.Width / 2, boundaries.Height - 50);
            playerShip = new PlayerShip(playerStartPos, boundaries);
            invaders = new List<Invader>();
            playerShots = new List<Shot>();
            invaderShots = new List<Shot>();

            NextWave();
        }
        #endregion

        #region Public Fields
        public event EventHandler OnGameOver;
        #endregion

        #region Private Fields
        const int MaxSkipFrame = 6;
        const int InvaderImgSize = 60;

        Point playerStartPos;

        private int score = 0;
        private int life = 3;
        private int wave = 0;
        private int skippedFrame = MaxSkipFrame;
        private int curFrame = 0;

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
            if(!playerShip.IsAlive)
            {
                return;
            }
            
            foreach(Shot shot in playerShots.ToList())
            {
                if(!shot.Move())
                {
                    playerShots.Remove(shot);
                }
            }
            foreach (Shot shot in invaderShots.ToList())
            {
                if (!shot.Move())
                {
                    invaderShots.Remove(shot);
                }
            }

            MoveInvaders();
            ReturnFire();
            CheckShotCollideWithPlayer();
            CheckShotCollideWithInvader();

            if (invaders.Count() == 0)
            {
                NextWave();
            }
        }
        public void Draw(Graphics g, int animationCell, bool isGameOver)
        {
            g.FillRectangle(Brushes.Black, boundaries);

            stars.Draw(g, random);
            foreach(Invader invader in invaders)
            {
                invader.Draw(g, animationCell);
            }
            playerShip.Draw(g);
            foreach(Shot shot in playerShots)
            {
                shot.Draw(g);
            }
            foreach (Shot shot in invaderShots)
            {
                shot.Draw(g);
            }

            g.DrawString($"Score: {score}", new Font("Consolas", 15, FontStyle.Bold), Brushes.White, new Point(boundaries.X + 10, boundaries.Y + 10));
            g.DrawString($"Life: {life}", new Font("Consolas", 15, FontStyle.Bold), Brushes.White, new Point(boundaries.Width - 100, boundaries.Y + 10));

            if(isGameOver)
            {
                g.DrawString($"GAME OVER", new Font("Consolas", 100, FontStyle.Bold), Brushes.White, new Point(150, 80));
            }

        }
        public void Twinkle()
        {
            stars.Twinkle(random);
        }
        public void MovePlayer(Direction dir)
        {
            if(playerShip.IsAlive)
            {
                playerShip.Move(dir);
            }
        }
        public void FireShot()
        {
            if(playerShots.Count < 2)
            {
                Point firePos = new Point(playerShip.Location.X + (playerShip.ImageSize / 2), playerShip.Location.Y);
                playerShots.Add(new Shot(firePos, Direction.Up, boundaries));
            }
        }
        #endregion

        #region Private Methods

        void MoveInvaders()
        {
            if(curFrame > skippedFrame)
            {
                foreach (Invader invader in invaders)
                {
                    invader.Move(invaderDirection);
                }

                Func<Invader, bool> rightPred = (Invader invader) => { return invader.Location.X > (boundaries.Width - 100); };
                Func<Invader, bool> leftPred = (Invader invader) => { return invader.Location.X < 100; };
                ChangeDirAtEdge(Direction.Right, Direction.Left, rightPred);
                ChangeDirAtEdge(Direction.Left, Direction.Right, leftPred);

                var bottomInvaders =
                    from invader in invaders
                    where invader.Location.Y > playerShip.Location.Y
                    select invader;
                if(bottomInvaders.Count() > 0)
                {
                    OnGameOver(this, null);
                }
            }

            ++curFrame;
            if(curFrame > MaxSkipFrame)
            {
                curFrame = 0;
            }
        }
        void ChangeDirAtEdge(Direction dir, Direction nextDir, Func<Invader, bool> predicate )
        {
            if(invaderDirection == dir)
            {
                var edgeInvaders =
                    from invader in invaders
                    where predicate.Invoke(invader)
                    select invader;

                if (edgeInvaders.Count() > 0)
                {
                    foreach (Invader invader in invaders)
                    {
                        invader.Move(Direction.Down);
                    }
                    invaderDirection = nextDir;
                }
            }
        }

        void ReturnFire()
        {
            if(invaderShots.Count == wave +1)
            {
                return;
            }
            if(random.Next(10) < 10 - wave)
            {
                return;
            }

            var invaderColumns =
                from invader in invaders
                group invader by invader.Location.X into colums
                select colums;
            int randomNum = random.Next(invaderColumns.Count());
            var randomInvaders = invaderColumns.ElementAt(randomNum);

            var bottomInvaders =
                from invader in randomInvaders
                orderby invader.Location.Y descending
                select invader;

            Invader bottomInvader = bottomInvaders.First();
            Point firePos = new Point(bottomInvader.Location.X + bottomInvader.ImageSize / 2, bottomInvader.Location.Y + bottomInvader.ImageSize);
            invaderShots.Add(new Shot(firePos, Direction.Down, boundaries));
        }

        void CheckShotCollideWithPlayer()
        {
            foreach(Shot shot in invaderShots.ToList())
            {
                if(playerShip.Area.Contains(shot.Location))
                {
                    life--;
                    invaderShots.Remove(shot);
                    playerShip.IsAlive = false;

                    if (life <= 0)
                    {
                        OnGameOver(this, null);
                    }
                    return;
                }
            }
        }

        void CheckShotCollideWithInvader()
        {
            foreach(Shot shot in playerShots.ToList())
            {
                Invader target = invaders.FirstOrDefault(invader => invader.Area.Contains(shot.Location));
                if(target != null)
                {
                    playerShots.Remove(shot);
                    invaders.Remove(target);
                    score += target.Score;
                }
            }
        }

        void NextWave()
        {
            ++wave;
            invaderDirection = Direction.Right;

            if(wave < 7)
            {
                skippedFrame = 6 - wave;
            }
            else
            {
                skippedFrame = 0;
            }

            for (int y = 0; y < 5; ++y)
            {
                for(int x = 0; x < 6; ++x)
                {
                    Invader.Type type = (Invader.Type)y + 1;
                    Point spawnPos = new Point(x * InvaderImgSize, (y + 1) * InvaderImgSize);
                    invaders.Add(new Invader(type, spawnPos, 10 * (Invader.Type.Count - type)));
                }
            }
        }
        #endregion
    }
}
