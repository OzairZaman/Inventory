using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class CreateUser : MonoBehaviour
{
    #region Variables
    [Header("Create user")]
    public Text userName;
    public Text email;
    public InputField passWord;
    public InputField repeatPassWord;
    public GameObject alert;
    public Text alertText;
    string httpHeader;

    //private
    
    #endregion


    IEnumerator Create(string _user, string _password, string _email)
    {
        //the url
        string createUserURL = "http://localhost:81/nsirpg/insertuser.php";
        WWWForm form = new WWWForm();
        form.AddField("username", _user);
        form.AddField("email", _email);
        form.AddField("password", _password);

        UnityWebRequest webRequest = UnityWebRequest.Post(createUserURL, form);

        yield return webRequest.SendWebRequest();

        httpHeader = webRequest.downloadHandler.text;
        if (httpHeader == "1")
        {
            //show alert box
            alert.SetActive(true);
            alertText.text = "Created Successfully";
        }
        else
        {
            alert.SetActive(true);
            alertText.text = httpHeader;
        }
    }

    public void CreateNewuser()
    {
        //check if fields are empty
        if (userName.text.Length == 0 || email.text.Length == 0 || passWord.text.Length == 0 || repeatPassWord.text.Length == 0)
        {
            alert.gameObject.SetActive(true);
            alertText.text = "No Empty Fields Allowed";
            return;
        }

        //check if passwords match
        if (passWord.text == repeatPassWord.text)
        {

            Debug.Log(userName.text + " local " + passWord.text);
            StartCoroutine(Create(userName.text, passWord.text, email.text));
        }
        else
        {
            alert.gameObject.SetActive(true);
            alertText.text = "Password does not Match";
        }
    }

}
