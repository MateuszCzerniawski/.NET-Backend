using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetbackend.Models;
[Table("Items")]
public class Item
{
    [Key][Column("PK")]
    public int ItemId { get; set; }
    
    [Column("name")][MaxLength(50)]
    public string ItemName { get; set; }
    
    [Column("wieg")]
    public int ItemWeight { get; set; }
    
    public IEnumerable<BackpackSlot> BackpackSlots { get; set; }
}