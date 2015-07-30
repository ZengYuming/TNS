using System;
namespace TNS.Db
{
    public class Manager
    {
        public Manager() { }
        public Manager(string Account, string PassWord)
        {
            this.Account = Account;
            this.PassWord = PassWord;
            Name = String.Empty;
        }
        public Manager(string Account, string PassWord, string Name)
            : this(Account, PassWord)
        {
            this.Name = Name;
        }

        //GUID
        public string ManagerId { get; set; }
        public string Account { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
    }
}
