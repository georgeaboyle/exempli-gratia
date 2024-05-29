using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact ()
    {
        // This method is meant to be overridden by scripts in other places
        // This is why it is "virtual"
        //base.Interact():
        //TryGrow();
        
        Debug.Log("I say, I say, I'm Interacting with " + transform.name);
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            Interact();
            hasInteracted = true;
            Debug.Log("INTERACT");
        }
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused ()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    // I don't know if we need this at all now that we aren't using the radius...
    // I'll add it back in if I find it's necessary

    private void OnDrawGizmosSelected ()
    {
        if (interactionTransform == null)
            interactionTransform = transform;
    }
}
