using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [Header("Objets To Spawn")]
    [SerializeField] GameObject _asteroids = null;
    [SerializeField] GameObject _powerupSpeed = null;
    [SerializeField] GameObject _powerupMultiShot = null;

    PlayerShip _playerShip;

    private void Awake()
    {
        _playerShip = FindObjectOfType<PlayerShip>();
    }

    private void Start()
    {
        SpawnAsteroids();
    }

    private void FixedUpdate()
    {
        if (Time.time % 3 == 0)
        {
            SpawnAsteroids();
        } 
        else if (Time.time % 5 == 0)
        {
            SpawnPowerUpSpeed();
        } 
        else if (Time.time % 8 == 0)
        {
            SpawnPowerUpMultiShot();
        }
    }

    void SpawnAsteroids()
    {
        Vector3 newTransform = new Vector3(Random.Range(-175f, 175f), 0f, Random.Range(-175f, 175f));
        GameObject asteroidClone = (GameObject)Instantiate(_asteroids, newTransform, Quaternion.identity);
    }

    void SpawnPowerUpSpeed()
    {
        Vector3 newTransform = new Vector3(Random.Range(-100f, 100f), 0f, Random.Range(-100f, 100f));
        GameObject asteroidClone = (GameObject)Instantiate(_powerupSpeed, newTransform, Quaternion.identity);
    }

    void SpawnPowerUpMultiShot()
    {
        Vector3 newTransform = new Vector3(Random.Range(-100f, 100f), 0f, Random.Range(-100f, 100f));
        GameObject asteroidClone = (GameObject)Instantiate(_powerupMultiShot, newTransform, Quaternion.identity);
    }
}
