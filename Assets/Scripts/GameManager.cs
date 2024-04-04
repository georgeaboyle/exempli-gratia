using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


// Here I'm looking at the GameManager from Methodyca to try to get a sense for how their
// inventory system works

// Looks like I need to build out a few more blocks of code to make this work.
// I'll keep this code for a while, but it may get scrapped if I can find an easier way to do this.



//public class GameManager : MonoBehaviour
//{
//    // avoiding magic numbers
//    public float rayDistance;





//    #region Singleton
//    public static GameManager instance;
//    private void Awake()
//    {
//        // Check for extant copies and assign
//        if (instance == null)
//            instance = this;

//    }
//    #endregion

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Scan();

//    }

//    private void Scan()
//    {
//        // Prevent interaction with game when in menu
//        if (IsCursorOnGUI())
//            return;

//        // cast ray at cursor location onto game world
//        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

//        // check if cursor hit an interactable object 
//        if (Physics.Raycast(mouseRay, out RaycastHit hit, rayDistance))
//        {
//            if (hit.collider.GetComponent<ObjectInteraction>())
//            {
//                interactableObject = hit.collider.GetComponent<ObjectInteraction>();
//                canInteract = interactableObject.canInteract;

//            }
//        }
//    }

//    private bool IsCursorOnGUI()
//    {
//        if (EventSystem.current.IsPointerOverGameObject())
//            return true;
//        else
//            return false;
//    }
//}
