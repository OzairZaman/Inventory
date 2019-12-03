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
    public Text loginPass;
    public string s;
    // note for textmeshPro
    //TMPro.TMP_InputField textMeshProReference;
   
    #region Methods
    IEnumerator CreateUser(string _user, string _password, string _email)
    {
        //the url
        string createUserURL = "http://localhost/nsirpg/insertuser.php";
        WWWForm form = new WWWForm();
        form.AddField("username", _user);
        form.AddField("email", _email);
        form.AddField("password", _password);

        UnityWebRequest webRequest = UnityWebRequest.Post(createUserURL, form);

        yield return webRequest.SendWebRequest();
    }

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
        JSONString js = JSON.Parse(s) as JSONString;
        Debug.Log("beep");
        if (js == "c")
        {
            //Debug.Log("grrrrrrrrrrrrrrrrrrrr");
            SceneManager.LoadScene(1);
        }

    }

    public void CreateNewuser()
    {
        //StartCoroutine(CreateUser(userName.text, passWord.text, email.text));
    }

    public void LoginUser()
    {
        
        myGuy.takeToNexScene = loginName.text;
        StartCoroutine(DoLogin(loginName.text, loginPass.text));
        
    }
    #endregion
}
