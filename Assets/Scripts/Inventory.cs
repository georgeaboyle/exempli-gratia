using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            //Debug.LogWarning("More than one instance of Inventory found!!!!");
            Debug.LogWarning("Removing duplicate Inventory instance.");
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    
    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("No space in inventory.");
                return false;
            }
            items.Add(item);

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    
    public List<Item> GetList()
    {
        return items;
    }

    
    public bool HasItem(string name)
    {
        foreach (Item item in items)
        {
            if (item.name == name)
            {
                return true;
            }
        }
        return false;
    }

    // Using reference to Item object instead of string name
    public bool HasItem(Item itemToCheck)
    {
        foreach (Item item in items)
        {
            if (item == itemToCheck)
            {
                return true;
            }
        }
        return false;
    }
}
