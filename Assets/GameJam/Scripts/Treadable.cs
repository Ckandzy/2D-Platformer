using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class Treadable : MonoBehaviour
    {
        public Transform lowestPos;
        public Damageable damageable;
        public float bounceSpeed = 16f;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("Player"))
                return;
            if (damageable.CurrentHealth > 0)
            {
                ContactPoint2D[] contactPoint2D = new ContactPoint2D[3];
                collision.GetContacts(contactPoint2D);
                for (int i = 0; i < contactPoint2D.Length; i++)
                {
                    if (contactPoint2D[i].point.y < lowestPos.position.y)
                    {
                        //对玩家产生伤害
                        return;
                    }
                    if (contactPoint2D[i].normal.y > 0)
                    {
                        //对玩家产生伤害
                        return;
                    }
                }
                if (collision.gameObject.GetComponent<Damager>() == null)
                    Debug.Log(collision.gameObject.name);
                damageable.TakeDamage(collision.gameObject.GetComponent<Damager>());
                PlayerCharacter.PlayerInstance.SetVerticalMovement(bounceSpeed);
                this.gameObject.SetActive(false);
            }
        }
    }
}
