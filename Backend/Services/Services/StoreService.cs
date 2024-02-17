using AutoMapper;
using Data.Infrastructure;
using Data.Repositories.Contracts;
using Models.Models;
using Services.Contracts;

namespace Services.Services
{
    public class StoreService(IUnitOfWork unitOfWork, IStoreRepository storeRepository, IMapper mapper) : IStoreService
    {
        public StoreDTO AddStore(StoreDTO model)
        {
            Store store = mapper.Map<Store>(model);
            storeRepository.Add(store);
            unitOfWork.SaveChanges();
            var x = mapper.Map<StoreDTO>(store);
            return x;
        }

        public void DeleteStore(int id)
        {
            Store store = mapper.Map<Store>(storeRepository.GetById(id));
            if (store != null)
            {
                storeRepository.Delete(store);
                unitOfWork.SaveChanges();
            }
        }

        public StoreDTO GetStore(int id)
        {
            return mapper.Map<StoreDTO>(storeRepository.GetById(id));

        }
        public ICollection<ItemDTO> GetStores(int pageNumber, int pageSize)
        {
            return mapper.Map<List<ItemDTO>>(storeRepository.GetAll(pageNumber, pageSize));
        }

        public ICollection<StoreDTO> GetStores()
        {
            return mapper.Map<List<StoreDTO>>(storeRepository.GetAll());
        }

        public StoreDTO UpdateStore(StoreDTO model)
        {
            Store store = mapper.Map<Store>(model);
            storeRepository.Update(store);
            unitOfWork.SaveChanges();
            return mapper.Map<StoreDTO>(store);
        }
    }
}
