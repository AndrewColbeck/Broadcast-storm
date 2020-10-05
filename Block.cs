using System;
using SwinGameSDK;
namespace BroadcastStorm
{
    public class Block : GameObject
    {
        /// <summary> 
        /// This Class will initialise Block Objects, which are Midi representations
        /// and also the objects which will fall from the top of the screen which the
        /// Player must avoid.
        /// <summary> 
        
        private bool _offScreen;
        private int _timeToLiveSet = 3;
        private int _timeToLive;

        public bool OffScreen { get => _offScreen; set => _offScreen = value; }
        public int TimeToLive { get => _timeToLive; set => _timeToLive = value; }

        public Block (float x) : base (x)
        {
            LoadAssets ();
        }

        public Block () : base (new Point2D())
        {
            LoadAssets ();
        }
        
        // Load Bitmaps:
        private void LoadAssets()
        {
            try 
            {
                SwinGame.LoadBitmapNamed ("block", "/OneDrive/_Swinburne/_Degree/OOP/_Tasks/6-4D_and_6-5HD_Custom_Program/Image_Files/Block01_24x50_11_4_grn.png");
                SetThisImage (SwinGame.BitmapNamed("block"));
                
            } catch (Exception e) 
            {
                Console.Error.WriteLine ("Error Loading Bitmaps: {0}", e.Message);
            }

            _timeToLive = _timeToLiveSet;
        }
        
        public void Update()
        {
                Y += 10;
                _timeToLive--;
            
        }
        
        public void Reset()
        {
            X = 0;
            Y = -60;
            _offScreen = false;
            _timeToLive = _timeToLiveSet;
        }
    }
}
