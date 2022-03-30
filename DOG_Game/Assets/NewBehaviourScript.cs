using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject indoor;
    public GameObject outdoor;


    public void SwapToIndoors()
    {
        indoor.SetActive(true);
        outdoor.SetActive(false);
    }

    public void SwapToOutdoors()
    {
        indoor.SetActive(false);
        outdoor.SetActive(true);
    }
}
