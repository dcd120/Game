using System;
using System.Drawing;

namespace MyGame
{

    class zvezda : BaseObject
    {
        protected int Colour;
        public zvezda(Point pos, Point dir, Size size, int colour) : base(pos, dir, size)
        {
            Colour = colour;
        }

        public override void Draw()
        {
            Pen pen;
            // рисование разными цветами
            switch (Colour)
            {
                case 0:
                    pen = Pens.White;
                    break;
                case 1:
                    pen = Pens.Yellow;
                    break;
                case 2:
                    pen = Pens.Red;
                    break;
                default:
                    pen = Pens.Purple;
                    break;
            }
                           
            // Рисуем шестиконечную звездочку
            Game.Buffer.Graphics.DrawLine(pen, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(pen, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(pen, Pos.X, Pos.Y + Size.Height / 2, Pos.X + Size.Width, Pos.Y + Size.Height / 2);
            Game.Buffer.Graphics.DrawLine(pen, Pos.X + Size.Width / 2, Pos.Y, Pos.X + Size.Width / 2,Pos.Y);
            
        }

        public override void Update()
        {
            // звезды будут двигаться справо на лево, 
            // чем крупнее звезда (т.е. ближе), тем быстрее она движется
            // еще маленький бонус от цвета )
            // переменная "дир" используется в качестве базового акселератора
            Pos.X = Pos.X - Dir.X - Size.Height - Colour;
            if (Pos.X < 0)
            {
                // достигая конца экрана, зевезда меняет свой цвет
                Colour++;
                if (Colour > 3) Colour = 0;
                Pos.X = Game.Width + Size.Width;

            }
        }

    }

}