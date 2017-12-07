using UnityEngine;

public static class ItemGen
{
    public static Item CreateItem(int itemID)
    {
        Item temp = new Item();
        string name = "";
        int value = 0;
        string description = "";
        string icon = "";
        string mesh = "";
        ItemType type = ItemType.Food;
        int amount = 0;
        float damage = 0f;
        float heal = 0f;
        float armour = 0f;

        switch (itemID)
        {
            #region Food 0-99
            case 0:
                name = "Apple";
                value = 5;
                description = "Munchies and Crunchies";
                icon = "Apple";
                mesh = "Apple";
                type = ItemType.Food;
                heal = 5f;
                break;
            case 1:
                name = "Meat";
                value = 7;
                description = "Meaty Goodness";
                icon = "Meat";
                mesh = "Meat";
                type = ItemType.Food;
                heal = 7f;
                break;
            #endregion
            #region Weapon 100-199
            case 100:
                name = "Axe";
                value = 5;
                description = "";
                icon = "Axe";
                mesh = "Axe";
                type = ItemType.Weapon;
                break;
            case 101:
                name = "Bow";
                value = 5;
                description = "";
                icon = "Bow";
                mesh = "Bow";
                type = ItemType.Weapon;
                break;
            case 102:
                name = "Shield";
                value = 5;
                description = "";
                icon = "Shield";
                mesh = "Shield";
                type = ItemType.Weapon;
                break;
            case 103:
                name = "Sword";
                value = 5;
                description = "";
                icon = "Sword";
                mesh = "Sword";
                type = ItemType.Weapon;
                break;
            #endregion
            #region Apparel 200-299
            case 200:
                name = "Armour";
                value = 5;
                description = "";
                icon = "Armour";
                mesh = "Armour";
                type = ItemType.Apparel;
                break;
            case 201:
                name = "Belts";
                value = 5;
                description = "";
                icon = "Belts";
                mesh = "Belts";
                type = ItemType.Apparel;
                break;
            case 202:
                name = "Boots";
                value = 5;
                description = "";
                icon = "Boots";
                mesh = "Boots";
                type = ItemType.Apparel;
                break;
            case 203:
                name = "Bracers";
                value = 5;
                description = "";
                icon = "Bracers";
                mesh = "Bracers";
                type = ItemType.Apparel;
                break;
            case 204:
                name = "Cloaks";
                value = 5;
                description = "";
                icon = "Cloaks";
                mesh = "Cloaks";
                type = ItemType.Apparel;
                break;
            case 205:
                name = "Gloves";
                value = 5;
                description = "";
                icon = "Gloves";
                mesh = "Gloves";
                type = ItemType.Apparel;
                break;
            case 206:
                name = "Helmets";
                value = 5;
                description = "";
                icon = "Helmets";
                mesh = "Helmets";
                type = ItemType.Apparel;
                break;
            case 207:
                name = "Necklace";
                value = 5;
                description = "";
                icon = "Necklace";
                mesh = "Necklace";
                type = ItemType.Apparel;
                break;
            case 208:
                name = "Pants";
                value = 5;
                description = "";
                icon = "Pants";
                mesh = "Pants";
                type = ItemType.Apparel;
                break;
            case 209:
                name = "Rings";
                value = 5;
                description = "";
                icon = "Rings";
                mesh = "Rings";
                type = ItemType.Apparel;
                break;
            case 210:
                name = "Shoulders";
                value = 5;
                description = "";
                icon = "Shoulders";
                mesh = "Shoulders";
                type = ItemType.Apparel;
                break;
            #endregion
            #region Crafting 300-399
            case 300:
                name = "Ingots";
                value = 5;
                description = "";
                icon = "Ingots";
                mesh = "Ingots";
                type = ItemType.Crafting;
                break;
            case 301:
                name = "Gem";
                value = 5;
                description = "";
                icon = "Gem";
                mesh = "Gem";
                type = ItemType.Crafting;
                break;
            #endregion
            #region Quests 400-499

            #endregion
            #region Money 500-599
            case 500:
                name = "Coins";
                value = 1;
                description = "";
                icon = "Coins";
                mesh = "Coins";
                type = ItemType.Money;
                break;
            #endregion
            #region Ingredients 600-699

            #endregion
            #region Potions 700-799
            case 700:
                name = "HP";
                value = 100;
                description = "";
                icon = "HP";
                mesh = "HP";
                type = ItemType.Potions;
                break;
            #endregion
            #region Scrolls 800-899
            case 800:
                name = "Scroll";
                value = 5;
                description = "";
                icon = "Scroll";
                mesh = "Scroll";
                type = ItemType.Potions;
                break;
            #endregion
            default:
                name = "Apple";
                value = 5;
                description = "Munchies and Crunchies";
                icon = "Apple";
                mesh = "Apple";
                type = ItemType.Food;
                heal = 5f;
                break;
        }

        temp.ID = itemID;
        temp.Name = name;
        temp.Value = value;
        temp.Description = description;
        temp.Icon = Resources.Load("Icons/" + icon) as Texture2D;
        temp.Mesh = mesh;
        temp.Type = type;
        temp.Amount = amount;
        temp.Damage = damage;
        temp.Heal = heal;
        temp.Armour = armour;
        return temp;
    }
}