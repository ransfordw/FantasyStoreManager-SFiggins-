using FantasyStoreManager.Data;
using FantasyStoreManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyStoreManager.Services
{
    public class StoreService
    {
        private readonly Guid _userId;

        public StoreService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateStore(StoreCreate model)
        {
            var entity = new Store()
            {
                OwnerId = _userId,
                Name = model.Name,
                Location = model.Location,
                TypeofStore = model.TypeOfStore
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Stores.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StoreListItem> GetStores()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Stores.Where(e => e.OwnerId == _userId).Select(e => new StoreListItem
                {
                    StoreId = e.StoreId,
                    Name = e.Name,
                    Location = e.Location,
                    TypeOfStore = e.TypeofStore
                });

                return query.ToArray();
            }
        }

        public StoreDetail GetStoreById(int storeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Stores.Single(e => e.StoreId == storeId && e.OwnerId == _userId);
                return new StoreDetail
                {
                    StoreId = entity.StoreId,
                    Name = entity.Name,
                    Location = entity.Location,
                    TypeOfStore = entity.TypeofStore
                };
            }
        }

        public bool UpdateStore(StoreEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Stores.Single(e => e.StoreId == model.StoreId && e.OwnerId == _userId);
                entity.Name = model.Name;
                entity.Location = model.Location;
                entity.TypeofStore = model.TypeOfStore;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStore(int storeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Stores.Single(e => e.StoreId == storeId && e.OwnerId == _userId);
                ctx.Stores.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
    
}
