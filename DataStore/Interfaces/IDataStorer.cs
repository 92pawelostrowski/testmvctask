using DataStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Interfaces
{
    public interface IDataStorer
    {
        bool StoreData(LogDTO storeObject);
    }
}
