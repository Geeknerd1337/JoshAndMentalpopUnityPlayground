using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public bool consumable = false;

    [TextArea(3,10)]
    public string description = "Item Description";

    public virtual void Use()
    {
        //Use the item
        Debug.Log("Using" + name);
    }

}
