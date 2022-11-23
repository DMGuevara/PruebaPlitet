namespace RestDemo.Context
{
    public class DataContext
    {
        private string connectionString = string.Empty;

        public DataContext()
        {
            var constructor = new ConfigurationBuilder().SetBasePath
              (Directory.GetCurrentDirectory()).AddJsonFile
              ("appsettings.json").Build();
              connectionString = constructor.GetSection
              ("ConnectionStrings:CadenaConexion").Value;
        }
        public string CadenaSQL()
        {
            return connectionString;
        }
    }
}
