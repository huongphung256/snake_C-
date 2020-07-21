using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace demo_drawing
{
    class Data
    {
        public DataTable data;
        public string connecting;
        public SqlConnection connect;
        public Data()
        {
            data = new DataTable();
            connect = null;
            connecting = @"Data Source=DESKTOP-DQKNN50;Initial Catalog=SnackApp;Integrated Security=True";
        }
        public void DataConnect()
        {
            connect = new SqlConnection(connecting);
            connect.Open();
        }
        public void DataQuery()
        {
            string query = $"SELECT MAX(high_score) FROM Point";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
            adapter.Fill(data);
        }
        public void DataAdd(int point)
        {
            string query = $"INSERT INTO Point VALUES('{point}')";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }
        public void DataDisconnect()
        {
            connect.Close();
        }
        
    }
}
