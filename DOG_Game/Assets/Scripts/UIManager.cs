using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public int bones;
    public int treats;

    public int decorationPrice;
    public int roomCost;

    public int trophy;
    public int dogBowl;
    public int shinyStone;
    public int tennisBall;
    public int newspaper;

    public TMP_Text bonesCount;
    public TMP_Text treatsCount;

    public TMP_Text trophyCount;
    public TMP_Text dogBowlCount;
    public TMP_Text shinyStoneCount;
    public TMP_Text tennisBallCount;
    public TMP_Text newspaperCount;

    public Button dogHouseButton;
    public Button ballButton;
    public Button fenceButton;

    public GameObject dogHouseObject;
    public GameObject ballObject;
    public GameObject fenceObject;

    public Button ropeButton;
    public Button pillowButton;
    public Button blanketButton;

    public GameObject ropeObject;
    public GameObject pillowObject;
    public GameObject blanketObject;

    /*public GameObject livingroomLocks;

    public Button livingRoomUpgradeButton;
    public Button BedRoomUpgradeButton;*/

    public void FixedUpdate()
    {
        bonesCount.text = bones.ToString();
        treatsCount.text = treats.ToString();

        trophyCount.text = trophy.ToString();
        dogBowlCount.text = dogBowl.ToString();
        shinyStoneCount.text = shinyStone.ToString();
        tennisBallCount.text = tennisBall.ToString();
        newspaperCount.text = newspaper.ToString();
    }

    public void sellTrophy()
    {
        if (trophy > 0)
        {
            trophy--;
            treats++;
        }
    }

    public void sellDogBowl()
    {
        if (dogBowl > 0)
        {
            dogBowl--;
            treats++;
        }
    }

    public void sellShinyStone()
    {
        if (shinyStone > 0)
        {
            shinyStone--;
            treats++;
        }
    }

    public void sellTennisBall()
    {
        if (tennisBall > 0)
        {
            tennisBall--;
            treats++;
        }
    }

    public void sellNewspaper()
    {
        if (newspaper > 0)
        {
            newspaper--;
            treats++;
        }
    }

    public void buyDogHouse()
    {
        if (treats > decorationPrice)
        {
            dogHouseButton.interactable = false;
            dogHouseObject.SetActive(true);
        }
    }

    public void buyBall()
    {
        if (treats > decorationPrice)
        {
            ballButton.interactable = false;
            ballObject.SetActive(true);
        }
    }

    public void buyFence()
    {
        if (treats > decorationPrice)
        {
            fenceButton.interactable = false;
            fenceObject.SetActive(true);
        }
    }

    public void buyRope()
    {
        if (treats > decorationPrice)
        {
            ropeButton.interactable = false;
            ropeObject.SetActive(true);
        }
    }

    public void buyPillow()
    {
        if (treats > decorationPrice)
        {
            pillowButton.interactable = false;
            pillowObject.SetActive(true);
        }
    }

    public void buyBlanket()
    {
        if (treats > decorationPrice)
        {
            blanketButton.interactable = false;
            blanketObject.SetActive(true);
        }
    }

    /*public void buyLivingRoomUpgrade()
    {
        if (treats > roomCost)
        {
            livingroomLocks.SetActive(false);
            livingRoomUpgradeButton.interactable = false;
        }
    }

    public void buyBedRoomUpgrade()
    {
        if (treats > roomCost)
        {
            BedRoomUpgradeButton.interactable = false;
        }
    }*/

}
