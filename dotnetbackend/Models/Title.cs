using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetbackend.Models;
[Table("Titles")]
public class Title
{
    [Key][Column("PK")]
    public int TitleId { get; set; }
    
    [Column("nam")][MaxLength(100)]
    public string TitleName { get; set; }
    
    public IEnumerable<CharacterTitle> CharacterTitles { get; set; }
}