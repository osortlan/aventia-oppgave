using System.ComponentModel.DataAnnotations;

public class StreamSessionDao
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;
}