using dotnetbackend.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetbackend.Contexts;

public class DatabaseContext : DbContext
{
    
    public DbSet<BackpackSlot> BackpackSlots { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Character>().HasData(new List<Character>()
        {
            new Character()
            {
                CharacterId = 1,
                CharacterFirstName = "Jan",
                CharacterLastName = "Biały",
                CharacterCurrentWeight = 30,
                CharacterMaxWeight = 100,
                CharacterMoney = 123
            },
            new Character()
            {
                CharacterId = 2,
                CharacterFirstName = "Geralt",
                CharacterLastName = "Kowalski",
                CharacterCurrentWeight = 24,
                CharacterMaxWeight = 200,
                CharacterMoney = 456
            }
        });
        modelBuilder.Entity<Item>().HasData(new List<Item>()
        {
            new Item()
            {
                ItemId = 1,
                ItemName = "Miecz",
                ItemWeight = 20
            },
            new Item()
            {
                ItemId = 2,
                ItemName = "Tarcza",
                ItemWeight = 10
            },
            new Item()
            {
                ItemId = 3,
                ItemName = "Chleb",
                ItemWeight = 1
            }
        });
        modelBuilder.Entity<Title>().HasData(new List<Title>()
        {
            new Title()
            {
                TitleId = 1,
                TitleName = "Biedak"
            },
            new Title()
            {
                TitleId = 2,
                TitleName = "Szlachic"
            },
            new Title()
            {
                TitleId = 3,
                TitleName = "Uczony"
            }
        });
        modelBuilder.Entity<BackpackSlot>().HasData(new List<BackpackSlot>(){
            new BackpackSlot()
            {
                BackpackSlotId = 1,
                CharacterId = 1,
                ItemId = 1,
            },
            new BackpackSlot()
            {
                BackpackSlotId = 2,
                CharacterId = 1,
                ItemId = 2,
            },
            new BackpackSlot()
            {
                BackpackSlotId = 3,
                CharacterId = 2,
                ItemId = 3,
            },
            new BackpackSlot()
            {
                BackpackSlotId = 4,
                CharacterId = 2,
                ItemId = 3,
            },
            new BackpackSlot()
            {
                BackpackSlotId = 5,
                CharacterId = 2,
                ItemId = 3,
            },
            new BackpackSlot()
            {
                BackpackSlotId = 6,
                CharacterId = 2,
                ItemId = 3,
            },
            new BackpackSlot()
            {
                BackpackSlotId = 7,
                CharacterId = 2,
                ItemId = 1,
            }
        });
        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>()
        {
            new CharacterTitle()
            {
                CharacterId = 1,
                TitleId = 2,
                CharacterTitleAquireAt = new DateTime(2024,6,11)
            },
            new CharacterTitle()
            {
                CharacterId = 1,
                TitleId = 3,
                CharacterTitleAquireAt = new DateTime(2024,6,11)
            },
            new CharacterTitle()
            {
                CharacterId = 2,
                TitleId = 1,
                CharacterTitleAquireAt = new DateTime(2024,6,11)
            }
        });
    }
}