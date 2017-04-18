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

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;


    public float SpeedMult;
    public float MaxSpeedMult;
    public float JumpMult;
    public float JumpCountLeft;
    public float JumpCountMax;


    // Use this for initialization
    void Start ()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        SpeedMult = 1; //Speed Multipier, can be edited from other scripts. Going to keep status effects in other scripts.
        MaxSpeedMult = 1;
        MaxSpeed = 50;
        JumpMult = 1;
        
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        Hinput = Input.GetAxis("Horizontal");


 
        //if (Input.GetButton("Horizontal"))
        //{
        //    Hinput = 1;
        //    _rb.AddForce(transform.right * Hinput * Movespeed * SpeedMult);
        //}
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            _rb.AddForce(transform.right * Hinput * Movespeed * SpeedMult);
        }

        //if (Input.GetButton("Jump"))
        //{
        //    Debug.Log("TryingToJump");
        //    Jump();
        //}
        else;


        
	}

    //void Jump()
    //{
    //    if (Grounded == true)
    //    {
    //        _rb.AddForce(transform.up * JumpForce * JumpMult);
    //    }
    //    else
    //    {
    //        Debug.Log("Can't Jump while in air!");
    //    }
    //}

    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "Platform")
    //    {
    //        JumpCountLeft = JumpCountMax;
    //        InAir = false;
    //        Grounded = true;
    //    }
    //    else
    //    {
    //        Debug.Log("Col is Not a platform");
    //    }
    //}
    //// This was my other checker but it's dumb and antiquated.
    //void OnCollisionExit(Collision col)
    //{
    //    if (col.gameObject.tag == "Platform")
    //    {
    //        InAir = true;
    //        Grounded = false;
    //    }
    //    else
    //    {
    //        Debug.Log("Exitting col with something not a platform");
    //    }
    //}
}
