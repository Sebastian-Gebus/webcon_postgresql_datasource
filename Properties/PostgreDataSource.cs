using System.Collections.Generic;
using System.Data;
using WebCon.WorkFlow.SDK.Common.Model;
using WebCon.WorkFlow.SDK.DataSourcePlugins;
using WebCon.WorkFlow.SDK.DataSourcePlugins.Model;
using Npgsql;

namespace PostgreDataSource
{
    public class PostgreDataSource : CustomDataSource<PostgreDataSourceConfig>
    {
        public override List<DataSourceColumn> GetColumns()
        {
            return new List<DataSourceColumn>()
            {
                new DataSourceColumn("Id","Id"),
                new DataSourceColumn("Name","Name")
            };
        }

        public override DataTable GetData(SearchConditions searchConditions)
        {
            var result = GenerateDataTable();
            var ConnectionString = string.Format("Host={0};Username={1};Password={2};Database={3}", Configuration.DbHost, Configuration.DbUser, Configuration.DbPassword, Configuration.DbName);

            var Connection = new NpgsqlConnection(ConnectionString);
            Connection.Open();

            string SqlQuery = @"
                        SELECT
                        '' as Id,
                        '' as Name
                        ";

            using (NpgsqlCommand SqlCommand = new NpgsqlCommand(SqlQuery, Connection))
            {
                SqlCommand.Prepare();

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(SqlCommand);

                DataSet _ds = new DataSet();
                DataTable _dt = new DataTable();

                da.Fill(_ds);
                _dt = _ds.Tables[0];
                result = _dt;

                Connection.Close();
            }

            return result;
        }
        private DataTable GenerateDataTable()
        {
            var dt = new DataTable("data");
            foreach (var column in GetColumns())
            {
                dt.Columns.Add(new DataColumn(column.Name));
            }

            return dt;
        }
    }
}