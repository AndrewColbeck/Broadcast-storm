using System;
using System.Threading;
using SwinGameSDK;

namespace BroadcastStorm
{
    public class GameMain
    {
        /// <summary>
        /// This Class is the Main Class for the Broadcast Storm Game, from which
        /// the Game Loop is run, and Assets are drawn onto the screen. 
        /// </summary>
        
        static BackgroundClient _backgroundClient = new BackgroundClient();
        static int _gameSize = 800;
        
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("Broadcast Storm", _gameSize, _gameSize);
            SwinGame.ShowSwinGameSplashScreen();
            
            //Create GameManager:
            GameManager _gameManager = new GameManager (_gameSize);
            
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.Black);
                SwinGame.DrawFramerate(0,0);

                Thread.Sleep (1);
                
                _backgroundClient.Update ();
                
                //Update Game
                _gameManager.Update ();
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}