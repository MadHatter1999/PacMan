using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacmanVTwo
{
    public class Map
    {
        //Variables
        const int Scale = 2;
        int X = 0;
        int Y = 0;
        static int Height = 744;
        static int Width = 672;

        List<Rectangle> Walls = new list<Rectangle>();

        public Rectangle screen;
        PointF location;

        Image MapBase =(Image)( new  Bitmap("C:\\Users\\Student\\source\\repos\\PROG2200-700-4032-NSCC-FALL2019\\Anthony_Healy\\pacman\\pacmanVTwo\\pacmanVTwo\\sprites\\map_pink.bmp"));
        
        /// <summary>
        /// Default
        /// </summary>
        public Map()
        {

        }
      /// <summary>
      /// Takes map and sets X and Y
      /// </summary>
      /// <param name="X"></param>
      /// <param name="Y"></param>
        public Map(int X,int Y)
        {
            this.X = X;
            this.Y = Y;
            screen = new Rectangle(X,Y,Width,Height);
            location = new PointF(this.X, this.Y);
            AssignMapWalls();
           
        }
        /// <summary>
        /// Creating the Rectangle Walls
        /// </summary>
        private void AssignMapWalls()
        {
            // Top And bottom Walls
                //Top and Bottom
                    Rectangle WallTop = new Rectangle(X,Y, 675, 15);
                    Walls.Add(WallTop);
                    Rectangle WallBot = new Rectangle(X, Y+Height-15, 675, 15);
                    Walls.Add(WallBot);
            // Side Walls
                //Left Side
                    Rectangle WallSideTopLeft = new Rectangle(WallTop.X+3,WallTop.Y+15,15,210);
                    Walls.Add(WallSideTopLeft);

                    Rectangle WallSideAboveRightTP = new Rectangle(WallSideTopLeft.X,WallSideTopLeft.Y+WallSideTopLeft.Height,133,99);
                    Walls.Add(WallSideAboveRightTP);

                    Rectangle WallSBelowLTP = new Rectangle(WallSideAboveRightTP.X,WallSideAboveRightTP.Y+WallSideAboveRightTP.Height+48,132,96);
                    Walls.Add(WallSBelowLTP);

                    Rectangle WallSLowLeft = new Rectangle(WallSBelowLTP.X,WallSBelowLTP.Y+WallSBelowLTP.Height,15,261);
                    Walls.Add(WallSLowLeft);

                //Right Side
                    Rectangle WallSTR = new Rectangle((WallTop.X + WallTop.Width)-15, WallTop.Y + 15, 15, 210);
                    Walls.Add(WallSTR);

                    Rectangle WallSAboveRTP = new Rectangle(WallSTR.X-133+15, WallSTR.Y + WallSTR.Height, 133, 99);
                    Walls.Add(WallSAboveRTP);

                    Rectangle WallSBelowRTP = new Rectangle(WallSideAboveRightTP.X+screen.Width-133, WallSideAboveRightTP.Y + WallSideAboveRightTP.Height + 48, 132, 96);
                    Walls.Add(WallSBelowRTP);

                    Rectangle WallSLowRTP = new Rectangle(WallSBelowLTP.X+screen.Width-15, WallSBelowLTP.Y + WallSBelowLTP.Height, 15, 261);
                    Walls.Add(WallSLowRTP);

            // Middle Areas
                    Rectangle GhostBox = new Rectangle(this.X+255,this.Y+300,168,96);
                    Walls.Add(GhostBox);

                    Rectangle IslandOne = new Rectangle(this.X + 63, this.Y + 60, 72, 48);
                    Walls.Add(IslandOne);

                    Rectangle IslandTwo = new Rectangle(this.X + 183, this.Y + 60, 96, 48);
                    Walls.Add(IslandTwo);

                    Rectangle IslandThree = new Rectangle(this.X + 327, this.Y + 15, 24, 93);
                    Walls.Add(IslandThree);

                    Rectangle IsleFour = new Rectangle(this.X + 399, this.Y +60 , 96, 48);
                    Walls.Add(IsleFour);
                    
                    Rectangle IsleFive = new Rectangle(this.X + 543, this.Y + 60, 72, 48);
                    Walls.Add(IsleFive);

                    Rectangle IsleSix = new Rectangle(this.X + 63, this.Y + 156, 72, 24);
                    Walls.Add(IsleSix);

                    Rectangle IsleSeven = new Rectangle(this.X + 183, this.Y + 156, 27, 168);
                     Walls.Add(IsleSeven);

                    Rectangle IsleEight = new Rectangle(this.X + 255, this.Y + 156, 168, 24);
                    Walls.Add(IsleEight);

                    Rectangle IsleNine = new Rectangle(this.X + 324, this.Y + 180, 30, 72);
                    Walls.Add(IsleNine);

                    Rectangle IsleTen = new Rectangle(this.X + 207, this.Y + 225, 72, 30);
                    Walls.Add(IsleTen);


                    Rectangle Isle11 = new Rectangle(this.X + 399, this.Y + 225, 72, 30);
                    Walls.Add(Isle11);

                    Rectangle Isle12 = new Rectangle(this.X + 471, this.Y + 156, 24, 168);
                    Walls.Add(Isle12);

                    Rectangle Isle13 = new Rectangle(this.X + 543, this.Y + 156, 72, 24);
                    Walls.Add(Isle13);

                    Rectangle Isle14 = new Rectangle(this.X + 183, this.Y + 372, 24, 96);
                    Walls.Add(Isle14);

                    Rectangle Isle15 = new Rectangle(this.X + 471, this.Y + 372, 24, 96);
                    Walls.Add(Isle15);

                    Rectangle Isle16 = new Rectangle(this.X + 255, this.Y + 444, 168, 24);
                    Walls.Add(Isle16);

                    Rectangle Isle17 = new Rectangle(this.X + 324, this.Y + 468, 30, 72);
                    Walls.Add(Isle17);
            
                    Rectangle Isle18 = new Rectangle(this.X + 63, this.Y+516, 72, 27);
                    Walls.Add(Isle18);

                    Rectangle Isle19 = new Rectangle(this.X + 183, this.Y + 516, 96 ,24);
                    Walls.Add(Isle19);

                    Rectangle Isle20= new Rectangle(this.X + 399, this.Y + 516, 96, 24);
                    Walls.Add(Isle20);

                    Rectangle Isle21 = new Rectangle(this.X + 543, this.Y + 516, 72, 27);
                    Walls.Add(Isle21);

                    Rectangle Isle22 = new Rectangle(this.X + 111, this.Y + 543, 24 ,69);
                    Walls.Add(Isle22);

                    Rectangle Isle23 = new Rectangle(this.X + 18, this.Y + 588, 45, 24);
                    Walls.Add(Isle23);

                    Rectangle Isle24 = new Rectangle(this.X + 63, this.Y + 657, 216, 27);
                    Walls.Add(Isle24);

                    Rectangle Isle25 = new Rectangle(this.X + 183, this.Y + 588, 24, 69);
                    Walls.Add(Isle25);

                    Rectangle Isle26 = new Rectangle(this.X + 255, this.Y + 588, 168, 27);
                    Walls.Add(Isle26);

                    Rectangle Isle27 = new Rectangle(this.X + 327, this.Y + 615, 24, 68);
                    Walls.Add(Isle27);

                    Rectangle Isle28 = new Rectangle(this.X + 399, this.Y + 657, 216, 27);
                    Walls.Add(Isle28);

                    Rectangle Isle29 = new Rectangle(this.X + 615, this.Y + 588, 45, 24);
                    Walls.Add(Isle29);

                    Rectangle Isle30 = new Rectangle(this.X + 471, this.Y + 588, 24, 69);
                    Walls.Add(Isle30);
            
                    Rectangle Isle31 = new Rectangle(this.X + 543, this.Y + 543, 24, 69);
                    Walls.Add(Isle31);

        }
        /// <summary>
        /// This is where we Draw Things Kiddo
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(MapBase,location);
            //gotta put the walls up
            DrawWalls(graphics);
        }
        /// <summary>
        /// Draws the walls DEV
        /// </summary>
        /// <param name="g"></param>
        public void DrawWalls(Graphics g)
        {
            foreach (Rectangle Wall in Walls)
            {
                g.DrawRectangle(new Pen(Brushes.Red),Wall);
            }
        }
        /// <summary>
        /// Colision Detection
        /// </summary>
        /// <param name="player">Player Object</param>
        /// <param name="mode">For Colision detection</param>
        /// <returns></returns>

        public bool HasHitWall(Rectangle rectangle)
        {
            foreach (Rectangle wall in Walls)
            {
                if (rectangle.IntersectsWith(wall))
                {

                    return true;
                }
            }
            return false;
        }

    }
}
