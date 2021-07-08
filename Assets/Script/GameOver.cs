using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text secondsServivedUI;
    public Text highScoreSecondServivedUI;
    private bool gameOver;
    public Text seconds;
    public GameObject secondsBoard;

    
    // Start is called before the first frame update
    void Start()
    {
        highScoreSecondServivedUI.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("highScore",0)).ToString();
        FindObjectOfType<PlayerController>().OnPlayerDeath += onGameOver;
    }

    

    public void restart()
    {
        if (gameOver)
        {
            SceneManager.LoadScene(1);

        }
    }
    
    public void postscoretoleaderboard()
    {
        String leaderboard = Mathf.RoundToInt(PlayerPrefs.GetFloat("highScore",0)).ToString();
        
        Social.ReportScore(int.Parse(leaderboard),"CgkIgof7xpIVEAIQAg",(bool success) =>
        {
            if (success)
            {
                // debugText.text = "Successfully add score to leaderboard";
            }
            else
            {
                // debugText.text = "unsuccessful";
            }
        });
    }

    private void Update()
    {
        seconds.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
    }

    void onGameOver()
    {
        gameOverScreen.SetActive(true);
        secondsBoard.SetActive(false);

        int secondsSurvived = Mathf.RoundToInt(Time.timeSinceLevelLoad);
        
        
        
        if (secondsSurvived > PlayerPrefs.GetFloat("highScore",0))
        {
            PlayerPrefs.SetFloat("highScore",secondsSurvived);
            highScoreSecondServivedUI.text = secondsSurvived.ToString();
            postscoretoleaderboard();
            
        }
        
        if (secondsSurvived>20)
        {
            achievementsCompleted("CgkIgof7xpIVEAIQAw");
        }
        else if (secondsSurvived>40)
        {
            achievementsCompleted("CgkIgof7xpIVEAIQBA");
        }
        else if (secondsSurvived>60)
        {
            achievementsCompleted("CgkIgof7xpIVEAIQBQ");
        }
        else if (secondsSurvived>80)
        {
            achievementsCompleted("CgkIgof7xpIVEAIQBg");
        }
        else if (secondsSurvived>100)
        {
            achievementsCompleted("CgkIgof7xpIVEAIQBw");
        }
        
        
        secondsServivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
    
    public void achievementsCompleted(String key)
    {
        Social.ReportProgress(key,100.0f, (bool success) =>
        {
            if (success)
            {
                //debugText.text = "successfully unlocked achievements";

            }
            else
            {
                //debugText.text = "unsuccessful achievements";

            }
        } );
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
