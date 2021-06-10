using SimpleSub.Domain.ValueObjects;

namespace SimpleSub.Domain.Interfaces
{
    public interface IDateProvider
    {
        public Date Now();
    }
}
