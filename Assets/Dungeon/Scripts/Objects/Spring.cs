using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gamekit2D
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Spring : MonoBehaviour
    {
        public Vector2 ejectionSpeed;

        protected readonly int m_HashEjectionPara = Animator.StringToHash("Ejection");
        protected Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject == PlayerCharacter.PlayerInstance.gameObject)
            {
                if (PlayerCharacter.PlayerInstance.GetMoveVector().y < -2)
                {
                    //Debug.Log(PlayerCharacter.PlayerInstance.GetMoveVector().y);
                    PlayerCharacter.PlayerInstance.SetMoveVector(ejectionSpeed);
                    //animator.SetTrigger(m_HashEjectionPara);
                }
            }
        }
    }
}
