using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour{
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Enemy")){
            Debug.Log("dood");
            levelmanager.instance.Respawn();
        }

    }

}
