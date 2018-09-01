using System;
using System.Drawing;

namespace MyGame
{

    class Planet : BaseObject
    {
        protected Bitmap image;
        //protected Random rnd;
        
        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = new Bitmap("planet.bmp");
            //rnd = new Random();
        }

        public override void Draw()
        {
            // Рисуем картинку планеты
            Game.Buffer.Graphics.DrawImage(image, Pos);

        }

        public override void Ressurect()
        {
            Pos.X = Game.Width + Size.Width;
            Pos.Y = Game.rnd.Next(Size.Height, Game.Height - Size.Height);
        }

        public override void Update()
        {
            // планета медленно движется влево
            Pos.X = Pos.X - Dir.X;
            if (Pos.X + Size.Width < 0)
            {
                // достигая конца экрана, планета случайно перемещается по вертикали
                Ressurect();
            }
        }

    }

}