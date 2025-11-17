using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System;

public class MoveCam : MonoBehaviour
{
    public GameObject arrows;
    private Transform camScreen;
    Vector3 startPos;
    Vector3 focusPos = new Vector3(6, 0, 0);
    Vector3 previousMousePos;
    Vector3 currentMousePos;
    private bool inFrame;
    private int moveAmount = 1;
    private float mouseSensitivity = 0.5f;

    [Header("npc sprite")]
    public SpriteRenderer idleSprite;
    public Sprite poseSprite;
    private Sprite startSprite;

    public GameObject questionText;

    [Header("cam bounds")]
    public float minX = -5f;
    public float maxX = 10f;
    public float minY = -3f;
    public float maxY = 3f;

    private Animator anim;
    private bool canMoveCam;
    public GameObject nextButton;
    private AudioSource camShutter;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camScreen = GetComponent<Transform>();
        camShutter = GetComponent<AudioSource>();
        startPos = camScreen.position;
        inFrame = false;
        canMoveCam = true;
        nextButton.SetActive(false);
        
        Vector3 mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        previousMousePos = mouseStart;

        startSprite = idleSprite.sprite;
        questionText.SetActive(true);

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(arrows);
        }

        OnMouseDrag();

        if (camScreen.position == focusPos)
        {
            inFrame = true;
            idleSprite.sprite = poseSprite;
            questionText.SetActive(false);

            if (inFrame == true)
            {
                Debug.Log("can take picture");
                TakePicture();
            }
        } else
        {
            idleSprite.sprite = startSprite;
            questionText.SetActive(true);
        }
    }

    private void OnMouseDrag()
    {
        if (canMoveCam == true && Input.GetMouseButton(0))
        {
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 delta = currentMousePos - previousMousePos;

            if (delta.x > mouseSensitivity)
            {
                transform.position = new Vector3(camScreen.position.x + moveAmount, camScreen.position.y, camScreen.position.z);
                previousMousePos = currentMousePos;
            }
            else if (delta.x < -mouseSensitivity)
            {
                transform.position = new Vector3(camScreen.position.x - moveAmount, camScreen.position.y, camScreen.position.z);
                previousMousePos = currentMousePos;
            }

            if (delta.y > mouseSensitivity)
            {
                transform.position = new Vector3(camScreen.position.x, camScreen.position.y + moveAmount, camScreen.position.z);
                previousMousePos = currentMousePos;
            }
            else if (delta.y < -mouseSensitivity)
            {
                transform.position = new Vector3(camScreen.position.x, camScreen.position.y - moveAmount, camScreen.position.z);
                previousMousePos = currentMousePos;
            }
        }

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );

        if (Input.GetMouseButtonUp(0))
        {
            previousMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void TakePicture()
    {
        canMoveCam = false;
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("canTakePic", true);
            camShutter.Play();

            StartCoroutine(Countdown());
        }
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1f);
        nextButton.SetActive(true);
        Destroy(this);
    }
}
