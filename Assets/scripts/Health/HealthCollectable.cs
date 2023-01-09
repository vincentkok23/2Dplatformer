using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class HealthCollectable : MonoBehaviour
    {
        [SerializeField] private float healthValue;
        [SerializeField] private AudioSource AddHealth;
        private void OnTriggerEnter2D (Collider2D collision)
        {
            if (collision.tag == "Player")
            {

                collision.GetComponent<Health>().AddHealth(healthValue);
                gameObject.SetActive(false);
                AddHealth.Play();
            }
        }
    }
}

