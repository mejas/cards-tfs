using System;
using System.Collections.Generic;
using Cards.Extensions.Tfs.Core;
using FluentAssertions;
using Moq;
using Xunit;

namespace Cards.Extensions.Tfs.Tests
{
    public class AreaTests
    {
        public class Structure
        {
            [Fact]
            [Trait("Category", "Area")]
            public void WhenInitialize_ShouldNotBeNull()
            {
                var subject = new Area();
                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenInitialize_ShouldIDBeZero()
            {
                var subject = new Area();
                subject.ID.Should().Be(0);
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenInitialize_ShouldNameBeNull()
            {
                var subject = new Area();
                subject.Name.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenInitialize_ShouldCreatedDateBeMinValue()
            {
                var subject = new Area();
                subject.CreatedDate.Should().Be(DateTime.MinValue);
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenInitialize_ShouldModifiedDateBeMinValue()
            {
                var subject = new Area();
                subject.ModifiedDate.Should().Be(DateTime.MinValue);
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenInitialize_ShouldCreatedUserBeNull()
            {
                var subject = new Area();
                subject.CreatedUser.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenInitialize_ShouldModifiedUserBeNull()
            {
                var subject = new Area();
                subject.ModifiedUser.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenInitialize_ShouldBeActive()
            {
                var subject = new Area();
                subject.Active.Should().Be(true);
            }
        }

        public class AddMethod
        {
            [Fact]
            [Trait("Category", "Area")]
            public void WhenNameIsNotNull_ShouldNotBeNull()
            {
                //Arrange
                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");


                var NOW = DateTime.Now;
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Area>()))
                    .Callback<Area>(a => subject = a)
                    .Returns(() => subject);

                var area = new Area(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                var areaName = "Backlog";

                //Act
                subject = area.Add(areaName);

                //Assert
                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenNameIsNotNull_NameShouldBeBacklog()
            {
                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                var NOW = DateTime.Now;
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Area>()))
                    .Callback<Area>(a => subject = a)
                    .Returns(() => subject);

                var area = new Area(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                var areaName = "Backlog";

                subject = area.Add(areaName);

                subject.Name.Should().Be("Backlog");
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenNameIsNotNull_IDShouldBeOne()
            {
                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                var NOW = DateTime.Now;
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Area>()))
                    .Callback<Area>(a => 
                    {
                        a.ID = 1;
                        subject = a;
                    }).Returns(() => subject);

                var area = new Area(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                var areaName = "Backlog";

                subject = area.Add(areaName);

                subject.ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenNameIsNotNull_CreatedDateShouldHaveValue()
            {
                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                var NOW = new DateTime(2014, 5, 19);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Area>()))
                    .Callback<Area>(a => subject = a)
                    .Returns(() => subject);

                var area = new Area(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                var areaName = "Backlog";

                subject = area.Add(areaName);

                subject.CreatedDate.Should().Be(new DateTime(2014, 5, 19));
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenNameIsNotNull_ModifiedDateShouldHaveValue()
            {
                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                var NOW = new DateTime(2014, 5, 19);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Area>()))
                    .Callback<Area>(a => subject = a)
                    .Returns(() => subject);

                var area = new Area(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                var areaName = "Backlog";

                subject = area.Add(areaName);

                subject.ModifiedDate.Should().Be(new DateTime(2014, 5, 19));
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenNameIsNotNull_CreatedUserShouldHaveValue()
            {
                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                var NOW = new DateTime(2014, 5, 19);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Area>()))
                    .Callback<Area>(a => subject = a)
                    .Returns(() => subject);

                var area = new Area(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                var areaName = "Backlog";

                subject = area.Add(areaName);

                subject.CreatedUser.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenNameIsNotNull_ModifiedUserShouldHaveValue()
            {
                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                var NOW = new DateTime(2014, 5, 19);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Area>()))
                    .Callback<Area>(a => subject = a)
                    .Returns(() => subject);

                var area = new Area(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                var areaName = "Backlog";

                subject = area.Add(areaName);

                subject.ModifiedUser.Should().Be("Dave Rodgers");
            }
        }

        public class GetAllMethod
        {
            [Fact]
            [Trait("Category", "Area")]
            public void WhenGetAll_ShouldNotBeNull()
            {
                var storageProvider = new Mock<IStorageProvider>();

                List<Area> subject = null;

                storageProvider
                    .Setup(d => d.GetAllAreas())
                    .Returns(() => new List<Area>());

                var area = new Area(null, storageProvider.Object, null);

                subject = area.GetAll();

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGetAll_ShouldBeEmpty()
            {
                var storageProvider = new Mock<IStorageProvider>();

                List<Area> subject = null;

                storageProvider
                    .Setup(d => d.GetAllAreas())
                    .Returns(() => new List<Area>());

                var area = new Area(null, storageProvider.Object, null);

                subject = area.GetAll();

                subject.Should().BeEmpty();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGetAll_AndWithNewArea_ShouldHaveOneElement()
            {
                var storageProvider = new Mock<IStorageProvider>();
                storageProvider.Setup(d => d.GetAllAreas()).Returns(
                    () => 
                    {
                        List<Area> toReturn = new List<Area>();
                        toReturn.Add(new Area());

                        return toReturn;
                    });

                var area = new Area(null, storageProvider.Object, null);

                var subject = area.GetAll();

                subject.Count.Should().Be(1);

            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGetAll_AndWithNewArea_StatusShouldBeActive()
            {
                var storageProvider = new Mock<IStorageProvider>();
                storageProvider.Setup(d => d.GetAllAreas()).Returns(
                    () =>
                    {
                        List<Area> toReturn = new List<Area>();
                        toReturn.Add(new Area());
                        toReturn.Add(new Area());

                        return toReturn;
                    });

                var area = new Area(null, storageProvider.Object, null);

                var subject = area.GetAll();

                subject.Should().OnlyContain(item=>item.Active == true);

            }
        }

        public class GetMethod
        {
            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_ShouldBeNull()
            {
                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.GetArea(It.IsAny<int>()))
                    .Returns(() => null);

                var area = new Area(null, storageProvider.Object, null);
                var id = 1;

                subject = area.Get(id);

                subject.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_ShouldNotBeNull()
            {
                var NOW = DateTime.Now;
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.GetArea(It.Is<int>(i => i == 1)))
                    .Returns(() => new Area() { ID = 1, Name = "Backlog", CreatedDate = NOW });

                var area = new Area(dateProvider.Object, storageProvider.Object, null);

                subject = area.Get(1);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_AndWithNewArea_IDShouldBeOne()
            {
                var NOW = DateTime.Now;
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.GetArea(It.Is<int>(i => i == 1)))
                    .Returns(() => new Area() { ID = 1, Name = "Backlog", CreatedDate = NOW });

                var area = new Area(dateProvider.Object, storageProvider.Object, null);

                subject = area.Get(1);

                subject.ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_AndWithNewArea_NameShouldBeBacklog()
            {
                var NOW = DateTime.Now;
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.GetArea(It.Is<int>(i => i == 1)))
                    .Returns(() => new Area() { ID = 1, Name = "Backlog", CreatedDate = NOW });

                var area = new Area(dateProvider.Object, storageProvider.Object, null);

                subject = area.Get(1);

                subject.Name.Should().Be("Backlog");
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_CreatedDateShouldHaveValue()
            {
                var NOW = new DateTime(2014, 5, 19);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();
                
                Area subject = null;

                storageProvider
                    .Setup(d => d.GetArea(It.Is<int>(i => i == 1)))
                    .Returns(() => new Area() { ID = 1, CreatedDate = NOW });

                var area = new Area(dateProvider.Object, storageProvider.Object, null);

                subject = area.Get(1);

                subject.CreatedDate.Should().Be(new DateTime(2014, 5, 19));
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_ModifiedDateShouldHaveValue()
            {
                var NOW = new DateTime(2014, 5, 19);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.GetArea(It.Is<int>(i => i == 1)))
                    .Returns(() => new Area() { ID = 1, CreatedDate = NOW, ModifiedDate = NOW });

                var area = new Area(dateProvider.Object, storageProvider.Object, null);

                subject = area.Get(1);

                subject.ModifiedDate.Should().Be(new DateTime(2014, 5, 19));
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_CreatedUserShouldHaveValue()
            {
                var NOW = new DateTime(2014, 5, 19);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.GetArea(It.Is<int>(i => i == 1)))
                    .Returns(() => new Area() { ID = 1, CreatedDate = NOW, CreatedUser = "Dave Rodgers" });

                var area = new Area(dateProvider.Object, storageProvider.Object, null);

                subject = area.Get(1);

                subject.CreatedUser.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_ModifiedUserShouldHaveValue()
            {
                var NOW = new DateTime(2014, 5, 19);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.GetArea(It.Is<int>(i => i == 1)))
                    .Returns(() => new Area() { ID = 1, CreatedDate = NOW, ModifiedUser = "Dave Rodgers" });

                var area = new Area(dateProvider.Object, storageProvider.Object, null);

                subject = area.Get(1);

                subject.ModifiedUser.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_ActiveValueShouldBeTrue()
            {
                var NOW = new DateTime(2014, 5, 19);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.GetArea(It.Is<int>(i => i == 1)))
                    .Returns(() => new Area() { ID = 1, CreatedDate = NOW, ModifiedUser = "Dave Rodgers" });

                var area = new Area(dateProvider.Object, storageProvider.Object, null);

                subject = area.Get(1);

                subject.Active.Should().Be(true);
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_ShouldStatusBeActive()
            {
                var NOW = new DateTime(2014, 5, 19);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.GetArea(It.Is<int>(i => i == 1)))
                    .Returns(() => new Area() { ID = 1, CreatedDate = NOW, ModifiedUser = "Dave Rodgers", Active = true });

                var area = new Area(dateProvider.Object, storageProvider.Object, null);

                subject = area.Get(1);

                subject.Active.Should().Be(true);
            }

        }

        public class UpdateMethod
        {
            [Fact]
            [Trait("Category", "Area")]
            public void WhenEdit_ShouldBeNull()
            {
                var NOW = new DateTime(2014, 5, 20);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Area>()))
                    .Callback<Area>(a => subject = a)
                    .Returns(() => null);

                var area = new Area(dateProvider.Object, storageProvider.Object, null);

                subject = area.Update(null);

                subject.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenEdit_ShouldNotBeNull()
            {
                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                var NOW = new DateTime(2014, 5, 20);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.GetArea(It.Is<int>(i => i == 1)))
                    .Returns(() => new Area() { ID = 1, Name = "Backlog", CreatedDate = NOW });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Area>()))
                    .Callback<Area>(a => subject = a.ID == 1 ? a : null)
                    .Returns(() => subject);

                var area = new Area(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = area.Get(1);
                subject.Name = "Not a Backlog";

                subject = area.Update(subject);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenEdit_NameShouldBeUpdated()
            {
                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                var NOW = new DateTime(2014, 5, 20);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.GetArea(It.Is<int>(i => i == 1)))
                    .Returns(() => new Area() { ID = 1, Name = "Backlog", CreatedDate = NOW });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Area>()))
                    .Callback<Area>(a => subject = a.ID == 1 ? a : null)
                    .Returns(() => subject);

                var area = new Area(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = area.Get(1);

                subject.Name = "Not a Backlog";

                subject = area.Update(subject);

                subject.Name.Should().Be("Not a Backlog");
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenEdit_ModifiedDateShouldBeUpdated()
            {
                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                var NOW = new DateTime(2014, 5, 20);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.GetArea(It.Is<int>(i => i == 1)))
                    .Returns(() => new Area() { ID = 1, Name = "Backlog", CreatedDate = NOW });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Area>()))
                    .Callback<Area>(a => subject = a.ID == 1 ? a : null)
                    .Returns(() => subject);

                var area = new Area(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = area.Get(1);

                subject.Name = "Not a backlog";

                subject = area.Update(subject);

                subject.ModifiedDate.Should().Be(new DateTime(2014, 5, 20));
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenEdit_ModifiedUserShouldBeUpdated()
            {
                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider.Setup(d => d.GetUserName()).Returns("MIKADO");

                var NOW = new DateTime(2014, 5, 20);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.GetArea(It.Is<int>(i => i == 1)))
                    .Returns(() => new Area() { ID = 1, Name = "Backlog", CreatedDate = NOW, CreatedUser = "Dave Rodgers" });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Area>()))
                    .Callback<Area>(a => subject = a.ID == 1 ? a : null)
                    .Returns(() => subject);

                var area = new Area(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = area.Get(1);

                subject.Name = "Not a backlog";

                subject = area.Update(subject);

                subject.ModifiedUser.Should().Be("MIKADO");
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenEdit_CreatedUserUserShouldNotBeUpdated()
            {
                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                var NOW = new DateTime(2014, 5, 20);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.GetArea(It.Is<int>(i => i == 1)))
                    .Returns(() => new Area() { ID = 1, Name = "Backlog", CreatedDate = NOW, CreatedUser = "Dave Rodgers" });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Area>()))
                    .Callback<Area>(a => subject = a.ID == 1 ? a : null)
                    .Returns(() => subject);

                var area = new Area(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = area.Get(1);

                subject.Name = "Not a backlog";

                subject = area.Update(subject);

                subject.CreatedUser.Should().Be("Dave Rodgers");
            }
        }

        public class RemoveMethod
        {
            [Fact]
            [Trait("Category", "Area")]
            public void WhenDelete_DataShouldBeRemoved()
            {

                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                var NOW = new DateTime(2014, 5, 20);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var storageProvider = new Mock<IStorageProvider>();

                Area subject = null;

                storageProvider
                    .Setup(d => d.RemoveArea(It.Is<int>(i => i == 1)));

                storageProvider
                    .Setup(d => d.GetArea(It.Is<int>(i => i == 1)))
                    .Returns(() => null);

                var area = new Area(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                area.Remove(1);

                subject = area.Get(1);

                subject.Should().BeNull();
            }
        }
    }
}
