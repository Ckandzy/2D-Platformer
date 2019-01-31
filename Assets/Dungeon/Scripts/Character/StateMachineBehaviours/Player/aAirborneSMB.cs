using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class aAirborneSMB : SceneLinkedSMB<PlayerCharacter>
    {
        public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }

        public override void OnSLStateNoTransitionUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.UpdateFacing();
            m_MonoBehaviour.UpdateJump();
            m_MonoBehaviour.AirborneHorizontalMovement();
            m_MonoBehaviour.AirborneVerticalMovement();
            m_MonoBehaviour.CheckForGrounded();
            m_MonoBehaviour.CheckForClimbing();
            if (m_MonoBehaviour.remainingJumpTimes > 0)
            {
                if (m_MonoBehaviour.CheckForJumpInput())
                {
                    m_MonoBehaviour.remainingJumpTimes--;
                    m_MonoBehaviour.SetVerticalMovement(m_MonoBehaviour.jumpSpeed);
                }
            }
            if (m_MonoBehaviour.CheckForMeleeAttackInput())
                m_MonoBehaviour.MeleeAttack();
            else if (m_MonoBehaviour.CheckForRangeAttackInput())
                m_MonoBehaviour.RangeAttack();
        }
    }
}