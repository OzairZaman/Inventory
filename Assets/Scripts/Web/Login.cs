using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;


public class Login : MonoBehaviour
{



    //[Header("Create user")]
    //public Text userName;
    //public Text email; login should not have email i believe
    //public Text passWord;
    private myGuy m;
    [Header("Login user")]
    public Text loginName;
    public InputField loginPass;
    public string s;
    // note for textmeshPro
    //TMPro.TMP_InputField textMeshProReference;
   
    #region Methods
    

    IEnumerator DoLogin(string _user, string _password)
    {
        //the url
        
        string createUserURL = "http://localhost:81/nsirpg/Login.php";
        WWWForm form = new WWWForm();
        form.AddField("username", _user);

        form.AddField("password", _password);

        UnityWebRequest webRequest = UnityWebRequest.Post(createUserURL, form);

        yield return webRequest.SendWebRequest();
        
        s = webRequest.downloadHandler.text;
        Debug.Log(s);
        JSONString js = JSON.Parse(s) as JSONString;
        if (js == "c")
        {
            SceneManager.LoadScene(1);
        }

    }

    
    public void LoginUser()
    {
        
        myGuy.takeToNexScene = loginName.text;
        Debug.Log(loginName.text + " local " + loginPass.text);
        StartCoroutine(DoLogin(loginName.text, loginPass.text));
        
    }
    #endregion
}
