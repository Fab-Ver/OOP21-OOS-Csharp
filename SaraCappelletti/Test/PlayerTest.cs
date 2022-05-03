using Commons.Geometry;
using NUnit.Framework;
using SaraCappelletti.PlayerModel;

namespace SaraCappelletti.Test
{
    internal class PlayerTest
    {
        private IPlayer _player;

        [SetUp]
        public void Setup()
        {
            _player = new Player();
        }

        [Test]
        public void Jump_AfterJump_JumpStateUp()
        {
            _player.Jump();
            Assert.AreEqual(JumpState.UP, _player.JumpState);
        }


        [Test]
        public void UpdateJump_AfterJump_MovingUpFromLand()
        {
            _player.Jump();
            _player.UpdateJump();
            Assert.True(_player.Bounds.MinY < Player.LAND - Player.MAIN_CHARACTER_HEIGHT);
            Assert.AreNotEqual(JumpState.DOWN, _player.JumpState);
        }

        [Test]
        public void UpdateJump_NotJumping_OnLand()
        {
            _player.UpdateJump();
            Assert.AreEqual(_player.Bounds.MinY, Player.LAND - Player.MAIN_CHARACTER_HEIGHT);
            Assert.AreEqual(JumpState.NOT_JUMPING, _player.JumpState);
        }

        [Test]
        public void AddLives_AfterAdd2_LivesEqual3()
        {
            _player.AddLives(2);
            Assert.AreEqual(_player.Lives, 3);
        }

        [Test]
        public void JumpCounter_Jump4Times_JumpCounterEquals4()
        {
            for (int i = 0; i < 4; i++)
            {
                _player.Jump();
                _player.UpdateJump();
                while (_player.Bounds.MaxY < Player.LAND)
                {
                    _player.UpdateJump();
                }
            }
            Assert.AreEqual(_player.JumpCounter, 4);
        }

        [Test]
        public void Bounds_PlayerNotMoving_PlayerBoundsOnLand()
        {
            Assert.AreEqual(_player.Bounds, new Rectangle(Player.PLAYER_X,
                                                            Player.LAND - Player.MAIN_CHARACTER_HEIGHT,
                                                            Player.MAIN_CHARACTER_WIDTH,
                                                            Player.MAIN_CHARACTER_HEIGHT));
        }
    }
}
