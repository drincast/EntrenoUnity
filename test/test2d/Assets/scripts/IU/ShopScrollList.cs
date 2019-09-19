using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public float price = 1f;
}

public class ShopScrollList : MonoBehaviour
{
    public List<Item> itemList;
    public Transform contentPanel;
    public ShopScrollList otherShop;
    public Text myGoldisplay;
    public SimpleObjectPool buttonObjectPool;
    public float gold = 20f;

    void Start() {
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        //myGoldisplay.text = "Gold: " + gold.ToString();
        RemoveButtons();
        AddButtons();
    }

    private void AddButtons()
    {
        //Debug.Log(string.Format("itemList.Count: {0}", itemList.Count));
        for(int i = 0; i < itemList.Count; i++)
        {
            Item item = itemList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(item, this);
        }

    }

    private void RemoveButtons()
    {
        while(contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    public void TryTransferItemToOtherShop(Item item)
    {
        Debug.Log(string.Format("item: {0} - otherShop.gold: {1} - item.price: {2}", item.itemName, otherShop.gold, item.price));


        if(otherShop.gold >= item.price)
        {
            Debug.Log(string.Format("adicionar item ok: {0}", item.itemName));
            gold += item.price;
            otherShop.gold -= item.price;
            AddItem(item, otherShop);
            RemoveItem(item, this);

            RefreshDisplay();
            otherShop.RefreshDisplay();
        }
    }

    private void AddItem(Item itemToAdd, ShopScrollList shopList)
    {
        shopList.itemList.Add(itemToAdd);
    }

    private void RemoveItem(Item itemToRemove, ShopScrollList shopList)
    {
        for(int i = shopList.itemList.Count -1; i >= 0; i--)
        {
            if(shopList.itemList[i] == itemToRemove)
            {
                shopList.itemList.RemoveAt(i);
                break;
            }
        }
    }
}

