using System.ComponentModel.DataAnnotations;

namespace DocSeeker.API.News.Resources;

public class SaveNewResource
{

    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Description{ get; set; }
    
    [Required]
    public string ImageUrl { get; set; }
}