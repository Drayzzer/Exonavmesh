using FMODUnity;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{
    public class PlayerController : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private GameObject _gunFlash;
        [SerializeField] private GameObject _hitEffect;
        
        [Header("Settings")]
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Vector2 _move;
        [SerializeField] private Vector2 _look;
        [SerializeField] private Transform _gunOut;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _gunRange = 20;
        [SerializeField] private Animator _animator;
        [SerializeField] private EventReference _er;
        [SerializeField] private EventReference _eventReference;
        
        private PlayerInput _pI;
        private Rigidbody _rb;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _pI = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            Vector3 move = new Vector3(_move.x, 0 , _move.y);
            Vector3 look = new Vector3(_look.x, 0 , _look.y);   
            
            // Movement
            transform.Translate(new Vector3(_move.x, 0, _move.y) * (_moveSpeed * Time.deltaTime), Space.World);
            
            // Rotation
            Vector3 dir = _look.magnitude > 0.1f ? look : move;

            if (dir.sqrMagnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
            }
            
            // Animation
            Vector3 moveDirection = transform.InverseTransformDirection(move);
            
            _animator.SetFloat("X", moveDirection.x);
            _animator.SetFloat("Z", moveDirection.z);
        }
        
        public void OnMove(InputValue value)
        {
            FmodTest.Instance.Play(_eventReference,true, gameObject);
            _move = value.Get<Vector2>();
        }

        public void OnLook(InputValue value)
        {
            _look = value.Get<Vector2>();
        }
        
        public void OnAttack(InputValue value)
        {
            FmodTest.Instance.Play(_er,false, null);
            if (value.isPressed)
            {
                RaycastHit hit;
                Instantiate(_gunFlash, _gunOut.position, _gunOut.rotation);
                if (Physics.Raycast(_gunOut.position, _gunOut.forward, out hit, _gunRange,_layerMask))
                {
                    Instantiate(_hitEffect, hit.transform.position, hit.transform.rotation);
                    Destroy(hit.transform.gameObject);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(_gunOut.position, _gunOut.forward * _gunRange);
        }
    }
}





