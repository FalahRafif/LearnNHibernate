using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace LearnNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data Source = DESKTOP - 2UMMUTE\SQLEXPRESS; Initial Catalog = LearnNhibernate; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False
            var cfg = new Configuration();

            String DataSource               =  @"UMMUTE\SQLEXPRESS";
            String InitialCatalog           = "LearnNhibernate";
            String IntegratedSecurity       =  "True";
            String ConnectTimeout           =  "15";
            String Encrypt                  =  "False";
            String TrustServerCertificate   =  "False";
            String ApplicationIntent        =  "ReadWrite";
            String MultiSubnetFailover      =  "False";

            cfg.DataBaseIntegration(x => { 
                x.ConnectionString = $"Data Source = {DataSource}; Initial Catalog = {InitialCatalog}; Integrated Security = {IntegratedSecurity}; Connect Timeout = {ConnectTimeout}; Encrypt = {Encrypt}; TrustServerCertificate = {TrustServerCertificate}; ApplicationIntent = {ApplicationIntent}; MultiSubnetFailover = {MultiSubnetFailover}"; 
                x.Driver<SqlClientDriver>(); 
                x.Dialect<MsSql2008Dialect>(); 
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            var sefact = cfg.BuildSessionFactory();

            using (var session = sefact.OpenSession())
            {

                using (var tx = session.BeginTransaction())
                {
                    //perform database logic 
                    tx.Commit();
                }

                Console.ReadLine();
            }
        }
    }
}
