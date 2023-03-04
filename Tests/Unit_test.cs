using Calabonga.DemoClasses;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Tests
{
    public class Unit_tests
    {
        [Fact]
        public void check_job_success()
        {
            var sut = new Chess();
            Assert.False(sut.coords_making(1, 1, 1, 1, 1, 1));
            Assert.False(sut.coords_making(1, 1, 5, 4, 2, 3));
            Assert.False(sut.checking_borders(1, 1, 1, 1, 1, 1));
            Assert.True(sut.checking_same_coords(1, 1, 1, 1, 1, 1));
            Assert.True(sut.checking_alarm_elephant(1, 1, 1, 1, 1, 1));
            Assert.True(sut.checking_alarm_rook(1, 1, 1, 1, 1, 1));
        }
        [Fact]
        public void check_bad_coords()
        {
            //Arrange
            var sut = new Chess();

            //Act

            //Assert
            Assert.False(sut.checking_borders(10, 10, 5, 5, 8, 8));
            Assert.True(sut.checking_borders(5, 5, 5, 5, 7, 7));
        }
        [Fact]
        public void check_same_coords()
        {
            //Arrange
            var sut = new Chess();

            //Act

            //Assert
            Assert.True(sut.checking_same_coords(5, 5, 5, 5, 7, 7));
            Assert.False(sut.checking_same_coords(2, 5, 5, 4, 7, 5));
        }
        [Fact]
        public void check_alarm_elephent()
        {
            var sut = new Chess();
            Assert.True(sut.checking_alarm_elephant(2, 2, 7, 8, 4, 4));
            Assert.False(sut.checking_alarm_elephant(2, 2, 2, 4, 7, 6));
        }
        [Fact]
        public void check_alarm_rook()
        {
            var sut = new Chess();
            Assert.False(sut.checking_alarm_rook(2, 2, 7, 8, 4, 4));
            Assert.True(sut.checking_alarm_rook(2, 2, 2, 4, 7, 6));
        }

    }
}