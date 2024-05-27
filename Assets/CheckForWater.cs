using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForWater : Interactable
{
    public string reqItem = "WaterCan";
    private bool hasGrown = false;
    public GameObject lantana_iris_flower2;

    Inventory inventory = new Inventory();


    public void GetList()
    {
        List<item> calledList = Inventory.GetList();

    }


    public void TryGrow(Inventory inventory)
    {
        if (inventory.GetList())
        {
            GrowFlower();
        }
    }

    

    public void GrowFlower()
    {
        hasGrown = true;
        Debug.Log("Grow that flower!");

        if(lantana_iris_flower2 != null)
        {
            lantana_iris_flower2.SetActive(true);
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

        ;
    }
}
