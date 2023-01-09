using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class EnemyAI : MonoBehaviour
    {
        public float moveSpeed = 1f;
        public LayerMask ground;
        public LayerMask wall;
        public bool deathState = false;
        public GameObject EnemyGameObject;
        public feetcheck enemyHealth;
        public GameObject deathEnemyPrefab;
        private Rigidbody2D rigidbody;
        public Collider2D triggerCollider;

        [SerializeField] private AudioSource Dead;
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);


            if (enemyHealth.deathState == true)
            {


                Debug.Log("deathstate is true enemy");
                EnemyGameObject.SetActive(false);
                GameObject deathEnemy = (GameObject)Instantiate(deathEnemyPrefab, EnemyGameObject.transform.position, EnemyGameObject.transform.rotation);
                deathEnemy.transform.localScale = new Vector3(EnemyGameObject.transform.localScale.x, EnemyGameObject.transform.localScale.y, EnemyGameObject.transform.localScale.z);
                enemyHealth.deathState = false;
               
            }

        }

        void FixedUpdate()
        {
            if (!triggerCollider.IsTouchingLayers(ground) || triggerCollider.IsTouchingLayers(wall))
            {
                Flip();
            }
        }

        private void Flip()
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            moveSpeed *= -1;
        }
      

    }
}
