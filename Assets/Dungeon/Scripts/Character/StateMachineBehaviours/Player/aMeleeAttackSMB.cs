using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class aMeleeAttackSMB : SceneLinkedSMB<PlayerCharacter>
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
            //m_MonoBehaviour.AirborneHorizontalMovement();
            if (m_MonoBehaviour.CheckForGrounded())
                m_MonoBehaviour.GroundedHorizontalMovement(false);
            m_MonoBehaviour.AirborneVerticalMovement();
            m_MonoBehaviour.CheckForGrounded();
        }

        public override void OnSLStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.DisableMeleeAttack();
        }
    }
}