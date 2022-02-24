using System.ComponentModel.DataAnnotations;

namespace SkysMvcCatShop.Data
{
    public enum InquiryTypes
    {
        [Display(Name ="Type of inquiry:")]
        Support,
        Sales,
        Collaboration,
        Others
    }
}
