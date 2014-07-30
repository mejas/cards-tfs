using System;
using System.Collections.Generic;
using Cards.Extensions.Tfs.Core.Interfaces;
using Cards.Extensions.Tfs.Core.Models;
using FluentAssertions;
using Moq;
using Xunit;

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
                    .Setup(d => d.GetLabel(It.Is<int>(i => i == 1)))
                    .Returns(() => new Label() { ID = 1, Active = true, ColorCode = "#123456", Name = "MIKADO" });

                Label label = new Label(null, null, storageProvider.Object);

                subject = label.Get(0);

                subject.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenGet_LabelShouldNotBeNull()
            {
                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.GetLabel(It.Is<int>(i => i == 1)))
                    .Returns(() => new Label() { ID = 1, Active = true, ColorCode = "#123456", Name = "MIKADO" });

                Label label = new Label(null, null, storageProvider.Object);

                subject = label.Get(1);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenGet_ShouldIDHaveValue()
            {
                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.GetLabel(It.Is<int>(i => i == 1)))
                    .Returns(() => new Label() { ID = 1, Active = true, ColorCode = "#123456", Name = "MIKADO" });

                Label label = new Label(null, null, storageProvider.Object);

                subject = label.Get(1);

                subject.ColorCode.Should().Be("#123456");
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenGet_ShouldColorHaveValue()
            {
                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.GetLabel(It.Is<int>(i => i == 1)))
                    .Returns(() => new Label() { ID = 1, Active = true, ColorCode = "#123456", Name = "MIKADO" });

                Label label = new Label(null, null, storageProvider.Object);

                subject = label.Get(1);

                subject.ColorCode.Should().Be("#123456");
            }
        }

        public class UpdateMethod
        {
            [Fact]
            [Trait("Category", "Label")]
            public void WhenUpdate_ShouldBeNull()
            {
                var storageProvider = new Mock<IStorageProvider>();

                Label subject = null;

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Label>()))
                    .Callback<Label>(l => subject = l)
                    .Returns(() => subject);

                var label = new Label(null, null, storageProvider.Object);

                subject = label.Update(null);

                subject.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenUpdate_ShouldNotBeNull()
            {
                var identityProvider = new Mock<IIdentityProvider>();
                var dateProvider = new Mock<IDateProvider>();
                var storageProvider = new Mock<IStorageProvider>();

                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");

                var NOW = new DateTime(2014, 7, 21);

                dateProvider
                    .Setup(d => d.Now())
                    .Returns(NOW);

                Label subject = null;

                storageProvider
                    .Setup(d => d.GetLabel(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        {
                        var now = DateTime.UtcNow;
                        var user = "Dave Rodgers";
                        return new Label()
                        {
                            ID = 1,
                            Name = "myLabel",
                            CreatedDate = now,
                            CreatedUser = user,
                            ModifiedDate = now,
                            ModifiedUser = user,
                            ColorCode = "#000000"
                        };
                        });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Label>()))
                    .Returns(() => subject);

                var label = new Label(dateProvider.Object, identityProvider.Object, storageProvider.Object);

                subject = label.Get(1);

                subject.Name = "newMyLabel";
                subject.ColorCode = "#111111";

                subject = label.Update(subject);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenUpdate_ShouldNameBeUpdated()
            {
                var identityProvider = new Mock<IIdentityProvider>();
                var dateProvider = new Mock<IDateProvider>();
                var storageProvider = new Mock<IStorageProvider>();

                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");

                var NOW = new DateTime(2014, 7, 21);

                dateProvider
                    .Setup(d => d.Now())
                    .Returns(NOW);

                Label subject = null;

                storageProvider
                    .Setup(d => d.GetLabel(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                    {
                        var now = DateTime.UtcNow;
                        var user = "Dave Rodgers";
                        return new Label()
                        {
                            ID = 1,
                            Name = "myLabel",
                            CreatedDate = now,
                            CreatedUser = user,
                            ModifiedDate = now,
                            ModifiedUser = user,
                            ColorCode = "#000000"
                        };
                    });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Label>()))
                    .Returns(() => subject);

                var label = new Label(dateProvider.Object, identityProvider.Object, storageProvider.Object);

                subject = label.Get(1);

                subject.Name = "newMyLabel";
                subject.ColorCode = "#111111";

                subject = label.Update(subject);

                subject.Name.Should().Be("newMyLabel");
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenUpdate_ShouldColorCodeBeUpdated()
            {
                var identityProvider = new Mock<IIdentityProvider>();
                var dateProvider = new Mock<IDateProvider>();
                var storageProvider = new Mock<IStorageProvider>();

                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");

                var NOW = new DateTime(2014, 7, 21);

                dateProvider
                    .Setup(d => d.Now())
                    .Returns(NOW);

                Label subject = null;

                storageProvider
                    .Setup(d => d.GetLabel(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                    {
                        var now = DateTime.UtcNow;
                        var user = "Dave Rodgers";
                        return new Label()
                        {
                            ID = 1,
                            Name = "myLabel",
                            CreatedDate = now,
                            CreatedUser = user,
                            ModifiedDate = now,
                            ModifiedUser = user,
                            ColorCode = "#000000"
                        };
                    });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Label>()))
                    .Returns(() => subject);

                var label = new Label(dateProvider.Object, identityProvider.Object, storageProvider.Object);

                subject = label.Get(1);

                subject.Name = "newMyLabel";
                subject.ColorCode = "#111111";

                subject = label.Update(subject);

                subject.ColorCode.Should().Be("#111111");
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenUpdate_ShouldModifiedDateBeUpdated()
            {
                var identityProvider = new Mock<IIdentityProvider>();
                var dateProvider = new Mock<IDateProvider>();
                var storageProvider = new Mock<IStorageProvider>();

                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");

                var NOW = new DateTime(2014, 7, 21);

                dateProvider
                    .Setup(d => d.Now())
                    .Returns(NOW);

                Label subject = null;

                storageProvider
                    .Setup(d => d.GetLabel(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                    {
                        var now = DateTime.UtcNow;
                        var user = "Dave Rodgers";
                        return new Label()
                        {
                            ID = 1,
                            Name = "myLabel",
                            CreatedDate = now,
                            CreatedUser = user,
                            ModifiedDate = now,
                            ModifiedUser = user,
                            ColorCode = "#000000"
                        };
                    });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Label>()))
                    .Returns(() => subject);

                var label = new Label(dateProvider.Object, identityProvider.Object, storageProvider.Object);

                subject = label.Get(1);

                subject.Name = "newMyLabel";
                subject.ColorCode = "#111111";

                subject = label.Update(subject);

                subject.ModifiedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Label")]
            public void WhenUpdate_ShouldModifiedUserBeUpdated()
            {
                var identityProvider = new Mock<IIdentityProvider>();
                var dateProvider = new Mock<IDateProvider>();
                var storageProvider = new Mock<IStorageProvider>();

                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");

                var NOW = new DateTime(2014, 7, 21);

                dateProvider
                    .Setup(d => d.Now())
                    .Returns(NOW);

                Label subject = null;

                storageProvider
                    .Setup(d => d.GetLabel(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                    {
                        var now = DateTime.UtcNow;
                        var user = "Dave Rodgers";
                        return new Label()
                        {
                            ID = 1,
                            Name = "myLabel",
                            CreatedDate = now,
                            CreatedUser = user,
                            ModifiedDate = now,
                            ModifiedUser = user,
                            ColorCode = "#000000"
                        };
                    });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Label>()))
                    .Returns(() => subject);

                var label = new Label(dateProvider.Object, identityProvider.Object, storageProvider.Object);

                subject = label.Get(1);

                subject.Name = "newMyLabel";
                subject.ColorCode = "#111111";

                subject = label.Update(subject);

                subject.ModifiedUser.Should().Be("MIKADO");
            }
        }

        public class RemoveMethod
        {
            [Fact]
            [Trait("Category", "Label")]
            public void WhenRemove_ShouldBeNull()
            {
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();

                storageProvider.Setup(d => d.RemoveLabel(It.IsAny<Label>()));
                storageProvider.Setup(d => d.GetCard(It.Is<int>(i => i == 1))).Returns(() => null);

                var label = new Label(dateProvider.Object, identityProvider.Object, storageProvider.Object);

                label.Remove(1);

                var subject = label.Get(1);

                subject.Should().BeNull();
            }
        }
    }
}
