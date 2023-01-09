using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {

        private Vector3 respawnpoint;
        private int nbJumps = 0;
        public float movingSpeed;
        public float jumpForce;
        private float moveInput;
        private bool facingRight = false;
        [HideInInspector]
        public bool deathState = false;

        public float time;
        public float score;


        private bool isGrounded;
        public Transform groundCheck;

        public Rigidbody2D rigidbody;

        private Animator animator;
        private GameManager gameManager;



        [SerializeField] private AudioSource JumpSoundEffect;
        [SerializeField] private AudioSource Checkpoint;
        [SerializeField] private AudioSource respawn;
        [SerializeField] private AudioSource coin;

        void Start()
        {

            respawnpoint = transform.position;
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        }

        private void FixedUpdate()
        {

        }

        void Update()
        {

          
            if (Input.GetButton("Horizontal"))
            {
                moveInput = Input.GetAxis("Horizontal");
                Vector3 direction = transform.right * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
                animator.SetInteger("playerState", 1); // Turn on run animation

            }
            else
            {
                if (isGrounded) animator.SetInteger("playerState", 0); // Turn on idle animation
            }
            if (Input.GetKeyDown(KeyCode.Space) && nbJumps < 2)
            {
                JumpSoundEffect.Play();
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0f, 0f);
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                nbJumps++;
                Debug.Log(nbJumps);
            }
            if (!isGrounded) animator.SetInteger("playerState", 2); // Turn on jump animation

            if (facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight == true && moveInput < 0)
            {
                Flip();
            }
        }



        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
            isGrounded = colliders.Length > 1;
            nbJumps = 0;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.tag == "Ground")
            {
                CheckGround();
            }
            if (collision.gameObject.tag == "Enemy")
            {
                Invoke("Respawn", 0);

            }else if (collision.gameObject.tag == "Finish")
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "Time", time);
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "Score", score);
                SavePrefs.ClearedList.Add(SceneManager.GetActiveScene().name);
            }

        }

        private void Respawn()
        {
            respawn.Play();
            transform.position = respawnpoint;

        }

        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Coin")
            {
                Destroy(other.gameObject);
                Debug.Log("coin");
                coin.Play();
                gameManager.coinsCounter += 1;
                
            }

            else if (other.gameObject.tag == "Checkpoint")
            {
                Checkpoint.Play();
                Debug.Log("Checkpoint");
                respawnpoint = transform.position;
                Destroy(other.gameObject);
            }
        }

    }
}

