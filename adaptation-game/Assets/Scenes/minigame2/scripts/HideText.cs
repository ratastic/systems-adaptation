using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HideText : MonoBehaviour
{
    public LightCigarette cigScript;
    public PourDrink drinkScript;
    public GameObject ohWaiterText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (drinkScript.glassCol.IsTouching(drinkScript.bottleCol) || cigScript.cig.IsTouching(cigScript.lighter))
        {
            Destroy(ohWaiterText);
        }
    }

}
