using GameDrewTotal.Data;
using GameDrewTotal.Services;
using GameDrewTotal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameDrewTotal.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IGameRepository _repository;
        public AppController(IMailService mailService, IGameRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {

            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if(ModelState.IsValid)
            {
                //Send the email
                _mailService.SendMessage("andressafaalr@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            } else
            {
                //Show errors
            }

            return View();
        }


        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        [Authorize]
        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();
            return View(results);
        }

    }
}
