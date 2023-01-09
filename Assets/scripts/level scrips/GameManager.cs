using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        public int coinsCounter = 0;

        public GameObject playerGameObject;
        public PlayerController player;
        private Health playerhealth;
        private Transform respawnPoint;
        public GameObject deathPlayerPrefab;
        public float SoundsDelay;
        public feetcheck enemyHealth;

        public Text coinText;


        [SerializeField] private AudioSource Dead;
        void Start()
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
            playerhealth = GameObject.Find("Player").GetComponent<Health>();
        }

        void Update()
        {
            coinText.text = coinsCounter.ToString();

            

            if (playerhealth.deathState == true)
            {
                Dead.Play();
                Debug.Log("deathstae is true in update kijken of die shiet werkt");
                playerGameObject.SetActive(false);
                GameObject deathPlayer = (GameObject)Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
                deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
                playerhealth.deathState = false;
                Invoke("ReloadLevel", 3);

            }
            if (enemyHealth.deathState == true)
            {
                Invoke("Sounds", SoundsDelay);
                Debug.Log("enemy dead sound");
                Dead.Play();
            }
        }
        void Sounds()
        {
            Debug.Log("deathstate is false enemy");
            enemyHealth.deathState = false;
        }
     


        private void ReloadLevel()
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}
