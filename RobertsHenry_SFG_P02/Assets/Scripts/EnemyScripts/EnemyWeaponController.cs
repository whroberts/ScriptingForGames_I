using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] GameObject _sunBall = null;

    [SerializeField] Transform _gunBarrel = null;

    [Header("Effects")]
    [SerializeField] ParticleSystem _explosionParticles = null;

    GameObject clone;

    float _fireRate = 3f;
    float _nextFire = 2f;
    float _speed = 10f;

    private void Update()
    {
        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            FireSunBall();
        }
    }

    void FireSunBall()
    {
        clone = Instantiate(_sunBall);
        clone.transform.localPosition = _gunBarrel.position;
        Rigidbody rb = clone.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * _speed;
    }

    public void OnContact()
    {
        _explosionParticles.transform.position = clone.transform.position;
        _explosionParticles.Play();
        Destroy(clone);
    }
}
