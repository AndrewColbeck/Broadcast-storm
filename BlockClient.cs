using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace BroadcastStorm
{
    public sealed class BlockClient
    {
        /// <summary>  
        /// This Class handles Block allocation, it is a Singleton Class, only one instance can exist.
        /// The 'Sealed' keyword allows for special JIT performance during compilation.
        /// 
        /// The Class interfaces with the Block Pool and is part of the Object Pool Design Pattern
        /// that has been implemented in this Program.
        /// </summary> 

        private static readonly BlockClient _instance = new BlockClient ();
        private List<Block> _activeBlocks = new List<Block> ();
        private Stack<Block> _blockBuffer = new Stack<Block> ();
        private BlockPool _pool = BlockPool.Instance;
        private Random rnd = new Random ();
        private int _rowCounter = 0;
        
        // 'static' contructor informs the Compiler this type does not need
        // to be initialised until the first field or method is accessed.
        static BlockClient ()
        {
        }
        
        // Private Constructor, only this Class can initialise an instance of itself
        private BlockClient()
        {
        }
        
        // Public Accessor, returns one private instance
        public static BlockClient Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Update()
        {
           
            if (_rowCounter > 10)
            {
                 _activeBlocks.Add (_pool.GetBlock (rnd.Next(800)));
                _rowCounter = 0;
            } else
            {
                _rowCounter++;
            }
           
            foreach (Block b in _activeBlocks)
            {
                b.Update ();
                b.Draw ();
                
                if (b.Y > 800)
                {
                    _blockBuffer.Push (b);
                }
            }
            
            foreach (Block b in _blockBuffer)
            {
                b.Reset ();
                _activeBlocks.Remove (b);
                _pool.RecycleBlock (b);
            }
            _blockBuffer.Clear ();
        }
    }
}
