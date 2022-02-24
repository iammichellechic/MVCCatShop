using Microsoft.AspNetCore.Mvc.Rendering;
using SkysMvcCatShop.Data;
using System.ComponentModel.DataAnnotations;

namespace SkysMvcCatShop.ViewModels
{
    public class InquirySendViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        [DataType(DataType.Text)]
        [MaxLength(512)]
        public string Text { get; set; }
        public InquiryTypes InquiryType { get; set; }

    
    }
}
