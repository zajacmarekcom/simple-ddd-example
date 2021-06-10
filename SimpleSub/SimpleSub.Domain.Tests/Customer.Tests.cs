using Moq;
using SimpleSub.Domain.Enums;
using SimpleSub.Domain.Interfaces;
using SimpleSub.Domain.ValueObjects;
using System;
using System.Linq;
using Xunit;

namespace SimpleSub.Domain.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void WhenNewCustomerIsCreated_ThenFreeSubscriptionIsActive()
        {
            // Given
            var customerId = new CustomerId(1);

            // When
            var customer = Customer.Create(customerId, null);

            // Then
            Assert.Equal(SubscriptionType.Free, customer.SubscriptionType);
            Assert.Equal(1, customer.Subscriptions.Count);
        }

        [Fact]
        public void WhenCustomerIsCreated_ThenCustomerIdShouldBeCorrect()
        {
            // Given
            var customerId = new CustomerId(1);

            // When
            var customer = Customer.Create(customerId, null);

            // Then
            Assert.Equal(customerId.Value, customer.CustomerId.Value);
            Assert.Equal(1, customer.CustomerId.Value);
        }

        [Fact]
        public void WhenCustomerWithFreeSubscriptionRenewSubscription_ThenSubTypeShouldBeChangedToStandard()
        {
            // Given
            var customerId = new CustomerId(1);
            var customer = Customer.Create(customerId, null);

            // When
            customer.RenewSubscription();

            // Then
            Assert.Equal(SubscriptionType.Standard, customer.SubscriptionType);
        }

        [Fact]
        public void WhenCustomerWithFreeSubscriptionRenewSubscription_ThenSecondSubscriptionShouldBeAdded()
        {
            // Given
            var customerId = new CustomerId(1);
            var customer = Customer.Create(customerId, null);

            // When
            customer.RenewSubscription();

            // Then
            Assert.Equal(2, customer.Subscriptions.Count);
        }

        [Fact]
        public void WhenCustomerIsCreated_ThenSubscriptionShouldExpiredInMonth()
        {
            // Given
            var customerId = new CustomerId(1);
            var today = new DateTime(2021, 1, 1);
            var monthLater = new Date(today.AddDays(30));
            var dateProvider = new Mock<IDateProvider>();
            dateProvider.Setup(x => x.Now()).Returns(new Date(today));

            // When
            var customer = Customer.Create(customerId, dateProvider.Object);

            // Then
            Assert.Equal(monthLater, customer.Subscriptions.Last().Expires);
        }
    }
}
