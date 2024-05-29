using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextStarter : MonoBehaviour
{
    [TextArea(5, 3)]
    public string[] SMS;

    private void OnMouseDown()
    {
       PhoneConvo.instance.StartDialogue(SMS);
    }
}
