namespace dotnetbackend.ResponseModels;

public class GetCharacterInfoResponseModel
{
    
    public string firstName { get; set; }
    
    public string lastName { get; set; }
    
    public int currentWeight { get; set; }
    
    public int maxWeight { get; set; }
    
    public int money { get; set; }
    
    public List<BackpackSlotResponseModel> backpackSlots { get; set; }
    public List<TitleResponseModel> titles { get; set; }
}

public class BackpackSlotResponseModel
{
    public int slotId { get; set; }
    
    public string itemName { get; set; }
    
    public int itemWeight { get; set; }
}

public class TitleResponseModel
{
    public string title { get; set; }
    public DateTime aquired_at { get; set; }
}