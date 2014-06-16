using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Cards.Extensions.Tfs.Core;
using Cards.Extensions.Tfs.Core.Models;
using FluentAssertions;
using Moq;
using Cards.Extensions.Tfs.Core.Interfaces;

namespace Cards.Extensions.Tfs.Tests
{
    public class CardActivityTests
    {
        public class Structure
        {
            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenInitialize_ShouldNotBeNull()
            {
                CardActivity subject = new CardActivity();

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenInitialize_ShouldLoggedDateBeMinDate()
            {
                CardActivity subject = new CardActivity();

                subject.LoggedDate.Should().Be(DateTime.MinValue);
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenInitialize_ShouldLoggedUserBeNull()
            {
                CardActivity subject = new CardActivity();

                subject.LoggedUser.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenInitialize_ShouldActivityTypeBeNone()
            {
                CardActivity subject = new CardActivity();

                subject.ActivityType.Should().Be(null);
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenInitialize_ShouldIDBeZero()
            {
                CardActivity subject = new CardActivity();
                subject.ID.Should().Be(0);
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenInitialize_ShouldCardIDBeZero()
            {
                CardActivity subject = new CardActivity();
                subject.CardID.Should().Be(0);
            }
        }

        public class AddMethod
        {
            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenAdd_ShouldNotBeNull()
            {
                CardActivity subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<CardActivity>()))
                    .Callback<CardActivity>(a => subject = a)
                    .Returns(() => subject);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");


                DateTime NOW = new DateTime(2014,6,13);
                CardActivity cardActivity = new CardActivity(storageProvider.Object, identityProvider.Object);

                subject = cardActivity.Add(1, CardActivityType.Add, NOW);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenAdd_ShouldCardIDBeOne()
            {
                CardActivity subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<CardActivity>()))
                    .Callback<CardActivity>(a => subject = a)
                    .Returns(() => subject);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");


                DateTime NOW = new DateTime(2014, 6, 13);
                CardActivity cardActivity = new CardActivity(storageProvider.Object, identityProvider.Object);

                subject = cardActivity.Add(1, CardActivityType.Add, NOW);

                subject.CardID.Should().Be(1);
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenAdd_ShouldActivityTypeBeAdd()
            {
                CardActivity subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.Add(It.IsAny<CardActivity>()))
                    .Callback<CardActivity>(a => subject = a)
                    .Returns(() => subject);

                var identityProvider = new Mock<IIdentityProvider>();
                identityProvider
                    .Setup(d => d.GetUserName())
                    .Returns("MIKADO");


                DateTime NOW = new DateTime(2014, 6, 13);
                CardActivity cardActivity = new CardActivity(storageProvider.Object, identityProvider.Object);

                subject = cardActivity.Add(1, CardActivityType.Add, NOW);

                subject.ActivityType.Should().Be(CardActivityType.Add.ToString());
            }
        }

        public class GetMethod
        {
            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenGet_ShouldBeNull()
            {
                DateTime NOW = new DateTime(2014, 6, 13);

                CardActivity subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCardActivity(It.Is<int>(i => i == 1)))
                    .Returns(() => new CardActivity() { ID = 22, CardID = 3, ActivityType = CardActivityType.Modify.ToString(), LoggedDate = NOW, LoggedUser = "Dave Rodgers" });

                CardActivity cardActivity = new CardActivity(storageProvider.Object, null);

                subject = cardActivity.Get(0);

                subject.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenGet_ShouldNotBeNull()
            {
                DateTime NOW = new DateTime(2014, 6, 13);

                CardActivity subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCardActivity(It.Is<int>(i => i == 1)))
                    .Returns(() => new CardActivity() { ID = 22, CardID = 3, ActivityType = CardActivityType.Modify.ToString(), LoggedDate = NOW, LoggedUser = "Dave Rodgers" });

                CardActivity cardActivity = new CardActivity(storageProvider.Object, null);

                subject = cardActivity.Get(1);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenGet_ShouldCardIDBeThree()
            {
                DateTime NOW = new DateTime(2014, 6, 13);

                CardActivity subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCardActivity(It.Is<int>(i => i == 1)))
                    .Returns(() => new CardActivity() { ID = 22, CardID = 3, ActivityType = CardActivityType.Modify.ToString(), LoggedDate = NOW, LoggedUser = "Dave Rodgers" });

                CardActivity cardActivity = new CardActivity(storageProvider.Object, null);

                subject = cardActivity.Get(1);

                subject.CardID.Should().Be(3);
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenGet_ShouldCardActivityBeModify()
            {
                DateTime NOW = new DateTime(2014, 6, 13);

                CardActivity subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCardActivity(It.Is<int>(i => i == 1)))
                    .Returns(() => new CardActivity() { ID = 22, CardID = 3, ActivityType = CardActivityType.Modify.ToString(), LoggedDate = NOW, LoggedUser = "Dave Rodgers" });

                CardActivity cardActivity = new CardActivity(storageProvider.Object, null);

                subject = cardActivity.Get(1);

                subject.ActivityType.Should().Be(CardActivityType.Modify.ToString());
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenGet_ShouldLoggedDateHaveValue()
            {
                DateTime NOW = new DateTime(2014, 6, 13);

                CardActivity subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCardActivity(It.Is<int>(i => i == 1)))
                    .Returns(() => new CardActivity() { ID = 22, CardID = 3, ActivityType = CardActivityType.Modify.ToString(), LoggedDate = NOW, LoggedUser = "Dave Rodgers" });

                CardActivity cardActivity = new CardActivity(storageProvider.Object, null);

                subject = cardActivity.Get(1);

                subject.LoggedDate.Should().Be(NOW);
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenGet_ShouldLoggedUserHaveValue()
            {
                DateTime NOW = new DateTime(2014, 6, 13);

                CardActivity subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCardActivity(It.Is<int>(i => i == 1)))
                    .Returns(() => new CardActivity() { ID = 22, CardID = 3, ActivityType = CardActivityType.Modify.ToString(), LoggedDate = NOW, LoggedUser = "Dave Rodgers" });

                CardActivity cardActivity = new CardActivity(storageProvider.Object, null);

                subject = cardActivity.Get(1);

                subject.LoggedUser.Should().Be("Dave Rodgers");
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenGet_ShouldIDBe22()
            {
                DateTime NOW = new DateTime(2014, 6, 13);

                CardActivity subject = null;

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetCardActivity(It.Is<int>(i => i == 1)))
                    .Returns(() => new CardActivity() { ID = 22, CardID = 3, ActivityType = CardActivityType.Modify.ToString(), LoggedDate = NOW, LoggedUser = "Dave Rodgers" });

                CardActivity cardActivity = new CardActivity(storageProvider.Object, null);

                subject = cardActivity.Get(1);

                subject.ID.Should().Be(22);
            }
        }

        public class GetAllMethod
        {
            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenGet_ShouldBeNull()
            {
                DateTime NOW = new DateTime(2014, 6, 13);

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetAllCardActivities(It.Is<int>(i => i == 3)))
                    .Returns(() =>
                    {
                        return new List<CardActivity>()
                        {
                            new CardActivity() { ID = 22, CardID = 3, ActivityType = CardActivityType.Modify.ToString(), LoggedDate = NOW, LoggedUser = "Dave Rodgers" },
                            new CardActivity() { ID = 22, CardID = 3, ActivityType = CardActivityType.Move.ToString(), LoggedDate = NOW, LoggedUser = "Dave Rodgers" }
                        };
                    });

                CardActivity cardActivity = new CardActivity(storageProvider.Object, null);

                var subject = cardActivity.GetAll(1);

                subject.Should().BeNull();
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenGet_ShouldNotBeNull()
            {
                DateTime NOW = new DateTime(2014, 6, 13);

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetAllCardActivities(It.Is<int>(i => i == 3)))
                    .Returns(() =>
                    {
                        return new List<CardActivity>()
                        {
                            new CardActivity() { ID = 22, CardID = 3, ActivityType = CardActivityType.Modify.ToString(), LoggedDate = NOW, LoggedUser = "Dave Rodgers" },
                            new CardActivity() { ID = 22, CardID = 3, ActivityType = CardActivityType.Move.ToString(), LoggedDate = NOW, LoggedUser = "Dave Rodgers" }
                        };
                    });

                CardActivity cardActivity = new CardActivity(storageProvider.Object, null);

                var subject = cardActivity.GetAll(3);

                subject.Should().NotBeNull();
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenGet_ShouldCountBeTwo()
            {
                DateTime NOW = new DateTime(2014, 6, 13);

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetAllCardActivities(It.Is<int>(i => i == 3)))
                    .Returns(() =>
                    {
                        return new List<CardActivity>()
                        {
                            new CardActivity() { ID = 22, CardID = 3, ActivityType = CardActivityType.Modify.ToString(), LoggedDate = NOW, LoggedUser = "Dave Rodgers" },
                            new CardActivity() { ID = 22, CardID = 3, ActivityType = CardActivityType.Move.ToString(), LoggedDate = NOW, LoggedUser = "Dave Rodgers" }
                        };
                    });

                CardActivity cardActivity = new CardActivity(storageProvider.Object, null);

                var subject = cardActivity.GetAll(3);

                subject.Count.Should().Be(2);
            }

            [Fact]
            [Trait("Category", "CardActivity")]
            public void WhenGet_ShouldAllCardIDsBeThree()
            {
                DateTime NOW = new DateTime(2014, 6, 13);

                var storageProvider = new Mock<IStorageProvider>();
                storageProvider
                    .Setup(d => d.GetAllCardActivities(It.Is<int>(i => i == 3)))
                    .Returns(() =>
                    {
                        return new List<CardActivity>()
                        {
                            new CardActivity() { ID = 22, CardID = 3, ActivityType = CardActivityType.Modify.ToString(), LoggedDate = NOW, LoggedUser = "Dave Rodgers" },
                            new CardActivity() { ID = 22, CardID = 3, ActivityType = CardActivityType.Move.ToString(), LoggedDate = NOW, LoggedUser = "Dave Rodgers" }
                        };
                    });

                CardActivity cardActivity = new CardActivity(storageProvider.Object, null);

                var subject = cardActivity.GetAll(3);

                subject.Should().OnlyContain(item => item.CardID == 3);
            }
        }
    }
}
