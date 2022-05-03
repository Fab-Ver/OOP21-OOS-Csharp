using Commons.Geometry;
using System;
using System.IO;

namespace SaraCappelletti.PlayerModel
{
    internal class Player : IPlayer
    {
        /// <summary>
        /// Width of the sprite.
        /// </summary>
        public const int MAIN_CHARACTER_WIDTH = 70;
        /// <summary>
        /// Height of the sprite.
        /// </summary>
        public const int MAIN_CHARACTER_HEIGHT = 96;
        /// <summary>
        /// Y coordinate of the land.
        /// </summary>
        public const double LAND = 440.0;
        /// <summary>
        /// X coordinate of the player.
        /// </summary>
        public const double PLAYER_X = 40.0;
        /// <summary>
        /// How much does the player jump.
        /// </summary>
        public const double JUMP_HEIGHT = 160.0;

        private const double DOUBLE_JUMP = 1.5;
        private const double GRAVITY = 4.5;
        private const string FILE_NAME = "OOS_selectedSkin.txt";

        private double _finalJumpY;
        private double _y = LAND;

        /// <summary>
        /// Creates the Player.
        /// </summary>
        public Player()
        {
            Image = new Image(ReadImagePathFromFile());
        }

        public Image Image { get; }

        /// <summary>
        /// The y of player's head.
        /// </summary>
        private double HeadY => _y - MAIN_CHARACTER_HEIGHT;
        public Rectangle Bounds => new Rectangle(PLAYER_X, HeadY, MAIN_CHARACTER_WIDTH, MAIN_CHARACTER_HEIGHT);
        public double LandHeight { get; set; } = LAND;
        public JumpState JumpState { get; private set; } = JumpState.NOT_JUMPING;
        public int JumpCounter { get; private set; }

        public int Lives { get; private set; } = 1;
        public bool IsDoubleJumpActive { get; set; }
        public bool IsShieldActive { get; set; }

        public void Jump()
        {
            if (JumpState == JumpState.NOT_JUMPING)
            {
                double jumpHeight = JUMP_HEIGHT;
                JumpState = JumpState.UP;
                JumpCounter++;
                if (IsDoubleJumpActive)
                {
                    jumpHeight *= DOUBLE_JUMP;
                }
                _finalJumpY = Math.Max(_y - jumpHeight, 0);
            }
        }

        public void UpdateJump()
        {
            if (JumpState != JumpState.NOT_JUMPING)
            {
                if (_y <= _finalJumpY)
                {
                    JumpState = JumpState.DOWN;
                }
                if (JumpState == JumpState.UP)
                {
                    _y -= GRAVITY;
                }
                else
                {
                    _y += GRAVITY;
                }
                if (_y >= LandHeight)
                {
                    JumpState = JumpState.NOT_JUMPING;
                    _y = LandHeight;
                }
            }

            if (JumpState == JumpState.NOT_JUMPING && _y < LandHeight)
            {
                JumpState = JumpState.DOWN;
            }
        }

        public void AddLives(int num) => Lives += num;

        /// <summary>
        /// Reads the image path from file.
        /// </summary>
        /// <returns>A String with the imagePath</returns>
        private string ReadImagePathFromFile()
        {
            var fileName = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), FILE_NAME);
            try
            {
                return File.ReadAllText(fileName);
            }
            catch
            {
                return "Player.png";
            }
        }
    }
}
