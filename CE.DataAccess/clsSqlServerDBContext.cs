namespace CE.DataAccess
{
    using CE.Model;
    using System.Data.Sql;
    using System.Data.SqlClient;

    public class clsSqlServerDBContext
    {

        // Connect to Database

        // 1. Require a Connection String (database server name, database name, credential optionally, other attributes)

        // 2. Open A Connection or check if the connection is already opened with database

        // 3. Perform the operation (CRUD)

        // 4. Close the connection with database (to avoid hanging execution or graceful closure)

        // Constructor 


        //private string ConnStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //private string ConnStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Mortgage;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private string ConnStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Mortgage;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public clsSqlServerDBContext() { }


        public int InsertCustomer(Customer customer)
        {
            // 1.Initialize connection with database with connectionstring copied from database explorer
            SqlConnection objSqlConnection = new SqlConnection(ConnStr);

            // 2. Open the connection with database
            objSqlConnection.Open();

            string query = $"INSERT INTO tblCustomer (FirstName,LastName,Age,LoanAmount) VALUES('{customer.FirstName}','{customer.LastName}',{customer.Age},{customer.LoanAmount})";


            SqlCommand objSqlCommand = new SqlCommand(query, objSqlConnection);
            objSqlCommand.CommandText = query;
            objSqlCommand.Connection = objSqlConnection;
            objSqlCommand.CommandType = System.Data.CommandType.Text;

            int resultsAffected = objSqlCommand.ExecuteNonQuery();

            if(objSqlConnection.State == System.Data.ConnectionState.Open)
            {
                // 4. Close the connection:
                objSqlConnection.Close();
            }

            return resultsAffected;
        }

    }
}