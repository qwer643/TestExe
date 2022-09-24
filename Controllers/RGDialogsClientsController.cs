using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Linq;
using TestExe.Models;

namespace TestExe.Controllers
{

    [ApiController]
    [Route("getClients")]
    public class RGDialogsClientsController : ControllerBase
    {
        private readonly RGDialogsClients _rgDialogsClients;
        private readonly List<RGDialogsClients> _listOfDialogs;

        public RGDialogsClientsController()
        {
            _rgDialogsClients = new RGDialogsClients();
            _listOfDialogs = _rgDialogsClients.Init();
        }

        // Весь список клиентов и диалогов
        //[HttpGet]
        //public List<RGDialogsClients> GetAll() 
        //{
        //    return _listOfDialogs;
        //}

        // Клиенты для диалога по GUID
        //[HttpGet]
        //public IEnumerable<RGDialogsClients> GetClients(Guid dialogGuid) 
        //{
        //    return _listOfDialogs.Where( rgDialog => rgDialog.IDRGDialog == dialogGuid);
        //}

        // Диалог по списку GUID клиентов
        [HttpGet]
        public Guid GetDialog([FromQuery] List<Guid> clientsInput)
        {
            // Сгруппировать список
            var groupByDialog =
                from rgDialog in _listOfDialogs
                group rgDialog by rgDialog.IDRGDialog into dialogGroup
                select dialogGroup;

            // Для групп - провести сравнение с входным списком ID
            foreach (var dialogGroup in groupByDialog)
            {
                if (dialogGroup.Count() == clientsInput.Count())
                {
                    if (DialogGroupToList(dialogGroup).All(clientsInput.Contains)) {
                        return dialogGroup.Key;
                    }
                }
            }
            return Guid.Empty;
        }

        private List<Guid> DialogGroupToList( IGrouping<Guid, RGDialogsClients> dialogGroup)
        {
            List<Guid> clients = new();
            foreach (var client in dialogGroup)
            {
                clients.Add( client.IDClient );
            }
            return clients;
        }
    }

}
