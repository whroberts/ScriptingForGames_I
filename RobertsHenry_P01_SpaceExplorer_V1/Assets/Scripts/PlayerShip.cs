using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 12f;
    [SerializeField] float _turnSpeed = 3f;
    [SerializeField] int _maxHealth = 100;

    [Header("Feedback")]
    [SerializeField] TrailRenderer _trailLeft = null;
    [SerializeField] TrailRenderer _trailRight = null;
    [SerializeField] ParticleSystem _engineParticles = null;


    UIController _uiController;
    SpawnObjects _spawnObjects;
    Rigidbody _rb = null;
    GameAudio _gameAudio;
    bool _isBoosting = false;
    public int _currentHeath = 0;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _gameAudio = FindObjectOfType<GameAudio>();
        _uiController = FindObjectOfType<UIController>();
        _spawnObjects = FindObjectOfType<SpawnObjects>();

        _trailLeft.enabled = false;
        _trailRight.enabled = false;
        _currentHeath = _maxHealth;
    }

    private void FixedUpdate()
    {
        MoveShip();
        TurnShip();
    }

    private void MoveShip()
    {
        Vector3 notMoving = new Vector3(0f, 0f, 0f);

        float moveAmountThisFrame = Input.GetAxisRaw("Vertical") * _moveSpeed;

        Vector3 moveDirection = transform.forward * moveAmountThisFrame;

        if (!_isBoosting)
        {
            if (moveDirection == notMoving)
            {
                _gameAudio.IdleClip(false);
                _engineParticles.Stop();
            }
            else
            {

                _gameAudio.IdleClip(false);
                _engineParticles.Play();
            }
        }

        _rb.AddForce(moveDirection);
        
    }

    private void TurnShip()
    {

        float turnAmountThisFrame = Input.GetAxisRaw("Horizontal") * _turnSpeed;

        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);

        _rb.MoveRotation(_rb.rotation * turnOffset);
    }

    public void Kill()
    {
        _gameAudio.DeathClip();
        _spawnObjects.enabled = false;
        _uiController._losePanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Damage(int damage)
    {
        _currentHeath -= damage;
        
        if (_currentHeath <= 0)
        {
            Kill();
        }
    }

    public void SetSpeed(float speedChange)
    {
        _moveSpeed += speedChange;
    }

    public void SetBoosters(bool activeState)
    {
        _trailLeft.enabled = activeState;
        _trailRight.enabled = activeState;

        if (activeState)
        {
            _isBoosting = true;
            _engineParticles.Stop();
        } else
        {
            _isBoosting = false;
            _engineParticles.Play();
        }
    }
}
