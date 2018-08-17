using System;

namespace Jumper1.Controllers
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class StartupController
    {
      public static GameController game;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (game = new GameController())
               game.Run();
        }
    }
#endif
}
