using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacmanVTwo
{

    /// <summary>
    /// Its your boy PacMan
    /// </summary>
    public class Player
    {
        int Score=0;
        public bool hasWon=false;
        int Life = 3;

        bool isDead = false;
        public enum Direction {
            Up,
            Down,
            Left,
            Right,
            Still
        }
        //this direction serves the porpose of determin clipping 
        Direction LastMove = Direction.Still;
        //Images
        List<Image> sprites = new List<Image>();

        //active Sprite
        //0=Up
        //1=Down
        //2=Left
        //3=right
        //4=full
        Image ActiveSprite;
        //loacation from the top left
        int X;
        int Y;
        private static  int Height =39, Width=39;
        //hit box
        public Rectangle HitBox;
        //speed
        int Speed= 2;
        //canvas
        private Rectangle Canvas;
        //Map
        Map CurrMap;
        List<bool> AD = new List<bool>();

        public int GetLifes()
        {
            return Life;
        }
        /// <summary>
        /// Gets Score
        /// </summary>
        /// <returns></returns>
        public int GetScore()
        {
            return Score;
        }
        /// <summary>
        /// Adds Score
        /// </summary>
        public void AddScore()
        {
            Score++;
        }

        /// <summary>
        /// Adds Extra Life
        /// </summary>
        public void AddLife()
        {
            if (Life<3)
            {
                Life++;
            }
            
        }

        /// <summary>
        /// This gets the map to help with colistions
        /// </summary>
        /// <param name="map"></param>
        public void SetMap(Map map)
        {
            this.CurrMap = map;
        }


        /// <summary>
        /// creating Empty PacMan Class
        /// </summary>
        public Player()
        {
            setDefualtDirections();
        }

        /// <summary>
        /// creating full PacMan Class
        /// </summary>
        public Player(int X, int Y,Rectangle canvas)
        {
            this.X = X;
            this.Y = Y;
            HitBox=new Rectangle(X-2, Y-2, Height,Width);
            this.Canvas = canvas;
 

            //getting the important stuff readyy
            setDefualtDirections();
            GetSprites();
            ActiveSprite=sprites[4]; 

        }
        public Player(Rectangle canvas)
        {
            this.X = (canvas.Width / 2);
            this.Y = (canvas.Height / 2) ;
            HitBox = new Rectangle(X-2, Y-2, Height, Width);
            this.Canvas = canvas;

            //getting the sprites
            setDefualtDirections();
            GetSprites();
            ActiveSprite = sprites[4];

        }
        /// <summary>
        /// /Returns if wall was hit
        /// </summary>
        /// <returns></returns>
        public bool WallCollision()
        {
            if (CurrMap.HasHitWall(HitBox))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// This Draws/ Spawns PacMan
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics) {

            //draw pacman
            graphics.DrawImage(ActiveSprite,this.X,this.Y);

        }

        /// <summary>
        /// This gets the sprites
        /// </summary>
        private void GetSprites()
        {
            Image PacUp= (Image) new Bitmap("C:\\Users\\Student\\source\\repos\\PROG2200-700-4032-NSCC-FALL2019\\Anthony_Healy\\pacman\\pacmanVTwo\\pacmanVTwo\\sprites\\pacman\\pac_up.bmp");
            this.sprites.Add(PacUp);

            Image PacDown = (Image)new Bitmap("C:\\Users\\Student\\source\\repos\\PROG2200-700-4032-NSCC-FALL2019\\Anthony_Healy\\pacman\\pacmanVTwo\\pacmanVTwo\\sprites\\pacman\\pac_down.bmp");
            this.sprites.Add(PacDown);

            Image PacLeft = (Image)new Bitmap("C:\\Users\\Student\\source\\repos\\PROG2200-700-4032-NSCC-FALL2019\\Anthony_Healy\\pacman\\pacmanVTwo\\pacmanVTwo\\sprites\\pacman\\pac_left.bmp");
            this.sprites.Add(PacLeft);

            Image PacRight = (Image)new Bitmap("C:\\Users\\Student\\source\\repos\\PROG2200-700-4032-NSCC-FALL2019\\Anthony_Healy\\pacman\\pacmanVTwo\\pacmanVTwo\\sprites\\pacman\\pac_right.bmp");
            this.sprites.Add(PacRight);

            Image PacFull = (Image)new Bitmap("C:\\Users\\Student\\source\\repos\\PROG2200-700-4032-NSCC-FALL2019\\Anthony_Healy\\pacman\\pacmanVTwo\\pacmanVTwo/sprites/pacman/pac_full.bmp");
            this.sprites.Add(PacFull);


        }
        /// <summary>
        /// This sets active sprite
        /// </summary>
        /// <param name="index"></param>
        public void SetActiveSprite(int index)
        {
            ActiveSprite = sprites[index];
        }

        /// <summary>
        /// This moves Player(Big Function)
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Direction direction)
        {
  
                switch (direction)
                {
                    case Direction.Still:
                        MoveStill();
                        break;
                    case Direction.Up:
                            MoveUp();
                        break;
                    case Direction.Down:
                            MoveDown();
                        break;
                    case Direction.Left:
                            MoveLeft();
                        break;
                    case Direction.Right:
                            MoveRight();
                        break;
                }

        }

        //mover Functions
            /// <summary>
            /// Moves Player Up
            /// </summary>
            private void MoveUp()
            {
                
                this.Y -= this.Speed;
                ActiveSprite = sprites[0];
                HitBox.Y -= this.Speed;


                
            }
            /// <summary>
            /// Moves Player Down
            /// </summary>
            private void MoveDown()
            {
                this.Y += this.Speed;
                ActiveSprite = this.sprites[1];
                HitBox.Y += this.Speed;



        }
            /// <summary>
            /// Moves Player Left
            /// </summary>
            private void MoveLeft()
            {
         
                    this.X -= this.Speed;
                    ActiveSprite = this.sprites[2];
                    HitBox.X -= this.Speed;

        }
            /// <summary>
            /// Moves Player Right
            /// </summary>
            private void MoveRight()
            {
                    this.X += this.Speed;
                    this.ActiveSprite = this.sprites[3];
                    HitBox.X += this.Speed;

        }
            //Destroyes System32
            public void MoveStill()
            {
                this.ActiveSprite = this.sprites[4];
            }

        //Colision detection


        /// <summary>
        /// 0=up
        /// 1=down
        /// 2=left
        /// 3=right
        /// </summary>
        public void setDefualtDirections()
        {
            //I know Naming Conventions but this will do alot of the heavy work
            //This will help with walls 
            AD.Add(false);
            AD.Add(false);
            AD.Add(false);
            AD.Add(false);
        }
        /// <summary>
        /// Resets the directions
        /// </summary>
        public void ResetDirections()
        {
            //I know Naming Conventions but this will do alot of the heavy work
            //This will help with walls 
            for (int i = 0; i <3 ; i++)
            {
                AD[i] = false;
            }
        }
        /// <summary>
        /// This will Change the The Directions Permission
        /// </summary>
        /// <param name="IndexOfDirection"></param>
        /// <param name="Permission"></param>
        public void ChangeDirectionPermission(int IndexOfDirection, bool Permission) {
            try
            {
                AD[IndexOfDirection] = Permission;
            }
            catch(IndexOutOfRangeException e)
            {

            }

        }
        //check if colided
        /// <summary>
        /// This will check if wall was hit then determine what way the was the player headed 
        /// </summary>
        /// <returns></returns>
        public bool HasContactedWall(Rectangle Side)
        {
            if (CurrMap.HasHitWall(Side))
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        //Reset Player
        public void Reset()
        {

                
   
            
            if (Life <= 0 && isDead)
            {
                //varReseting
                Life = 3;
                Score = 0;
                this.X = 312;
                this.Y = 258;
                HitBox.X = X;
                HitBox.Y = Y;

                Die();

            }
            else if (hasWon )
            {
                //varReseting
                Life = 3;
                Score = 0;
                this.X = 312;
                this.Y = 258;
                HitBox.X = X;
                HitBox.Y = Y;
                Win();

            }
            else
            {
                Life--;
                this.X = 312;
                this.Y = 258;
                HitBox.X = X;
                HitBox.Y = Y;
            }
        }
      
        public bool IsDead()
        {
            return isDead;
        }
        public void IsDead(bool isDead)
        {
            this.isDead = isDead;
        }

        //die
        public void Die()
        {
            isDead = true;

        }
        public void Win()
        {
            hasWon = true;

        }
        public void EatDot(List<DotSmall> dots)
        {
            foreach (DotSmall dot in dots)
            {
                if (HitBox.IntersectsWith(dot.HitBox)&& !dot.GetIsEaten())
                {
                    dot.SetEaten();
                    AddScore();
                }
            }
        }
    }
}
