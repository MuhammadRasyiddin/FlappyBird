using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public GameObject popUpMenu;
    public Text highScoreText;
    private string highscore;
    private float scores;
    private void Update()
    {
        scores = Bird.point;
        highscore = "Your Score\n\n" + scores.ToString();
        highScoreText.text = highscore;
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("SampleScene");
    }
}
