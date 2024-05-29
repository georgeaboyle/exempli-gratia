using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextStarter : MonoBehaviour
{
    [TextArea(5, 3)]
    public string[] SMS;

    private void OnMouseDown()
    {
        Debug.Log("clicked on a phone");
        PhoneConvo.instance.StartDialogue(SMS);
    }
}
