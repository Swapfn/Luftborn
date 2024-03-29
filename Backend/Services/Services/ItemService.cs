﻿using AutoMapper;
using Data.Infrastructure;
using Data.Repositories.Contracts;
using Models.Models;
using Services.Contracts;

namespace Services.Services
{
    public class ItemService(IUnitOfWork unitOfWork, IItemRepository ItemRepository, IMapper mapper) : IItemService
    {
        public ItemDTO AddItem(ItemDTO model)
        {
            Item Item = mapper.Map<Item>(model);
            ItemRepository.Add(Item);
            unitOfWork.SaveChanges();
            var x = mapper.Map<ItemDTO>(Item);
            return x;
        }

        public void DeleteItem(int id)
        {
            Item Item = mapper.Map<Item>(ItemRepository.GetById(id));
            if (Item != null)
            {
                ItemRepository.Delete(Item);
                unitOfWork.SaveChanges();
            }
        }

        public ItemDTO GetItem(int id)
        {
            return mapper.Map<ItemDTO>(ItemRepository.GetById(id));

        }

        public ICollection<ItemDTO> GetItems()
        {
            return mapper.Map<List<ItemDTO>>(ItemRepository.GetAll());
        }

        public (ICollection<ItemDTO> Items, int Count) GetItems(int pageNumber, int pageSize)
        {
            var Items = ItemRepository.GetAll(pageNumber, pageSize);
            var count = Items.Count;
            var map = mapper.Map<List<ItemDTO>>(Items.Items);
            return (map, count);
        }

        public ItemDTO UpdateItem(ItemDTO model)
        {
            Item Item = mapper.Map<Item>(model);
            ItemRepository.Update(Item);
            unitOfWork.SaveChanges();
            return mapper.Map<ItemDTO>(Item);
        }
    }
}
