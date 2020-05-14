using Foundation;
using UIKit;
using WalkingGame.Core;

namespace WalkingGame.iOS
{
    [Register("AppDelegate")]
    class Program : UIApplicationDelegate
    {
        private static GameStart game;

        internal static void RunGame()
        {
            game = new GameStart();
            game.Run();
        }

        static void Main(string[] args)
        {
            UIApplication.Main(args, null, "AppDelegate");
        }

        public override void FinishedLaunching(UIApplication app)
        {
            RunGame();
        }
    }
}
