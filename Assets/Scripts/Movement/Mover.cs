using RPG.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Transform target;
        private NavMeshAgent agent;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                Debug.Log("NavMeshAgent is null");
            }

        }

        void Update()
        {
            UpdateAnimator();
        }


        public void StartMoveTo(Vector3 destination)
        {
            GetComponent<Fighter>().CancelAttack();
            MoveTo(destination);
        }
        public void MoveTo(Vector3 destination)
        {
            agent.destination = destination;
            agent.isStopped = false;
        }

        public void StopMovement()
        {
            agent.isStopped = true;
        }

        private void UpdateAnimator()
        {
            Vector3 agentVelocity = agent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(agentVelocity);
            float speed = localVelocity.z;
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("ForwordSpeed", speed);
        }


    }
}

