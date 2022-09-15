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
        Game game;

        List<Keys> pressedKeys = new List<Keys>();
        bool isGameOver = false;
        #endregion


        #region Constructor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion


        #region Private Methods
        private void OnKeyPressDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Q)
            {
                Application.Exit();
            }

            if(isGameOver)
            {
                if(e.KeyCode == Keys.S)
                {
                    // Reset Game
                    return;
                }
            }

            if(e.KeyCode == Keys.Space)
            {
                //game.FireShot();
            }


            if(pressedKeys.Contains(e.KeyCode))
            {
                pressedKeys.Remove(e.KeyCode);
            }
            pressedKeys.Add(e.KeyCode);
        }

        private void OnKeyPressUp(object sender, KeyEventArgs e)
        {
            if(pressedKeys.Contains(e.KeyCode))
            {
                pressedKeys.Remove(e.KeyCode);
            }
        }

        private void OnGameOver(object sender, KeyEventArgs e)
        {
            isGameOver = true;
            //game.GameOver();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            //game.Draw(g, animationCell);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if(pressedKeys.Count() >= 1)
            {
                switch(pressedKeys[0])
                {
                    case Keys.Left:
                    {
                        //game.MovePlayer(Direction.Left);
                    }
                    break;
                    case Keys.Right:
                    {
                        //game.MovePlayer(Direction.Right);
                    }
                    break;
                }
            }
            //game.Go();
        }
        #endregion
    }
}
