using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNHibernate
{
    class Student
    {
        //Property
        public virtual int ID { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual StudentAcademicStanding AcademicStanding { get; set; }
        public enum StudentAcademicStanding
        {
            Excellent,
            Good,
            Fair,
            Poor,
            Terrible
        }
    }
}
