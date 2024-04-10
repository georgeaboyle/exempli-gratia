using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // LMB click
        if (Input.GetMouseButtonDown(0))
        {
            print("Raycasting...");
            Vector2 mousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rayDirection = Vector2.zero;

            RaycastHit2D hit2D;
            hit2D = Physics2D.Raycast(mousePositionWorld, rayDirection);
            if (hit2D)
            {
                print("Clicked on something");
            }

            Debug.DrawRay(mousePositionWorld, Vector3.forward * 100f, Color.red, 0.2f);
        }
    }
}
