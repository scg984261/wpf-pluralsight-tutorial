namespace WiredBrainCoffee.CustomersApp.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsDeveloper { get; set; }

        public Customer()
        {
        }

        public Customer(int Id, string firstName, string LastName, bool isDeveloper)
        {
            this.Id = Id;
            this.FirstName = firstName;
            this.LastName = LastName;
            this.IsDeveloper = isDeveloper;
        }
    }
}
