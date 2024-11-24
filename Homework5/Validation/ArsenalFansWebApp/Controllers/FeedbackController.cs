using Microsoft.AspNetCore.Mvc;
using ArsenalFansWebApp.Models;
using ArsenalFansWebApp.Validation;

namespace ArsenalFansWebApp.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FeedbackViewModel feedbackViewModel)
        {
            var validator = new FeedbackViewModelValidator();
            var validationResult = validator.Validate(feedbackViewModel);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(feedbackViewModel);
            }

            //Code for working with feedback. For example, data mapping and _feedbackService.Send(feedbackDto)

            TempData["SuccessMessage"] = "Feedback submitted successfully!";

            return RedirectToAction("Index");
        }
    }
}