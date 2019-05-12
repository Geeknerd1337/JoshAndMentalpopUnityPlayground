using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Item> items = new List<Item>();

    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one inventory in scene");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    [SerializeField]
    public OnItemChanged OnItemChangedCallback;


    public int space = 9;

    

    public bool Add(Item item)
    {
        if(items.Count >= space)
        {
            return false;
        }

        items.Add(item);

        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {

        items.Remove(item);

        if (OnItemChangedCallback != null)
        {

            OnItemChangedCallback.Invoke();
        }
        
    }
}
