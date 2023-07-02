using System.ComponentModel.DataAnnotations;

namespace VGCApp.Models
{
    public class Review
    {
        public int ID { get; set; }
        public int VideoGameModelID { get; set; }
        [Display(Name = "Username")]
        public string? UName { get; set; }
        [Display(Name = "Review date")]
        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }
        [Display(Name = "Review")]
        public string? ReviewText { get; set;}
    }
}
