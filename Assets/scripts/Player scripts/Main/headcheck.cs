using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer
{
    public class headcheck : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D bootRb;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<headcheck>())
            {
                Debug.Log("Hit");
                bootRb.velocity = new Vector3(bootRb.velocity.x, 10f ,0f);
                bootRb.AddForce(Vector2.up * 300f);
            }
        }

    }
}
