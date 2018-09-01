using System;
using System.Drawing;

namespace MyGame
{
    class Asteroid : BaseObject, ICloneable, IComparable
    {
        public int Power { get; set; } = 3;
        protected Bitmap image;



        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = new Bitmap("aster.png");
            Power = 1;
        }
        public override void Draw()
        {
            //Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            //Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < -Size.Width)
            {
                Ressurect();
            }
            //if (Pos.X > Game.Width) Dir.X = -Dir.X;
            //if (Pos.Y < 0) Dir.Y = -Dir.Y;
            //if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }


        // пример реализации интерфейса копирования для астероида
        public object Clone()
        {
            // Создаем копию нашего астероида
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height));
            // Не забываем скопировать новому астероиду Power нашего астероида
            asteroid.Power = Power;
            return asteroid;
        }

        public override void Ressurect()
        {
            Pos.X = Game.Width + 100;
            Pos.Y = Game.rnd.Next(0, Game.Height);
            int nSize = Game.rnd.Next(5, 50);
            Size.Height = nSize;
            Size.Width = nSize;
            Dir.X = -nSize / 5;
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj is Asteroid temp)
            {
                if (Power > temp.Power)
                    return 1;
                if (Power < temp.Power)
                    return -1;
                else
                    return 0;
            }
            throw new ArgumentException("Parameter is not а Asteroid!");
        }

        public event MessageText Log;

        public void Loggin(string msg)
        {
            Log?.Invoke(this.ToString() + msg);
        }

    }

}
