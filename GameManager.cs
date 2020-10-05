using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace BroadcastStorm
{
    public class GameManager
    {
        /// <summary> 
        /// The GameManager Class holds Game Settings, and Player Information
        /// The Block Client is initialised from this Class, and this Class
        /// is responsible for the running of the Game.
        /// </summary> 
        
        private int _scr;
        private List<GameObject> _gameObjects;
        private Player _player1;
        private Player _player2;
        private BlockClient _client;
        private InputHandler _inputHandler;
        private Point2D _p = new Point2D();
        private Random rnd = new Random ();
        private float _playerSpeed;
        private float _blockFallSpeed;
        private MidiManager _midiManager = new MidiManager ();
        
        public GameManager (int screenSize)
        {
            _scr = screenSize;
            LoadGame();
        }
    
        private void GameSettings()
        {
            _playerSpeed = 8f;
            _blockFallSpeed = 5.0f;
        }
        
        private void LoadGame()
        {
            // Load Game Settings:
            GameSettings ();
            
            // Lists:
            _gameObjects = new List<GameObject> ();

            // Players:
            _player1 = new Player (Rand(_p, 0, _scr/2, _scr/2, _scr-100), _playerSpeed);
            _player2 = new Player (Rand(_p, _scr/2, _scr-100, _scr/2, _scr-100), _playerSpeed);
            _gameObjects.Add (_player1);
            _gameObjects.Add (_player2);

            // Singleton Instances:
            _client = BlockClient.Instance;
            _inputHandler = InputHandler.Instance;

            // MidiManager:
            
        }
        
        public void Update()
        {
            // Handle Input
            _inputHandler.HandleInput (_player1, _player2);

            // Update Players

            // Update Block Client
            _client.Update ();

            // Draw Assets
            DrawAssets ();
        }
        
        private void DrawAssets()
        {
            foreach(GameObject g in _gameObjects)
            {
                g.Draw ();
            }
            
        }
        
        // This function will randomly place a point in graph defined within minX and maxY
        private Point2D Rand(Point2D p, float minX, float maxX, float minY, float maxY)
        {
            // *** WARNING, INT TYPECAST LOSES FLOAT RESOLUTION ***
            p.X = rnd.Next((int)minX, (int)maxX);
            p.Y = rnd.Next((int)minY, (int)maxY);
            return p;
        }
        
        // This function will randomly place a point anywhere on the screen
        private Point2D Rand(Point2D p)
        {
            // *** WARNING, INT TYPECAST LOSES FLOAT RESOLUTION ***
            p.X = rnd.Next(0, _scr);
            p.Y = rnd.Next(0, _scr);
            return p;
        }
        
        // This function will randomise the X axis only:
        private Point2D RandX(Point2D p)
        {
            // *** WARNING, INT TYPECAST LOSES FLOAT RESOLUTION ***
            p.X = rnd.Next(0, _scr);
            return p;
        }
    }
}
