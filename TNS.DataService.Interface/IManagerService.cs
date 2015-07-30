using TNS.Db;
using Framework.Core.Model;
using System.Collections.Generic;

namespace TNS.DataService.Interface
{
    public interface IManagerService : IService
    {
        IEnumerable<Manager> GetList(PageInfo page);

        Manager Get(int id);

        Manager Get(string account, string passWord);

        //   bool Update(Manager person);
    }
}
