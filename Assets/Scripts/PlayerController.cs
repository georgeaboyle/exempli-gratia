using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public LayerMask clickableMask;

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
        // This is to prevent clicking through the inventory UI

        /*if (EventSystem.current.IsPointerOverGameObject())
            return;
        */



        //Brackeys put this here for movement, then copied the code later for interactable
        //I'm going to leave this in for now because my brain is breaking
        //I'll come back later and clean up this code (I promise)

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, clickableMask))
            {
                //Vector3 mousePos = Input.mousePosition;
                //mousePos = cam.ScreenToWorldPoint(mousePos);
                Debug.Log("We hit" + hit.collider.name + " " + hit.point);
                //Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

                // Focus/select object

                // Stop focusing any objects
            }
            if (Input.GetMouseButtonDown(1))
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


                    // ^^ is from Brackeys. What I really did is below
                    // Above, I created a mask called "ClickableMask" and I may just put all clickable 
                    // objects on that layer in the game. Also going to need to create a script to make
                    // clickable objects "glow" on mouse hover.
                    // For now, I'm going to continue copying what Brackeys is doing step-by-step to avoid
                    // any mistakes I might introduce from being "clever"


                }

            }
        }
    }

    // Well, I'm not sure how these two are going to work out/interact because we currently don't have
    // character movement. 


    //Nothing is "broken" and the game still runs with these lines, so I'll leave them until I know better
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