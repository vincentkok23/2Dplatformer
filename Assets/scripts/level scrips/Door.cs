using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool Active = false;
    public Transform StartPos;
    public  Transform EndPos;
    public float Speed;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var step = Speed * Time.deltaTime;
        if (Active)
        {
           
            transform.position = Vector3.MoveTowards(transform.position, EndPos.position,step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPos.position, step);
        }

        
    }
}
