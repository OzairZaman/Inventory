using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class SaveItems : MonoBehaviour
{
    //what do we save
    string user; 
    string ItemsTosave; // we will concatinate all item ID from the inv List
    public GameObject alert;
    public RawImage saved;
    string s = "";

    private void Start()
    {
        user = myGuy.takeToNexScene; // this stores the user name from our log in scene that got passed to this scene.
        //Debug.Log(user);
        //StringifyTheItems();
    }


    IEnumerator Save(string _items, string _username)
    {
        //the url
        //Debug.Log("in save function");
        string createUserURL = "http://localhost:81/nsirpg/item/saveitems.php";
        WWWForm form = new WWWForm();
        form.AddField("items", _items);
        form.AddField("username", _username);

        UnityWebRequest webRequest = UnityWebRequest.Post(createUserURL, form);

        yield return webRequest.SendWebRequest();

        s = webRequest.downloadHandler.text;
        Debug.Log(s);
        if (s=="1")
        {
            Debug.Log("INSIDE");
            //SaveIcon
            saved.gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("SaveIcon").GetComponent<RawImage>().CrossFadeAlpha(0, 0.75f, true);
            yield return new WaitForSeconds(0.75f);
            saved.gameObject.SetActive(false);


            //saved.CrossFadeAlpha(0, 2, false);
        }
        
    }

    public void StringifyTheItems()
    {
        ItemsTosave = ""; //reset the string
        for (int i = 0; i < LinearCanvasInventory.inv.Count; i++)
        {
            ItemsTosave += LinearCanvasInventory.inv[i].ID;
        }

        //Debug.Log(ItemsTosave);
        StartCoroutine(Save(ItemsTosave, user));
    }
}
