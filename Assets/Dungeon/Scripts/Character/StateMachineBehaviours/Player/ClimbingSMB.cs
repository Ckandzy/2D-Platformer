using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class ClimbingSMB : SceneLinkedSMB<PlayerCharacter>
    {
        public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.StartClimb();
        }

        public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.GroundedHorizontalMovement(false);
            //m_MonoBehaviour.CheckForGrounded();
            m_MonoBehaviour.LadderVerticalMovement();
            m_MonoBehaviour.CheckForClimbing();
            m_MonoBehaviour.CheckForGrounded();
            if (m_MonoBehaviour.CheckForJumpInput())
                m_MonoBehaviour.SetVerticalMovement(m_MonoBehaviour.jumpSpeed);
        }

        public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}