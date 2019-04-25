using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Item> items = new List<Item>();
    public List<int> quants = new List<int>();

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


    public int space = 20;

    public bool Add(Item item)
    {
        if(items.Count >= space)
        {
            return false;
        }

        if (!items.Contains(item))
        {
            items.Add(item);
            quants.Add(1);
        }
        else
        {
            for(var i = 0; i < items.Count; i++)
            {
                if(items[i] == item)
                {
                    quants[i]++;
                }
            }
        }

        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i] == item)
            {
                if(quants[i] > 1)
                {
                    quants[i]--;
                }
                else
                {
                    quants.RemoveAt(i);
                    items.Remove(item);
                }
            }
        }   

        if (OnItemChangedCallback != null)
        {
            Debug.Log("Hello4");
            OnItemChangedCallback.Invoke();
        }
        
    }
}
