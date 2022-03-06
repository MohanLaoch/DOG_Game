using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog : MonoBehaviour
{
    [SerializeField] public string dogName;

    [Range(0, 100)]
    public float dogHappiness;

    public string favToy;
    public string favFood;
    public string leastToy;
    public string leastFood;

    public string[] allTreasure;
    public string currentTreasure;
    public int index;

    public bool stray;
    public bool adoptable;

    public bool hasTreasure;
    public int treasureChance;
    bool timerDone;

    private GameObject treasure;

    public void Start()
    {
        treasure = transform.Find("Treasure").gameObject;
    }

    public void Update()
    {
        if (dogHappiness > 100)
        {
            dogHappiness = 100;
        }
        else if (dogHappiness < 0)
        {
            dogHappiness = 0;
        }
    }

    void FixedUpdate()
    {
        if (dogHappiness >= 50 && stray) //if happy and still a stray, make adoptable
        {
            adoptable = true;
        }
        else                             //otherwise if unhappy and a stray or, unadoptable
        {
            adoptable = false;
        }

        if (timerDone)
        {
            hasTreasure = true;
            treasure.SetActive(true);
        }

    }

    void CollectTreasure() //make dog shiny, if clicked on when shiny then give treasure
    {
        index = Random.Range(0, allTreasure.Length);
        currentTreasure = allTreasure[index];
        

        hasTreasure = false;
        timerDone = false; //restart treasure timer
    }

    void CalculateHappiness()
    {

    }

    void OnMouseDown()
    {
        // this object was clicked - do something
        if (hasTreasure)
        {
            CollectTreasure();
        }
    }

}
