using DogFacts.Forms;

namespace DogFacts
{
    internal static class Program
    {
        /// <summary>
        ///  Entrada pricipal da aplica��o
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}