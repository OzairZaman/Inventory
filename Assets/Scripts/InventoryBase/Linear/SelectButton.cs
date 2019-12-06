using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    #region Variables
    public Text myButtonText;
    public int index;
    public RawImage itemIcon;
    public Text itemName;
    public Text itemDescription;
    #endregion
    void Start()
    {
        //getiing references to UI elements that will be holding different info
        myButtonText = GetComponentInChildren<Text>();
        itemIcon = GameObject.FindGameObjectWithTag("MainIcon").GetComponent<RawImage>();
        itemName = GameObject.FindGameObjectWithTag("ItemName").GetComponent<Text>();
        itemDescription = GameObject.FindGameObjectWithTag("ItemDesc").GetComponent<Text>();
    }


    void Update()
    {
        
    }

    /// <summary>
    /// This method will use index to access particular
    /// part index of the statci list inventory.
    /// This gets call by OnClick event
    /// </summary>
    public void ShowSelectedItem()
    {
        myButtonText.text = LinearCanvasInventory.inv[index].Name;
        itemIcon.CrossFadeAlpha(255, 0.01f, false);
        itemIcon.texture = LinearCanvasInventory.inv[index].Icon;
        itemName.text = LinearCanvasInventory.inv[index].Name;
        itemDescription.text = LinearCanvasInventory.inv[index].Description;
        gameObject.tag = "button"+index;
        //remember the selection
        LinearCanvasInventory.userSelected = index; // used for discard, but needs rework. See notes in DiscardItem();
        Debug.Log(name + " | " + index + " | " + gameObject.tag);
    }

    public void DiscardItem()
    {
        //Note: The discard will need a major rework of the way the index 
        //the way list works and the way button representing an iten in 
        //the invetory is indexed. button ID's are startic and List index is
        //dynamically adjusted. This after deleting we 
        
        
        ////find a reference to the button that is selected
        //string tag = "button" + LinearCanvasInventory.userSelected;
        //GameObject button = GameObject.FindGameObjectWithTag(tag);
        ////remove item from inv

        ////destroy the UI button
        //if (button)
        //{
        //    Destroy(button);
        //    LinearCanvasInventory.maxInventorySpace--;
        //    //clean up UI
        //    GameObject.FindGameObjectWithTag("MainIcon").GetComponent<RawImage>().CrossFadeAlpha(0, 0.125f, false);
        //    GameObject.FindGameObjectWithTag("ItemName").GetComponent<Text>().text = "";
        //    GameObject.FindGameObjectWithTag("ItemDesc").GetComponent<Text>().text = "";
        //}
        
    }
}
