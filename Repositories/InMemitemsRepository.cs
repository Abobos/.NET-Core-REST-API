using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Catalog.Entities;
using Catalog.Interfaces;

namespace Catalog.Repositories
{
    public class InMemItemsRepository : IItemRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Rollins", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Shirt", Price = 18, CreatedDate = DateTimeOffset.UtcNow }
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }
         
        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();

            return await Task.FromResult(item);

        } 

        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);

            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var itemIndex = items.FindIndex(existingItem => existingItem.Id == item.Id);

            items[itemIndex] = item;

            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var itemIndex = items.FindIndex(existingItem => existingItem.Id == id);

            items.RemoveAt(itemIndex);

            await Task.CompletedTask;
        }
    }
}