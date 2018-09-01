using System;
using System.Windows.Forms;
// Создаем шаблон приложения, где подключаем модули
namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height
            };

            try
            {
                Game.Init(form);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Size of screen is invalid!");
                
                return;
            }
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}

