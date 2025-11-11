using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PourDrink : MonoBehaviour
{
    public Collider2D glassCol;
    private Collider2D bottleCol;
    public Animator drinkingWoman;
    public AnimationClip drinkingClip;
    public bool drinkFinished;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bottleCol = GetComponent<Collider2D>();
        drinkFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        Pouring();
    }

    public void Pouring()
    {
        if (bottleCol.IsTouching(glassCol))
        {
            Debug.Log("drink poured");
            StartCoroutine(Drinking());
        }
    }

    public IEnumerator Drinking()
    {
        drinkingWoman.SetBool("canDrink", true);
        yield return new WaitForSeconds(drinkingClip.length);
        drinkFinished = true;
    }

    // void FixedUpdate()
    // {
    //     StopAllCoroutines();
    // }
}