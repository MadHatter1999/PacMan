using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacmanVTwo
{
    class OverLay
    {
        Font drawFont = new Font("Arial", 16);
        Brush drawBrush = Brushes.Red;
        Brush RedBrush = Brushes.White;
        Brush GreenBrush = Brushes.Green;
        Image LifeIcon = (Image)new Bitmap("C:\\Users\\Student\\source\\repos\\PROG2200-700-4032-NSCC-FALL2019\\Anthony_Healy\\pacman\\pacmanVTwo\\pacmanVTwo\\sprites\\pacman\\pac_left.bmp");
            
        bool isDead = false;
        int X;
        int Y;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Map"></param>
        public OverLay(Rectangle Map)
        {
            this.X = Map.X + Map.Width+5;
            this.Y = Map.Y;
        }
        /// <summary>
        /// Draw function
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g,int Life,int Score)
        {
            DrawLifeBar(X,Y,Life,g);
            DrawScore(X, Y + LifeIcon.Height,Score, g);
        }
        /// <summary>
        /// Lose OverLay
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g, String msg)
        {
            DrawGameOver(g);
            g.DrawString(msg,drawFont,drawBrush,X,Y+20);
        }

        public void Draw(Graphics g, int Life, int Score, String msg)
        {
            DrawLifeBar(X, Y, Life, g);
            DrawScore(X, Y + LifeIcon.Height, Score, g);
            g.DrawString("YOU WON\n"+msg, drawFont, GreenBrush, X, Y+75);

        }
        /// <summary>
        /// Draws the Lose screen
        /// </summary>
        /// <param name="g"></param>
        private void DrawGameOver(Graphics g)
        {
            g.DrawString("Game Over", drawFont, drawBrush, X, Y);
        }
        /// <summary>
        /// Draws the Life Bar And Handles Logic 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Lifes"></param>
        /// <param name="g"></param>
        private void DrawLifeBar(int X, int Y, int Lifes, Graphics g)
        {
                switch (Lifes)
                {
                case 0:
                    break;
                case 1:
                    g.DrawImage(LifeIcon, X, Y);
                    break;
                case 2:
                    g.DrawImage(LifeIcon, X, Y);
                    g.DrawImage(LifeIcon, X+LifeIcon.Width, Y);
                    break;
                case 3:
                    g.DrawImage(LifeIcon, X, Y);
                    g.DrawImage(LifeIcon, X + LifeIcon.Width, Y);
                    g.DrawImage(LifeIcon, X +( LifeIcon.Width*2), Y);
                    break;
            }
                
      
        }

        /// <summary>
        /// Draws Score
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Score"></param>
        /// <param name="g"></param>
        private void DrawScore(int X,int Y,int Score , Graphics g)
        {
            

            g.DrawString("Score: "+Score.ToString(),drawFont,RedBrush,X,Y);
        }
    }
}
