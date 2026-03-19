using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class NavTarget : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private Transform _target;
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            _agent.SetDestination(_target.transform.position);
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
