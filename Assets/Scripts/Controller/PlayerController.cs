﻿using UnityEngine;
using System.Collections;
using RPG.Movement;
using System;
using RPG.Combat;
using System.Drawing;

namespace RPG.Controller
{
    public class PlayerController : MonoBehaviour
    {

        void Update()
        {
            if(InteractWithCombat()) return ;
            if(InteractWithMovement()) return ;
            print("Nothing to interact with");
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target != null ) 
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        GetComponent<Fighter>().Attack(target);

                    }
                    return true;
                }

            }
            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hitInfo;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hitInfo);
            if (hasHit == true)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveTo(hitInfo.point);
                }
                return true;
            }
            return false;

        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
