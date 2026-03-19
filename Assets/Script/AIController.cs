using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{
    [RequireComponent(typeof(Animator))]
    public class AIController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                _animator.SetTrigger("Hit");
            }
        }
    }
}
