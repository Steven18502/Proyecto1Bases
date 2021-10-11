namespace Proyecto1Bases
{
    public class PostgreSQLConfiguration
    {
        public PostgreSQLConfiguration(string connectionString) => ConnectionString = connectionString; 

        public string ConnectionString { get; set; }
    }
}