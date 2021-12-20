using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using Xunit;

namespace Rockets.Common.Supervisor.UnitTest
{
    public class TestLandingPositionAvailability
    {
        [Fact]
        public void Test_Landing_Platform_Should_Return_Throw_Null_Exception()
        {
            string position = "";
            LandingPositionAvailability testLandingTrajectoryAvailability = new LandingPositionAvailability();
            var caughtException = Assert.Throws<Exception>(() => testLandingTrajectoryAvailability.LandingPermission(position));

            Assert.Equal("A valid position must be supplied.", caughtException.Message);

        }

        [Fact]
        public void Test_Landing_Platform_Should_Return_Throw_Exception()
        {
            string position = "f,c";
            LandingPositionAvailability testLandingTrajectoryAvailability = new LandingPositionAvailability();
            var caughtException = Assert.Throws<Exception>(() => testLandingTrajectoryAvailability.LandingPermission(position));

            Assert.Equal("A valid position must be supplied.", caughtException.Message);

        }

        [Fact]
        public void Test_Landing_Platform_Should_Return_Ok_For_Landing0()
        {
            string position = "5,7";
            LandingPositionAvailability testLandingTrajectoryAvailability = new LandingPositionAvailability();

            Assert.Equal("Ok for landing", testLandingTrajectoryAvailability.LandingPermission(position));
        }
        [Fact]
        public void Test_Landing_Platform_Should_Return_Ok_For_Landing3()
        {
            string position = "7,7";
            LandingPositionAvailability testLandingTrajectoryAvailability = new LandingPositionAvailability();

            Assert.Equal("Ok for landing", testLandingTrajectoryAvailability.LandingPermission(position));
        }
        [Fact]
        public void Test_Landing_Platform_Should_Return_Ok_For_Landing2()
        {
            string position = "7,5";
            LandingPositionAvailability testLandingTrajectoryAvailability = new LandingPositionAvailability();

            Assert.Equal("Ok for landing", testLandingTrajectoryAvailability.LandingPermission(position));
        }
        [Fact]
        public void Test_Landing_Platform_Should_Return_Ok_For_Landing()
        {
            string position = "13,13";
            LandingPositionAvailability testLandingTrajectoryAvailability = new LandingPositionAvailability();

            Assert.Equal("Ok for landing", testLandingTrajectoryAvailability.LandingPermission(position));
        }

        [Fact]
        public void Test_Landing_Platform_Should_Return_Ok_For_Landing1()
        {
            string position = "8,9";
            LandingPositionAvailability testLandingTrajectoryAvailability = new LandingPositionAvailability();

            Assert.Equal("Ok for landing", testLandingTrajectoryAvailability.LandingPermission(position));
        }

        [Fact]
        public void Test_Landing_Platform_Should_Return_Clash()
        {
            string position = "5,5";
            LandingPositionAvailability testLandingTrajectoryAvailability = new LandingPositionAvailability();


            testLandingTrajectoryAvailability.LandingPermission(position);
            Assert.Equal("Clash", testLandingTrajectoryAvailability.LandingPermission(position));
        }

        [Fact]
        public void Test_Landing_Platform_Should_Return_Clash1()
        {
            string position = "6,6";
            LandingPositionAvailability testLandingTrajectoryAvailability = new LandingPositionAvailability();
            testLandingTrajectoryAvailability.LandingPermission("5,5");
            Assert.Equal("Clash", testLandingTrajectoryAvailability.LandingPermission(position));
        }

        [Fact]
        public void Test_Landing_Platform_Should_Return_Out_Of_Platform1()
        {
            string position = "4,5";
            LandingPositionAvailability testLandingTrajectoryAvailability = new LandingPositionAvailability();

            Assert.Equal("Out of platform", testLandingTrajectoryAvailability.LandingPermission(position));
        }

        [Fact]
        public void Test_Landing_Platform_Should_Return_Out_Of_Platform()
        {
            string position = "16,15";
            LandingPositionAvailability testLandingTrajectoryAvailability = new LandingPositionAvailability();

            Assert.Equal("Out of platform", testLandingTrajectoryAvailability.LandingPermission(position));
        }
    }
}