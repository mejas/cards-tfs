using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Cards.Extensions.Tfs.Core.Models;
using Moq;
using Cards.Extensions.Tfs.Core.Interfaces;

namespace Cards.Extensions.Tfs.Tests
{
    public class LabelTests
    {
        public class Structure
        {
            [Fact]
            [Trait("Category","Label")]
            public void WhenInitilalize_LabelShouldNotBeNull()
            {
                Label subject = new Label();

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenInitilalize_LabelIDShouldBeZero()
            {
                Label subject = new Label();

                subject.ID.Should().Be(0);
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenInitilalize_LabelCreatedUserShouldBeNull()
            {
                Label subject = new Label();

                subject.CreatedUser.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenInitilalize_LabelCreatedDateShouldBeMinDate()
            {
                Label subject = new Label();

                subject.CreatedDate.Should().Be(DateTime.MinValue);
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenInitilalize_LabelModifiedUserShouldBeNull()
            {
                Label subject = new Label();

                subject.ModifiedUser.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenInitilalize_LabelModifiedDateShouldBeMinDate()
            {
                Label subject = new Label();

                subject.ModifiedDate.Should().Be(DateTime.MinValue);
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenInitilalize_LabelNameShouldBeNull()
            {
                Label subject = new Label();

                subject.Name.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenInitilalize_LabelColorCodeShouldBeNull()
            {
                Label subject = new Label();

                subject.ColorCode.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenInitilalize_LabelActiveShouldBeTrue()
            {
                Label subject = new Label();

                subject.Active.Should().Be(true);
            }
        }

        public class GetAllMethod
        {
            [Fact]
            [Trait("Category", "Label")]
            public void WhenGetAll_LabelShouldNotBeNull()
            {
                var storageProvider = new Mock<IStorageProvider>();

                storageProvider
                    .Setup(d => d.GetAllLabels())
                    .Returns(() => new List<Label>());

                Label label = new Label(null, null, storageProvider.Object);

                var subject = label.GetAll();

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenGetAll_LabelShouldHaveNoElements()
            {
                var storageProvider = new Mock<IStorageProvider>();

                storageProvider
                    .Setup(d => d.GetAllLabels())
                    .Returns(() => new List<Label>());

                Label label = new Label(null, null, storageProvider.Object);

                var subject = label.GetAll();

                subject.Count.Should().Be(0);
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenGetAll_LabelShouldHaveOneElement()
            {
                var storageProvider = new Mock<IStorageProvider>();

                storageProvider
                    .Setup(d => d.GetAllLabels())
                    .Returns(() => new List<Label> { new Label() { Active = true, ColorCode = "#123456", Name = "MIKADO" } });

                Label label = new Label(null, null, storageProvider.Object);

                var subject = label.GetAll();

                subject.Count.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenGetAll_LabelHaveActiveOnly()
            {
                var storageProvider = new Mock<IStorageProvider>();

                storageProvider
                    .Setup(d => d.GetAllLabels())
                    .Returns(() => new List<Label> { new Label() { Active = true, ColorCode = "#123456", Name = "MIKADO" } });

                Label label = new Label(null, null, storageProvider.Object);

                var subject = label.GetAll();

                subject.Should().OnlyContain(item=>item.Active);
            }
        }

        public class AddMethod
        {
            [Fact]
            [Trait("Category", "Label")]
            public void WhenAdd_LabelShouldNotBeNull()
            {
                var NOW = new DateTime(2014, 12, 12);
                var dateProvider = new Mock<IDateProvider>();

                dateProvider
                    .Setup(d => d.Now())
                    .Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Label>()))
                    .Callback<Label>(a => subject = a)
                    .Returns(() => { subject.ID = 1; return subject; });

                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider = new Mock<IIdentityProvider>();

                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");

                Label label = new Label(dateProvider.Object, identityProvider.Object, storageProvider.Object);

                subject = label.Add("MIKADO", "#00000");

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenAdd_LabelShouldHaveID()
            {
                var NOW = new DateTime(2014, 12, 12);
                var dateProvider = new Mock<IDateProvider>();

                dateProvider
                    .Setup(d => d.Now())
                    .Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Label>()))
                    .Callback<Label>(a => subject = a)
                    .Returns(() => { subject.ID = 1; return subject; });

                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider = new Mock<IIdentityProvider>();

                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");

                Label label = new Label(dateProvider.Object, identityProvider.Object, storageProvider.Object);

                subject = label.Add("MIKADO", "#000000");

                subject.ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenAdd_LabelShouldNameBeMIKADO()
            {
                var NOW = new DateTime(2014, 12, 12);
                var dateProvider = new Mock<IDateProvider>();

                dateProvider
                    .Setup(d => d.Now())
                    .Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Label>()))
                    .Callback<Label>(a => subject = a)
                    .Returns(() => { subject.ID = 1; return subject; });

                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider = new Mock<IIdentityProvider>();

                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");

                Label label = new Label(dateProvider.Object, identityProvider.Object, storageProvider.Object);

                subject = label.Add("MIKADO", "#000000");

                subject.Name.Should().Be("MIKADO");
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenAdd_LabelShouldColorBeHexBlack()
            {
                var NOW = new DateTime(2014, 12, 12);
                var dateProvider = new Mock<IDateProvider>();

                dateProvider
                    .Setup(d => d.Now())
                    .Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Label>()))
                    .Callback<Label>(a => subject = a)
                    .Returns(() => { subject.ID = 1; return subject; });

                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider = new Mock<IIdentityProvider>();

                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");

                Label label = new Label(dateProvider.Object, identityProvider.Object, storageProvider.Object);

                subject = label.Add("MIKADO", "#000000");

                subject.ColorCode.Should().Be("#000000");
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenAdd_LabelCreatedUserBeMIKADO()
            {
                var NOW = new DateTime(2014, 12, 12);
                var dateProvider = new Mock<IDateProvider>();

                dateProvider
                    .Setup(d => d.Now())
                    .Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Label>()))
                    .Callback<Label>(a => subject = a)
                    .Returns(() => { subject.ID = 1; return subject; });

                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider = new Mock<IIdentityProvider>();

                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");

                Label label = new Label(dateProvider.Object, identityProvider.Object, storageProvider.Object);

                subject = label.Add("MIKADO", "#000000");

                subject.CreatedUser.Should().Be("MIKADO");
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenAdd_LabelCreatedDateShouldBeNow()
            {
                var NOW = new DateTime(2014, 12, 12);
                var dateProvider = new Mock<IDateProvider>();

                dateProvider
                    .Setup(d => d.Now())
                    .Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Label>()))
                    .Callback<Label>(a => subject = a)
                    .Returns(() => { subject.ID = 1; return subject; });

                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider = new Mock<IIdentityProvider>();

                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");

                Label label = new Label(dateProvider.Object, identityProvider.Object, storageProvider.Object);

                subject = label.Add("MIKADO", "#000000");

                subject.CreatedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenAdd_LabelModifiedUserShouldBeMIKADO()
            {
                var NOW = new DateTime(2014, 12, 12);
                var dateProvider = new Mock<IDateProvider>();

                dateProvider
                    .Setup(d => d.Now())
                    .Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Label>()))
                    .Callback<Label>(a => subject = a)
                    .Returns(() => { subject.ID = 1; return subject; });

                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider = new Mock<IIdentityProvider>();

                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");

                Label label = new Label(dateProvider.Object, identityProvider.Object, storageProvider.Object);

                subject = label.Add("MIKADO", "#000000");

                subject.ModifiedUser.Should().Be("MIKADO");
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenAdd_LabelModifiedDateShouldBeNow()
            {
                var NOW = new DateTime(2014, 12, 12);
                var dateProvider = new Mock<IDateProvider>();

                dateProvider
                    .Setup(d => d.Now())
                    .Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Label>()))
                    .Callback<Label>(a => subject = a)
                    .Returns(() => { subject.ID = 1; return subject; });

                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider = new Mock<IIdentityProvider>();

                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");

                Label label = new Label(dateProvider.Object, identityProvider.Object, storageProvider.Object);

                subject = label.Add("MIKADO", "#000000");

                subject.ModifiedDate.Should().Be(NOW);
            }
        }

        public class GetMethod
        {
            [Fact]
            [Trait("Category", "Label")]
            public void WhenGet_LabelShouldBeNull()
            {
                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.GetLabel(It.Is<string>(i => i == "MIKADO")))
                    .Returns(() => new Label() { ID = 1, Active = true, ColorCode = "#123456", Name = "MIKADO" });

                Label label = new Label(null, null, storageProvider.Object);

                subject = label.Get("mikakuning");

                subject.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenGet_LabelShouldNotBeNull()
            {
                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.GetLabel(It.Is<string>(i => i == "MIKADO")))
                    .Returns(() => new Label() { ID = 1, Active = true, ColorCode = "#123456", Name = "MIKADO" });

                Label label = new Label(null, null, storageProvider.Object);

                subject = label.Get("MIKADO");

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenGet_ShouldIDHaveValue()
            {
                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.GetLabel(It.Is<string>(i => i == "MIKADO")))
                    .Returns(() => new Label() { ID = 1, Active = true, ColorCode = "#123456", Name = "MIKADO" });

                Label label = new Label(null, null, storageProvider.Object);

                subject = label.Get("MIKADO");

                subject.ColorCode.Should().Be("#123456");
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenGet_ShouldColorHaveValue()
            {
                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.GetLabel(It.Is<string>(i => i == "MIKADO")))
                    .Returns(() => new Label() { ID = 1, Active = true, ColorCode = "#123456", Name = "MIKADO" });

                Label label = new Label(null, null, storageProvider.Object);

                subject = label.Get("MIKADO");

                subject.ColorCode.Should().Be("#123456");
            }
        }

        public class UpdateMethod
        {
        }
    }
}
