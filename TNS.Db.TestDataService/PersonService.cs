using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace TNS.Db.TestDataService
{
    public class PersonService
    {
        public static DataTable table = new DataTable();



        /// <summary>
        /// Use for CS application
        /// </summary>
        /// <returns></returns>
        public static List<Person> GetList()
        {
            var result = new List<Person>();
            result.Add(new Person("tony", "zeng", "tonyzeng"));
            result.Add(new Person("jack", "yu", "tonyzeng"));
            result.Add(new Person("nancy", "lu", "tonyzeng"));
            result.Add(new Person("simple", "liang", "tonyzeng"));
            result.Add(new Person("maggie", "she", "tonyzeng"));
            return result;
        }

        /// <summary>
        /// Use for report
        /// </summary>
        /// <returns></returns>
        public static DataSet GetDataSet()
        {
            table.TableName = "Person";
            table.Columns.Add(new DataColumn("personId", typeof(string)));
            table.Columns.Add(new DataColumn("firstName", typeof(string)));
            table.Columns.Add(new DataColumn("secondName", typeof(string)));
            table.Columns.Add(new DataColumn("comments", typeof(string)));

            addPerson("tony", "zeng", "tonyzeng");
            addPerson("jack", "yu", "tonyzeng");
            addPerson("nancy", "lu", "tonyzeng");
            addPerson("simple", "liang", "tonyzeng");
            addPerson("maggie", "she", "tonyzeng");
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);

            return dataSet;
        }

        public static void add(Person person)
        {
            addPerson(person.firstName, person.secondName, person.comments);
        }

        private static void addPerson(string firstName, string secondName, string comments)
        {
            DataRow row = table.NewRow();
            row["personId"] = Guid.NewGuid();
            row["firstName"] = firstName;
            row["secondName"] = secondName;
            row["comments"] = comments;
            table.Rows.Add(row);
        }
    }
}