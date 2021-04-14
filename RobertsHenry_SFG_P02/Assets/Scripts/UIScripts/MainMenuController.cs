using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Text _highScoreTextView = null;
    [SerializeField] Slider _sensitivitySld = null;
    [SerializeField] Text _settingsValue = null;

    float _mouseSensitivity;

    private void Start()
    {
        Cursor.visible = true;


        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();

        _mouseSensitivity = PlayerPrefs.GetInt("PlayerSensitivity");

        _sensitivitySld.value = _mouseSensitivity;
        SetSensitivity();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        _highScoreTextView.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void SetSensitivity()
    {
        _mouseSensitivity = _sensitivitySld.value;
        _settingsValue.text = _mouseSensitivity.ToString();
        PlayerPrefs.SetInt("PlayerSensitivity", (int)_sensitivitySld.value);
    }
}
