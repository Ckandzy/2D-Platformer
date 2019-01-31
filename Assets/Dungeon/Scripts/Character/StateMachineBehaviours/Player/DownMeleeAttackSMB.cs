using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class DownMeleeAttackSMB : SceneLinkedSMB<PlayerCharacter>
    {
        //int m_HashAirborneMeleeAttackState = Animator.StringToHash ("Hero_Melee");
    
        public override void OnSLStatePostEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //m_MonoBehaviour.ForceNotHoldingGun();
            //m_MonoBehaviour.EnableMeleeAttack();
            //m_MonoBehaviour.SetHorizontalMovement(m_MonoBehaviour.meleeAttackDashSpeed * m_MonoBehaviour.GetFacing());
        }

        public override void OnSLStateNoTransitionUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.UpdateFacing();
            m_MonoBehaviour.UpdateJump();
            if (m_MonoBehaviour.CheckForGrounded())
                m_MonoBehaviour.GroundedHorizontalMovement(false);
            else
            {
                m_MonoBehaviour.AirborneHorizontalMovement();
                m_MonoBehaviour.AirborneVerticalMovement();
            }
            if (m_MonoBehaviour.remainingJumpTimes > 0)
            {
                if (m_MonoBehaviour.CheckForJumpInput())
                {
                    m_MonoBehaviour.remainingJumpTimes--;
                    m_MonoBehaviour.SetVerticalMovement(m_MonoBehaviour.jumpSpeed);
                }
            }
        }

        public override void OnSLStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.DisableMeleeAttack();
        }
    }
}