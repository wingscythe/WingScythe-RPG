using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        if (direction > 0)
        {
            anim.SetFloat("Direction", 1.0f);
        }
        else if (direction < 0)
        {
            anim.SetFloat("Direction", -1.0f);
        }
        else
        {
            anim.SetFloat("Direction", 0.0f);
        }

        float movement = Input.GetAxis("Vertical");
        if (movement > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed", 1.0f);
        }
        else if (movement > 0)
        {
            anim.SetFloat("Speed", 0.5f);
        }
        else if (movement < 0 && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed", -1.0f);
        }
        else if (movement < 0)
        {
            anim.SetFloat("Speed", -0.5f);
        }
        else
        {
            anim.SetFloat("Speed", 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Jump", true);
        }
    }
}
