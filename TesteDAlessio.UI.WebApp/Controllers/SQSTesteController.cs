using Amazon.SQS;
using Microsoft.AspNetCore.Mvc;
using TesteDAlessio.Domain.Entities;
using TesteDAlessio.UI.WebApp.Helpers;
using TesteDAlessio.UI.WebApp.Models;

namespace TesteDAlessio.UI.WebApp.Controllers
{
    public class SQSTesteController : Controller
    {
        IAWSSQSService _awsSqsService;

        public SQSTesteController(IAWSSQSService awsSqsService)
        {
            _awsSqsService = awsSqsService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new SQSTesteModel();
            
            model.Messages = await _awsSqsService.GetAllMessagesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("MessageBody")] SQSTesteModel model)
        {

            var envioOK = false;
            if (model.MessageBody != null)
                envioOK = await _awsSqsService.PostMessageAsync(model.MessageBody);

            model.Messages = await _awsSqsService.GetAllMessagesAsync();

            return View(model);
        }
    }
}
