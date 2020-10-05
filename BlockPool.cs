// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/6-4D_and_6-5HD_Custom_Program/Broadcast_Storm_Iteration_01 - BlockPool.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Program designed for submission in OOP Portfolio. 
// Last modified:	29/05/2018
// To Fix:         	Find a way to Add Blocks to _offscreen Blocks :)
//
//
using System;
using System.Collections.Generic;
using SwinGameSDK;
using NAudio;
namespace BroadcastStorm
{
    public sealed class BlockPool
    {
        // Summary: This is a Singleton Class, only one instance can exist.
        // 'Sealed' allows for special JIT performance. /Summary
        
        private static readonly BlockPool _instance = new BlockPool ();
        private Stack<Block> _blockBuffer = new Stack<Block>();
        private Stack<Block> _blockPool = new Stack<Block> ();
        // 'static' contructor informs Compiler this type does not need
        // to be initialised until the first field or method is accessed.
        static BlockPool ()
        {
        }
        
        // Private Constructor, only this Class can initialise an instance of itself
        private BlockPool()
        {
            //_blockPool.Add (new Block ());
        }
        
        // Public Accessor, returns one private instance
        public static BlockPool Instance
        {
            get
            {
                return _instance;
            }
        }
        
        // Acquire Block Method:
        public Block GetBlock(float x)
        {
            // Check if any Blocks exist in Pool
            Block block;
            
            if (_blockPool.Count == 0)
            {
                block = new Block (x);   
            }
            else
            {
                block = _blockPool.Pop ();
                block.X = x;
            }
            PopUnusedBlocks ();
            return block;
        }
        
        public void RecycleBlock(Block b)
        {
            _blockPool.Push (b);
        }
        
        private void PopUnusedBlocks()
        {
            foreach(Block b in _blockPool)
            {
                b.TimeToLive--;
                if (b.TimeToLive <= 0)
                {
                    SwinGame.DrawText ("BLOCK POP", Color.White, 500, 500);
                    _blockBuffer.Push (b);
                }
                _blockBuffer.Clear ();
            }
            
        }
        
        
        
    }
}
