using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Script
{
    public class AIController : MonoBehaviour
    {
       
        
        private Animator _animator;
        private NavMeshAgent _agent;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            _animator.SetFloat("Speed", _agent.velocity.normalized.magnitude);
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _animator.SetTrigger("Hit");
            }
        }
    }
}
