using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dotnetbackend.Models;
[Table("Character_Titles")]
[PrimaryKey("CharacterId","TitleId")]
public class CharacterTitle
{
    [Column("FK_charact")][ForeignKey("Character")]
    public int CharacterId { get; set; }
    public Character Character { get; set; }
    
    [Column("FK_title")][ForeignKey("Title")]
    public int TitleId { get; set; }
    public Title Title { get; set; }
    
    [Column("aquire_at")]
    public DateTime CharacterTitleAquireAt { get; set; }
}