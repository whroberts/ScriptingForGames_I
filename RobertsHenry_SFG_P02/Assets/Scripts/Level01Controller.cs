using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] UIController _uiController = null;
    [SerializeField] MouseLook _mouseLook = null;

    public int _destroyedEnemies = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_uiController._isPaused)
            {
                _uiController.PauseLevel();
            } 
            else if (_uiController._isPaused)
            {
                _uiController.ResumeLevel();
            }
        }
    }

    public void SaveOnExit()
    {
        string highScoreText = "HighScore";
        string sensitivityText = "PlayerSensitivity";

        int highScore = PlayerPrefs.GetInt(highScoreText);
        int currentSensitivity = PlayerPrefs.GetInt(sensitivityText);

        if (_destroyedEnemies > highScore)
        {
            PlayerPrefs.SetInt(highScoreText, _destroyedEnemies);
        }

        if (_mouseLook._mouseSensitivity != currentSensitivity)
        {
            PlayerPrefs.SetInt(sensitivityText, _mouseLook._mouseSensitivity);
        }


    }
}
