using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 5;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Move(Vector2 Dir)
    {
        _rigidbody.AddForce(new Vector3(Dir.x, 0, Dir.y) * MovementSpeed, ForceMode.Force);
    }
}
