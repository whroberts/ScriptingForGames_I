using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Stats")]
    public int _maxHealth = 100;
    public int _currentEnemyHealth = 0;

    [Header("Scripts")]
    [SerializeField] Level01Controller _lc = null;

    Animator _animator;
    GameObject _clone;

    private void Awake()
    {
        _currentEnemyHealth = _maxHealth;
        _animator = GetComponent<Animator>();
    }

    public void DamageEnemy(int damage)
    {
        _currentEnemyHealth -= damage;

        if (_currentEnemyHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        _lc._destroyedEnemies++;
        SpawnNewEnemy();
    }

    void SpawnNewEnemy()
    {
        Vector3 newLocation = new Vector3(Random.Range(-15f, 15f), 1.8f, Random.Range(-15f, 15f));
        _clone = Instantiate(this.gameObject);
        _clone.transform.localPosition = newLocation;

        Destroy(this.gameObject);
    }
}
