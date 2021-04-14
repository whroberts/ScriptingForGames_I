using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject _player = null;
    [SerializeField] LayerMask _layersToHit;
    Vector3 _currentPos;
    Vector3 _playerPos;

    float _moveSpeed = 3f;

    private void Start()
    {
        
    }

    private void Update()
    {
        FacePlayer();
        CheckForPlayer();
    }

    void CheckForPlayer()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(this.transform.position, 10f, _layersToHit);
        foreach (var hit in detectedColliders)
        {
            _currentPos = new Vector3(transform.position.x, 1.8f, transform.position.z);
            _playerPos = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
            transform.position = Vector3.MoveTowards(_currentPos,_playerPos, -1 * _moveSpeed * Time.deltaTime);
        }
    }

    void FacePlayer()
    {
        this.gameObject.transform.LookAt(_player.transform);
    }
}
