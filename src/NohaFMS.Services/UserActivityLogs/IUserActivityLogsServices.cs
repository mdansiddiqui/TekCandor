

namespace NohaFMS.Services
{
    public partial interface IUserActivityLogsServices : IBaseService
    {
        void InsertUserActivityData(long uid, string description);

    }
}
