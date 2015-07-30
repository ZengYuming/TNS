using TNS.Db;
using Framework.Core.Model;
using System.Collections.Generic;

namespace TNS.DataService.Interface
{
    public interface IService
    {
        string GetErrorMessage();
        void ClearErrorMessage();
    }
}
