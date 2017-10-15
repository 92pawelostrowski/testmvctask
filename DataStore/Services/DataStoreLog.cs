using DataStore.Data;
using DataStore.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Services
{
    public class DataStoreLog : IDataStorer
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public bool StoreData(LogDTO storeObject)
        {
            try
            {
                var properties = storeObject.GetType().GetProperties();
                var logInfo = string.Join(", ", from prop in properties select prop.GetValue(storeObject, null) ?? "(null)");
                _logger.Log(LogLevel.Info, logInfo);
                return true;
            }
            catch(Exception ex)
            {
                _logger.Error("Unable to log object. " + ex.Message);
                return false;
            }
        }
    }
}
