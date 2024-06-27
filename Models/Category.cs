namespace SPA.Models
{
    public class Category
    {
        public int CateID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Film> Films { get; set; }
    }
}
