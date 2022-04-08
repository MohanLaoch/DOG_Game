using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class names : MonoBehaviour
{
    public GameObject myUI;
    public Text mytext;

    // Update is called once per frame
    void FixedUpdate()
    {
        mytext.text = myUI.GetComponent<UIScript>().name;
    }
}
