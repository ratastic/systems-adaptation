using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirstWinLogic : MonoBehaviour
{
    public Collider2D leftStrap;
    public Collider2D leftSnap;
    public Collider2D rightStrap;
    public Collider2D rightSnap;

    public SpriteRenderer mirrorSprite;
    public Sprite happy;

    public GameObject grid1;
    public GameObject grid2;
    public GameObject nextButton;

    //public AudioSource claspNoise;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid1.SetActive(true);
        grid2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        BraClasped();

        // if (leftStrap.IsTouching(leftSnap))
        // {
        //     claspNoise.Play();
        // }
        
        // if (rightStrap.IsTouching(rightSnap))
        // {
        //     claspNoise.Play();
        // }
    }

    public void BraClasped()
    {
        if (leftStrap.IsTouching(leftSnap) && rightStrap.IsTouching(rightSnap))
        {
            mirrorSprite.sprite = happy;
            grid1.SetActive(false);
            grid2.SetActive(true);
            nextButton.SetActive(true);
            Debug.Log("thank you");
        }
    }
}
