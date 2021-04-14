using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMultiShot : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float _powerupDuration = 5f;

    [Header("Setup")]
    [SerializeField] GameObject _visualsToDeactivate = null;

    ParticleSystem _pickUp;
    GameAudio _gameAudio;
    Collider _colliderToDeactiveate = null;
    bool _poweredUp = false;

    private void Awake()
    {
        _pickUp = GetComponent<ParticleSystem>();
        _gameAudio = FindObjectOfType<GameAudio>();
        _colliderToDeactiveate = GetComponent<Collider>();
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
        //EnableObject();

        _poweredUp = false;
    }

    void ActivatePowerup(PlayerShip playerShip)
    {
        if (playerShip != null)
        {
            WeaponController weaponController = playerShip.GetComponent<WeaponController>();
            weaponController._numLasers = 5;
            _pickUp.Play();
            _gameAudio.MultiShotClip(true);
        }
    }

    void DeactivatePowerup(PlayerShip playerShip)
    {
        if (playerShip != null)
        {
            WeaponController weaponController = playerShip.GetComponent<WeaponController>();
            weaponController._numLasers = 1;
            _gameAudio.MultiShotClip(false);
        }
    }

    public void DisableObject()
    {
        _colliderToDeactiveate.enabled = false;
        _visualsToDeactivate.SetActive(false);
    }

    public void EnableObject()
    {
        _colliderToDeactiveate.enabled = true;
        _visualsToDeactivate.SetActive(true);
    }
}
