using System;
using System.Collections;
using System.Drawing;

namespace MyGame
{
    abstract class BaseObject: ICollision, IEnumerable, IEnumerator
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public delegate void Message();
        public delegate void MessageText(string msg);

        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);

        public object Current => throw new NotImplementedException();

        public abstract void Draw();
        //{
        //Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y,
        //Size.Width, Size.Height);
        //}

        public abstract void Update();
        //{
        //    Pos.X = Pos.X + Dir.X;
        //    Pos.Y = Pos.Y + Dir.Y;
        //    if (Pos.X < 0) Dir.X = -Dir.X;
        //    if (Pos.X > Game.Width) Dir.X = -Dir.X;
        //    if (Pos.Y < 0) Dir.Y = -Dir.Y;
        //    if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        //}

        public abstract void Ressurect();

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
