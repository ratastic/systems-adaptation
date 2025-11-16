using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PourDrink : MonoBehaviour
{
    public Collider2D glassCol;
    public Collider2D bottleCol;
    public Animator drinkingWoman;
    public AnimationClip drinkingClip;
    public bool drinkFinished;
    private AudioSource pour;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //bottleCol = GetComponent<Collider2D>();
        pour = GetComponent<AudioSource>();
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
        pour.Play();
        yield return new WaitForSeconds(6f);
        drinkFinished = true;
    }

    // void FixedUpdate()
    // {
    //     StopAllCoroutines();
    // }
}