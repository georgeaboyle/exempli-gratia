using UnityEngine;
using UnityEngine.UI;

public class PhoneConvo : MonoBehaviour
{
    public static PhoneConvo instance;

    [Header("Public Variables")]
    public Canvas dialogueDisplay;
    [Tooltip("Your dialogue text goes here")]
    public Text textDisplay;

    public Button cont;

    [Header("Private Variables")]
    [SerializeField]
    private string[] dialogueLines;

    [SerializeField]
    private int dialogueProgress = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //ClearText();
        HideDialogueDisplay();
    }

    // This method is called by TextStarter.cs to actually initiate the dialogue
    // other methods are doing the lifting while this does the checks to see if those methods should run at all
    public void StartDialogue(string[] lines)
    {
        if (lines.Length < 1)
        {
            return;
        }
        else if (dialogueLines != null)
        {
            return;
        }

        dialogueLines = lines;
        AdvanceDialogue();
        ShowDialogueDisplay();
    }

    // button interaction
    public void OnContinueButtonClicked()
    {
        if (dialogueProgress < dialogueLines.Length)
        {
            AdvanceDialogue();
        }
        else
        {
            EndDialogue();
        }
    }

    // method to continue on click
    private void AdvanceDialogue()
    {
        textDisplay.text = dialogueLines[dialogueProgress];
        dialogueProgress++;
    }

    // method to end message interaction by calling other methods that actually do the work
    private void EndDialogue()
    {
        HideDialogueDisplay();
        //ClearText();
        dialogueProgress = 0;
    }

    // this method actually does the work of emptying the text area.
    // I may not want this as my messages are supposed to stay on screen as text messages
    // will revisit if necessary
    //private void ClearText()
    //{
    //    textDisplay.text = "";
    //    dialogueLines = null;
    //}

    // this method tells the canvas to appear when the dialogue is activated
    private void ShowDialogueDisplay()
    {
        dialogueDisplay.gameObject.SetActive(true);
    }

    // this method tells the canvas to disappear when dialogue is concluded
    private void HideDialogueDisplay()
    {
        dialogueDisplay.gameObject.SetActive(false);
    }

}
