﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace MyGame
{
    class Ship : BaseObject
    {

        private int _energy = 100;
        public int Energy => _energy;
        public void EnergyLow(int n)
        {
            _energy -= n;
        }

        public void Heal(int n)
        {
            _energy += n;
        }
                
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y,
            Size.Width, Size.Height);
        }
        public override void Update()
        {
        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }

        public static event Message MessageDie;

        public void Die()
        {
            MessageDie?.Invoke();
        }

        public override void Ressurect()
        {
            throw new NotImplementedException();
        }
    }
}
