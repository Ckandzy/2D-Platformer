using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gamekit2D
{
    public class CoinPickup : MonoBehaviour
    {
        //public int healthAmount = 1;
        public bool isStatic = false;
        public UnityEvent OnCoinPickup;

        private void Awake()
        {
            if (isStatic)
                this.GetComponentInParent<Rigidbody2D>().gravityScale = 0;
            else
                this.GetComponentInParent<Rigidbody2D>().gravityScale = 1;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == PlayerCharacter.PlayerInstance.gameObject)
            {
                OnCoinPickup.Invoke();
            }
        }
    }
}