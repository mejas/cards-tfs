using System;
using System.Collections.Generic;
using Cards.Extensions.Tfs.Core.Interfaces;
using Cards.Extensions.Tfs.Core.Models;
using Cards.Extensions.Tfs.Core.Services;
using FluentAssertions;
using Moq;
using Xunit;
using System.Linq;

namespace Cards.Extensions.Tfs.Tests
{
    public class CardTests
    {
        public class AddMethod : BaseTest<Card>
        {
            DateTime NOW = new DateTime(2014, 5, 22);
            
            protected override Dictionary<Type, Mock> OnInitializeServices()
            {
                Dictionary<Type, Mock> services = new Dictionary<Type, Mock>();

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                services.Add(typeof(IDateProvider), dateProvider);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                services.Add(typeof(IIdentityProvider), identityProvider);

                var storageProvider = new Mock<IStorageProvider>();

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback<Card>(c => Subject = c)
                    .Returns(() => Subject);

                CardActivity activity = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<CardActivity>()))
                    .Callback<CardActivity>(a => activity = a)
                    .Returns(() => activity);

                services.Add(typeof(IStorageProvider), storageProvider);

                return services;
            }

            protected override void Setup()
            {
                string name = "MyCard";
                string description = "MyDescription";
                int areaID = 1;

                Card card = new Card(GetService<IDateProvider>(), GetService<IStorageProvider>(), GetService<IIdentityProvider>(), null);

                Subject = card.Add(name, description, "MIKADO", areaID);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestForNullValue()
            {
                Setup();
                Subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCardName()
            {
                Setup();
                Subject.Name.Should().Be("MyCard");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCardDescription()
            {
                Setup();
                Subject.Description.Should().Be("MyDescription");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestAreaID()
            {
                Setup();
                Subject.AreaID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCardID()
            {
                Setup();
                Subject.ID.Should().Be(0);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestActiveState()
            {
                Setup();
                Subject.Active.Should().Be(true);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCreatedDate()
            {
                Setup();
                Subject.CreatedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestModifiedDate()
            {
                Setup();
                Subject.ModifiedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCreatedUser()
            {
                Setup();
                Subject.CreatedUser.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestModifiedUser()
            {
                Setup();
                Subject.ModifiedUser.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestAssignedTo()
            {
                Setup();
                Subject.AssignedTo.Should().Be("MIKADO");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestTFSID()
            {
                Setup();
                Subject.TfsID.Should().Be(0);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestLatestCardActivity()
            {
                Setup();
                Subject.CardActivities[Subject.CardActivities.Count - 1].ActivityType.Should().Be(CardActivityType.Add.ToString());
            }
        }

        public class AddBulkMethod : BaseTest<List<Card>>
        {
            DateTime NOW = new DateTime(2014, 5, 22);

            protected override Dictionary<Type, Mock> OnInitializeServices()
            {
                Dictionary<Type, Mock> services = new Dictionary<Type, Mock>();

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

                services.Add(typeof(IDateProvider), dateProvider);
                services.Add(typeof(IIdentityProvider), identityProvider);
                services.Add(typeof(IStorageProvider), storageProvider);
                services.Add(typeof(ITFSProvider), tfsProvider);

                return services;
            }

            protected override void Setup()
            {
                Card card = new Card(GetService<IDateProvider>(), GetService<IStorageProvider>(), GetService<IIdentityProvider>(), null);
                WorkItem workItem = new WorkItem(GetService<ITFSProvider>());

                Subject = card.Add(new List<WorkItem>() { workItem.Get(1234) }, 1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestForNulLValue()
            {
                Setup();
                Subject[0].Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCardName()
            {
                Setup();
                Subject[0].Name.Should().Be("MyCard");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCardDescription()
            {
                Setup();
                Subject[0].Description.Should().Be("MyDescription");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestAreaID()
            {
                Setup();
                Subject[0].AreaID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCardID()
            {
                Setup();
                Subject[0].ID.Should().Be(0);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestActiveState()
            {
                Setup();
                Subject[0].Active.Should().Be(true);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCreatedDate()
            {
                Setup();
                Subject[0].CreatedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestModifiedDate()
            {
                Setup();
                Subject[0].ModifiedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCreatedUser()
            {
                Setup();
                Subject[0].CreatedUser.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestModifiedUser()
            {
                Setup();
                Subject[0].ModifiedUser.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestAssignedTo()
            {
                Setup();
                Subject[0].AssignedTo.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestTFSID()
            {
                Setup();
                Subject[0].TfsID.Should().Be(1234);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestLatestCardActivity()
            {
                Setup();
                Subject.Should().OnlyContain(item => item.CardActivities[item.CardActivities.Count - 1].ActivityType == CardActivityType.Add.ToString());
            }
        }

        public class GetAllMethodNoMatch : BaseTest<List<Card>>
        {
            protected override Dictionary<Type, Mock> OnInitializeServices()
            {
                Dictionary<Type, Mock> services = new Dictionary<Type, Mock>();

                var storageProvider = new Mock<IStorageProvider>();

                List<Card> cards = new List<Card>();

                storageProvider
                    .Setup(d => d.GetAllCards(It.IsAny<int>()))
                    .Returns((int areaID) => cards.FindAll(item => item.AreaID == areaID) ?? new List<Card>());

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback((Card card) => cards.Add(card));

                services.Add(typeof(IStorageProvider), storageProvider);

                return services;
            }

            protected override void Setup()
            {
                var card = new Card(null, GetService<IStorageProvider>(), null, null);

                Subject = card.GetAll(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestForNullValue()
            {
                Setup();
                Subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestForEmptyValue()
            {
                Setup();
                Subject.Should().BeEmpty();
            }
        }

        public class GetAllMethodWithMatch : BaseTest<List<Card>>
        {
            DateTime NOW = new DateTime(2014, 5, 22);

            protected override Dictionary<Type, Mock> OnInitializeServices()
            {
                Dictionary<Type, Mock> services = new Dictionary<Type, Mock>();

                var storageProvider = new Mock<IStorageProvider>();

                List<Card> cards = new List<Card>();

                storageProvider
                    .Setup(d => d.GetAllCards(It.IsAny<int>()))
                    .Returns((int areaID) => cards.FindAll(item => item.AreaID == areaID) ?? new List<Card>());

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Callback((Card card) => cards.Add(card));

                services.Add(typeof(IStorageProvider), storageProvider);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                services.Add(typeof(IDateProvider), dateProvider);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns("Dave Rodgers");

                services.Add(typeof(IIdentityProvider), identityProvider);

                return services;
            }

            protected override void Setup()
            {
                var card = new Card(GetService<IDateProvider>(), GetService<IStorageProvider>(), GetService<IIdentityProvider>(), null);

                card.Add("SampleName", "SampleDescription", "SamplePerson", 2);

                Subject = card.GetAll(2);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenGetAll_AndWithNewCard_ShouldHaveOneElement()
            {
                Setup();
                Subject.Count.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenGetAll_AndWithNewCard_ShouldElementsBeActiveOnly()
            {
                Setup();
                Subject.Should().OnlyContain(item => item.Active == true);
            }
        }

        public class GetMethod : BaseTest<Card>
        {
            DateTime NOW = new DateTime(2014, 5, 22);
            string USERNAME = "Dave Rodgers";

            protected override Dictionary<Type, Mock> OnInitializeServices()
            {
                Dictionary<Type, Mock> services = new Dictionary<Type, Mock>();

                var cardsDb = new List<Card>();

                var storageProvider = new Mock<IStorageProvider>();

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Returns(
                    (Card card) => 
                    {
                        card.ID = cardsDb.Count+1;
                        cardsDb.Add(card); 
                        return card; 
                    });

                storageProvider
                    .Setup(d => d.GetCard(It.IsAny<int>()))
                    .Returns((int id) => cardsDb.Find(card => card.ID == id));

                var identityProvider = new Mock<IIdentityProvider>();

                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns(() => USERNAME);

                var dateProvider = new Mock<IDateProvider>();

                dateProvider
                    .Setup(d => d.Now())
                    .Returns(() => NOW);

                services.Add(typeof(IStorageProvider), storageProvider);
                services.Add(typeof(IIdentityProvider), identityProvider);
                services.Add(typeof(IDateProvider), dateProvider);

                return services;
            }

            protected override void Setup()
            {
                var card = new Card(GetService<IDateProvider>(), GetService<IStorageProvider>(), GetService<IIdentityProvider>(), null);

                card.Add("MyCard", "MyDescription", String.Empty, 1);

                Subject = card.Get(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestForNull()
            {
                Setup();
                Subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCardName()
            {
                Setup();
                Subject.Name.Should().Be("MyCard");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCardDescription()
            {
                Setup();
                Subject.Description.Should().Be("MyDescription");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestAreaID()
            {
                Setup();
                Subject.AreaID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCardID()
            {
                Setup();
                Subject.ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestActiveState()
            {
                Setup();
                Subject.Active.Should().Be(true);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCreatedDate()
            {
                Setup();
                Subject.CreatedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestModifiedDate()
            {
                Setup();
                Subject.ModifiedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCreatedUSer()
            {
                Setup();
                Subject.CreatedUser.Should().Be(USERNAME);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestModifiedUser()
            {
                Setup();
                Subject.ModifiedUser.Should().Be(USERNAME);
            }
        }

        public class UpdateMethod : BaseTest<Card>
        {
            DateTime NOW          = new DateTime(2014, 5, 22);
            DateTime CREATED_DATE = new DateTime(2014, 5, 21);

            protected override Dictionary<Type, Mock> OnInitializeServices()
            {
                Dictionary<Type, Mock> services = new Dictionary<Type, Mock>();

                services.Add(typeof(IStorageProvider), getStorageProvider());

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                services.Add(typeof(IDateProvider), dateProvider);
                services.Add(typeof(IIdentityProvider), identityProvider);

                return services;
            }

            private Mock getStorageProvider()
            {
                var storageProvider = new Mock<IStorageProvider>();

                var cardsDb = new List<Card>();
                var activityDb = new List<CardActivity>();

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Returns((Card card) => { cardsDb.Add(card); return card; });

                storageProvider
                    .Setup(d => d.GetCard(It.IsAny<int>()))
                    .Returns((int id) => cardsDb.Find(item => item.ID == id));

                storageProvider
                    .Setup(d => d.Update(It.IsAny<Card>()))
                    .Returns(
                    (Card card) => 
                    {
                        var exist = cardsDb.Find(item => item.ID == card.ID);

                        if (exist != null)
                        {
                            cardsDb[cardsDb.IndexOf(exist)] = card;

                            return card;
                        }

                        return null;
                    });

                storageProvider
                    .Setup(d => d.Add(It.IsAny<CardActivity>()))
                    .Returns((CardActivity activity) => { activityDb.Add(activity); return activity; });

                cardsDb.Add(new Card()
                        {
                            ID = 1,
                            Name = "MyCard",
                            Description = "MyDescription",
                            CreatedDate = CREATED_DATE,
                            ModifiedDate = CREATED_DATE,
                            CreatedUser = "Dave Rodgers",
                            ModifiedUser = "Dave Rodgers",
                            Active = true,
                            AreaID = 1
                        });

                activityDb.Add(new CardActivity()
                    {
                        ActivityType = CardActivityType.Add.ToString(),
                        CardID = 1,
                        ID = 0,
                        LoggedDate = CREATED_DATE,
                        LoggedUser = "Dave Rodgers"
                    });

                return storageProvider;
            }

            protected override void Setup()
            {
                var card = new Card(GetService<IDateProvider>(), GetService<IStorageProvider>(), GetService<IIdentityProvider>(), null);

                Subject = card.Get(1);

                Subject.Name        = "NotMyCard";
                Subject.Description = "NotMyDescription";
                Subject.AssignedTo  = "Me";
                Subject.AreaID      = 2;

                Subject = card.Update(Subject);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestForNull()
            {
                Setup();
                Subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCardName()
            {
                Setup();
                Subject.Name.Should().Be("NotMyCard");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCardDescription()
            {
                Setup();
                Subject.Description.Should().Be("NotMyDescription");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestAreaID()
            {
                Setup();
                Subject.ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCardID()
            {
                Setup();
                Subject.ID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestModifiedDate()
            {
                Setup();
                Subject.ModifiedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestModifiedUser()
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

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object, null);

                subject = card.Get(1);

                subject.Name = "NotMyCard";
                subject.Description = "NotMyDescription";
                subject.AreaID = 2;

                subject = card.Update(subject);

                subject.ModifiedUser.Should().Be("MIKADO");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCreatedDate()
            {
                Setup();
                Subject.CreatedDate.Should().Be(CREATED_DATE);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestCreatedUser()
            {
                Setup();
                Subject.CreatedUser.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestActiveState()
            {
                Setup();
                Subject.Active.Should().Be(true);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestAssignedTo()
            {
                Setup();
                Subject.AssignedTo.Should().Be("Me");
            }

            [Fact]
            [Trait("Category", "Card")]
            public void TestLatestActivity()
            {
                Setup();
                Subject.CardActivities[Subject.CardActivities.Count - 1].ActivityType.Should().Be(CardActivityType.Modify.ToString());
            }
        }

        public class RemoveMethod : BaseTest<Card>
        {
            protected override Dictionary<Type, Mock> OnInitializeServices()
            {
                Dictionary<Type, Mock> services = new Dictionary<Type, Mock>();

                var NOW = new DateTime(2014, 5, 22);

                var dateProvider = new Mock<IDateProvider>();
                dateProvider.Setup(d => d.Now()).Returns(NOW);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider.Setup(d => d.GetUserName()).Returns(() => "MIKADO");

                var storageProvider = new Mock<IStorageProvider>();

                var cardsDb = new List<Card>();

                storageProvider
                    .Setup(d => d.Add(It.IsAny<Card>()))
                    .Returns(
                    (Card card) => 
                    {
                        card.ID = cardsDb.Count + 1;

                        cardsDb.Add(card);

                        return card;
                    }
                    );

                storageProvider
                    .Setup(d => d.GetCard(It.IsAny<int>()))
                    .Returns(
                    (int id) => 
                    {
                        return cardsDb.FirstOrDefault(item => item.ID == id && item.Active);
                    });

                storageProvider
                    .Setup(d => d.RemoveCard(It.IsAny<Card>()))
                    .Callback(
                    (Card card) => 
                    {
                        cardsDb.Remove(card);
                    });

                services.Add(typeof(IDateProvider), dateProvider);
                services.Add(typeof(IIdentityProvider), identityProvider);
                services.Add(typeof(IStorageProvider), storageProvider);

                return services;
            }

            protected override void Setup()
            {
                var card = new Card(GetService<IDateProvider>(), GetService<IStorageProvider>(), GetService<IIdentityProvider>(), null);

                card.Add("samplecard", "sampledescription", String.Empty, 1);

                card.Remove(1);

                Subject = card.Get(1);
            }

            [Fact]
            [Trait("Category", "Card")]
            public void WhenDelete_ShouldDataBeRemoved()
            {
                Setup();
                Subject.Should().BeNull();
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

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object, null) { ID = 1, AreaID = 1, Name = "MyCard", CardActivities = new List<CardActivity>() };
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

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object, null) { ID = 1, AreaID = 1, Name = "MyCard", CardActivities = new List<CardActivity>() };
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

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object, null) { ID = 1, AreaID = 1, Name = "MyCard", CardActivities = new List<CardActivity>() };
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

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object, null) { ID = 1, AreaID = 1, Name = "MyCard", CardActivities = new List<CardActivity>() };
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

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object, null);
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

                storageProvider.Setup(d => d.GetCard(It.Is<int>(i => i == 1))).Returns(() => new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object, null) { ID = 1, AreaID = 1, Name = "MyCard", CardActivities = new List<CardActivity>() });

                Card subject = null;

                storageProvider.Setup(d => d.Update(It.IsAny<Card>())).Callback<Card>(a => subject = a).Returns(() => subject);

                CardActivity activity = null;

                storageProvider
                    .Setup(d => d.Add(It.IsAny<CardActivity>()))
                    .Callback<CardActivity>(a => activity = a)
                    .Returns(() => activity);

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object, null);
                var area = new Area(null, storageProvider.Object, null);

                subject = card.Move(1, area.GetAll().Find(item => item.ID == 2));

                subject.CardActivities[subject.CardActivities.Count - 1].ActivityType.Should().Be(CardActivityType.Move.ToString());
            }
        }

        public class CheckAge
        {
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

                var card = new Card(dateProvider.Object, storageProvider.Object, identityProvider.Object, new ConfigurationProvider()) { ID = 1, AreaID = 1, Name = "MyCard", CardActivities = new List<CardActivity>(), CreatedDate = new DateTime(2014, 5, 20), ModifiedDate = new DateTime(2014, 5, 20) };
                var area = new Area(null, storageProvider.Object, identityProvider.Object);

                storageProvider.Setup(d => d.GetCard(It.Is<int>(i => i == 1))).Returns(() => card);

                var targetArea = area.GetAll().Find(item => item.ID == 2);

                subject = card.Move(1, targetArea);

                subject.DaysSinceModified.Should().Be(0);
            }
        }
    }
}
