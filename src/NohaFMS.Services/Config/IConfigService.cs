using NohaFMS.Core.Domain;
using System.Collections.Generic;

namespace NohaFMS.Services
{
    public interface IConfigService : IBaseService
    {
        List<Config> GetAllKeys();
    }
}
