using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Gamekit2D
{
    public class Demo : MonoBehaviour
    {
        private void Start()
        {
            
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("On Collidision Endter");
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            Debug.Log("On Collidision Stay");
        }
    }
}
