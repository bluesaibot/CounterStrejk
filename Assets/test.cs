using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    //private const string URL = "192.168.1.128";
    private const string URL = "172.20.10.3";
    public GameObject lightning;

    private void Start()
    {
        WWW request = new WWW(URL + "/off");
    }

    public void shockON()
    {
        Debug.Log("bzzzzz");
        WWW request = new WWW(URL + "/on");
        lightning.SetActive(true);
    }

    public void shockOFF()
    {
        Debug.Log("no bzzzzz");
        WWW request = new WWW(URL + "/off");
        lightning.SetActive(false);
    }
}
