using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappy : MonoBehaviour
{
    bool crashed = false;
    private Rigidbody2D rb2d;
    float gravity = 2.0f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (crashed == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gravity = gravity * -1.0f;
                rb2d.gravityScale = gravity;
                if (gravity == 2.0f)
                {
                    anim.SetTrigger("Down");
                    anim.ResetTrigger("Up");
                }
                else
                {
                    anim.SetTrigger("Up");
                    anim.ResetTrigger("Down");
                }
            }
        }
    }

    void OnCollisionEnter2D()
    {
        rb2d.gravityScale = 0.0f;
        rb2d.velocity = Vector2.zero;
        crashed = true;
        anim.SetTrigger("ded");
        anim.ResetTrigger("Down");
        anim.ResetTrigger("Up");
        GameControl.instance.Crashed();
    }
}
