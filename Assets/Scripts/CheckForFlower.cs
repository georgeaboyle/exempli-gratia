using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForCamera : Interactable
{
    public string itemName2;
    private bool hasShot = false;
    public GameObject Photo;
    public AudioClip cameraSound;

    Inventory inventory = new Inventory();

    public void OnMouseDown()
    {
        TryPhoto();
        Debug.Log("TryPhoto runs OnMouseDown");
    }

    public void TryPhoto()
    {
        if (Inventory.instance.HasItem(itemName2))
        {
            Debug.Log("Checked inventory for camera");
            TakePhoto();
        }
        else
        {
            Debug.Log("No camera available.");
        }
    }


    public void TakePhoto()
    {
        hasShot = true;
        Debug.Log("Take that photo!");
        AudioSource.PlayClipAtPoint(cameraSound, transform.position);

        if (Photo != null)
        {
            Photo.SetActive(true);
        } 
        else
        {
            Debug.LogWarning("No flower present.");
        }
    }

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Checking for flower");
    }
}
