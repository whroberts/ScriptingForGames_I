using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour {


    GameController _gameController;
    ParticleSystem _asteroidExplosion;
    MeshRenderer _mesh;
    Collider _collider;
    GameAudio _gameAudio;

    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
        _asteroidExplosion = GetComponent<ParticleSystem>();
        _mesh = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
        _gameAudio = FindObjectOfType<GameAudio>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            _gameController.AddScore();
            _asteroidExplosion.Play();
            _gameAudio.AsteroidExplosion(this.gameObject.transform);
            

            _collider.enabled = false;
            _mesh.enabled = false;

            Destroy(other.gameObject);
            Destroy(this.gameObject, 2f);
        }
    }
}
