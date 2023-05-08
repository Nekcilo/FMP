using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private Rigidbody2D rb2D;

    public float moveSpeed;
    private float moveHorizontal;
    private Collider2D collider;
    public GameObject cheese;
    private bool visible = false;



    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>(); 
   
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collider != null)
            {
                if(collider.gameObject.tag == "Interactable")
                {
                    Debug.Log("Touched Object");
                    collider.gameObject.GetComponent<InteractionController>().Trigger();
                }
            }      
        }   
    }

    void FixedUpdate()
    {
        if(rb2D.velocity.x < 5 && rb2D.velocity.x > -5)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        collider = null;
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        collider = other;
    }
}