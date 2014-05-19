using System;
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
        }

        public class AddMethod
        {
            public AddMethod()
            {
                Area.Reset();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenNameIsNotNull_ShouldNotBeNull()
            {
                //Arrange
                var NOW = DateTime.Now;
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var area = new Area(dateProvider.Object);
                var areaName = "Backlog";

                //Act
                var subject = area.Add(areaName);

                //Assert
                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenNameIsNotNull_NameShouldBeBacklog()
            {
                var NOW = DateTime.Now;
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var area = new Area(dateProvider.Object);

                var areaName = "Backlog";

                var subject = area.Add(areaName);

                subject.Name.Should().Be("Backlog");
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenNameIsNotNull_IDShouldBeOne()
            {
                var NOW = DateTime.Now;
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var area = new Area(dateProvider.Object);

                var areaName = "Backlog";

                var subject = area.Add(areaName);

                subject.ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenNameIsNotNull_CreatedDateShouldHaveValue()
            {
                var NOW = new DateTime(2014, 5, 19);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var area = new Area(dateProvider.Object);
                
                var areaName = "Backlog";

                var subject = area.Add(areaName);

                subject.CreatedDate.Should().Be(new DateTime(2014, 5, 19));
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenNameIsNotNull_ModifiedDateShouldHaveValue()
            {
                var NOW = new DateTime(2014, 5, 19);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var area = new Area(dateProvider.Object);

                var areaName = "Backlog";

                var subject = area.Add(areaName);

                subject.ModifiedDate.Should().Be(new DateTime(2014, 5, 19));
            }
        }

        public class GetAllMethod
        {
            public GetAllMethod()
            {
                Area.Reset();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGetAll_ShouldNotBeNull()
            {
                var area = new Area();
                var subject = area.GetAll();

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGetAll_ShouldBeEmpty()
            {
                var area = new Area();
                var subject = area.GetAll();

                subject.Should().BeEmpty();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGetAll_AndWithNewArea_ShouldHaveOneElement()
            {
                var NOW = DateTime.Now;
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var area = new Area(dateProvider.Object);

                area.Add("Backlog");

                var subject = area.GetAll();

                subject.Count.Should().Be(1);
            }
        }

        public class GetMethod
        {
            public GetMethod()
            {
                Area.Reset();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_ShouldBeNull()
            {
                var area = new Area();
                var id = 1;

                var subject = area.Get(id);

                subject.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_AndWithNewArea_ShouldNotBeNull()
            {
                var NOW = DateTime.Now;
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var area = new Area(dateProvider.Object);

                area.Add("Backlog");

                var subject = area.Get(1);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_AndWithNewArea_IDShouldBeOne()
            {
                var NOW = DateTime.Now;
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var area = new Area(dateProvider.Object);

                area.Add("Backlog");

                var subject = area.Get(1);

                subject.ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_AndWithNewArea_NameShouldBeBacklog()
            {
                var NOW = new DateTime(2014, 5, 21);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var area = new Area(dateProvider.Object);

                area.Add("Backlog");

                var subject = area.Get(1);

                subject.Name.Should().Be("Backlog");
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_AndWithNewArea_CreatedDateShouldHaveValue()
            {
                var NOW = new DateTime(2014, 5, 19);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var area = new Area(dateProvider.Object);

                area.Add("Backlog");

                var subject = area.Get(1);

                subject.CreatedDate.Should().Be(new DateTime(2014, 5, 19));
            }
        }

        public class UpdateMethod
        {
            public UpdateMethod()
            {
                Area.Reset();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenEdit_ShouldBeNull()
            {
                var area = new Area();
                
                var subject = area.Update(area);

                subject.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenEdit_AndWithNewArea_ShouldNotBeNull()
            {
                var NOW = new DateTime(2014, 5, 20);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var area = new Area(dateProvider.Object);

                var areaToModify = area.Add("Backlog");
                areaToModify.Name = "Not a Backlog";

                var subject = area.Update(areaToModify);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenEdit_AndWithNewArea_NameShouldBeUpdated()
            {
                var NOW = new DateTime(2014, 5, 21);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var area = new Area(dateProvider.Object);

                var areaToModify = area.Add("Backlog");
                areaToModify.Name = "Not a Backlog";

                var subject = area.Update(areaToModify);

                subject.Name.Should().Be("Not a Backlog");
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenEdit_AndWithNewArea_ModifiedDateShouldBeUpdated()
            {
                var NOW = new DateTime(2014, 5, 20);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var area = new Area(dateProvider.Object);

                var areaToModify = area.Add("Backlog");
                areaToModify.Name = "Not a Backlog";

                var subject = area.Update(areaToModify);

                subject.ModifiedDate.Should().Be(new DateTime(2014, 5, 20));
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenEdit_AndWithNewAreaAndUseGet_ModifiedDateShouldBeUpdated()
            {
                var NOW = new DateTime(2014, 5, 21);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var area = new Area(dateProvider.Object);

                var areaToModify = area.Add("Backlog");
                areaToModify.Name = "Not a Backlog";

                area.Update(areaToModify);

                var subject = area.Get(1);

                subject.ModifiedDate.Should().Be(NOW);
            }
        }
    }
}
