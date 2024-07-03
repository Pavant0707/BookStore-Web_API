using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class BookContext
    {
        private readonly IConfiguration iconfiguration;
        private readonly string connectingstring;

        public BookContext(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
            connectingstring = iconfiguration.GetConnectionString("DBConnection");
        }
        public IDbConnection CreateConnection()=>new SqlConnection(connectingstring);
    }
}
