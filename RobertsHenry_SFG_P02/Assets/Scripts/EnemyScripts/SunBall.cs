using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBall : MonoBehaviour
{
    [SerializeField] int _damage = 15;

    PlayerHUD _playerHUD;
    EnemyWeaponController _eWC;

    float _lifeSpan = 3f;
    float _startTime;
    private void Awake()
    {
        _eWC = FindObjectOfType<EnemyWeaponController>();
        _startTime = Time.time;
    }

    private void Update()
    {
        Lifespan();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit Something");

        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.DamagePlayer(_damage);
        }
        _eWC.OnContact();
    }

    void Lifespan()
    {
        if (Time.time - _startTime >= _lifeSpan)
        {
            Destroy(this.gameObject);
        }
    }
}
