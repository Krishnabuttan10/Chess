using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class play_quit : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("LEVEL");
    }
    public void quit()
    {
        Application.Quit();
    }

    public void back()
    {
        SceneManager.LoadScene("example");
    }
}
