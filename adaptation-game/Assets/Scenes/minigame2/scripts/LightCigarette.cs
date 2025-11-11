using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightCigarette : MonoBehaviour
{
    public Collider2D cig;
    private Collider2D lighter;
    public Animator smokingWoman;
    public AnimationClip smokingClip;
    public bool isBurned;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lighter = GetComponent<Collider2D>();
        isBurned = false;
    }

    // Update is called once per frame
    void Update()
    {
        Lighting();
    }

    public void Lighting()
    {
        if (lighter.IsTouching(cig))
        {
            Debug.Log("lit cig");
            StartCoroutine(Smoking());
        }
    }

    public IEnumerator Smoking()
    {
        smokingWoman.SetBool("canSmoke", true);
        yield return new WaitForSeconds(smokingClip.length);
        isBurned = true;
    }

    // void FixedUpdate()
    // {
    //     StopAllCoroutines();
    // }
}
