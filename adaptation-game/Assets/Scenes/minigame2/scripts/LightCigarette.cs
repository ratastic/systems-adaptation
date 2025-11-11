using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightCigarette : MonoBehaviour
{
    public Collider2D cig;
    private BoxCollider2D lighter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lighter.GetComponent<BoxCollider2D>();
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
        }
    }

}
