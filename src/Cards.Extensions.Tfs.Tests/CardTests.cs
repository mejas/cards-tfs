using System;
using System.Collections.Generic;
using Cards.Extensions.Tfs.Core.Interfaces;
using Cards.Extensions.Tfs.Core.Models;
using FluentAssertions;
using Moq;
using Xunit;

namespace Cards.Extensions.Tfs.Tests
{
    public class CardTests
    {
        public class Structure
        {
            [Fact]
            [Trait("Category", "Card")]
            public void WhenInitialize_ShouldNotBeNull()
            {
                Card subject = new Card();
                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenInitialize_ShouldIDBeZero()
            {
                Card subject = new Card();
                subject.ID.Should().Be(0);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenInitialize_ShouldActiveBeTrue()
            {
                Card subject = new Card();
                subject.Active.Should().Be(true);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenInitialize_ShouldCardNameBeNll()
            {
                Card subject = new Card();
                subject.Name.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenInitialize_ShouldCardDescriptionBeNull()
            {
                Card subject = new Card();
                subject.Description.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenInitialize_ShouldAreaIDBeZero()
            {
                Card subject = new Card();
                subject.AreaID.Should().Be(0);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenInitialize_ShouldCreatedDateBeMinValue()
            {
                Card subject = new Card();
                subject.CreatedDate.Should().Be(DateTime.MinValue);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenInitialize_ShouldModifiedDateBeMinValue()
            {
                Card subject = new Card();
                subject.ModifiedDate.Should().Be(DateTime.MinValue);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenInitialize_ShouldCreatedUserBeNull()
            {
                Card subject = new Card();
                subject.CreatedUser.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenInitialize_ShouldModifiedUserBeNull()
            {
                Card subject = new Card();
                subject.ModifiedUser.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenInitialize_ShouldAssignedToBeNull()
            {
                Card subject = new Card();
                subject.AssignedTo.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenInitialize_ShouldTfsIdBeZero()
            {
                Card subject = new Card();
                subject.TfsID.Should().Be(0);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenInitialize_ShouldActivitiesCountBeZero()
            {
                Card subject = new Card();
                subject.CardActivities.Count.Should().Be(0);
            }
        }

        public class AddMethod
        {
            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldNotBeNull()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c)
                    .Returns(() => subject);

                string name = "MyCard";
                string description = "MyDescription";
                int areaID = 1;

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Add(name, description, "MIKADO", areaID);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldNameBeMyCard()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c)
                    .Returns(() => subject);

                string name = "MyCard";
                string description = "MyDescription";
                int areaID = 1;

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Add(name, description, "MIKADO", areaID);

                subject.Name.Should().Be("MyCard");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldDescriptionBeMyDescription()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c)
                    .Returns(() => subject);

                string name = "MyCard";
                string description = "MyDescription";
                int areaID = 1;

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Add(name, description, "MIKADO", areaID);

                subject.Description.Should().Be("MyDescription");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldAreaIDBeOne()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c)
                    .Returns(() => subject);

                string name = "MyCard";
                string description = "MyDescription";
                int areaID = 1;

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Add(name, description, "MIKADO", areaID);

                subject.AreaID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldIDBeOne()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c)
                    .Returns(() => { subject.ID = 1; return subject; });

                string name        = "MyCard";
                string description = "MyDescription";
                int areaID         = 1;

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Add(name, description, "MIKADO", areaID);

                subject.ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldBeActive()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c)
                    .Returns(() => { subject.ID = 1; return subject; });

                string name = "MyCard";
                string description = "MyDescription";
                int areaID = 1;

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Add(name, description, "MIKADO", areaID);

                subject.Active.Should().Be(true);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldCreatedDateHaveValue()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c)
                    .Returns(() => { subject.ID = 1; return subject; });

                string name = "MyCard";
                string description = "MyDescription";
                int areaID = 1;

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Add(name, description, "MIKADO", areaID);

                subject.CreatedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldModifiedDateHaveValue()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c)
                    .Returns(() => { subject.ID = 1; return subject; });

                string name = "MyCard";
                string description = "MyDescription";
                int areaID = 1;

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Add(name, description, "MIKADO", areaID);

                subject.ModifiedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldCreatedUserHaveValue()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c)
                    .Returns(() => { subject.ID = 1; return subject; });

                string name = "MyCard";
                string description = "MyDescription";
                int areaID = 1;

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Add(name, description, "MIKADO", areaID);

                subject.CreatedUser.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldModifiedUserHaveValue()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c)
                    .Returns(() => { subject.ID = 1; return subject; });

                string name = "MyCard";
                string description = "MyDescription";
                int areaID = 1;

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Add(name, description, "MIKADO", areaID);

                subject.ModifiedUser.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldAssignedToHaveValue()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c)
                    .Returns(() => { subject.ID = 1; return subject; });

                string name = "MyCard";
                string description = "MyDescription";
                int areaID = 1;

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Add(name, description, "MIKADO", areaID);

                subject.AssignedTo.Should().Be("MIKADO");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldTFSIdBeZero()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c)
                    .Returns(() => subject);

                string name = "MyCard";
                string description = "MyDescription";
                int areaID = 1;

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Add(name, description, "MIKADO", areaID);

                subject.TfsID.Should().Be(0);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldLatestCardActivityBeAdd()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c)
                    .Returns(() => subject);
                
                CardActivity activity = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<CardActivity>()))
                    .Callback<CardActivity>(a => activity = a)
                    .Returns(() => activity);

                string name = "MyCard";
                string description = "MyDescription";
                int areaID = 1;

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Add(name, description, "MIKADO", areaID);
                subject.CardActivities[subject.CardActivities.Count - 1].ActivityType.Should().Be(CardActivityType.Add.ToString());
            }
        }

        public class AddBulkMethod
        {
            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldNotBeNull()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card returnCard = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => returnCard = c)
                    .Returns(() => returnCard);

                var tfsProvider = new Mock<ITFSProvider>();
                tfsProvider
                    .Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1234)))
                    .Returns(() => new WorkItem() { ID = 1234, Title = "MyCard", Description = "MyDescription", AssignedTo = "Dave Rodgers" });

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                WorkItem workItem = new WorkItem(tfsProvider.Object);

                List<Card> subject = card.Add(new List<WorkItem>() { workItem.Get(1234) }, 1);

                subject[0].Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldNameBeMyCard()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card returnCard = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => returnCard = c)
                    .Returns(() => returnCard);

                var tfsProvider = new Mock<ITFSProvider>();
                tfsProvider
                    .Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1234)))
                    .Returns(() => new WorkItem() { ID = 1234, Title = "MyCard", Description = "MyDescription", AssignedTo = "Dave Rodgers" });

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                WorkItem workItem = new WorkItem(tfsProvider.Object);

                List<Card> subject = card.Add(new List<WorkItem>() { workItem.Get(1234) }, 1);

                subject[0].Name.Should().Be("MyCard");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldDescriptionBeMyDescription()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card returnCard = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => returnCard = c)
                    .Returns(() => returnCard);

                var tfsProvider = new Mock<ITFSProvider>();
                tfsProvider
                    .Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1234)))
                    .Returns(() => new WorkItem() { ID = 1234, Title = "MyCard", Description = "MyDescription", AssignedTo = "Dave Rodgers" });

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                WorkItem workItem = new WorkItem(tfsProvider.Object);

                List<Card> subject = card.Add(new List<WorkItem>() { workItem.Get(1234) }, 1);

                subject[0].Description.Should().Be("MyDescription");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldAreaIDBeOne()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card returnCard = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => returnCard = c)
                    .Returns(() => returnCard);

                var tfsProvider = new Mock<ITFSProvider>();
                tfsProvider
                    .Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1234)))
                    .Returns(() => new WorkItem() { ID = 1234, Title = "MyCard", Description = "MyDescription", AssignedTo = "Dave Rodgers" });

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                WorkItem workItem = new WorkItem(tfsProvider.Object);

                List<Card> subject = card.Add(new List<WorkItem>() { workItem.Get(1234) }, 1);

                subject[0].AreaID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldIDBeOne()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card returnCard = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => returnCard = c)
                    .Returns(() => { returnCard.ID = 1; return returnCard; });

                var tfsProvider = new Mock<ITFSProvider>();
                tfsProvider
                    .Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1234)))
                    .Returns(() => new WorkItem() { ID = 1234, Title = "MyCard", Description = "MyDescription", AssignedTo = "Dave Rodgers" });

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                WorkItem workItem = new WorkItem(tfsProvider.Object);

                List<Card> subject = card.Add(new List<WorkItem>() { workItem.Get(1234) }, 1);

                subject[0].ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldBeActive()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card returnCard = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => returnCard = c)
                    .Returns(() => returnCard);

                var tfsProvider = new Mock<ITFSProvider>();
                tfsProvider
                    .Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1234)))
                    .Returns(() => new WorkItem() { ID = 1234, Title = "MyCard", Description = "MyDescription", AssignedTo = "Dave Rodgers" });

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                WorkItem workItem = new WorkItem(tfsProvider.Object);

                List<Card> subject = card.Add(new List<WorkItem>() { workItem.Get(1234) }, 1);

                subject[0].Active.Should().Be(true);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldCreatedDateHaveValue()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card returnCard = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => returnCard = c)
                    .Returns(() => returnCard);

                var tfsProvider = new Mock<ITFSProvider>();
                tfsProvider
                    .Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1234)))
                    .Returns(() => new WorkItem() { ID = 1234, Title = "MyCard", Description = "MyDescription", AssignedTo = "Dave Rodgers" });

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                WorkItem workItem = new WorkItem(tfsProvider.Object);

                List<Card> subject = card.Add(new List<WorkItem>() { workItem.Get(1234) }, 1);

                subject[0].CreatedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldModifiedDateHaveValue()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card returnCard = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => returnCard = c)
                    .Returns(() => returnCard);

                var tfsProvider = new Mock<ITFSProvider>();
                tfsProvider
                    .Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1234)))
                    .Returns(() => new WorkItem() { ID = 1234, Title = "MyCard", Description = "MyDescription", AssignedTo = "Dave Rodgers" });

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                WorkItem workItem = new WorkItem(tfsProvider.Object);

                List<Card> subject = card.Add(new List<WorkItem>() { workItem.Get(1234) }, 1);

                subject[0].ModifiedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldCreatedUserHaveValue()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card returnCard = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => returnCard = c)
                    .Returns(() => returnCard);

                var tfsProvider = new Mock<ITFSProvider>();
                tfsProvider
                    .Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1234)))
                    .Returns(() => new WorkItem() { ID = 1234, Title = "MyCard", Description = "MyDescription", AssignedTo = "Dave Rodgers" });

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                WorkItem workItem = new WorkItem(tfsProvider.Object);

                List<Card> subject = card.Add(new List<WorkItem>() { workItem.Get(1234) }, 1);

                subject[0].CreatedUser.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldModifiedUserHaveValue()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card returnCard = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => returnCard = c)
                    .Returns(() => returnCard);

                var tfsProvider = new Mock<ITFSProvider>();
                tfsProvider
                    .Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1234)))
                    .Returns(() => new WorkItem() { ID = 1234, Title = "MyCard", Description = "MyDescription", AssignedTo = "Dave Rodgers" });

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                WorkItem workItem = new WorkItem(tfsProvider.Object);

                List<Card> subject = card.Add(new List<WorkItem>() { workItem.Get(1234) }, 1);

                subject[0].ModifiedUser.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldAssignedToHaveValue()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card returnCard = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => returnCard = c)
                    .Returns(() => returnCard);

                var tfsProvider = new Mock<ITFSProvider>();
                tfsProvider
                    .Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1234)))
                    .Returns(() => new WorkItem() { ID = 1234, Title = "MyCard", Description = "MyDescription", AssignedTo = "Dave Rodgers" });

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                WorkItem workItem = new WorkItem(tfsProvider.Object);

                List<Card> subject = card.Add(new List<WorkItem>() { workItem.Get(1234) }, 1);

                subject[0].AssignedTo.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldTFSIdBe1234()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card returnCard = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => returnCard = c)
                    .Returns(() => returnCard);

                var tfsProvider = new Mock<ITFSProvider>();
                tfsProvider
                    .Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1234)))
                    .Returns(() => new WorkItem() { ID = 1234, Title = "MyCard", Description = "MyDescription", AssignedTo = "Dave Rodgers" });

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                WorkItem workItem = new WorkItem(tfsProvider.Object);

                List<Card> subject = card.Add(new List<WorkItem>() { workItem.Get(1234) }, 1);

                subject[0].TfsID.Should().Be(1234);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenAdd_ShouldAllItemsLatestActivitiesBeAdd()
            {
                var NOW = new DateTime(2014, 5, 22);
                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                Card returnCard = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => returnCard = c)
                    .Returns(() => returnCard);

                CardActivity activity = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<CardActivity>()))
                    .Callback<CardActivity>(a => activity = a)
                    .Returns(() => activity);

                var tfsProvider = new Mock<ITFSProvider>();
                tfsProvider
                    .Setup(d => d.GetTFSItem(It.Is<int>(i => i == 1234)))
                    .Returns(() => new WorkItem() { ID = 1234, Title = "MyCard", Description = "MyDescription", AssignedTo = "Dave Rodgers" });

                Card card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                WorkItem workItem = new WorkItem(tfsProvider.Object);

                List<Card> subject = card.Add(new List<WorkItem>() { workItem.Get(1234) }, 1);

                subject.Should().OnlyContain(item => item.CardActivities[item.CardActivities.Count - 1].ActivityType == CardActivityType.Add.ToString());
            }
        }

        public class GetAllMethod
        {
            [Fact]
            [Trait("Category", "Card")]
            public void WhenGetAll_ShouldNotBeNull()
            {
                var storageProvider = new Mock<IStorageProvider>();

                storageProvider
                    .Setup(d => d.GetAllCards(It.IsAny<int>()))
                    .Returns(() => new List<Card>());

                var area = 1;
                var card = new Card(null, storageProvider.Object, null);

                var subject = card.GetAll(area);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenGetAll_ShouldBeEmpty()
            {
                var storageProvider = new Mock<IStorageProvider>();

                storageProvider
                    .Setup(d => d.GetAllCards(It.IsAny<int>()))
                    .Returns(() => new List<Card>());

                var area = 1;
                var card = new Card(null, storageProvider.Object, null);

                var subject = card.GetAll(area);

                subject.Should().BeEmpty();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenGetAll_AndWithNewCard_ShouldHaveOneElement()
            {
                var storageProvider = new Mock<IStorageProvider>();

                storageProvider
                    .Setup(d => d.GetAllCards(It.IsAny<int>()))
                    .Returns(() => {

                        var list = new List<Card>();

                        list.Add(new Card());

                        return list;

                    });

                var area = 1;
                var card = new Card(null, storageProvider.Object, null);

                var subject = card.GetAll(area);

                subject.Count.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenGetAll_AndWithNewCard_ShouldElementsBeActiveOnly()
            {
                var storageProvider = new Mock<IStorageProvider>();

                storageProvider
                    .Setup(d => d.GetAllCards(It.IsAny<int>()))
                    .Returns(() =>
                    {

                        var list = new List<Card>();

                        list.Add(new Card());
                        list.Add(new Card());

                        return list;

                    });

                var area = 1;
                var card = new Card(null, storageProvider.Object, null);

                var subject = card.GetAll(area);

                subject.Should().OnlyContain(item => item.Active == true);
            }
        }

        public class GetMethod
        {
            [Fact]
            [Trait("Category", "Card")]
            public void WhenGet_ShouldBeNull()
            {
                var storageProvider = new Mock<IStorageProvider>();

                storageProvider
                    .Setup(d => d.GetCard(It.IsAny<int>()))
                    .Returns(() => null);

                var card = new Card(null, storageProvider.Object, null);

                var subject = card.Get(1);

                subject.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenGet_ShouldBeNotBeNull()
            {
                var NOW = new DateTime(2014, 5, 22);
                var USERNAME = "Dave Rodgers";

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID           = 1,
                            AreaID       = 1,
                            Name         = "MyCard",
                            Description  = "MyDescription",
                            CreatedDate  = NOW,
                            ModifiedDate = NOW,
                            CreatedUser  = USERNAME,
                            ModifiedUser = USERNAME,
                        }
                    );

                Card card = new Card(null, storageProvider.Object, null);

                var subject = card.Get(1);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenGet_ShouldNameBeMyCard()
            {
                var NOW = new DateTime(2014, 5, 22);
                var USERNAME = "Dave Rodgers";

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            AreaID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = NOW,
                            ModifiedDate = NOW,
                            CreatedUser = USERNAME,
                            ModifiedUser = USERNAME,
                        }
                    );

                Card card = new Card(null, storageProvider.Object, null);

                var subject = card.Get(1);

                subject.Name.Should().Be("MyCard");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenGet_ShouldDescriptionBeMyDescription()
            {
                var NOW = new DateTime(2014, 5, 22);
                var USERNAME = "Dave Rodgers";

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            AreaID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = NOW,
                            ModifiedDate = NOW,
                            CreatedUser = USERNAME,
                            ModifiedUser = USERNAME,
                        }
                    );

                Card card = new Card(null, storageProvider.Object, null);

                var subject = card.Get(1);

                subject.Description.Should().Be("MyDescription");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenGet_ShouldAreaIDBeOne()
            {
                var NOW = new DateTime(2014, 5, 22);
                var USERNAME = "Dave Rodgers";

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            AreaID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = NOW,
                            ModifiedDate = NOW,
                            CreatedUser = USERNAME,
                            ModifiedUser = USERNAME,
                        }
                    );

                Card card = new Card(null, storageProvider.Object, null);

                var subject = card.Get(1);

                subject.AreaID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenGet_ShouldIDBeOne()
            {
                var NOW = new DateTime(2014, 5, 22);
                var USERNAME = "Dave Rodgers";

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            AreaID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = NOW,
                            ModifiedDate = NOW,
                            CreatedUser = USERNAME,
                            ModifiedUser = USERNAME,
                        }
                    );

                Card card = new Card(null, storageProvider.Object, null);

                var subject = card.Get(1);

                subject.ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenGet_ShouldBeActive()
            {
                var NOW = new DateTime(2014, 5, 22);
                var USERNAME = "Dave Rodgers";

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            AreaID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = NOW,
                            ModifiedDate = NOW,
                            CreatedUser = USERNAME,
                            ModifiedUser = USERNAME,
                        }
                    );

                Card card = new Card(null, storageProvider.Object, null);

                var subject = card.Get(1);

                subject.Active.Should().Be(true);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenGet_ShouldCreatedDateHaveValue()
            {
                var NOW = new DateTime(2014, 5, 22);
                var USERNAME = "Dave Rodgers";

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            AreaID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = NOW,
                            ModifiedDate = NOW,
                            CreatedUser = USERNAME,
                            ModifiedUser = USERNAME,
                        }
                    );

                Card card = new Card(null, storageProvider.Object, null);

                var subject = card.Get(1);

                subject.CreatedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenGet_ShouldModifiedDateHaveValue()
            {
                var NOW = new DateTime(2014, 5, 22);
                var USERNAME = "Dave Rodgers";

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            AreaID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = NOW,
                            ModifiedDate = NOW,
                            CreatedUser = USERNAME,
                            ModifiedUser = USERNAME,
                        }
                    );

                Card card = new Card(null, storageProvider.Object, null);

                var subject = card.Get(1);

                subject.ModifiedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenGet_ShouldCreatedUserHaveValue()
            {
                var NOW = new DateTime(2014, 5, 22);
                var USERNAME = "Dave Rodgers";

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            AreaID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = NOW,
                            ModifiedDate = NOW,
                            CreatedUser = USERNAME,
                            ModifiedUser = USERNAME,
                        }
                    );

                Card card = new Card(null, storageProvider.Object, null);

                var subject = card.Get(1);

                subject.CreatedUser.Should().Be(USERNAME);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenGet_ShouldModifiedUserHaveValue()
            {
                var NOW = new DateTime(2014, 5, 22);
                var USERNAME = "Dave Rodgers";

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            AreaID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = NOW,
                            ModifiedDate = NOW,
                            CreatedUser = USERNAME,
                            ModifiedUser = USERNAME,
                        }
                    );

                Card card = new Card(null, storageProvider.Object, null);

                var subject = card.Get(1);

                subject.ModifiedUser.Should().Be(USERNAME);
            }
        }

        public class UpdateMethod
        {
            [Fact]
            [Trait("Category", "Card")]
            public void WhenEdit_ShouldBeNull()
            {
                Card subject = null;

                var storageProvider = new Mock<IStorageProvider>();

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c)
                    .Returns(() => subject);

                var card = new Card(null, storageProvider.Object, null);

                subject = card.Update(null);

                subject.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenEdit_ShouldBeNotBeNull()
            {
                Card subject = null;

                var createdDate = new DateTime(2014, 5, 21);
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = createdDate,
                            ModifiedDate = NOW,
                            CreatedUser = "Dave Rodgers",
                            ModifiedUser = "Dave Rodgers",
                            Active = true,
                            AreaID = 1
                        });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c.ID == 1 ? c : null)
                    .Returns(() => subject);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Get(1);

                subject.Name = "NotMyCard";
                subject.Description = "NotMyDescription";
                subject.AreaID = 2;

                subject = card.Update(subject);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenEdit_ShouldNameBeUpdated()
            {
                Card subject = null;

                var createdDate = new DateTime(2014, 5, 21);
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = createdDate,
                            ModifiedDate = NOW,
                            CreatedUser = "Dave Rodgers",
                            ModifiedUser = "Dave Rodgers",
                            Active = true,
                            AreaID = 1
                        });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c.ID == 1 ? c : null)
                    .Returns(() => subject);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Get(1);

                subject.Name = "NotMyCard";
                subject.Description = "NotMyDescription";
                subject.AreaID = 2;

                subject = card.Update(subject);

                subject.Name.Should().Be("NotMyCard");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenEdit_ShouldDescriptionBeUpdated()
            {
                Card subject = null;

                var createdDate = new DateTime(2014, 5, 21);
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = createdDate,
                            ModifiedDate = NOW,
                            CreatedUser = "Dave Rodgers",
                            ModifiedUser = "Dave Rodgers",
                            Active = true,
                            AreaID = 1
                        });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c.ID == 1 ? c : null)
                    .Returns(() => subject);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Get(1);

                subject.Name = "NotMyCard";
                subject.Description = "NotMyDescription";
                subject.AreaID = 2;

                subject = card.Update(subject);

                subject.Description.Should().Be("NotMyDescription");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenEdit_ShouldAreaIDBeUpdated()
            {
                Card subject = null;

                var createdDate = new DateTime(2014, 5, 21);
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = createdDate,
                            ModifiedDate = NOW,
                            CreatedUser = "Dave Rodgers",
                            ModifiedUser = "Dave Rodgers",
                            Active = true,
                            AreaID = 1
                        });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c.ID == 1 ? c : null)
                    .Returns(() => subject);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Get(1);

                subject.Name = "NotMyCard";
                subject.Description = "NotMyDescription";
                subject.AreaID = 2;

                subject = card.Update(subject);

                subject.ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenEdit_ShouldIDNotBeUpdated()
            {
                Card subject = null;

                var createdDate = new DateTime(2014, 5, 21);
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = createdDate,
                            ModifiedDate = NOW,
                            CreatedUser = "Dave Rodgers",
                            ModifiedUser = "Dave Rodgers",
                            Active = true,
                            AreaID = 1
                        });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c.ID == 1 ? c : null)
                    .Returns(() => subject);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Get(1);

                subject.Name = "NotMyCard";
                subject.Description = "NotMyDescription";
                subject.AreaID = 2;

                subject = card.Update(subject);

                subject.ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenEdit_ShouldModifiedDateBeUpdated()
            {
                Card subject = null;

                var createdDate = new DateTime(2014, 5, 21);
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = createdDate,
                            ModifiedDate = NOW,
                            CreatedUser = "Dave Rodgers",
                            ModifiedUser = "Dave Rodgers",
                            Active = true,
                            AreaID = 1
                        });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c.ID == 1 ? c : null)
                    .Returns(() => subject);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Get(1);

                subject.Name = "NotMyCard";
                subject.Description = "NotMyDescription";
                subject.AreaID = 2;

                subject = card.Update(subject);

                subject.ModifiedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenEdit_ShouldModifiedUserBeUpdated()
            {
                Card subject = null;

                var createdDate = new DateTime(2014, 5, 21);
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = createdDate,
                            ModifiedDate = NOW,
                            CreatedUser = "Dave Rodgers",
                            ModifiedUser = "Dave Rodgers",
                            Active = true,
                            AreaID = 1
                        });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c.ID == 1 ? c : null)
                    .Returns(() => subject);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Get(1);

                subject.Name = "NotMyCard";
                subject.Description = "NotMyDescription";
                subject.AreaID = 2;

                subject = card.Update(subject);

                subject.ModifiedUser.Should().Be("MIKADO");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenEdit_ShouldCreatedDateBeUpdated()
            {
                Card subject = null;

                var createdDate = new DateTime(2014, 5, 21);
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = createdDate,
                            ModifiedDate = NOW,
                            CreatedUser = "Dave Rodgers",
                            ModifiedUser = "Dave Rodgers",
                            Active = true,
                            AreaID = 1
                        });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c.ID == 1 ? c : null)
                    .Returns(() => subject);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Get(1);

                subject.Name = "NotMyCard";
                subject.Description = "NotMyDescription";
                subject.AreaID = 2;

                subject = card.Update(subject);

                subject.CreatedDate.Should().Be(createdDate);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenEdit_ShouldCreatedUserBeUpdated()
            {
                Card subject = null;

                var createdDate = new DateTime(2014, 5, 21);
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = createdDate,
                            ModifiedDate = NOW,
                            CreatedUser = "Dave Rodgers",
                            ModifiedUser = "Dave Rodgers",
                            Active = true,
                            AreaID = 1
                        });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c.ID == 1 ? c : null)
                    .Returns(() => subject);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Get(1);

                subject.Name = "NotMyCard";
                subject.Description = "NotMyDescription";
                subject.AreaID = 2;

                subject = card.Update(subject);

                subject.CreatedUser.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenEdit_ShouldActiveBitBeUpdated()
            {
                Card subject = null;

                var createdDate = new DateTime(2014, 5, 21);
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = createdDate,
                            ModifiedDate = NOW,
                            CreatedUser = "Dave Rodgers",
                            ModifiedUser = "Dave Rodgers",
                            Active = true,
                            AreaID = 1
                        });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c.ID == 1 ? c : null)
                    .Returns(() => subject);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Get(1);

                subject.Name = "NotMyCard";
                subject.Description = "NotMyDescription";
                subject.AreaID = 2;

                subject = card.Update(subject);

                subject.Active.Should().Be(true);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenEdit_ShouldAssignedToBeUpdated()
            {
                Card subject = null;

                var createdDate = new DateTime(2014, 5, 21);
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = createdDate,
                            ModifiedDate = NOW,
                            CreatedUser = "Dave Rodgers",
                            ModifiedUser = "Dave Rodgers",
                            Active = true,
                            AreaID = 1
                        });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c.ID == 1 ? c : null)
                    .Returns(() => subject);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Get(1);

                subject.Name = "NotMyCard";
                subject.Description = "NotMyDescription";
                subject.AreaID = 2;
                subject.AssignedTo = "Me";

                subject = card.Update(subject);

                subject.AssignedTo.Should().Be("Me");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenEdit_ShouldLatestCardActivityBeModified()
            {
                Card subject = null;

                var createdDate = new DateTime(2014, 5, 21);
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCard(It.Is<int>(i => i == 1)))
                    .Returns(() =>
                        new Card()
                        {
                            ID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = createdDate,
                            ModifiedDate = NOW,
                            CreatedUser = "Dave Rodgers",
                            ModifiedUser = "Dave Rodgers",
                            Active = true,
                            AreaID = 1
                        });

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Card>()))
                    .Callback<Card>(c => subject = c.ID == 1 ? c : null)
                    .Returns(() => subject);

                CardActivity activity = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<CardActivity>()))
                    .Callback<CardActivity>(a => activity = a)
                    .Returns(() => activity);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                subject = card.Get(1);

                subject.Name = "NotMyCard";
                subject.Description = "NotMyDescription";
                subject.AreaID = 2;
                subject.AssignedTo = "Me";

                subject = card.Update(subject);

                subject.AssignedTo.Should().Be("Me");
            }
        }

        public class RemoveMethod
        {
            [Fact]
            [Trait("Category", "Card")]
            public void WhenDelete_ShouldDataBeRemoved()
            {
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();

                storageProvider.Setup(d => d.RemoveCard(It.IsAny<Card>()));
                storageProvider.Setup(d => d.GetCard(It.Is<int>(i => i == 1))).Returns(() => null);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);

                card.Remove(1);

                var subject = card.Get(1);

                subject.Should().BeNull();
            }
        }

        public class MoveMethod
        {
            [Fact]
            [Trait("Category", "Card")]
            public void WhenMove_IDIsValid()
            {
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();

                storageProvider.Setup(d => d.GetAllAreas()).Returns(() => new List<Area>() {
                
                    new Area(){ID=1,Name="FirstArea"},
                    new Area(){ID=2,Name="SecondArea"}

                });
                
                Card subject = null;

                storageProvider.Setup(d => d.Update(It.IsAny<Card>())).Callback<Card>(a => subject = a).Returns(() => subject);

                CardActivity activity = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<CardActivity>()))
                    .Callback<CardActivity>(a => activity = a)
                    .Returns(() => activity);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object) { ID = 1, AreaID = 1, Name = "MyCard", CardActivities = new List<CardActivity>() };
                var area = new Area(null, storageProvider.Object, identityProvider.Object);

                storageProvider.Setup(d => d.GetCard(It.Is<int>(i => i == 1))).Returns(() => card);

                var targetArea = area.GetAll().Find(item => item.ID == 2);

                subject = card.Move(1, targetArea);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenMove_AreaIDShouldBeUpdated()
            {
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();

                storageProvider.Setup(d => d.GetAllAreas()).Returns(() => new List<Area>() {
                
                    new Area(){ID=1,Name="FirstArea"},
                    new Area(){ID=2,Name="SecondArea"}

                });

                Card subject = null;

                storageProvider.Setup(d => d.Update(It.IsAny<Card>())).Callback<Card>(a => subject = a).Returns(() => subject);

                CardActivity activity = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<CardActivity>()))
                    .Callback<CardActivity>(a => activity = a)
                    .Returns(() => activity);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object) { ID = 1, AreaID = 1, Name = "MyCard", CardActivities = new List<CardActivity>() };
                var area = new Area(null, storageProvider.Object, identityProvider.Object);

                storageProvider.Setup(d => d.GetCard(It.Is<int>(i => i == 1))).Returns(() => card);

                var targetArea = area.GetAll().Find(item => item.ID == 2);

                subject = card.Move(1, targetArea);

                subject.AreaID.Should().Be(2);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenMove_ModifiedDateShouldBeUpdated()
            {
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();

                storageProvider.Setup(d => d.GetAllAreas()).Returns(() => new List<Area>() {
                
                    new Area(){ID=1,Name="FirstArea"},
                    new Area(){ID=2,Name="SecondArea"}

                });

                CardActivity activity = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<CardActivity>()))
                    .Callback<CardActivity>(a => activity = a)
                    .Returns(() => activity);

                Card subject = null;

                storageProvider.Setup(d => d.Update(It.IsAny<Card>())).Callback<Card>(a => subject = a).Returns(() => subject);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object) { ID = 1, AreaID = 1, Name = "MyCard", CardActivities = new List<CardActivity>() };
                var area = new Area(null, storageProvider.Object, identityProvider.Object);

                storageProvider.Setup(d => d.GetCard(It.Is<int>(i => i == 1))).Returns(() => card);

                var targetArea = area.GetAll().Find(item => item.ID == 2);

                subject = card.Move(1, targetArea);

                subject.ModifiedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenMove_ModifiedUserShouldBeUpdated()
            {
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();

                storageProvider.Setup(d => d.GetAllAreas()).Returns(() => new List<Area>() {
                
                    new Area(){ID=1,Name="FirstArea"},
                    new Area(){ID=2,Name="SecondArea"}

                });

                Card subject = null;

                storageProvider.Setup(d => d.Update(It.IsAny<Card>())).Callback<Card>(a => subject = a).Returns(() => subject);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object) { ID = 1, AreaID = 1, Name = "MyCard", CardActivities = new List<CardActivity>() };
                var area = new Area(null, storageProvider.Object, identityProvider.Object);

                storageProvider.Setup(d => d.GetCard(It.Is<int>(i => i == 1))).Returns(() => card);

                var targetArea = area.GetAll().Find(item => item.ID == 2);

                subject = card.Move(1, targetArea);

                subject.ModifiedUser.Should().Be("MIKADO");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenMove_IDIsInvalid()
            {
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();

                storageProvider.Setup(d => d.GetAllAreas()).Returns(() => new List<Area>() {
                
                    new Area(){ID=1,Name="FirstArea"},
                    new Area(){ID=2,Name="SecondArea"}

                });

                storageProvider.Setup(d => d.GetCard(It.Is<int>(i => i == 1))).Returns(() => new Card() { ID = 1, AreaID = 1, Name = "MyCard" });

                Card subject = null;

                storageProvider.Setup(d => d.Update(It.IsAny<Card>())).Callback<Card>(a => subject = a).Returns(() => subject);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                var area = new Area(null, storageProvider.Object, null);

                subject = card.Move(2, area.GetAll().Find(item => item.ID == 2));

                subject.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenMove_LatestActivityShouldBeMove()
            {
                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();

                storageProvider.Setup(d => d.GetAllAreas()).Returns(() => new List<Area>() {
                
                    new Area(){ID=1,Name="FirstArea"},
                    new Area(){ID=2,Name="SecondArea"}

                });

                storageProvider.Setup(d => d.GetCard(It.Is<int>(i => i == 1))).Returns(() => new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object) { ID = 1, AreaID = 1, Name = "MyCard", CardActivities = new List<CardActivity>() });

                Card subject = null;

                storageProvider.Setup(d => d.Update(It.IsAny<Card>())).Callback<Card>(a => subject = a).Returns(() => subject);

                CardActivity activity = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<CardActivity>()))
                    .Callback<CardActivity>(a => activity = a)
                    .Returns(() => activity);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object);
                var area = new Area(null, storageProvider.Object, null);

                subject = card.Move(1, area.GetAll().Find(item => item.ID == 2));

                subject.CardActivities[subject.CardActivities.Count - 1].ActivityType.Should().Be(CardActivityType.Move.ToString());
            }
        }
    }
}
