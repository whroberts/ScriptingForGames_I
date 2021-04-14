using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpeed : MonoBehaviour
{
    [Header("Powerup Settings")]
    [SerializeField] float _speedIncreaseAmount = 20;
    [SerializeField] float _powerupDuration = 5;

    [Header("Setup")]
    [SerializeField] GameObject _visualsToDeactivate = null;

    GameAudio _gameAudio;
    Collider _colliderToDeactivate = null;
    bool _poweredUp = false;

    private void Awake()
    {
        _colliderToDeactivate = GetComponent<Collider>();
        _gameAudio = FindObjectOfType<GameAudio>();
        EnableObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerShip playerShip = other.gameObject.GetComponent<PlayerShip>();

        if (playerShip != null && _poweredUp == false)
        {
            StartCoroutine(PowerupSequence(playerShip));
        }
    }
    
    IEnumerator PowerupSequence(PlayerShip playerShip)
    {
        _poweredUp = true;

        ActivatePowerup(playerShip);
        DisableObject();

        yield return new WaitForSeconds(_powerupDuration);
        DeactivatePowerup(playerShip);
        EnableObject();

        _poweredUp = false;
    }

    void ActivatePowerup(PlayerShip playerShip)
    {
        if (playerShip != null)
        {
            playerShip.SetSpeed(_speedIncreaseAmount);
            playerShip.SetBoosters(true);
            _gameAudio.BoostClip(true);
        }
    }

    void DeactivatePowerup(PlayerShip playerShip)
    {
        playerShip?.SetSpeed(-_speedIncreaseAmount);
        playerShip?.SetBoosters(false);
        _gameAudio.BoostClip(false);
    }

    public void DisableObject()
    {
        _colliderToDeactivate.enabled = false;
        _visualsToDeactivate.SetActive(false);
    }

    public void EnableObject()
    {
        _colliderToDeactivate.enabled = true;
        _visualsToDeactivate.SetActive(true);
    }
}
