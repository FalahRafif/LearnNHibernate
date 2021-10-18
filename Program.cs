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
            String DataSource               = @"DESKTOP-2UMMUTE\SQLEXPRESS";
            String InitialCatalog           =  "LearnNhibernate";
            String IntegratedSecurity       =  "True";
            String ConnectTimeout           =  "15";
            String Encrypt                  =  "False";
            String TrustServerCertificate   =  "False";
            String ApplicationIntent        =  "ReadWrite";
            String MultiSubnetFailover      =  "False";
            #endregion

            #region Set Up Connection String
            cfg.DataBaseIntegration(x => { 
                x.ConnectionString = $@"
                        Data Source = {DataSource}; 
                        Initial Catalog = {InitialCatalog}; 
                        Integrated Security = {IntegratedSecurity}; 
                        Connect Timeout = {ConnectTimeout}; 
                        Encrypt = {Encrypt}; 
                        TrustServerCertificate = {TrustServerCertificate}; 
                        ApplicationIntent = {ApplicationIntent}; 
                        MultiSubnetFailover = {MultiSubnetFailover}"; 

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

            #region CRUD Operation ////////////////////////////////////////////////////////////
            #region Create
            //using (var session = sefact.OpenSession())
            //{

            //    using (var tx = session.BeginTransaction())
            //    {

            //        var student1 = new Student
            //        {
            //            ID = 0,
            //            FirstMidName = "Allan",
            //            LastName = "Bommer"
            //        };

            //        var student2 = new Student
            //        {
            //            ID = 0,
            //            FirstMidName = "Jerry",
            //            LastName = "Lewis"
            //        };

            //        //save data
            //        session.Save(student1);
            //        session.Save(student2);
            //        //Begin Transaction
            //        tx.Commit();
            //    }

            //}
            //Console.WriteLine("Create Operation Finish");
            //Console.ReadLine();
            #endregion

            #region Read
            using (var session = sefact.OpenSession())
            {

                using (var tx = session.BeginTransaction())
                {
                    var students = session.CreateCriteria<Student>().List<Student>();

                    //Show All
                    Console.WriteLine("List Students");
                    foreach (var student in students)
                    {
                        Console.WriteLine("{0} \t{1} \t{2}",
                           student.ID, student.FirstMidName, student.LastName);
                    }

                    //Show Specific Data
                    var stdnt = session.Get<Student>(1);
                    Console.WriteLine("Retrieved by ID");
                    Console.WriteLine("{0} \t{1} \t{2}", stdnt.ID, stdnt.FirstMidName, stdnt.LastName);
                    tx.Commit();
                }

                Console.ReadLine();
            }
            #endregion

            #region Update
            //using (var session = sefact.OpenSession())
            //{

            //    using (var tx = session.BeginTransaction())
            //    {
            //        var students = session.CreateCriteria<Student>().List<Student>();

            //        var stdnt = session.Get<Student>(1);

            //        Console.WriteLine("Update the last name of ID = {0}", stdnt.ID);
            //        stdnt.LastName = "Donald";
            //        session.Update(stdnt);
            //        Console.WriteLine("\nFetch the complete list again\n");

            //        foreach (var student in students)
            //        {
            //            Console.WriteLine("{0} \t{1} \t{2}", student.ID,
            //               student.FirstMidName, student.LastName);
            //        }

            //        tx.Commit();
            //    }

            //    Console.ReadLine();
            //}
            #endregion

            #region Delete
            //using (var session = sefact.OpenSession())
            //{

            //    using (var tx = session.BeginTransaction())
            //    {
            //        var students = session.CreateCriteria<Student>().List<Student>();

            //        var stdnt = session.Get<Student>(1);

            //        Console.WriteLine("Delete the record which has ID = {0}", stdnt.ID);
            //        session.Delete(stdnt);
            //        Console.WriteLine("\nFetch the complete list again\n");

            //        foreach (var student in students)
            //        {
            //            Console.WriteLine("{0} \t{1} \t{2}", student.ID, student.FirstMidName,
            //               student.LastName);
            //        }

            //        tx.Commit();
            //    }

            //    Console.ReadLine();
            //}
            #endregion
            #endregion
        }
    }
}
