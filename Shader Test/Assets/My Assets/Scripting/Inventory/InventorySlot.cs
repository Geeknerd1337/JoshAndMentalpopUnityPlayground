using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
    Item item;
    public Image icon;
    //public Button removeButton;

    [SerializeField]
    public ToolTip tip;



    public void Awake()
    {
  

        tip = FindObjectOfType<ToolTip>();
    }

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        //removeButton.interactable = true;
        

    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        //removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        //Inventory.instance.Remove(item);
    }


    public void UseItem()
    {
        if(item != null && !tip.gameObject.activeSelf)
        {
            tip.ToggleMe(item, transform, this);
            tip.gameObject.SetActive(true);
            Debug.Log("Selected");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (item != null)
        {
        }
    }
}
