using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

namespace Script
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]private Animator _animator;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private Vector2 _move;
        [SerializeField] private Vector2 _look;
       
       
        private PlayerInput _pI;
        private Rigidbody _rb;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _rb = GetComponent<Rigidbody>();
            _pI = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            Vector3 move = new Vector3(_move.x, 0 , _move.y);
            Vector3 look = new Vector3(_look.x, 0 , _look.y);   
            
            transform.Translate(new Vector3(_move.x, 0, _move.y) * (_moveSpeed * Time.deltaTime), Space.World);

            Vector3 dir = _look.magnitude > 0.1f ? look : move;

            if (dir.sqrMagnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
            }
            _animator.SetFloat("X", move.x);
            _animator.SetFloat("Z", move.z);
        }

        public void OnMove(InputValue value)
        {
            _move = value.Get<Vector2>();
        }

        public void OnLook(InputValue value)
        {
            _look = value.Get<Vector2>();
        }
    }
}
