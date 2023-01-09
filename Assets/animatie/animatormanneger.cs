using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatormanneger : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()

    {
       
        int movementInt = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
        //Debug.Log(movementInt);
        anim.SetInteger("MovementInput", movementInt); 
    }
}

