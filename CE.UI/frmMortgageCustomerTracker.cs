using CE.Business;
using CE.Model;

namespace CE.UI
{
    public partial class frmCustomerInformation : Form
    {
        private clsMortgageCustomerTrackerSystem objMortgageCusTrackSystem = new clsMortgageCustomerTrackerSystem();
        public frmCustomerInformation()
        {
            InitializeComponent();
        }

        public void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            // Declare Object
            Customer objCustomer;

            // Create new Instance for customer
            objCustomer = new Customer();

            // Capture User Inputs and fill in the object, this will act as a carrier to other tiers
            objCustomer.FirstName = txtFirstName.Text.Trim();
            objCustomer.LastName = txtLastName.Text.Trim();

            // Validate the conversion for Number on your own
            //if(txtAge.Text.Trim() == string.Empty)
            //{

            //}

            // Validate using String Functions.
            if (string.IsNullOrEmpty(txtAge.Text.Trim()))
            {
                objCustomer.Age = 0;
            }
            else
            {
                objCustomer.Age = Convert.ToInt32(txtAge.Text.Trim());
            }

            // Validate Loan amount input for null value .
            if (string.IsNullOrEmpty(txtLoanAmount.Text.Trim()))
            {
                objCustomer.LoanAmount = 0;
            }
            else
            {
                objCustomer.LoanAmount = Convert.ToInt32(txtLoanAmount.Text.Trim());
            }


            // Validations

            // Perform Intented Operation

            bool status = objMortgageCusTrackSystem.AddCustomer(objCustomer);

            if (status)
            {
                MessageBox.Show("Record Saved");
                
                 var result = objMortgageCusTrackSystem.FetchCustomers();
                dgvCustomer.DataSource = result;                    
            }
        }
    }
}