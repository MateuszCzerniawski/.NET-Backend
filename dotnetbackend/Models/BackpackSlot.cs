using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetbackend.Models;
[Table("Backpack_Slots")]
public class BackpackSlot
{
    [Key][Column("PK")]
    public int BackpackSlotId { get; set; }
    
    [Column("FK_item")][ForeignKey("Item")]
    public int ItemId { get; set; }
    public Item Item { get; set; }
    
    [Column("FK_character")][ForeignKey("Character")]
    public int CharacterId { get; set; }
    public Character Character { get; set; }
}