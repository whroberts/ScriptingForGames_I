using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    PlayerShip _playerShip;
    UIController _uiController;

    public int _score = 0;

    private void Awake()
    {
        _playerShip = FindObjectOfType<PlayerShip>();
        _uiController = FindObjectOfType<UIController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ReloadLevel();
        } else if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }

        if (_score >= 1000)
        {
            Win();
        }
    }

    private void ReloadLevel()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(activeSceneIndex);
    }

    private void Win()
    {
        _playerShip.enabled = false;
        _uiController._winPanel.SetActive(true);
    }

    public void AddScore()
    {
        _score = _score + 1;
    }

    public void Lose()
    {
        _playerShip.Kill();
        _uiController._losePanel.SetActive(true);
    }
}
