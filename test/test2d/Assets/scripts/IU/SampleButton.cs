using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{
    public Button button;
    public Text nameLabel;
    public Text priceLabel;
    public Image iconImage;

    private Item item;
    private ShopScrollList scrollList;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    public void Setup(Item currentItem, ShopScrollList currentScrollList)
    {
//        Debug.Log(string.Format("currentItem.itemName: {0}", currentItem.itemName));

        item = currentItem;
        //Debug.Log(string.Format("currentItem.itemName: {0}", item.itemName));
        nameLabel.text = currentItem.itemName;
        priceLabel.text = currentItem.price.ToString();
        iconImage.sprite = currentItem.icon;

        scrollList = currentScrollList;
    }

    public void HandleClick()
    {
        scrollList.TryTransferItemToOtherShop(item);
    }
}
