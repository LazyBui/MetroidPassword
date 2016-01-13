using MetroidPassword.Tools;
using NUnit.Framework;
using Should;

namespace MetroidPassword.Tests
{
    [TestFixture]
    public class SmokeTests
    {
        [Test]
        public void My_progress_after_buying_the_game()
        {
            var password = new Password("00140000000000100RW000wT");
            var properties = password.Properties;

            properties.HasMorphBall.ShouldBeTrue();
            properties.BrinstarEnergyTank1.ShouldBeTrue();

            properties.BrinstarEnergyTank2.ShouldBeFalse();
            properties.BrinstarEnergyTank3.ShouldBeFalse();

            properties.HasBombs.ShouldBeFalse();
            properties.Swimsuit.ShouldBeFalse();

            properties.GameAge.ShouldEqual((uint)110);
        }

        [Test]
        public void Supergirl()
        {
            var properties = PropertiesWithLotsOfStuff();

            var password = new Password(properties);
            password.Encoded.ShouldEqual("---------mC0V-y00000y01g");
        }

        [Test]
        public void To_beat_the_game()
        {
            var properties = PropertiesWithLotsOfStuff();

            properties.StartInTourian = true;
            properties.HasIceBeam = true;

            new Password(properties).Encoded.ShouldEqual("---------mC3l-y00000y02j");
        }

        private static PasswordProperties PropertiesWithLotsOfStuff()
        {
            var properties = new PasswordProperties
            {
                BombsRedDoor = true,
                BombsTaken = true,
                BrinstarEnergyTank1 = true,
                BrinstarEnergyTank2 = true,
                BrinstarEnergyTank3 = true,
                BrinstarMissileContainer1 = true,
                BrinstarMissileContainer2 = true,
                BrinstarIceBeamRedDoor = true,
                HasMorphBall = true,
                HasBombs = true,
                HasHighJumpBoots = true,
                HasIceBeam = true,
                HasLongBeam = true,
                HasNormalBeam = true,
                HasScrewAttack = true,
                HasVariaSuit = true,
                HasWaveBeam = true,
                HighJumpBootsRedDoor = true,
                HighJumpBootsTaken = true,
                KraidLairMissileContainer1 = true,
                KraidLairMissileContainer2 = true,
                KraidLairMissileContainer3 = true,
                KraidLairMissileContainer4 = true,
                KraidDead = true,
                KraidLairEnergyTank = true,
                KraidLairRedDoor1 = true,
                KraidLairRedDoor2 = true,
                KraidLairRedDoor3 = true,
                KraidLairRedDoor4 = true,
                KraidRoomEnergyTank = true,
                KraidRoomRedDoor = true,
                KraidStatueRaised = true,
                RidleyLairMissileContainer1 = true,
                LongBeamRedDoor = true,
                MissileCount = 255,
                MorphBallTaken = true,
                NorfairEnergyTank = true,
                NorfairIceBeamRedDoor = true,
                NorfairMissileContainer1 = true,
                NorfairMissileContainer10 = true,
                NorfairMissileContainer11 = true,
                NorfairMissileContainer12 = true,
                NorfairMissileContainer2 = true,
                NorfairMissileContainer3 = true,
                NorfairMissileContainer4 = true,
                NorfairMissileContainer5 = true,
                NorfairMissileContainer6 = true,
                NorfairMissileContainer7 = true,
                NorfairMissileContainer8 = true,
                NorfairMissileContainer9 = true,
                RidleyDead = true,
                RidleyEnergyTank = true,
                RidleyLairEnergyTank = true,
                RidleyLairMissileContainer2 = true,
                RidleyLairMissileContainer3 = true,
                RidleyLairRedDoor = true,
                RidleyLairYellowDoor = true,
                RidleyStatueRaised = true,
                ScrewAttackTaken = true,
                Swimsuit = false,
                ScrewAttackRedDoor = true,
                TourianBridgeRedDoor = true,
                TourianRedDoor1 = true,
                TourianRedDoor2 = true,
                TourianYellowDoor = true,
                VariaSuitRedDoor = true,
                VariaSuitTaken = true,
                WaveBeamRedDoor = true,
                Zebetite1Dead = true,
                Zebetite2Dead = true,
                Zebetite3Dead = true,
                Zebetite4Dead = true,
                Zebetite5Dead = true,
            };
            return properties;
        }
    }
}