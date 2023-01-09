using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Health : MonoBehaviour
    {

        [SerializeField] private float maxHealth = 3;
        [SerializeField] private AudioSource Regain;

        private GameManager gameManager;
        public bool deathState = false;
        public float currentHealth { get; private set; }

        // Start is called before the first frame update
        private void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            currentHealth = maxHealth;
            Debug.Log("start van calsse" + currentHealth);
        }

        void TakeDamage(float damage)
        {
            
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);

            if (currentHealth <= 0)
            {
                Debug.Log("deathstae is true");

                deathState = true;
            }
            else
            {
                Debug.Log("deathstae is false");

                deathState = false;
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log("take damage" + collision.gameObject.tag);
                TakeDamage(1);
 
            }
        }
        public void AddHealth(float _value)
        {
            Regain.Play();
            currentHealth = Mathf.Clamp(currentHealth + _value, 0, maxHealth);
        }

    }
}
