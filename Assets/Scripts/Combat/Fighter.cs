using UnityEngine;
using System.Collections;
using RPG.Controller;
using RPG.Movement;


namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] private float weaponRange = 2.0f;
        private Transform target;

        private void Update()
        {
            
            if (target != null)
            {

                GetComponent<Mover>().MoveTo(target.position);

                if (GetIsInRange())
                {
                    GetComponent<Mover>().StopMovement();
                }
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(target.transform.position, transform.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            print("Screaming combat stuff " + combatTarget.transform.name);
        }

        public void CancelAttack()
        {
            target = null;
        }
    }

}