namespace CE.Model
{
    /// <summary>
    /// Customer Information Clas
    /// </summary>
    public class Customer 
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }

        // Requested Loan Amount by the customer
        public double LoanAmount { get; set; }
    }
}