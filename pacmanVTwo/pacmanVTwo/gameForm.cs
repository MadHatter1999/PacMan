using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacmanVTwo
{
    public partial class gameForm : Form
    {
        int oldScore = 0;
        bool hasWon=false;
        //Active Objects
        Map map;
        Player PacMan;
        Player.Direction LastInput=Player.Direction.Still;
        List<DotSmall> Dots = new List<DotSmall>();
        OverLay overlay;
        //Utility
        bool Up = false;
        bool Down = false;
        bool Left = false;
        bool Right = false;

        bool hasStarted = false;
        /// <summary>
        /// Checks on the Walls
        /// </summary>
        public void CheckWallDetection()
        {
            Up = map.HasHitWall(PacMan.HitBox);
            Down = map.HasHitWall(PacMan.HitBox);
            Left = map.HasHitWall(PacMan.HitBox);
            Right = map.HasHitWall(PacMan.HitBox);
            if (PacMan.WallCollision())
            {
                if (LastInput==Player.Direction.Up)
                    {
                        LastInput = Player.Direction.Still;
                    }
                    else if (LastInput == Player.Direction.Down)
                    {
                        LastInput = Player.Direction.Still;
                    }
                    else if (LastInput == Player.Direction.Left)
                    {
                        LastInput = Player.Direction.Still;
                    }
                    else if (LastInput == Player.Direction.Right)
                    {
                        LastInput = Player.Direction.Still;
                    }
               
            }


           
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public gameForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Sets the timer
        /// </summary>
        public void SetTimer()
        {
            aTimer.Interval = (6);              
            aTimer.Enabled = true;
        }
        /// <summary>
        /// Stops Timer
        /// </summary>
        public void StopTimer()
        {
            aTimer.Stop();
            hasStarted = false;
        }
        /// <summary>
        /// Starts Timer
        /// </summary>
        public void StartTimer()
        {
            aTimer.Start();
            hasStarted = true;
        }
        /// <summary>
        /// on Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;
              map = new Map(0,0);
              PacMan = new Player(312, 258 ,this.map.screen);
              PacMan.SetMap(map);
              SetAllDots();
                overlay = new OverLay(map.screen);
           
        }
        /// <summary>
        /// Setting All Dots
        /// </summary>
        private void SetAllDots()
        {
            Dots.Add(new DotSmall(290, 275));
            Dots.Add(new DotSmall(260, 275));
            Dots.Add(new DotSmall(230, 275));
            Dots.Add(new DotSmall(230, 305));
            Dots.Add(new DotSmall(230, 305));

        }
        private void DrawAllDots(Graphics g)
        {
            foreach (DotSmall dot in Dots)
            {
                if (!dot.GetIsEaten())
                {
                    dot.Draw(g);
                }
                
            }
        }
        /// <summary>
        /// Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //checlk if dead
            bool PacManAlive=CheckIfDead();
            bool win =CheckForWin();
            CheckWallDetection();
            PacMan.EatDot(Dots);
            if (win)
            {
                PacMan.Reset();
                ResetDetectors();
            }
            else if (!PacMan.WallCollision())
            {
                PacMan.Move(LastInput);
            }
            else
            {
               
                PacMan.Reset();
                ResetDetectors();
                

            }
            Invalidate();
        }
        /// <summary>
        /// Checks if has won
        /// </summary>
        /// <returns></returns>
        private bool CheckIfDead()
        {
            if (PacMan.IsDead())
            {
                PacMan.IsDead(true);
                return true ;   
            }
            else
            {
                return false;
            }
            
        }
   

        /// <summary>
        /// draws
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //take a break from this for now
            oldScore = Dots.Count();
            //map.Draw(graphics);
            map.Draw(g);
            if (PacMan.IsDead())
            
                {overlay.Draw(g,"Please Hit Space to Play Again \n Or Hit ESC to Quit");
            }
            else if (CheckForWin())
            {
                overlay.Draw(g,PacMan.GetLifes(),PacMan.GetScore(), "Please Hit Space to Play Again \n Or Hit ESC to Quit");
            }
            else
            {
                overlay.Draw(g,PacMan.GetLifes(),PacMan.GetScore());
            }
            
            PacMan.Draw(g);
            DrawAllDots(g);
        }

        private void HasHitAWall(KeyEventArgs e)
        {
            if (!PacMan.IsDead())
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                    if (!Up)
                    {
                        LastInput = Player.Direction.Up;
                    }
                        break;
                    case Keys.Down:
                    if (!Down)
                    {
                        LastInput = (Player.Direction.Down);
                    }
                        break;
                    case Keys.Left:
                    if (!Left)
                    {
                        LastInput = (Player.Direction.Left);
                    }
                        break;
                    case Keys.Right:
                    if (!Right)
                    {
                        LastInput = (Player.Direction.Right);
                    }
                        break;
                
                }
            }




        }
        /// <summary>
        /// Key Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameForm_KeyDown(object sender, KeyEventArgs e)
        {
   
                    switch (e.KeyCode)
                    {
                        case Keys.Space:
                            if (PacMan.IsDead())
                            {
                                PacMan.IsDead(false);
                                ResetDots();
                            }
                            else if (hasWon)
                            {
                                hasWon = false;
                                ResetDots();
                            }

                            break;
                        case Keys.Escape:
                        Application.Exit();
                            break;
                default:
                        HasHitAWall(e);
                   
                        break;
                }

            
        }
        /// <summary>
        /// Key Up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameForm_KeyUp(object sender, KeyEventArgs e)
        {

        }
        /// <summary>
        /// Resets Detectors
        /// </summary>
        private void ResetDetectors()
        {
            Up = false;
            Down = false;
            Left = false;
            Right = false;

        }
        /// <summary>
        /// Checks for to see if you win
        /// </summary>
        private bool CheckForWin()
        {
            if (PacMan.GetScore()==Dots.Count() && !PacMan.IsDead())
            {
                hasWon = true;
                return true;
            }
            else
            {
                hasWon = false;
                return false;
            }
        }
        /// <summary>
        /// Resets Dots
        /// </summary>
        private void ResetDots()
        {
            foreach (DotSmall Dot in Dots)
            {
                Dot.UnsetEaten();
            }
        }

    }
}
