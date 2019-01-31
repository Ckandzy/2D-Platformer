using UnityEngine;

namespace Gamekit2D
{
    public class ArrowAttackSMB : SceneLinkedSMB<PlayerCharacter>
    {
        public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.TeleportToColliderBottom();
        }

        public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
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

        public override void OnSLStatePreExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //AnimatorStateInfo nextState = animator.GetNextAnimatorStateInfo (0);
            //if (!nextState.IsTag ("WithGun"))
            //    m_MonoBehaviour.ForceNotHoldingGun ();
        }
    }
}