using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmanager : MonoBehaviour{
    public static levelmanager instance;
    public GameObject playerPrefab;
    public Transform respawnPoint;

    

    public void Awake()
    {
        instance = this;
    }
    public void Respawn()
    {
        Instantiate(respawnPoint, respawnPoint.position, Quaternion.identity);
   
    }

}
