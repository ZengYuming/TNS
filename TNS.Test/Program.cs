using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TNS.Db;

namespace TNS.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime a = new DateTime(2015, 5, 5, 5, 5, 5);
            DateTime b = new DateTime(2015, 5, 5, 5, 2, 3);
            TimeSpan d = a - b;
            Console.Write(d.TotalMinutes);
            Console.Read();
        }
    }
}
