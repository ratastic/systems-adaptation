using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BraStrapLogic : MonoBehaviour
{
    Vector3 startPoint;
    Vector3 startPos;
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPoint = transform.parent.position;
        startPos = transform.position;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;

        UpdateStrap(newPos);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPos, .2f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                UpdateStrap(collider.transform.position);
                return;
            }
        }
    }

    private void OnMouseUp()
    {
        UpdateStrap(startPos);
    }

    void UpdateStrap(Vector3 newPos)
    {
        transform.position = newPos;

        Vector3 direction = newPos - startPoint;
        transform.right = direction * transform.lossyScale.x;

        float dist = Vector2.Distance(startPoint, newPos);
        sr.size = new Vector2 (dist, sr.size.y);
    }
}
