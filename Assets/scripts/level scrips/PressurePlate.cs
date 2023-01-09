using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool active = false;
    private SpriteRenderer _renderer;
    public Door door;
    
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
             door.Active = true;
            _renderer.color = Color.green;

      
        } 


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            door.Active = false;
            _renderer.color = Color.red;

        }

    }

}