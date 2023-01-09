using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer
{
    public class EnemyRespawn : MonoBehaviour
    {
        private Vector3 respawnpoint;
        public GameObject EnemyRef;
        public void enemyRespwan()
        {
            transform.position = respawnpoint;
        }
        public void _Respawn()
        {
            GameObject enemyClone = (GameObject)Instantiate(EnemyRef);
            enemyClone.transform.position = transform.position;

        }


    }
}