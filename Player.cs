// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/6-4D_and_6-5HD_Custom_Program/Broadcast_Storm_Iteration_01 - SpaceShip.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Program designed for submission in OOP Portfolio. 
// Last modified:	26/05/2018
// To Fix:         	Check Instructions
//
//
using System;
using SwinGameSDK;
namespace BroadcastStorm
{
    public class Player : GameObject
    {
        private float _sp;
        
        public Player (Point2D location, float speed) : base (location)
        {
            _sp = speed;
            LoadAssets ();
        }

        // Properties:

        // Load Bitmaps:
        private void LoadAssets()
        {
            try 
            {
                SwinGame.LoadBitmapNamed ("spaceship", "/OneDrive/_Swinburne/_Degree/OOP/_Tasks/6-4D_and_6-5HD_Custom_Program/Image_Files/SpaceShip02_40.png");
                SetThisImage (SwinGame.BitmapNamed("spaceship"));
                
            } catch (Exception e) 
            {
                Console.Error.WriteLine ("Error Loading Bitmaps: {0}", e.Message);
            }
        }
        
        public void Move(Dir d)
        {
            switch (d) {
            case Dir.Up :
                Y -= _sp;
                break;
            case Dir.Down :
                Y += _sp;
                break; 
            case Dir.Left :
                X -= _sp;
                break; 
            case Dir.Right :
                X += _sp;
                break;  
            default:
                break;
            }
        }
        
    
    }
}
