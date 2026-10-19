using dotnetbackend.Contexts;
using dotnetbackend.Exceptions;
using dotnetbackend.Models;
using dotnetbackend.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace dotnetbackend.Services;

public interface IService
{
       Task<GetCharacterInfoResponseModel> GetCharacterInfoAsync(int id);
       Task<List<PostSlotResponseModel>> AddToInventory(int characterId,List<int> itemIds);
}

public class Service(DatabaseContext context) : IService
{
       public async Task<GetCharacterInfoResponseModel> GetCharacterInfoAsync(int id)
       {
           Character? character = await GetCharacterByIdAsync(id);
           var result = new GetCharacterInfoResponseModel()
           {
                firstName = character.CharacterFirstName,
                lastName = character.CharacterLastName,
                currentWeight = character.CharacterCurrentWeight,
                maxWeight = character.CharacterMaxWeight,
                money = character.CharacterMoney,
                backpackSlots = await context.BackpackSlots.Where(e=>e.CharacterId==id)
                    .Join(context.Items,slot=>slot.ItemId,item=>item.ItemId, (slot, item) => new BackpackSlotResponseModel()
                    {
                        slotId = slot.BackpackSlotId,
                        itemName = item.ItemName,
                        itemWeight = item.ItemWeight
                    }).ToListAsync(),
                titles = await context.CharacterTitles.Where(e=>e.CharacterId==id)
                    .Join(context.Titles,ct=>ct.TitleId,t=>t.TitleId,(ct,t)=>new TitleResponseModel()
                    {
                        title = t.TitleName,
                        aquired_at = ct.CharacterTitleAquireAt
                    }).ToListAsync()
           };
           return result;
       }

       public async Task<List<PostSlotResponseModel>> AddToInventory(int characterId, List<int> itemIds)
       {
           Character? character = await GetCharacterByIdAsync(characterId);
           var items = await GetSelectedItems(itemIds);
           var weightToAdd = items.Select(e => e.ItemWeight).Sum();
           if (character.CharacterCurrentWeight + weightToAdd > character.CharacterMaxWeight)
           {
               throw new BadRequestException("Character cannot lift that much");
           }

           var slotsToAdd = items.Select(e => new BackpackSlot()
           {
               CharacterId = character.CharacterId,
               ItemId = e.ItemId
           }).ToList();
           await context.BackpackSlots.AddRangeAsync(slotsToAdd);
           await context.SaveChangesAsync();
           var result = slotsToAdd.Select(e => new PostSlotResponseModel()
           {
               slotId = e.BackpackSlotId,
               characterId = e.CharacterId,
               itemId = e.ItemId
           }).ToList();
           return result;
       }

       private async Task<List<Item>> GetSelectedItems(List<int> ids)
       {
           string? missing = LookForMissing(ids);
           if (missing is not null)
           {
               throw new NotFoundException("Items of ids " + missing + "not found");
           }
           //var items = await context.Items.Where(e => ids.Contains(e.ItemId)).ToListAsync(); //stare
           var items = await context.Items
               .Join(ids, item => item.ItemId, id => id, (item, id) => item)
               .ToListAsync();
           return items;
       }

       private async Task<Character?> GetCharacterByIdAsync(int id)
       {
           Character character =  await context.Characters.Where(e => e.CharacterId == id).FirstOrDefaultAsync();
           if (character is null)
           {
               throw new NotFoundException("Character of id " + id + " not found");
           }

           return character;
       }

       private string? LookForMissing(List<int> items)
       {
           var all = context.Items.Select(e => e.ItemId).Distinct().ToList();
           var notFound = items.Except(all);
           if (notFound.Any())
           {
               string missing = "";
               foreach (int id in notFound)
               {
                   missing += id;
                   missing += ',';
               }

               if (missing[missing.Length - 1] == ',')
               {
                   missing = missing.Substring(0, missing.Length - 1);
               }
               return missing;
           }
           return null;
       }
}