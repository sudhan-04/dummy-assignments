namespace ExpenseTracker.Model
{
    public class Transaction

    {
        private string _type;
        private int _amount;
        private DateOnly _dateOnly;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public DateOnly DateOfTransaction
        {
            get { return _dateOnly; }
            set { _dateOnly = value; }
        }
    }

    public class Expense : Transaction
    {
        public string Category { get; set; }
    }

    public class Income : Transaction
    {
        public string Source { get; set; }
    }
}