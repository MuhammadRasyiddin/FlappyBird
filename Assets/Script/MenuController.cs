using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject popUpMenu;
    public void PauseGame()
    {
        Time.timeScale = 0;
        popUpMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        popUpMenu.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("SampleScene");
    }
}
