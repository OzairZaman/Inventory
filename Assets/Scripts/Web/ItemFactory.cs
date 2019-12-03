using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;

public class ItemFactory : MonoBehaviour
{
    //string parameter is going the be the jason string we download from database
    Action<string> _CreateItemsCallback;
    void Start()
    {
        _CreateItemsCallback = (jsonArrayString) => {
            StartCoroutine(CreateItemfromWebRoutine(jsonArrayString));
        };
    }

    public void CreateItemfromWeb()
    {
        //Main.Instance.GetItems.GetAllItems(_CreateItemsCallback);
    }

    IEnumerator CreateItemfromWebRoutine (string jsonArrayString)
    {
        //serveral thing we need to do in this function
        //1. parsing the jasonArrayString as an array
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

        yield return null;
    }
}
