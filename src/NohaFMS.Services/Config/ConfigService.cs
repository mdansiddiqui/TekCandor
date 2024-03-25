using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace NohaFMS.Services
{
    class ConfigService:BaseService
    {
        private readonly IRepository<Config> _configRepository;


        public virtual List<Config> GetAllKeys(bool callback, string dateto, string datefrom)
        {

            string dt = dateto;
            string df = datefrom;

            if (string.IsNullOrEmpty(dt) && string.IsNullOrEmpty(df))
            {
                //date_to = DateTime.Today;
                //date_from = DateTime.Today;
                var result = _configRepository.GetAll().ToList();

                return result;
            }
            //var assets = _chequeDepositRepository.GetAll().Where(c => c.Callback == callback && c.Date>=DT && c.Date>= Df).OrderBy(c => c.Date).ToList();

            return new List<Config>();
        }
    }
}
