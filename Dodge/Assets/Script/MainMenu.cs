using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScoreSecondServivedUI;
    
    // Start is called before the first frame update
    void Start()
    {
        highScoreSecondServivedUI.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("highScore",0)).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }
}
