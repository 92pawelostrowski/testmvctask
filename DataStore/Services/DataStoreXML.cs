using DataStore.Data;
using DataStore.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                List<LogDTO> dtoList = new List<LogDTO>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<LogDTO>));
                if (File.Exists(@"C:\ExerciseApp\serialized.xml"))
                {
                    using (var stream = new FileStream(@"C:\ExerciseApp\serialized.xml", FileMode.Open))
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
                    System.IO.Directory.CreateDirectory(Path.GetDirectoryName(@"C:\ExerciseApp\serialized.xml"));
                }
                using (var stream = new FileStream(@"C:\ExerciseApp\serialized.xml", FileMode.Create))
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
