using Cards.Extensions.Tfs.Core.Interfaces;
using Cards.Extensions.Tfs.Core.Models;
using FluentAssertions;
using Moq;
using Xunit;

namespace Cards.Extensions.Tfs.Tests
{
    public class SessionTests
    {
        #region Structure

        [Fact]
        [Trait("Category", "Session")]
        public void WhenSessionInitialized_IsNotNull()
        {
            var subject = new Session();

            subject.Should().NotBeNull();
        }

        [Fact]
        [Trait("Category", "Session")]
        public void WhenSessionInitializedWithName_IsNotNull()
        {
            var tfsProvider = new Mock<ITFSProvider>();

            tfsProvider
                .Setup(d=>d.GetTFSDisplayName(It.Is<string>(windowsID => windowsID == @"domain\MIKADO")))
                .Returns(()=>"Speed of the Night");

            var session = new Session(tfsProvider.Object);

            var subject = session.CreateSession(@"domain\MIKADO");

            subject.Should().NotBeNull();
        }

        [Fact]
        [Trait("Category", "Session")]
        public void WhenSessionInitializedWithName_DisplayNameShouldHaveValue()
        {
            var tfsProvider = new Mock<ITFSProvider>();

            tfsProvider
                .Setup(d => d.GetTFSDisplayName(It.Is<string>(windowsID => windowsID == @"domain\MIKADO")))
                .Returns(() => "Speed of the Night");

            var session = new Session(tfsProvider.Object);

            var subject = session.CreateSession(@"domain\MIKADO");

            subject.DisplayName.Should().Be("Speed of the Night");
        }

        [Fact]
        [Trait("Category", "Session")]
        public void WhenSessionInitializedWithName_WinIdShouldHaveValue()
        {
            var tfsProvider = new Mock<ITFSProvider>();

            tfsProvider
                .Setup(d => d.GetTFSDisplayName(It.Is<string>(windowsID => windowsID == @"domain\MIKADO")))
                .Returns(() => "Speed of the Night");

            var session = new Session(tfsProvider.Object);

            var subject = session.CreateSession(@"domain\MIKADO");

            subject.WindowsIdentityName.Should().Be(@"domain\MIKADO");
        }

        #endregion
    }
}
