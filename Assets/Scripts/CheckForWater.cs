using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForWater : Interactable
{
    public string itemName;
    private bool hasGrown = false;
    public GameObject lantana_iris_flower2;
    public AudioClip plantSound;

    Inventory inventory = new Inventory();


    public void OnMouseDown()
    {
        TryGrow();
        Debug.Log("TryGrow runs OnMouseDown");
    }

    //public void TryGrow(Inventory inventory)
    //{

    //    if (inventory.HasItem("WaterCan"))
    //    {
    //        GrowFlower();
    //    }
    //    else
    //    {
    //        Debug.Log("No water can available.");
    //    }
    //}

    public void TryGrow()
    {

        //if (Inventory.instance.HasItem("WaterCan"))
        if (Inventory.instance.HasItem(itemName))
        {
            Debug.Log("Checked inventory for waterCan");
            GrowFlower();
        }
        else
        {
            Debug.Log("No water can available.");
        }
    }


    public void GrowFlower()
    {
        hasGrown = true;
        Debug.Log("Grow that flower!");

        if(lantana_iris_flower2 != null)
        {
            lantana_iris_flower2.SetActive(true);
            AudioSource.PlayClipAtPoint(plantSound, transform.position);
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

        Debug.Log("Checking for water");
    }
}
