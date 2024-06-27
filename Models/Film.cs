using System.ComponentModel.DataAnnotations.Schema;

namespace SPA.Models
{
    public class Film
    {
        public int FilmID { get; set; }
        public string Name { get; set;}
        public string Description { get; set;}
        public int CateID { get; set; }
        [ForeignKey("CateID")]
        public Category Categories { get; set; }
    }
}
