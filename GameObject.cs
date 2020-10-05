using System;
using SwinGameSDK;

namespace BroadcastStorm
{
    public abstract class GameObject
    {
        /// <summary> 
        /// The GameObject class is an abstract Class from which the Player and
        /// Block Objects inherit fields and methods.  Abstraction was implemented here
        /// to support future Polymorphic integration between Players and Blocks, such
        /// as Collision checking.
        /// </summary> 
    
        // LOCALS:
        private Point2D _location = new Point2D();
        private Bitmap _bitmap;
        
        // CONSTRUCTOR:
        public GameObject (Point2D location)
        {
            _location = location;
        }
        
        public GameObject (float x)
        {
            X = x;
            Y = -60;
        }

        // PROPERTIES:
        public Point2D Location { get => _location; set => _location = value; }
        public float Y { get => _location.Y; set => _location.Y = value; } 
        public float X { get => _location.X; set => _location.X = value; }

        public virtual void Draw ()
        {
            SwinGame.DrawBitmap (_bitmap, _location.X, _location.Y);
        }
        
        public void SetThisImage(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                _bitmap = bitmap;
            }
        }
    }
}
