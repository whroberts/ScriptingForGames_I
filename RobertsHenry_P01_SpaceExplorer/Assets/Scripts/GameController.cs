using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject _playerShip = null;
    [SerializeField] GameObject _deathParticle = null;

    [SerializeField] int _scoreToWin = 100;

    PlayerShip _playerShipScript;
    SpawnObjects _spawnObjects;
    UIController _uiController;
    GameAudio _gameAudio;

    public int _score = 0;

    private void Awake()
    {
        _playerShipScript = _playerShip.GetComponent<PlayerShip>();
        _spawnObjects = GetComponent<SpawnObjects>();
        _gameAudio = GetComponent<GameAudio>();
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
    }

    private void ReloadLevel()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(activeSceneIndex);
    }

    private void Win()
    {
        _gameAudio.WinClip();
        _spawnObjects.enabled = false;
        _playerShip.SetActive(false);
        _uiController._winPanel.SetActive(true);
    }

    public void AddScore()
    {
        _score = _score + 1;

        if (_score >= _scoreToWin)
        {
            Win();
        }
    }

    public void Lose()
    {
        _gameAudio.DeathClip();
        _spawnObjects.enabled = false;

        Instantiate(_deathParticle, _playerShip.transform.position, Quaternion.identity);

        _playerShip.SetActive(false);
        _uiController._losePanel.SetActive(true);
    }
}
