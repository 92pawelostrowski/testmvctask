using DataStore.Data;
using DataStore.Interfaces;
using NLog;
using System;

namespace DataStore.Services
{
    public class DataStoreDB : IDataStorer
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public bool StoreData(LogDTO storeObject)
        {
            try
            {
                using (var db = new TestExerciseDBEntities())
                {
                    db.Database.CreateIfNotExists();
                    var storeData = db.Set<StoreData>();
                    storeData.Add(new StoreData { Name = storeObject.Name, Surname = storeObject.Surname });
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Unable to store object in db. " + ex.Message);
                return false;
            }
            return true;
        }
    }
}
