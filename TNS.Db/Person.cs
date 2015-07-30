using System;
namespace TNS.Db
{
    public class Person
    {
        public Person() { }
        public Person(string firstName, string secondName)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.comments = String.Empty;
        }

        public Person(string firstName, string secondName, string comments)
            : this(firstName, secondName)
        {
            this.comments = comments;
        }

        public Person(string firstName, string secondName, DateTime birthDay)
            : this(firstName, secondName)
        {
            this.birthDay = birthDay;
            this.comments = String.Empty;
        }

        public Person(string firstName, string secondName, DateTime birthDay, string comments)
            : this(firstName, secondName, birthDay)
        {
            this.comments = comments;
        }

        public string personId { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public DateTime birthDay { get; set; }
        public string comments { get; set; }
    }
}
