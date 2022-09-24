using TestExe.Models;

namespace TestExe.Repositories
{
    public interface IItemsRepository
    {
        Item? GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}