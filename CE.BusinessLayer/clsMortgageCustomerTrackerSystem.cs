using CE.DataAccess;
using CE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CE.Business
{
    public class clsMortgageCustomerTrackerSystem
    {
        private clsSqlServerDBContext objSqlDBContext = new clsSqlServerDBContext();


        public clsMortgageCustomerTrackerSystem() { }

        public bool AddCustomer(Customer objCustomer)
        {
            // Rule Validation & Verification 
            // Has the Customer Enter Correct Data - Verification
            // Has the customer entered the data correction - Validation
            // Business Logic Mandated

            if (objSqlDBContext.InsertCustomer(objCustomer) >= 1)
            {
                return true;
            }
            else
                return false;
        }

        //public bool UpdateCustomer() { }
        //public bool RemoveCustomer() { }

        //public bool HasCustomer() { }
        //public int GetCustomerCount() { }
        //public int GetCustomerId() { }
        //public string GetCustomerName() { }

    }
}
