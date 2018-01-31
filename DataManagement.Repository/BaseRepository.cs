using System;  
using System.Data;  
using System.Data.SqlClient; 

namespace DataManagement.Repository
{
    public class BaseRepository : IDisposable 
    {  
        protected IDbConnection con;  
        public BaseRepository() 
        {  
            string connectionString = "Server=localhost;Database=DataManagement;User Id=sa;pwd=SA!sql2017";  
            con = new SqlConnection(connectionString);  
        }  
        public void Dispose() {  
            //throw new NotImplementedException();  
        }  
    }  
}