namespace PaymentContext.Domain.Entities
{
    public class Student {
        private IList<Subscription> _subscriptions;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get => _subscriptions.As(); }

        public Student(
            string firstName,
            string lastName,
            string document,
            string email
        ) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Document = document;
            this.Email = email;
            this._subscriptions = new List<Subscription>();
        }

        public void AddSubscription(Subscription subscription) {
            foreach(var sub in Subscriptions) sub.Inactivate();
            _subscriptions.Add(subscription);
        }
    }
}