using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkysMvcCatShop.Data;
using SkysMvcCatShop.ViewModels;

namespace SkysMvcCatShop.Controllers
{
    public class InquiryController : Controller
    {
        private readonly ApplicationDbContext _context;

       // public List<SelectListItem> TypesInquiry { get; set; }
        public InquiryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult SendInquiry(InquirySendViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var inq= new Inquiry();
                inq.Name = viewModel.Name;
                inq.Email = viewModel.Email;
                inq.TelephoneNumber = viewModel.TelephoneNumber;
                inq.Text = viewModel.Text;
                inq.Type = viewModel.InquiryType;

                _context.Inquiries.Add(inq);
                _context.SaveChanges();

                return RedirectToAction("ConfirmInquiry");
            }
            //FillInquiryTypes();
            return View(viewModel);
        }

        //private void FillInquiryTypes()
        //{
        //    TypesInquiry= Enum.GetValues<InquiryTypes>()
        //        .Select(i=> new SelectListItem
        //        {
        //            Value = i.ToString(),
        //            Text = i.ToString()
        //        }).ToList();
       // }

        public IActionResult ConfirmInquiry()
        {
            return View();
        }
    }
}
