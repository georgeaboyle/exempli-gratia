using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Brackeys
    public LayerMask clickableMask;
    // Elinda
    public LayerMask interactMask;

    public Interactable focus;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // I think this is Brackeys' code? Not sure why it's commented out... May implement later if needed. 
        // This is to prevent clicking through the inventory UI

        /*if (EventSystem.current.IsPointerOverGameObject())
            return;
        */

        if (Input.GetMouseButtonDown(0))
        {
            OnMouseLeftClicked();
        }

        if (Input.GetMouseButtonDown(1))
        {
            OnMouseRightClicked();
        }


        //Brackeys put this here for movement, then copied the code later for interactable
        //I'm going to leave this in for now because my brain is breaking
        //I'll come back later and clean up this code (I promise)

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit, 1000, clickableMask))
        //    {
        //        // Vector3 mousePos = Input.mousePosition;
        //        // mousePos = cam.ScreenToWorldPoint(mousePos);
        //        Debug.Log("We hit" + hit.collider.name + " " + hit.point);
        //        // Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        //        // Focus/select object

        //        // Stop focusing any objects
        //    }
        //    if (Input.GetMouseButtonDown(1))
        //    {
        //        Ray ray1 = cam.ScreenPointToRay(Input.mousePosition);
        //        RaycastHit hit1;

        //        if (Physics.Raycast(ray1, out hit1, 100))
        //        {

        //            // Check if we hit an interactable
        //            Interactable interactable = hit1.collider.GetComponent<Interactable>();

        //            // If we did hit an interactable, set it as our focus
        //            if (interactable != null)
        //            {
        //                SetFocus(interactable);
        //            }





        //        }

        //    }
        //}
    }


    void OnMouseLeftClicked()
    {
        // Written by Elinda
        // Get the click position on screen
        Vector3 clickPosition = Input.mousePosition;

        // Create a ray starting at click point on screen and moves along the camera perspective
        Ray clickRay = cam.ScreenPointToRay(clickPosition);

        // Declare a variable to store the Raycast hit information
        RaycastHit hit;

        // Physics.Raycast returns a bool (true/false) whether it hit a collider or not
        // Interaction mask allows us to filter what objects the ray should register
        if (Physics.Raycast(clickRay, out hit, 100f, interactMask))
        {
            print("Clicked on " + hit.transform.name);

            // Do other logic with the object we clicked on
            //RandomiseColor random = hit.transform.GetComponent<RandomiseColor>();

            //if (random != null)
            //{
            //    random.Randomise();
            //}
        }
        else
        {
            print("Nothing clicked!");
        }

        // Project the click screen position to in-game world position
        // "cam" not "mainCamera" as in Elinda's original code. Used Brackeys' identifier since it's also used in his script later on.
        Vector3 clickOrigin = cam.ScreenToWorldPoint(new Vector3(clickPosition.x, clickPosition.y, 0f));

        // Draw editor debugger to see ray in action
        Debug.DrawRay(clickOrigin, clickRay.direction * 50f, Color.yellow, 0.5f);
    }

    void OnMouseRightClicked()
    {
        Ray ray1 = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit1;

        if (Physics.Raycast(ray1, out hit1, 100))
        {

            // Check if we hit an interactable
            Interactable interactable = hit1.collider.GetComponent<Interactable>();

            // If we did hit an interactable, set it as our focus
            if (interactable != null)
            {
                SetFocus(interactable);
            }





        }
    }
    
    
    
    
    void SetFocus (Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();


            focus = newFocus;
        }


        
        newFocus.OnFocused(transform);
    }

    void RemoveFocus ()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
    }
}