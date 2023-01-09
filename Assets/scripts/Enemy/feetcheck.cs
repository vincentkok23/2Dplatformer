using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class feetcheck : MonoBehaviour
    {
        Rigidbody2D rb;
        public Object EnemyRef;
        public bool deathState = false;
        /*        public SpriteRenderer spriteRenderer;*/

        void start()
        {
            EnemyRef = Resources.Load("Enemy");

        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<headcheck>())
            {
                deathState = true;
                rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector3(rb.velocity.x, 1f, 0f);
                rb.AddForce(Vector2.up * 300f);

/*                spriteRenderer.enabled = false;*/
                // Invoke ("Respawn", 5);

            }
           
/*            void Respawn()
            {

                GameObject enemyClone = (GameObject) Instantiate(EnemyRef);
                enemyClone.transform.position = transform.position;
                Destroy(transform.parent.gameObject);
                //resspawn enemy




            }*/

        }
       

    }
}
