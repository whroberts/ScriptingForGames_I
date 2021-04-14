using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour {

    [Header("Particle Effects")]
    [SerializeField] ParticleSystem _laserExplosion = null;

    GameController _gameController;
    MeshRenderer _mesh;
    Collider _collider;
    GameAudio _gameAudio;

    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
        _mesh = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
        _gameAudio = FindObjectOfType<GameAudio>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            _gameController.AddScore();

            _laserExplosion.Play();
            _gameAudio.AsteroidExplosion(this.gameObject.transform);

            DisableObject();

            Destroy(other.gameObject);
            Destroy(this.gameObject, 2f);
        }
    }

    public void DisableObject()
    {
        _collider.enabled = false;
        _mesh.enabled = false;
    }
}
