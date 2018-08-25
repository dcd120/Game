using System;
using System.Drawing;

namespace MyGame
{
    class Bullet : BaseObject
    {
        protected Bitmap image;

        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = new Bitmap("bullet.png");
            //image.RotateFlip(RotateFlipType)
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
            //Game.Buffer.Graphics.DrawRectangle(Pens.Green, Pos.X, Pos.Y, Size.Width, Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.OrangeRed, Pos.X - 5, Pos.Y + Size.Height / 2, Pos.X, Pos.Y + Size.Height / 2);

        }

        public override void Ressurect()
        {
            Pos.X = 10;
            Pos.Y = Game.rnd.Next(10, Game.Height - 10);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X > Game.Width)
            {
                Ressurect();
            }
        }
    }
}