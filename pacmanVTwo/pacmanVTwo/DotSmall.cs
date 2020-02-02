using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacmanVTwo
{
    public class DotSmall
    {
        public Rectangle HitBox;
        bool IsEaten= false;

        int X;
        int Y;
        static int Height=4, Width = 4;

        public  DotSmall(int X, int Y)
        {
            this.X=X;
            this.Y = Y;
            HitBox = new Rectangle(X, Y, Width, Height);
        }
        //Draw
        public void Draw(Graphics graphics)
        {
            if (HitBox!=null)
            {
                if (!IsEaten)
                {
            
                    graphics.FillRectangle(Brushes.AntiqueWhite, HitBox);
                }
                
            }
            
        }

        //Eaten
        public void SetEaten()
        {
            IsEaten = true;
        }
        public void UnsetEaten()
        {
            IsEaten = false;
        }
        public bool GetIsEaten()
        {

            return IsEaten;
        }

    }
}
