using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]
    private float Movespeed;
    [SerializeField]
    private float MaxSpeed;
    [SerializeField]
    private float JumpForce;
    [SerializeField]
    private float ForceResistance;
    [SerializeField]
    private float Hinput;
    [SerializeField]
    private float Vinput;
    [SerializeField]
    private bool InAir = true;
    [SerializeField]
    private bool Grounded = false;
    [SerializeField]
    private bool CanJump = true;
    [SerializeField]
    private int LastDirection;
    [SerializeField]
    private float DashLength = 3;
    private float DashCooldown = 3;
    private bool Dashing = false;
    private bool CanDash = true;

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;


    public float SpeedMult;
    public float MaxSpeedMult;
    public float JumpMult;
    public float JumpCountLeft;
    public float JumpCountMax;


    // Use this for initialization
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        SpeedMult = 1; //Speed Multipier, can be edited from other scripts. Going to keep status effects in other scripts.
        MaxSpeedMult = 1;
        MaxSpeed = 50;
        JumpMult = 1;
        JumpCountLeft = JumpCountMax;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Hinput = Input.GetAxis("Horizontal");
        if (Hinput != 0)
        {
            if (Hinput > 0)
            {
                LastDirection = 1;
            }
            else
            {
                LastDirection = -1;
            }
        }

        if (Input.GetButton("Dash")&&CanDash==true)
        {
            Debug.Log("Trying to Dash");
            Dashing = true;
            Dash();
        }



        //if (Input.GetButton("Horizontal"))
        //{
        //    Hinput = 1;
        //    _rb.AddForce(transform.right * Hinput * Movespeed * SpeedMult);
        //}
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            _rb.AddForce(transform.right * Hinput * Movespeed * SpeedMult);
        }

        if (Input.GetButton("Jump"))
        {
            Debug.Log("TryingToJump");
            Jump();

        }
        else;



    }

    void Dash()
    {
            _rb.AddForce(transform.right * Movespeed * 15 * LastDirection); //dash is broken, but I'm keeping this for now because no idea.
            StartCoroutine(DashCooldownTimer());
    }

    void Jump()
    {
        if (JumpCountLeft > 0 && CanJump == true)
        {
            _rb.AddForce(transform.up * JumpForce * JumpMult);
            JumpCountLeft--;
            CanJump = false;
            StartCoroutine(JumpCooldown());
        }
        else
        {
            Debug.Log("Out of jumps!");
        }
    }

    void OnCollisionEnter2D(Collision2D col) //This is the platform col
    {
        if (col.gameObject.tag == "Platform")
        {
            JumpCountLeft = JumpCountMax;
            InAir = false;
            Grounded = true;
        }
        else
        {
            Debug.Log("Col is Not a platform");
        }
    }
    // This was my other checker but it's dumb and antiquated.
    void OnCollisionExit2D(Collision2D col)
    {
        InAir = true;
        Grounded = false;

    }
    private IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(0.3f);
        CanJump = true;

    }
    private IEnumerator DashCooldownTimer()
    {
        yield return new WaitForSeconds(DashLength);
        Dashing = false;
        CanDash = false;
        yield return new WaitForSeconds(DashCooldown);
        CanDash = true;
    }
}