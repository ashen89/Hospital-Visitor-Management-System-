using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class DBConnection
    {
        public SqlConnection getConnection()
        {
            SqlConnection sqlCon = null;
            try
            {
                //sqlCon = new SqlConnection("data source=10.0.0.4; initial catalog=Hospital_DB; user id=hnd; password=hnd");
                sqlCon = new SqlConnection(@"Data Source=DESKTOP-1JP647P;Initial Catalog=ManiYa;Integrated Security=True"); //this is used when SQL doesn't
                //let you enter the user ID and password
                sqlCon.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Connecting to DB" + ex);
            }
            return sqlCon;
        }
    }
}
