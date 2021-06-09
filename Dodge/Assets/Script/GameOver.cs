using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text secondsServivedUI;
    public Text highScoreSecondServivedUI;
    private bool gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        highScoreSecondServivedUI.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("highScore",0)).ToString();
        FindObjectOfType<PlayerController>().OnPlayerDeath += onGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    void onGameOver()
    {
        gameOverScreen.SetActive(true);

        int secondsSurvived = Mathf.RoundToInt(Time.timeSinceLevelLoad);
        
        if (secondsSurvived > PlayerPrefs.GetFloat("highScore",0))
        {
            PlayerPrefs.SetFloat("highScore",secondsSurvived);
            highScoreSecondServivedUI.text = secondsSurvived.ToString();
        }
        
        
        secondsServivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("highScore");
        highScoreSecondServivedUI.text = "0";

    }

    public void openMainPage()
    {
        SceneManager.LoadScene(0);
    }
}
