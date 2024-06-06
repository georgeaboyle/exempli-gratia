using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public AudioClip itemPickupSound;

    private void Start()
    {
        if (Inventory.instance.HasItem(item.name))
        {
            print("Already have " + item.name);
            Destroy(gameObject);
        }
    }

    public override void Interact()
    {
        // This is where we get the chance to override the Interact method in the Interactable script

        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("picking up " + item.name);
        
        // add to inventory
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
            AudioSource.PlayClipAtPoint(itemPickupSound, transform.position);
            Destroy(gameObject);
    }
}
