using SimpleSub.Domain.Enums;
using SimpleSub.Domain.Interfaces;
using SimpleSub.Domain.ValueObjects;
using System.Collections.Generic;

namespace SimpleSub.Domain
{
    public class Customer
    {
        private List<Subscription> _subscriptions = new List<Subscription>();

        public Customer(CustomerId customerId)
        {
            CustomerId = customerId;
            _subscriptions.Add(new Subscription());
        }

        public static Customer Create(CustomerId customerId, IDateProvider dateProvider)
        {
            return new Customer(customerId);
        }

        public CustomerId CustomerId { get; }
        public SubscriptionType SubscriptionType { get; private set; }
        public IReadOnlyList<Subscription> Subscriptions => _subscriptions.AsReadOnly();

        public void RenewSubscription()
        {
            SubscriptionType = SubscriptionType.Standard;
            _subscriptions.Add(new Subscription());
        }
    }
}
