using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class NavTarget : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            _agent.SetDestination(_target.transform.position);
            _animator.SetFloat("Speed", _agent.velocity.normalized.magnitude);
        }
    }
}
