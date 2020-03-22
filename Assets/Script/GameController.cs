using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text amoText;
    public GameObject pauseButton;
    private string score;
    private string amo;

    // Update is called once per frame
    void Update()
    {
        score = "Score :\n" + Bird.point.ToString();
        amo = "Amo : " + Bird.point.ToString();

        scoreText.text = score;
        amoText.text = amo;
        if(Bird.isDead == true)
        {
            pauseButton.SetActive(false);
        }
    }
}
