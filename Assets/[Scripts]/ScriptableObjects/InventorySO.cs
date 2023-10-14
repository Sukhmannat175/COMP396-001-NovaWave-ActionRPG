using System.Runtime.Serialization;
using System;
using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(fileName = "New Inventory Object", menuName = "ScriptableObejcts/Create New Inventory Object")]
public class InventorySO : ScriptableObject
{
    // public string savePath;
    public ItemDatabaseSO database;
    public Inventory Container;

    public void AddItem(Item _item, int _amount)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i].ID == _item.Id)
            {
                Container.Items[i].AddAmount(_amount);
                return;
            }
        }
        SetEmptySlot(_item, _amount);
    }

    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i].ID <= -1)
            {
                Container.Items[i].UpdateSlot(_item.Id, _item, _amount);
                return Container.Items[i];
            }
        }
        // Set up UI to show inventory is full
        return null;
    }

    public void MoveItem(InventorySlot item1, InventorySlot item2)
    {
        InventorySlot temp = new InventorySlot(item2.ID, item2.item, item2.amount);
        item2.UpdateSlot(item1.ID, item1.item, item1.amount);
        item1.UpdateSlot(temp.ID, temp.item, temp.amount);
    }

    public void RemoveItem(Item _item)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i].item == _item)
            {
                Container.Items[i].UpdateSlot(-1, null, 0);
            }
        }
    }

    // Should not save and load only for inventory?
    // [ContextMenu("Save")]
    // public void Save()
    // {
    //     IFormatter formatter = new BinaryFormatter();
    //     Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
    //     formatter.Serialize(stream, Container);
    //     stream.Close();
    // }

    // [ContextMenu("Load")]
    // public void Load()
    // {
    //     if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
    //     {
    //         IFormatter formatter = new BinaryFormatter();
    //         Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
    //         Container = (Inventory)formatter.Deserialize(stream);
    //         stream.Close();
    //     }
    // }

    // [ContextMenu("Clear")]
    // public void Clear()
    // {
    //     Container = new Inventory();
    // }
}

//
// Inventory class
//
[System.Serializable]
public class Inventory
{
    // implement a logic to put same nunber to InventorySlot for Player.OnApplicationQuit()
    public InventorySlot[] Items = new InventorySlot[48];
}

//
// InventorySlot class
//
[System.Serializable]
public class InventorySlot
{
    public int ID = -1;
    public Item item;
    public int amount;

    // Constructor
    public InventorySlot()
    {
        ID = -1;
        item = null;
        amount = 0;
    }

    public InventorySlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }

    public void UpdateSlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

}