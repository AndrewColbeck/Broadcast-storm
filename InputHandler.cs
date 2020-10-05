using System;
using SwinGameSDK;
namespace BroadcastStorm
{
    public sealed class InputHandler
    {
        /// <summary> 
        /// This is a Singleton Class, only one instance can exist.
        /// The InputHandler is responsible for Controlling UI, and re-locating
        /// the Player Objects within the game.  The 'Sealed' keyword allows for special JIT performance.
        ///  </Summary>
        
        private static readonly InputHandler _instance = new InputHandler ();
        
        // 'static' contructor informs Compiler this type does not need
        // to be initialised until the first field or method is accessed.
        static InputHandler ()
        {
        }
        
        // Private Constructor, only this Class can initialise an instance of itself
        private InputHandler()
        {
        }
        
        // Public Accessor, returns one private instance
        public static InputHandler Instance
        {
            get
            {
                return _instance;
            }
        }
        
        public void HandleInput(Player p1, Player p2)
        {
            // Fetch the next batch of UI interaction
            SwinGame.ProcessEvents();
            
            // Handle Player 1 Movement
            if (SwinGame.KeyDown(KeyCode.WKey))
            {
                p1.Move (Dir.Up);
            }
            if (SwinGame.KeyDown(KeyCode.AKey))
            {
                p1.Move (Dir.Left);
            }
            if (SwinGame.KeyDown(KeyCode.DKey))
            {
                p1.Move (Dir.Right);
            }
            if (SwinGame.KeyDown(KeyCode.SKey))
            {
                p1.Move (Dir.Down);
            }
            
            // Handle Player 2 Movement
            if (SwinGame.KeyDown(KeyCode.UpKey))
            {
                p2.Move (Dir.Up);
            }
            if (SwinGame.KeyDown(KeyCode.LeftKey))
            {
                p2.Move (Dir.Left);
            }
            if (SwinGame.KeyDown(KeyCode.RightKey))
            {
                p2.Move (Dir.Right);
            }
            if (SwinGame.KeyDown(KeyCode.DownKey))
            {
                p2.Move (Dir.Down);
            }
        }
    }
}
