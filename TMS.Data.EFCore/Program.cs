using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Repository.Data.DataContext;
namespace TMS.Data.EFCore
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Start Connect To DB To Apply Migration");
            List<string> dbObjectName = new List<string>();

            using (ApplicationDbContext sc = CreateDbContext(out string conString))
            {
                ApplyMigration(sc);
                CleanDatabase(conString, dbObjectName);
            }

       

            Console.WriteLine("End Migration");
            Console.ReadLine();
        }

     
        public static ApplicationDbContext CreateDbContext(out string conString,string _ConnectionName = "DBConString")
        {
            var configurationBuilder = new ConfigurationBuilder()
            
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile($"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}/repositorysetting.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = configurationBuilder.Build();
            string connectionString = configuration.GetConnectionString(_ConnectionName);

            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString);

            conString = connectionString;
            return new ApplicationDbContext(optionsBuilder.Options);
        }

   

        private static void ApplyMigration(ApplicationDbContext appDbContext)
        {
            Console.WriteLine("Start Apply Schema Migration");

            appDbContext.Database.Migrate();

            Console.WriteLine("Schema Migration Ends");
        }

    
        private static List<string> SplitQuery(string query)
        {
            return query.Split("GO").ToList();
        }

        private static void CleanDatabase(string conString, List<string> createdOjects)
        {
            Console.WriteLine("Start Clean DataBase");



            Console.WriteLine(" Clean DataBase  Ends");
        }

    }
}
