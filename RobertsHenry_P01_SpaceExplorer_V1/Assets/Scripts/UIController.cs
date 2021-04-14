using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] TMP_Text _scoreText = null;
    [SerializeField] TMP_Text _health = null;
    public GameObject _winPanel = null;
    public GameObject _losePanel = null;

    GameController _gameController;
    PlayerShip _playerShip;

    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
        _playerShip = FindObjectOfType<PlayerShip>();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score: "+ _gameController._score.ToString();
        _health.text = _playerShip._currentHeath.ToString();
    }
}
