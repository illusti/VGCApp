using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VGCApp.Models
{
    public class VideoGameModel
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public List<Review>? Reviews { get; set; }
    }
}
