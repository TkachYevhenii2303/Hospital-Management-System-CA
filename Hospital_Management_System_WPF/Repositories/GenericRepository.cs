using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_WPF.Repositories
{
    public abstract class GenericRepository
    {
        private readonly string _connectionString;

        public GenericRepository()
        {
            _connectionString = "Server=(LocalDB)\\MSSQLLocalDB; Database=Hospital_Managament_System_Clean_Architecture_Database; Integrated Security=true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
