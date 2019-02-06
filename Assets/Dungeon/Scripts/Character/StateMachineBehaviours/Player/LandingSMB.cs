using UnityEngine;

namespace Gamekit2D
{
    public class LandingSMB : SceneLinkedSMB<PlayerCharacter>
    {
        public override void OnSLStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //m_MonoBehaviour.TeleportToColliderBottom();
            m_MonoBehaviour.remainingJumpTimes = m_MonoBehaviour.maxJumpTimes;
        }

        public override void OnSLStateNoTransitionUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.UpdateFacing();
            m_MonoBehaviour.GroundedHorizontalMovement(false);
            m_MonoBehaviour.GroundedVerticalMovement();
            m_MonoBehaviour.CheckForCrouching();
            m_MonoBehaviour.CheckForGrounded();
            //m_MonoBehaviour.CheckForPushing();
            //m_MonoBehaviour.CheckForClimbing();
            //m_MonoBehaviour.CheckForHoldingGun();
            //m_MonoBehaviour.CheckAndFireGun ();
            //if (m_MonoBehaviour.remainingJumpTimes > 0)
            //{
            //    if (m_MonoBehaviour.CheckForJumpInput())
            //    {
            //        m_MonoBehaviour.remainingJumpTimes--;
            //        m_MonoBehaviour.SetVerticalMovement(m_MonoBehaviour.jumpSpeed);
            //    }
            //}
            //if(m_MonoBehaviour.CheckForMeleeAttackInput ())
                //m_MonoBehaviour.MeleeAttack();
        }
    }
}