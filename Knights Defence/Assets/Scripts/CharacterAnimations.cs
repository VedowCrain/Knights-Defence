using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator Anim;
    private float verticalMovement;
    private float horizontalMovement;
    private float movementMultiplier = 0.5f;

    // Use this for initialization
    void Start ()
    {
        Anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            
            movementMultiplier = 1;
        }
        if (Input.GetButtonUp("Fire3"))
        {
            
            movementMultiplier = 0.5f;
        }

        horizontalMovement = Input.GetAxis("Horizontal");
        Anim.SetFloat("Horizontal", horizontalMovement *movementMultiplier);

        verticalMovement = Input.GetAxis("Vertical");
        Anim.SetFloat("Vertical", verticalMovement *movementMultiplier);

        if (Input.GetButtonDown("Jump"))
        {
            Anim.SetTrigger("Jump");
        }

    }
}
