using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nay : MonoBehaviour
{
    public string name;
    public GameObject dog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        name = dog.GetComponent<dog>().dogName;
    }

    void OnMouseOver()
    {

        GameObject.Find("DogManager").GetComponent<dogManager>().SetTooltip(name);

    }
}
