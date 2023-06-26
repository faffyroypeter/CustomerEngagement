namespace CE.Model
{
    /// <summary>
    /// Customer Information Clas
    /// </summary>
    public class Customer
    {
        // Constructor -gets called during new operator
        public Customer()
        {
            // perform property initializing here

        }

        // Public Variable
        // public string FirstName;

        
        // Member Variable
        private string _firstName;

        public string? FirstName{ get; set; }

        // Property
        public string? FirstName1
        {
            // 
            get { return this._firstName; }
            
            
            // Set method Customer.FirstName = "Peter"

            set
            {
                if(checkIfSameNameExists(value))
                {
                    _firstName = value;
                }
                else
                {
                    _firstName = null;
                }
               
            }
        }

        private bool checkIfSameNameExists(string? value)
        {
            if (value == "A")
            {

                return true;
            }
            return false;
        }

        // Assignment and get is automatically taken care by platfor, no need to introduce member variable,
        public string? LastName { get; set; }
        public int? Age { get; set; }

        // Requested Loan Amount by the customer
        public double? LoanAmount { get; set; }
    }
}

interface IPeter
{
    string? Name { get; set; }
}