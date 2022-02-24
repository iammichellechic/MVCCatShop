using System.ComponentModel.DataAnnotations;

namespace SkysMvcCatShop.Data
{
    public class Inquiry
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(
            @"^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$",
            ErrorMessage = "Enter a valid phone number")]
        public string TelephoneNumber { get; set; }
        [DataType(DataType.Text)]
        [MaxLength(512)]
        public string Text { get; set; }
        public InquiryTypes Type { get; set; }
    }
}
