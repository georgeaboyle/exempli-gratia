using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public LayerMask interactMask;

    public Interactable focus;

    Camera cam;

    public static PlayerController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // Protect entire game object from being destroyed. This will keep ALL components on the game object
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Camera cam;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            OnMouseLeftClicked();
        }

        if (Input.GetMouseButtonDown(1))
        {
            OnMouseRightClicked();
        }
    }

    void OnMouseLeftClicked()
    {
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
            if (hit.transform.name == "Door 4")
            {
                ChangeScene();
            }
        }
        else
        {
            print("Nothing clicked!");
        }

        // Project the click screen position to in-game world position
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

    void ChangeScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}