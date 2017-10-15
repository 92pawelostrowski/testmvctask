using DataStore.Data;
using DataStore.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DataStore.Services
{
    public class DataStoreXML : IDataStorer
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public bool StoreData(LogDTO storeObject)
        {
            try
            {
                var directory = ConfigurationSettings.AppSettings["DirXML"] ?? @"C:\ExerciseApp\serialized.xml";

                List<LogDTO> dtoList = new List<LogDTO>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<LogDTO>));
                if (File.Exists(directory))
                {
                    using (var stream = new FileStream(directory, FileMode.Open))
                    {
                        XmlReader reader = XmlReader.Create(stream);
                        if (serializer.CanDeserialize(reader))
                        {
                            dtoList = (List<LogDTO>)serializer.Deserialize(reader);
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(directory));
                }
                using (var stream = new FileStream(directory, FileMode.Create))
                {
                    dtoList.Add(storeObject);
                    serializer.Serialize(stream, dtoList);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error("Unable to save to xml. " + ex.Message);
                return false;
            }
        }
    }
}
