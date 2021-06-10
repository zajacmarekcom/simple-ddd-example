using System;

namespace SimpleSub.Domain.ValueObjects
{
    public class Date
    {
        private readonly DateTime _date;

        public Date(DateTime date) => _date = date;

        public DateTime Value => _date.Date;
    }
}
