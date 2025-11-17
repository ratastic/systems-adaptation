using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightCigarette : MonoBehaviour
{
    public Collider2D cig;
    public Collider2D lighter;
    public Animator smokingWoman;
    public AnimationClip smokingClip;
    public bool isBurned;
    private AudioSource lighterNoise;
    private bool lightSoundPlayed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lighterNoise = GetComponent<AudioSource>();
        isBurned = false;
    }

    // Update is called once per frame
    void Update()
    {
        Lighting();
    }

    public void Lighting()
    {
        if (lighter.IsTouching(cig) && !lightSoundPlayed)
        {
            Debug.Log("lit cig");
            lightSoundPlayed = true;
            lighterNoise.Play();
            StartCoroutine(Smoking());
        }
    }

    public IEnumerator Smoking()
    {
        smokingWoman.SetBool("canSmoke", true);
        yield return new WaitForSeconds(6f);
        isBurned = true;
    }
}
