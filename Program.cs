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
            #region Connection To DB //////////////////////////////////////////////////////////
            var cfg = new Configuration();

            #region Prepare Statment
            String DataSource               =  @"UMMUTE\SQLEXPRESS";
            String InitialCatalog           = "LearnNhibernate";
            String IntegratedSecurity       =  "True";
            String ConnectTimeout           =  "15";
            String Encrypt                  =  "False";
            String TrustServerCertificate   =  "False";
            String ApplicationIntent        =  "ReadWrite";
            String MultiSubnetFailover      =  "False";
            #endregion

            #region Set Up Connection String
            cfg.DataBaseIntegration(x => { 
                x.ConnectionString = $"Data Source = {DataSource}; Initial Catalog = {InitialCatalog}; Integrated Security = {IntegratedSecurity}; Connect Timeout = {ConnectTimeout}; Encrypt = {Encrypt}; TrustServerCertificate = {TrustServerCertificate}; ApplicationIntent = {ApplicationIntent}; MultiSubnetFailover = {MultiSubnetFailover}"; 

                x.Driver<SqlClientDriver>(); 
                x.Dialect<MsSql2008Dialect>(); 
            });
            #endregion

            #region Connect To DB
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
            #endregion
            #endregion
        }
    }
}
