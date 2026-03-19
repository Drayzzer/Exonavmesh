using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class NavTarget : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _target = GameObject.FindGameObjectWithTag("target").transform;
        }

        private void Update()
        {
            _agent.SetDestination(_target.transform.position);
        }
    }
}
