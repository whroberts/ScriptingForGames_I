using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HazardVolume : MonoBehaviour
{
    [Header("Particle Effects")]
    [SerializeField] ParticleSystem _objectExplosion = null;

    Asteroids _asteroids;
    GameAudio _gameAudio;

    private void Awake()
    {
        _asteroids = FindObjectOfType<Asteroids>();
        _gameAudio = FindObjectOfType<GameAudio>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerShip playerShip = other.gameObject.GetComponent<PlayerShip>();

        if (playerShip != null)
        {
            playerShip.Damage(10);

            _objectExplosion.Play();
            //_gameAudio.AsteroidExplosion(this.gameObject.transform);
            //_gameAudio.DamageClip();

            _asteroids.DisableObject();
            Destroy(this.gameObject, 2f);
        }
    }
}
