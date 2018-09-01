using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Heal : BaseObject
    {
        private int _hp = 25;

        public Heal(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Red, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;

            if (Pos.X < -Size.Width)
            {
                Ressurect();
            }
        }
 
        public override void Ressurect()
        {
            Pos.X = Game.Width + 100;
            Pos.Y = Game.rnd.Next(0, Game.Height);
        }
    }
}