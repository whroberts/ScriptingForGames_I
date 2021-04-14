using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVolume : MonoBehaviour
{
    [SerializeField] ParticleSystem _damage = null;
    [SerializeField] PlayerHUD _playerHUD = null;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        
        if (playerHealth != null)
        {
            playerHealth.DamagePlayer(10);
            _damage.Play();
            StartCoroutine(_playerHUD.DamagePanel());
        }
    }
}
