using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

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
                var area= new Area();
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
                var area = new Area();
                var areaName = "Backlog";

                var subject = area.Add(areaName);

                subject.Name.Should().Be("Backlog");
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenNameIsNotNull_IDShouldBeOne()
            {
                var area = new Area();
                var areaName = "Backlog";

                var subject = area.Add(areaName);

                subject.ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenNameIsNotNull_CreatedDateShouldHaveValue()
            {
                var area = new Area();
                
                var areaName = "Backlog";

                var subject = area.Add(areaName);

                subject.CreatedDate.Should().Be(new DateTime(2014, 5, 19));
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenNameIsNotNull_ModifiedDateShouldHaveValue()
            {
                var area = new Area();
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
                var area = new Area();

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
                var area = new Area();

                area.Add("Backlog");

                var subject = area.Get(1);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_AndWithNewArea_IDShouldBeOne()
            {
                var area = new Area();

                area.Add("Backlog");

                var subject = area.Get(1);

                subject.ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_AndWithNewArea_NameShouldBeBacklog()
            {
                var area = new Area();

                area.Add("Backlog");

                var subject = area.Get(1);

                subject.Name.Should().Be("Backlog");
            }

            [Fact]
            [Trait("Category", "Area")]
            public void WhenGet_AndWithNewArea_CreatedDateShouldHaveValue()
            {
                var area = new Area();

                area.Add("Backlog");

                var subject = area.Get(1);

                subject.CreatedDate.Should().Be(new DateTime(2014, 5, 19));
            }
        }
    }
}
