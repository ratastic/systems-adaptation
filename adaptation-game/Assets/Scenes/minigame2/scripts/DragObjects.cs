using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;

public class DragObjects : MonoBehaviour
{
    Vector3 startPos;
    Quaternion initialRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDrag()
    {
        Vector3 move = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        move.z = 0;

        transform.position = move;
    }

    private void OnMouseUp()
    {
        transform.position = startPos;
        transform.rotation = initialRotation;
    }
}
