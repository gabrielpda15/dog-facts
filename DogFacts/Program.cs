using DogFacts.Forms;

namespace DogFacts
{
    internal static class Program
    {
        /// <summary>
        ///  Entrada pricipal da aplicação
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}