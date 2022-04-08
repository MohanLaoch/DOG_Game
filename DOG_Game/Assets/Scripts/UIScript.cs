using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public List<GameObject> Children;
    public GameObject dog;
    public string name;

    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform child in transform)
        {

            Children.Add(child.gameObject);

        }
    }

    void Update()
    {
        name = dog.GetComponent<dog>().dogName;
    }


    void OnMouseOver()
    {
        //Debug.Log("MOUSEOVER");
        foreach (Transform child in transform)
        {

            child.gameObject.SetActive(true);

        }

        //GameObject.Find("DogManager").GetComponent<dogManager>().SetTooltip(name);

    }

    void OnMouseExit()
    {
        //Debug.Log("MOUSEEXIT");

        foreach (Transform child in transform)
        {

            child.gameObject.SetActive(false);

        }
    }
}

