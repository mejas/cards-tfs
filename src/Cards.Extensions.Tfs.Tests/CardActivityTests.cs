using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Cards.Extensions.Tfs.Core;
using Cards.Extensions.Tfs.Core.Models;
using FluentAssertions;

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

                subject.ActivityType.Should().Be(CardActivityType.None);
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
                CardActivity cardActivity = new CardActivity();
            }
        }
    }
}
