using UnityEngine;
using System.Collections;

public class Item
{
    public enum ItemTypes { Wachs, Docht };

    public ItemTypes itemType;
    public float einkaufsPreis;
    public float verkaufsPreis;
    public float stufe;
    public float schwierigkeit; 


    public Item(ItemTypes itemType, float einkaufsPreis, float verkaufsPreis, float stufe, float schwierigkeit)
    {
        this.itemType = itemType;
        this.einkaufsPreis = einkaufsPreis;
        this.verkaufsPreis = verkaufsPreis;
        this.stufe = stufe;
        this.schwierigkeit = schwierigkeit;
    }

}
