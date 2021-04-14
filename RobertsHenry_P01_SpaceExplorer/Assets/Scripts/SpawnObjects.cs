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

    private void FixedUpdate()
    {
        if (Time.time < 30)
        {
            if (Time.time % 1 == 0)
            {
                SpawnAsteroids();
            }
        } else if (Time.time >= 30 && Time.time < 60)
        {
            if (Time.time % 0.5 == 0)
            {
                SpawnAsteroids();
            }
        }
        else
        {
            if (Time.time % 0.25 == 0)
            {
                SpawnAsteroids();
            }
        }

        if (Time.time % 20 == 0)
        {
            SpawnPowerUpSpeed();
        } 
        else if (Time.time % 15 == 0)
        {
            SpawnPowerUpMultiShot();
        }
    }

    void SpawnAsteroids()
    {
        Vector3 newTransform = new Vector3(Random.Range(-175f, 175f), 0f, Random.Range(-175f, 175f));
        GameObject asteroidClone = (GameObject)Instantiate(_asteroids, newTransform, Quaternion.identity);
        asteroidClone.transform.localScale = new Vector3(Random.Range(20f, 40f), Random.Range(20f, 40f), Random.Range(20f, 40f));
    }

    void SpawnPowerUpSpeed()
    {
        Vector3 newTransform = new Vector3(Random.Range(-100f, 100f), 0f, Random.Range(-100f, 100f));
        GameObject powerupSpeedClone = (GameObject)Instantiate(_powerupSpeed, newTransform, Quaternion.identity);
    }

    void SpawnPowerUpMultiShot()
    {
        Vector3 newTransform = new Vector3(Random.Range(-100f, 100f), 0f, Random.Range(-100f, 100f));
        GameObject powerupMultiShotClone = (GameObject)Instantiate(_powerupMultiShot, newTransform, Quaternion.identity);
    }
}
