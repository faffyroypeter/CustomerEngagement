namespace CE.CustomerEngagementApi.Model
{
    // Domain model for Customer

    public class Customer
    {
        public Guid CustomerId{ get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set;}

        //public int? age { get; set; }

    }
}
