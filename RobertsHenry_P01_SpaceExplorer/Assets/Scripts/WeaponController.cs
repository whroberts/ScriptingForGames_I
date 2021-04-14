using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] GameObject _laser = null;
    [SerializeField] GameObject _laserContainer = null;
    [SerializeField] float _laserSpeed = 300f;

    [Header("GamePlay")]
    public int _numLasers = 1;

    Transform _laserTrans;
    GameAudio _gameAudio;
    Vector3 _offset;

    float[] _shotDirection = new float[5] { 30f, 15f, 0f, -15f, -30f };
    float[] _shotPosition = new float[5] { -2f,-1f,0f,1f,2f};

    private void Awake()
    {
        _laserTrans = _laserContainer.GetComponent<Transform>();
        _gameAudio = FindObjectOfType<GameAudio>();

        _offset = this.transform.position - _laserTrans.position;
    }
    private void LateUpdate()
    {
        //_laserStart = 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShootLaser();
        }
    }

    private void ShootLaser()
    {
        for (int i = 0; i < _numLasers; i++)
        {
            GameObject laserClone = (GameObject)Instantiate(_laser,_laserTrans);
            Rigidbody rb = laserClone.GetComponent<Rigidbody>();
            Transform trans = laserClone.GetComponent<Transform>();
            AudioSource _audioSource = laserClone.GetComponent<AudioSource>();

            if (_numLasers != 1)
            {
                trans.localRotation = Quaternion.Euler(90f, 0f, _shotDirection[i]+this.gameObject.transform.rotation.z);
                _audioSource.volume = 0.2f;
            }
            rb.velocity = trans.up * _laserSpeed;
            Destroy(laserClone, 3f);
        }
    }
}
