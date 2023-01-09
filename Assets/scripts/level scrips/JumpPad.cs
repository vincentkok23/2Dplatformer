using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{

    Rigidbody2D rb;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("JumpPad");
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(rb.velocity.x, 1f, 0f);
            rb.AddForce(Vector2.up * 500f);

        }
    }

}
