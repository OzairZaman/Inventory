using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myGuy : MonoBehaviour
{
    
    [SerializeField]
    public static string takeToNexScene;
    //public GameObject myMan;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Surviver");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
