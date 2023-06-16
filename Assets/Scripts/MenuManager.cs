using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void ShowHowToPlay()
    {
        SceneManager.LoadScene(2);
    }
}
