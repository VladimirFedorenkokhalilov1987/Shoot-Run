using System;
using UnityEngine;
namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for
        public Shoot shoot;
        public float shootTime = 10f;
        private float shootTimeDefault;
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
	        agent.updateRotation = false;
	        agent.updatePosition = true;
            target = FindObjectOfType<Player>().transform;
            shootTimeDefault = shootTime;
        }


        private void Update()
        {
            if(!target)
                target = FindObjectOfType<Player>().transform;

            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
            {
                character.Move(Vector3.zero, false, false);
                character.gameObject.transform.LookAt(target);
                
                if (shootTime > 0)
                {
                    shootTime -= Time.deltaTime;
                }

                if (shootTime < 0)
                {
                    shoot.DoShoot();
                    shootTime = shootTimeDefault;
                }
            }

        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
