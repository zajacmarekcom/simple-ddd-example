namespace SimpleSub.Domain.ValueObjects
{
    public class CustomerId
    {
        public CustomerId(int id) => Value = id;

        public int Value { get; }
    }
}
