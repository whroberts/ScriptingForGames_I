using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [Header("Health Bar")]
    [SerializeField] Slider _healthBarSlider = null;
    [SerializeField] Text _healthText = null;

    [Header("Damage")]
    [SerializeField] GameObject _damagePanel = null;

    [Header("Values")]
    [SerializeField] Text _enemyHealthValue = null;
    [SerializeField] Text _enemiesDestroyedValue = null;

    [Header("Scripts")]
    [SerializeField] PlayerHealth _playerHealth = null;

    EnemyHealth _enemyHealth;
    Level01Controller _levelController;

    private void Awake()
    {
        _levelController = FindObjectOfType<Level01Controller>();
    }

    private void Start()
    {
        _healthBarSlider.maxValue = _playerHealth._totalPlayerHealth;
    }

    private void Update()
    {
        _enemyHealth = FindObjectOfType<EnemyHealth>();

        _healthText.text = _playerHealth._currentPlayerHealth.ToString();
        _healthBarSlider.value = _playerHealth._currentPlayerHealth;
        _enemyHealthValue.text = _enemyHealth._currentEnemyHealth.ToString();
        _enemiesDestroyedValue.text = _levelController._destroyedEnemies.ToString();
    }

    public IEnumerator DamagePanel()
    {
        _damagePanel.SetActive(true);

        yield return new WaitForSeconds(0.7f);
        Debug.Log("Back to false");
        _damagePanel.SetActive(false);

    }
}
