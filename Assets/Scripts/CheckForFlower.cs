using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForFlower : Interactable
{
    public string itemName2;
    private bool hasShot = false;
    public GameObject Photo;

    Inventory inventory = new Inventory();


    public void OnMouseDown()
    {
        TryPhoto();
        Debug.Log("TryGrow runs OnMouseDown");
    }

    public void TryPhoto()
    {

        //if (Inventory.instance.HasItem("WaterCan"))
        if (Inventory.instance.HasItem(itemName2))
        {
            Debug.Log("Checked inventory for waterCan");
            TakePhoto();
        }
        else
        {
            Debug.Log("No water can available.");
        }
    }


    public void TakePhoto()
    {
        hasShot = true;
        Debug.Log("Take that photo!");

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
        // This is where we get the chance to override the Interact method in the Interactable script

        base.Interact();

        Debug.Log("Checking for flower");
    }
}
