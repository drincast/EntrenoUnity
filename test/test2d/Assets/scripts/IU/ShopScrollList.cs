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
}

