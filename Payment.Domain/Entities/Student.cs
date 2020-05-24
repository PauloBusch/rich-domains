using Flunt.Validations;
using Payment.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity {
        private List<Subscription> _subscriptions;
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get => _subscriptions.AsReadOnly(); }

        public Student(
            Name name,
            Document document,
            Email email
        ) {
            this.Name = name;
            this.Document = document;
            this.Email = email;
            this._subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public void AddSubscription(Subscription subscription) {
            var hasSubscriptionActive = false;
            foreach (var sub in Subscriptions)
                if (sub.Active) hasSubscriptionActive = true;

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Already subscription active")
                .IsGreaterThan(0, subscription.Payments.Count, "Student.Payments", "Require Payments")    
            );
        }
    }
}