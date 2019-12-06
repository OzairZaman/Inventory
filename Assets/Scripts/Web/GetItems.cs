using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
//using SimpleJSON;
using System.Linq;

public class GetItems : MonoBehaviour
{

    string user;
    public GameObject buttonPrefab;
    public RectTransform parent;
    string httpheader = "";
    public string[] returnedItems;

    #region Internal
    void Start()
    {
        
        user = myGuy.takeToNexScene;
        InitiateGetItems();
    }

    void Update()
    {

    }
    #endregion

    #region External
    public IEnumerator GetAllItems(string _username)
    {
        //the url
        string createUserURL = "http://localhost:81/nsirpg/item/GetItem.php";
        WWWForm form = new WWWForm();
        form.AddField("username", _username);

        //form.AddField("password", _password);

        UnityWebRequest webRequest = UnityWebRequest.Post(createUserURL, form);

        yield return webRequest.SendWebRequest();

        //we want to convert the shit we got from our database to a JSON object
        //string jsonString = webRequest.downloadHandler.text;
        //JSONArray jsonArray = JSON.Parse(jsonString) as JSONArray;
        //Debug.Log(jsonArray[0].AsObject.Count);

        httpheader = webRequest.downloadHandler.text;
        if (httpheader.Length > 3)
        {
            returnedItems = Split(httpheader, 3).ToArray(); //(old code) IEnumerable<string> theItems | string[] myarray = theItems.ToArray();


            for (int i = 0; i < returnedItems.Length; i++)
            {
                int id = 0;
                if (!int.TryParse(returnedItems[i], out id))
                {
                    //if shit went wrong
                }

                LinearCanvasInventory.inv.Add(ItemData.CreateItem(id));
                int currentSlot = LinearCanvasInventory.inv.Count - 1;
                GameObject button = Instantiate(buttonPrefab, parent) as GameObject; //parent is the Gridlaout object
                button.GetComponent<SelectButton>().index = currentSlot;
                button.name = LinearCanvasInventory.inv[currentSlot].Name;
                button.GetComponentInChildren<Text>().text = LinearCanvasInventory.inv[currentSlot].Name;
            }
        }
    }

    public void InitiateGetItems()
    {
        //Debug.Log(user);
        StartCoroutine(GetAllItems(user));
    }

    static IEnumerable<string> Split(string str, int chunkSize)
    {
        return Enumerable.Range(0, str.Length / chunkSize)
            .Select(i => str.Substring(i * chunkSize, chunkSize));
    }
    #endregion
}
