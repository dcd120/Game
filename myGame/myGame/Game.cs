using System;
using System.Windows.Forms;
using System.Drawing;
namespace MyGame
{

    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;
        private static Heal[] _heals;
        private static Font myFont;
        public static Timer timer = new Timer();
        public static Random rnd;
        private static int Score;

        public static void Logging(string msg)
        {
            Console.Write(msg);
        }


        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(100, 100));

        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif,60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {//_bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
                _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(10, 0), new Size(30, 20));
            }
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }        
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }

        public static void Init(Form form)
        {
            // выбрасываем исключение
            if ((form.Width > 1000)||(form.Width < 0)||(form.Height > 1000)||(form.Height <0))
            {
                //throw new IndexOutOfRangeException();
            }



            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для
            // текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в
            // буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            rnd = new Random();

            Load();

            myFont= new Font(FontFamily.GenericMonospace, 10);

            //Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

            form.KeyDown += Form_KeyDown;            Ship.MessageDie += Finish;            Score = 0;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        
        public static void Draw()
        {
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200,
            //200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200,
            //200));
            //Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj?.Draw();
            foreach (BaseObject obj in _asteroids)
                obj?.Draw();
            foreach (BaseObject obj in _heals)
                obj?.Draw();
            _bullet?.Draw();
            _ship?.Draw();
            if (_ship != null) Buffer.Graphics.DrawString("Energy:" + _ship.Energy + " Score:" + Score, SystemFonts.DefaultFont, Brushes.White, 0, 0);            
            // выведем надпись с инициалами
            Game.Buffer.Graphics.DrawString("by Nikolay Zarivnoy (c) 2018", myFont, Brushes.Aquamarine,10,20);

            Buffer.Render();

        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            //foreach (Asteroid a in _asteroids)
            //{
            //    a.Update();

            //    //if (a.Collision(_bullet))
            //    //{
            //    //    System.Media.SystemSounds.Hand.Play();
            //    //    // регенирируем объекты
            //    //    a.Ressurect();
            //    //    _bullet.Ressurect();
            //    //}
            //}

            foreach (Heal a in _heals)
            {
                a.Update();

                if (a.Collision(_ship))
                {
                    System.Media.SystemSounds.Question.Play();
                    // регенирируем объекты
                    _ship.Heal(25);
                    a.Ressurect();
                }
            }

            _bullet?.Update();

            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _asteroids[i] = null;
                    _bullet = null;
                    Score++;
                    continue;
                }
                if (!_ship.Collision(_asteroids[i])) continue;
                //var rnd = new Random();
                _asteroids[i].Loggin("Ship hit!");
                _ship?.EnergyLow(10);
                System.Media.SystemSounds.Asterisk.Play();
                _asteroids[i] = null;
                if (_ship.Energy <= 0) _ship?.Die();
            }

        }
        
        public static void Load()
        {
            _objs = new BaseObject[201];

            int size = 0;
            int base_speed = 5;
            //int angleA = 0;
            //int angleB = 0;
            //for (int i = 0; i < _objs.Length / 2; i++)
            //{
            //    size = rnd.Next(10,20);
            //    angleA = rnd.Next(-1, 1);
            //    if (angleA == 0) angleA = 1;
            //    angleB = rnd.Next(-1, 1);
            //    if (angleB == 0) angleB = 1;
            //    _objs[i] = new BaseObject(new Point(rnd.Next(50,750), rnd.Next(50, 550)), new Point((base_speed - size)*angleA,(base_speed - size)*angleB), new Size(size, size));
            //}
            //for (int i = _objs.Length / 2; i < _objs.Length; i++)
            //{
            //    size = rnd.Next(3, 6);
            //    _objs[i] = new Star(new Point(rnd.Next(50, 750), rnd.Next(50, 550)), new Point(-1*(base_speed - size), 0), new Size(size, size));
            //}

            // формируем свой фон (путешествие через космос)
            // в составе объекты:
            // а) звезды разных размеров и цветов (звездочки из 4 линий)
            // б) планеты (картинки)

            for (int i = 0; i < _objs.Length - 1; i++)
            {
                size = rnd.Next(1, 2);
                // звезды случайно заполнят пространство в правой 2/3 экрана и начнут течь на лево, имитируя полет вправо
                _objs[i] = new zvezda(new Point(rnd.Next(10,Game.Width-10),rnd.Next(10,Game.Height-10)), new Point(rnd.Next(base_speed, base_speed+2),0), new Size(size,size), rnd.Next(0, 3));
            }

            _objs[200] = new Planet(new Point(400,300), new Point(5,0), new Size(235,235));

            //_bullet = new Bullet(new Point(0, 200), new Point(10, 0), new Size(30, 20));
            _asteroids = new Asteroid[70];

            //for (var i = 0; i < _objs.Length; i++)
            //{
            //    int r = rnd.Next(5, 50);
            //    _objs[i] = new Star(new Point(1000, rnd.Next(0, Game.Height)), new
            //    Point(-r, r), new Size(3, 3));
            //}
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(Game.Width + rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r));
                (_asteroids[i] as Asteroid).Log += Logging;
                (_asteroids[i] as Asteroid).Loggin("Obj_ created");
            }

            _heals = new Heal[3];
            for (var i = 0; i < _heals.Length; i++)
            {
                _heals[i] = new Heal(new Point(Game.Width + rnd.Next(0, Game.Width / 4), rnd.Next(0, Game.Height)), new Point(-20, 0), new Size(20, 20));
            }

        }

    }
}
