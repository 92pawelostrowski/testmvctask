using DataStore.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStore.Data;

namespace DataStore
{
    public class Storer
    {
        IDataStorer _storeService;

        public Storer(IDataStorer storeService)
        {
            _storeService = storeService;
        }

        public bool FetchFormData<TDest>(TDest formData) where TDest : new()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<TDest, LogDTO>();
            });
            var loggedObject = Mapper.Map<TDest, LogDTO>(formData);

            _storeService.StoreData(loggedObject);

            return true;
        }
    }
}
