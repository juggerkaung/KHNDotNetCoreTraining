using System.Data;
using System.Data.SqlClient;

namespace DotNetTrainingBatch5.Shared
{
    public class AdoDotNetService
    {

        private readonly string _connectionString;

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        // if use params then can remove null , params should be in the last where it's gonna read the parameter to the
        // public DataTable Query(string query, SqlParameterModel[] sqlParameters = null)
        public DataTable Query(string query, params SqlParameterModel[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if(sqlParameters is not null)
            {
                foreach (var SqlParameter in sqlParameters)
                {
                    cmd.Parameters.AddWithValue(SqlParameter.Name, SqlParameter.Value);

                }

            }

          

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            return dt;
        }

        public int Execute(string query, params SqlParameterModel[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (sqlParameters is not null)
            {
                foreach (var SqlParameter in sqlParameters)
                {
                    cmd.Parameters.AddWithValue(SqlParameter.Name, SqlParameter.Value);

                }

            }
            var result = cmd.ExecuteNonQuery();

            connection.Close();

            return result;
        }

    }


    public class SqlParameterModel
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public SqlParameterModel(string name, object value)
        {
            Name = name;
            Value = value;
        }

    }
}
