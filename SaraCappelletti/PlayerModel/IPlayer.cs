using Commons.Geometry;

namespace SaraCappelletti.PlayerModel
{
    internal interface IPlayer
    {
        /// <summary>
        /// The bounds of the Player.
        /// </summary>
        Rectangle Bounds { get; }
        /// <summary>
        /// The Height of the land
        /// </summary>
        double LandHeight { get; set; }
        /// <summary>
        /// The Image of the Player.
        /// </summary>
        Image Image { get; }
        /// <summary>
        /// True if doubleJump is active.
        /// </summary>
        bool IsDoubleJumpActive { get; set; }
        /// <summary>
        /// True if the shield is active.
        /// </summary>
        bool IsShieldActive { get; set; }
        /// <summary>
        /// The number of jumps the player has done.
        /// </summary>
        int JumpCounter { get; }
        /// <summary>
        /// The actual jump state of the player.
        /// </summary>
        JumpState JumpState { get; }
        /// <summary>
        /// The number of lives of the player.
        /// </summary>
        int Lives { get; }

        /// <summary>
        /// Makes the jump start.
        /// </summary>
        void Jump();
        /// <summary>
        /// Update the coordinate of the player during the jump.
        /// </summary>
        void UpdateJump();
        /// <summary>
        /// Update numbers of lives adding num 
        /// </summary>
        /// <param name="num">The numbers of lives to add</param>
        void AddLives(int num);
    }
}