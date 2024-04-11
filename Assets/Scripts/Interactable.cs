using UnityEngine;

public class Interactable : MonoBehaviour
{
    // commenting out the radius. Since our game doesn't have a player character, I don't think we should have this.
    // public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact ()
    {
        // This method is meant to be overridden by scripts in other places
        // This is why it is "virtual"

        Debug.Log("I say, I say, I'm Interacting with " + transform.name);
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            // float distance = Vector3.Distance(player.position, interactionTransform.position);
            Interact();
            hasInteracted = true;
            Debug.Log("INTERACT");
            //if (distance <= radius)
            //{
            //    Interact();
            //    Debug.Log("INTERACT");
            //    hasInteracted = true;
            //}
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

        //gizmos.color = color.yellow;
        //gizmos.drawwiresphere(interactionTransform.position, radius);

    }
}
