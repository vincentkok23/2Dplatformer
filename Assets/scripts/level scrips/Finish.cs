using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Platformer
{
    public class Finish : MonoBehaviour
    {

        public static bool GameIsPaused = false;
        public GameObject FinishMenu;
        public GameObject Canvas;
        [SerializeField] private AudioSource finish;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {

                

                finish.Play();
                End();
            }

           
        }
        public void End()
        {
/*            Canvas.SetActive(false);*/
            FinishMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void QuitGame()
        {
            Debug.Log("quit");
            Application.Quit();
        }
        public void Restart()
        {
            Time.timeScale = 1f;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Debug.Log("Restart");
        }
    }
}