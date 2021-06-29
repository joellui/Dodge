using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

using UnityEngine.UI;

public class GPSAuth : MonoBehaviour
{
    [SerializeField] private Text debugText;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        signinwithplaygames();
    }

    void Initialize()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().RequestServerAuthCode(false)
            .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        debugText.text = "playgames initialized";
    }

    void signinwithplaygames()
    {
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (success) =>
        {
            switch (success)
            {
                case SignInStatus.Success:
                    debugText.text = "Signin player using play games successfully";
                    break;
                default:
                    debugText.text = "Signin failed";
                    break;
            }

        });
    }

    public void postscoretoleaderboard()
    {
        String leaderboard = Mathf.RoundToInt(PlayerPrefs.GetFloat("highScore",0)).ToString();
        
        Social.ReportScore(int.Parse(leaderboard),"CgkIgof7xpIVEAIQAg",(bool success) =>
        {
            if (success)
            {
                debugText.text = "Successfully add score to leaderboard";
            }
            else
            {
                debugText.text = "unsuccessful";
            }
        });
    }

    public void showLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }

    public void achievementsCompleted()
    {
        Social.ReportProgress("CgkIgof7xpIVEAIQAw",100.0f, (bool success) =>
        {
            if (success)
            {
                debugText.text = "successfully unlocked achievements";

            }
            else
            {
                debugText.text = "unsuccessful achievements";

            }
        } );
    }

    public void showAchievements()
    {
        Social.ShowAchievementsUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
