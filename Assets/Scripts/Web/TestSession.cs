using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;


public class TestSession : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(hmm());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator hmm()
    {
        //the url
        string createUserURL = "http://localhost/nsirpg/test.php";
        WWWForm form = new WWWForm();
        //form.AddField("username", _user);
        //form.AddField("email", _email);
        //form.AddField("password", _password);

        UnityWebRequest webRequest = UnityWebRequest.Post(createUserURL, form);

        yield return webRequest.SendWebRequest();
        Debug.Log(webRequest.downloadHandler.text + "  is it Bob2?");
    }
}
