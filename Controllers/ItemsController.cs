using Microsoft.AspNetCore.Mvc;
using TestExe.Models;
using TestExe.Repositories;

namespace TestExe.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _itemsRepository;

        public ItemsController(IItemsRepository repository)
        {
            _itemsRepository = repository;
        }


        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return _itemsRepository.GetItems();
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = _itemsRepository.GetItem(id);
            if (item is null)
            {
                return NotFound();
            }
            return item;
        }


    }
}
