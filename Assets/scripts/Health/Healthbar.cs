using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Platformer
{
    public class Healthbar : MonoBehaviour
    {
        [SerializeField] private Health playerHealth;
        [SerializeField] private Image currentHealth;

        private void Start()
        {

        }
        private void Update()
        {
            currentHealth.fillAmount = playerHealth.currentHealth / 10;
        }

    }
}