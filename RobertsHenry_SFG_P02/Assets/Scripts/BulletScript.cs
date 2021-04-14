using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float _bulletSpeed = 25f;
    [SerializeField] Vector3 _bulletForce;

    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _bulletForce = new Vector3(0f, 0f, _bulletSpeed);
    }

    private void Start()
    {
        Shoot();
    }

    void Shoot()
    {
        //_rigidbody.AddForce(_bulletForce, ForceMode.Impulse);
        _rigidbody.velocity = this.transform.forward * _bulletSpeed;
    }
}
