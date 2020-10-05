using System;
using SwinGameSDK;
namespace BroadcastStorm
{
    public class BackgroundClient
    {
        /// <summary> 
        /// This Class will Provide a seamless Floating Background for Broadcast Storm Game
        /// Needs to be cleaned up!
        /// </summary> 
        
        float _outerBackgroundSpeed = 0.3f;
        float _innerBackgroundSpeed = 2f;
        
        Point2D _outerBackgroundLocation1;
        Point2D _outerBackgroundLocation2;
        Bitmap [] _outerBackground = new Bitmap [2];
        
        public BackgroundClient ()
        {
            LoadAssets ();
            _outerBackgroundLocation1.X = 0;
            _outerBackgroundLocation1.Y = 0;
            _outerBackgroundLocation1.X = 0;
            _outerBackgroundLocation1.Y = -1000;
            PopulateBitmapArray (_outerBackground, SwinGame.BitmapNamed("uni02"));
        }
        
        public void Update()
        {
            Draw ();
            _outerBackgroundLocation1.Y = _outerBackgroundLocation1.Y + _outerBackgroundSpeed;
            _outerBackgroundLocation2.Y = _outerBackgroundLocation2.Y + _outerBackgroundSpeed;
            if (_outerBackgroundLocation1.Y > 1000)
            {
                _outerBackgroundLocation1.Y = _outerBackgroundLocation1.Y - 2000;
            }
            if (_outerBackgroundLocation2.Y > 1000)
            {
                _outerBackgroundLocation2.Y = _outerBackgroundLocation2.Y - 2000;
            }
        }
        
        private void PopulateBitmapArray(Bitmap[] bitmaps, Bitmap image)
        {
            for (int i = 0; i < bitmaps.Length; i++) 
            {
                bitmaps [i] = image;
            }
        }
        
        private void Draw()
        {
            SwinGame.DrawBitmap (_outerBackground [0], _outerBackgroundLocation1.X, _outerBackgroundLocation1.Y);
            SwinGame.DrawBitmap (_outerBackground [1], _outerBackgroundLocation1.X, _outerBackgroundLocation2.Y);
        }
        
        private void LoadAssets()
        {
            // Load Bitmaps:
            try 
            {
                SwinGame.LoadBitmapNamed ("uni02", "/OneDrive/_Swinburne/_Degree/OOP/_Tasks/6-4D_and_6-5HD_Custom_Program/Image_Files/Universe_Tile_03.png");
                SwinGame.LoadBitmapNamed ("unifore", "/OneDrive/_Swinburne/_Degree/OOP/_Tasks/6-4D_and_6-5HD_Custom_Program/Image_Files/Universe_Tile_Foreground_1000x400.png");
                
            } catch (Exception e) 
            {
                Console.Error.WriteLine ("Error Loading Bitmaps: {0}", e.Message);
            }
        }
    }
}
