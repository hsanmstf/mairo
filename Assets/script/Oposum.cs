using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oposum : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sp;
    [SerializeField]
    float speed=12;
    bool isright = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) <= 0.01f)
        {
            isright = !isright;
            sp.flipX = !sp.flipX;
        } 
        if(isright)
        {
            rb.velocity = new Vector2(Time.fixedDeltaTime * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(Time.fixedDeltaTime * speed*-1, rb.velocity.y);
        }
    }
}
