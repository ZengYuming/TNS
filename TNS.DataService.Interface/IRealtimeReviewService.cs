using System.Collections.Generic;
using TNS.Db;

namespace TNS.DataService.Interface
{
    public interface IRealtimeReviewService
    {
        List<RealtimeReview> GetList(TNS.Metadata.Query.QRealtimeReview condition);
        List<RealtimeReview> GetList_Stubbing(TNS.Metadata.Query.QRealtimeReview condition, string jsonPath);
    }
}
