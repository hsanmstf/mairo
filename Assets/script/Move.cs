using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    int playerHealth = 3;
    public float speed;
    public float jump = 10;
    Rigidbody2D rb;
    SpriteRenderer s ;
    Animator anim;
    bool isjump;
    // Start is called before the first frame update
    void Start()
    {
        isjump = false;
        anim = GetComponent<Animator>();
        s = GetComponent<SpriteRenderer>();
        Transform t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

        // GetComponent<Transform>().Translate(new Vector2(0.01f, 0));

      

        
       

    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
        //{
        //  //  transform.Translate(new Vector2(speed, 0));
        //    s.flipX = false;

        //}

        //if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
        //{
        //   // transform.Translate(new Vector2(-speed, 0));
        //    s.flipX = true;
        //}

        //transform.Translate(new Vector2(speed * Input.GetAxis("Horizontal")*Time.deltaTime, 0));
        if (Input.GetAxis("Horizontal") > 0) { 
            s.flipX = false;
        //anim.SetFloat("Speed", rb.velocity.x);
        }
        else if (Input.GetAxis("Horizontal") < 0) { 
            s.flipX = true;
       // anim.SetFloat("Speed", -rb.velocity.x);
        }
        if (Input.GetButtonDown("Jump") && !isjump)


        

        { 
            rb.velocity = new Vector2(0,jump);
            isjump = true;
        }
        if (Mathf.Abs(rb.velocity.y)<0.01)
        {
            isjump = false;
        }
        anim.SetFloat("Speed",Mathf.Abs (rb.velocity.x));
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal") , rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ( "Enimy"))
            playerHealth = playerHealth - 1;
        Debug.Log(playerHealth);
        if(playerHealth<=0)
            Debug.Log("gameover");
    }








}
