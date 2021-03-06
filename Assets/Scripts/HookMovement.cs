﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour {


    public Rigidbody2D rb;
    private Transform PlayerTransform;
    private GameObject Player;


    void Awake ()
    {
        Player = GameObject.Find("PlaceholderMan");
        PlayerTransform = Player.transform;
    }
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 100);
	}
	void OnCollision2D(Collision2D col)
    {
        rb.isKinematic = true;
    }
	// Update is called once per frame
	void Update ()
    {
		
	}
    void Die()
    {
        Destroy(gameObject);
    }
}
