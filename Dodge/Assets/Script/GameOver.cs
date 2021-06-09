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
    public Text highScoresecondServivedUI;
    private bool gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        highScoresecondServivedUI.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("highScore",0)).ToString();
        FindObjectOfType<PlayerController>().OnPlayerDeath += onGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
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
            highScoresecondServivedUI.text = secondsSurvived.ToString();
        }
        
        
        secondsServivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("highScore");
        highScoresecondServivedUI.text = "0";

    }
}
