using System.Collections.Generic;
using Cards.Extensions.Tfs.Core.Interfaces;
using Cards.Extensions.Tfs.Core.Models;
using FluentAssertions;
using Moq;
using Xunit;

namespace Cards.Extensions.Tfs.Tests
{
    public class WorkItemTests
    {
        public class Structure
        {
            [Fact]
            [Trait("Category", "WorkItem")]
            public void WhenInitialize_ShouldNotBeNull()
            {
                WorkItem workItem = new WorkItem();
                workItem.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "WorkItem")]
            public void WhenInitialize_ShouldIDBeZero()
            {
                WorkItem workItem = new WorkItem();
                workItem.ID.Should().Be(0);
            }

            [Fact]
            [Trait("Category", "WorkItem")]
            public void WhenInitialize_ShouldTitleBeNull()
            {
                WorkItem workItem = new WorkItem();
                workItem.Title.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "WorkItem")]
            public void WhenInitialize_ShouldDescriptionBeNull()
            {
                WorkItem workItem = new WorkItem();
                workItem.Description.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "WorkItem")]
            public void WhenInitialize_ShouldAssignedToBeNull()
            {
                WorkItem workItem = new WorkItem();
                workItem.AssignedTo.Should().BeNull();
            }
        }

        public class GetByIdMethod
        {
            [Fact]
            [Trait("Category", "WorkItem")]
            public void WhenGet_ShouldBeNull()
            {
                var tfsProvider = new Mock<ITFSProvider>();

                tfsProvider.Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1))).Returns(new WorkItem() { ID = 1, Title = "TFS Work Item", Description = "TFS Work Item Description", AssignedTo = "Somebody" });

                WorkItem workItem = new WorkItem(tfsProvider.Object);

                var subject = workItem.Get(0);

                subject.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "WorkItem")]
            public void WhenGet_ShouldNotBeNull()
            {
                var tfsProvider = new Mock<ITFSProvider>();

                tfsProvider.Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1))).Returns(new WorkItem() { ID = 1, Title = "TFS Work Item", Description = "TFS Work Item Description", AssignedTo = "Somebody" });

                WorkItem workItem = new WorkItem(tfsProvider.Object);

                var subject = workItem.Get(1);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "WorkItem")]
            public void WhenGet_ShoudIDBeOne()
            {
                var tfsProvider = new Mock<ITFSProvider>();

                tfsProvider.Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1))).Returns(new WorkItem() { ID = 1, Title = "TFS Work Item", Description = "TFS Work Item Description", AssignedTo = "Somebody" });

                WorkItem workItem = new WorkItem(tfsProvider.Object);

                var subject = workItem.Get(1);

                subject.ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "WorkItem")]
            public void WhenGet_ShoudHaveTitle()
            {
                var tfsProvider = new Mock<ITFSProvider>();

                tfsProvider.Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1))).Returns(new WorkItem() { ID = 1, Title = "TFS Work Item", Description = "TFS Work Item Description", AssignedTo = "Somebody" });

                WorkItem workItem = new WorkItem(tfsProvider.Object);

                var subject = workItem.Get(1);

                subject.Title.Should().NotBeNullOrEmpty();
            }
        }

        public class GetBySavedQueryMethod
        {
            [Fact]
            [Trait("Category", "WorkItem")]
            public void WhenGet_ShouldNotBeNull()
            {
                var tfsProvider = new Mock<ITFSProvider>();

                tfsProvider.
                    Setup(d => d.GetTFSItems(It.IsAny<string>()))
                    .Returns(() => { return new List<WorkItem>() { new WorkItem() { ID = 1, Title = "TFS Work Item", Description = "TFS Work Item Description", AssignedTo = "Somebody" } }; });

                WorkItem workItem = new WorkItem(tfsProvider.Object);

                var subject = workItem.Get("query");

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "WorkItem")]
            public void WhenGet_ShouldCountBeOne()
            {
                var tfsProvider = new Mock<ITFSProvider>();

                tfsProvider.
                    Setup(d => d.GetTFSItems(It.IsAny<string>()))
                    .Returns(() => { return new List<WorkItem>() { new WorkItem() { ID = 1, Title = "TFS Work Item", Description = "TFS Work Item Description", AssignedTo = "Somebody" } }; });

                WorkItem workItem = new WorkItem(tfsProvider.Object);

                var subject = workItem.Get("query");

                subject.Count.Should().Be(1);
            }
        }
    }
}
