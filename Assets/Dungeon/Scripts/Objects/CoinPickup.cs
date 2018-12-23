using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gamekit2D
{
    public class CoinPickup : MonoBehaviour
    {
        //public int healthAmount = 1;
        public UnityEvent OnCoinPickup;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == PlayerCharacter.PlayerInstance.gameObject)
            {
                OnCoinPickup.Invoke();
            }
        }
    }
}