using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextStarter : MonoBehaviour
{
    [TextArea(5, 3)]
    public string[] SMS;
    public AudioClip phoneSound;

    private void OnMouseDown()
    {
        Debug.Log("clicked on the smartphone");
        AudioSource.PlayClipAtPoint(phoneSound, transform.position);
        PhoneConvo.instance.StartDialogue(SMS);
    }
}
