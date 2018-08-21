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


        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }

        public static void Init(Form form)
        {
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
            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }


        public static void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200,
            //200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200,
            //200));
            //Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();

            // выведем надпись с инициалами
            Game.Buffer.Graphics.DrawString("by Nikolay Zarivnoy (c) 2018", new Font(FontFamily.GenericMonospace, 10), Brushes.Aquamarine,300,100);

            Buffer.Render();

        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }


        public static void Load()
        {
            Random rnd = new Random();
            _objs = new BaseObject[101];

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
                size = rnd.Next(1, 3);
                // звезды случайно заполнят пространство в правой 2/3 экрана и начнут течь на лево, имитируя полет вправо
                _objs[i] = new zvezda(new Point(rnd.Next(50,790),rnd.Next(10,590)), new Point(rnd.Next(base_speed, base_speed+2),0), new Size(size,size), rnd.Next(0, 3));
            }

            _objs[100] = new Planet(new Point(400,300), new Point(5,0), new Size(235,235));


        }

    }
}
