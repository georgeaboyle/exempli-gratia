using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        // I don't need this for this build since it will be played in a browser window
        // However, I have included it in case I want to add a quit button to the menu for stand-alone builds
        // Basically, just ignore this. It's here for me, not for you.
        Application.Quit();
    }
}
