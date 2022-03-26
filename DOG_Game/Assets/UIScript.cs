using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public List<GameObject> Children;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {

            Children.Add(child.gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        Debug.Log("MOUSEOVER");
        foreach (Transform child in transform)
        {

            child.gameObject.SetActive(true);

        }

    }

    void OnMouseExit()
    {
        Debug.Log("MOUSEEXIT");

        foreach (Transform child in transform)
        {

            child.gameObject.SetActive(false);

        }
    }
}

