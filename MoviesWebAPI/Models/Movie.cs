namespace MoviesWebAPI.Models
{
    public class Movie
    {
       public int id { get; set; }
       public string title { get; set; } 
       public int release_year {get; set;} 
       public string genre_id {get; set;} 
       public string director_id  {get; set;}
       public decimal rating {get; set;} 
       public int box_office {get; set;} 

    }
}
