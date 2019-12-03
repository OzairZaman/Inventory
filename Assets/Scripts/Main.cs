using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public static Main Instance;
    public GetItems GetItems;


    void Start()
    {
        Instance = this;
        GetItems = GetComponent<GetItems>();
    }
}
