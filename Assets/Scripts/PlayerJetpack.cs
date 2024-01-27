using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerJetpack : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,       // 0
        Walking,    // 1
        Flying,     // 2
    }

    public PlayerState curState;            // current player state

                                            // values
    public float moveSpeed;                 // force applied horizontally when moving
    public float flyingSpeed;               // force applied upwards when flying
    public bool grounded;                   // is the player currently standing on the ground?
    
                                            // components
    public Rigidbody2D rig;                 // Rigidbody2D component
    public Animator anim;                   // Animator component

    public string sceneHomeUFO3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        grounded = IsGrounded();
        CheckInputs();
    }

    // moves the player horizontally
    void Move()
    {
        // get horizontal axis (A & D, Left Arrow & Right Arrow)
        float dir = Input.GetAxis("Horizontal");
        // flip player to face the direction they're moving
        if (dir > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (dir < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        // set rigidbody horizontal velocity
        rig.velocity = new Vector2(dir * moveSpeed, rig.velocity.y);
    }

    void Fly()
    {
        // add force upwards
        rig.AddForce(Vector2.up * flyingSpeed, ForceMode2D.Impulse);
    }

    // returns true if player is on ground, false otherwise
    bool IsGrounded()
    {
        // shoot a raycast down underneath the player
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.85f), Vector2.down, 0.3f);
        // did we hit anything?
        if (hit.collider != null)
        {
            // was it the floor?
            if (hit.collider.CompareTag("Floor"))
            {
                return true;
            }
        }
        return false;
    }

    // sets the player's state
    void SetState()
    {
        // don't worry about changing states if the player's stunned
            // idle
            if (rig.velocity.magnitude == 0 && grounded)
                curState = PlayerState.Idle;
            // walking
            if (rig.velocity.x != 0 && grounded)
                curState = PlayerState.Walking;
            // flying
            if (rig.velocity.magnitude != 0 && !grounded)
                curState = PlayerState.Flying;
        // tell the animator we've changed states
        anim.SetInteger("State", (int)curState);
    }

    void CheckInputs()
    {
            // movement
            Move();
            // flying
            if (Input.GetKey(KeyCode.W))
                Fly();
        // update our current state
        SetState();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Portal2")
        {
            SceneManager.LoadScene(sceneHomeUFO3);
        }
    }
}
