﻿using Core.DTOs;
using Core.Entities;

namespace API.Helper
{
    public static class UpdateEntitiesHelper
    {
        public static void UpdateStore(Store store, StoreDto storeDto)
        {
            if (storeDto.Name != null)
                store.Name = storeDto.Name;

            //if (storeDto.Address != null)
            //    store.Address = storeDto.Address;

            if (storeDto.Description != null)
                store.Description = storeDto.Description;

            store.ModifiedDate = DateTime.Now;

            if (storeDto.PhoneNumber != null)
                store.PhoneNumber = storeDto.PhoneNumber;

            //if (storeDto.EmailAddress != null)
            //    store.EmailAddress = storeDto.EmailAddress;

            //if(storeDto.Serial != null)
            //    store.Serial = storeDto.Serial;



            //return store;

        }
    }
}
