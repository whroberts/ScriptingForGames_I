using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] AudioClip _boost = null;
    [SerializeField] AudioClip _hitWall = null;
    [SerializeField] AudioClip _asteroidExplosion = null;
    [SerializeField] AudioClip _multiShotPickup = null;
    [SerializeField] AudioClip _death = null;
    [SerializeField] AudioClip _win = null;
    [SerializeField] AudioClip _background = null;
    [SerializeField] AudioClip _damage = null;

    [Header("Audio Sources")]
    [SerializeField] AudioSource _audioSourcePlayer = null;
    [SerializeField] AudioSource _audioSourceGame = null;
    [SerializeField] AudioSource _spawnableAudio = null;


    private void Awake()
    {
        _audioSourceGame.clip = _background;
        _audioSourceGame.Play();
    }

    public void BoostClip(bool state)
    {
        _audioSourcePlayer.clip = _boost;

        if (state) {
            _audioSourcePlayer.Play();
        } else
        {
            _audioSourcePlayer.Stop();
        }
    }

    public void HitWallClip()
    {
        _audioSourcePlayer.clip = _hitWall;
        _audioSourcePlayer.Play();
    }

    public void AsteroidExplosion(Transform transform)
    {
        _spawnableAudio.clip = _asteroidExplosion;
        AudioSource tempAudio = Instantiate(_spawnableAudio, transform.position, Quaternion.identity);
        tempAudio.volume = 0.2f;
        tempAudio.Play();
        Destroy(tempAudio.gameObject, 1f);
    }

    public void MultiShotClip(bool state)
    {
        _audioSourcePlayer.clip = _multiShotPickup;
        if (state)
        {
            _audioSourcePlayer.Play();
        } else
        {
            _audioSourcePlayer.Stop();
        }

    }

    public void DamageClip()
    {
        _audioSourcePlayer.clip = _damage;
        _audioSourcePlayer.Play();
    }

    public void DeathClip()
    {
        _audioSourceGame.clip = _death;
        _audioSourceGame.Play();
    }

    public void WinClip()
    {
        _audioSourceGame.clip = _win;
        _audioSourceGame.Play();
    }
}
