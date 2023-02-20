using System.ComponentModel.DataAnnotations;



public class NameModel

{
    [Required(ErrorMessage = "Please enter your name...")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters long...")]
    public string? Name {get; set;}

}