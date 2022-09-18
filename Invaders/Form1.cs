using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invaders
{
    public partial class Form1 : Form
    {
        #region Private Fields
        const int AnimationCellMax = 3;

        List<Keys> pressedKeys = new List<Keys>();
        Game game;
        bool isGameOver = false;
        Random random = new Random();

        int animationCellCnt;
        bool isIncreaseCellCnt;
        #endregion


        #region Constructor
        public Form1()
        {
            InitializeComponent();
            game = new Game(random, ClientRectangle);
            game.OnGameOver += new EventHandler(game_OnGameOver);
            isIncreaseCellCnt = true;
            animationTimer.Start();
        }
        #endregion


        #region Private Methods
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            UpdateAnimationCellCnt();
            game.Twinkle();
            Refresh();
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!isGameOver)
            {
                if (pressedKeys.Count() >= 1)
                {
                    switch (pressedKeys[0])
                    {
                        case Keys.Left:
                        {
                            game.MovePlayer(Direction.Left);
                        }
                        break;
                        case Keys.Right:
                        {
                            game.MovePlayer(Direction.Right);
                        }
                        break;
                    }
                }
                game.Go();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics, animationCellCnt, isGameOver);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Q)
            {
                Application.Exit();
            }

            if(e.KeyCode == Keys.S)
            {
                ResetGame();
                return;
            }

            if(e.KeyCode == Keys.Space)
            {
                game.FireShot();
            }

            if(pressedKeys.Contains(e.KeyCode))
            {
                pressedKeys.Remove(e.KeyCode);
            }
            pressedKeys.Add(e.KeyCode);
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(pressedKeys.Contains(e.KeyCode))
            {
                pressedKeys.Remove(e.KeyCode);
            }
        }
        private void game_OnGameOver(object sender, EventArgs e)
        {
            isGameOver = true;
            gameTimer.Stop();
            Invalidate();
        }
        private void ResetGame()
        {
            isGameOver = false;
            game = new Game(random, ClientRectangle);
            game.OnGameOver += new EventHandler(game_OnGameOver);
            gameTimer.Start();
        }
        private void UpdateAnimationCellCnt()
        {
            if(isIncreaseCellCnt)
            {
                animationCellCnt++;
                if (animationCellCnt == AnimationCellMax)
                {
                    isIncreaseCellCnt = false;
                }
            }
            else
            {
                animationCellCnt--;
                if (animationCellCnt == 0)
                {
                    isIncreaseCellCnt = true;
                }
            }
        }
        #endregion

    }
}
