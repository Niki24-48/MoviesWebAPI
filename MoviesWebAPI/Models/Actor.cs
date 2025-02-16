namespace MoviesWebAPI.Models
{
    public class Actor
    {
        public int id { get; set; }
        public string name  {get; set;}
        public DateOnly? birth_year { get; set; }
        public string nationality {get; set;}
    }
}
