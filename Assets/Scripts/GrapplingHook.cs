using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{

    [SerializeField]
    private bool IsGrappling = false;
    [SerializeField]
    private bool CanGrapple = true;
    [SerializeField]
    private Vector3 Rinput;
    [SerializeField]
    private GameObject Hook;
    [SerializeField]
    private float RopeLength;

    private float GunCD;
    private float fireDelay;
    private Vector3 hookOffset = new Vector3(0, 0.5f, 0);

    private SpriteRenderer _sr;

    // Use this for initialization
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Rinput = new Vector3(Input.GetAxis("RightStickX"), Input.GetAxis("RightStickY"));
        if (Input.GetButton("GrapplingHook"))
        {
            FireGrapple();
        }
        if (Rinput.sqrMagnitude < 0.05f)
        {
            return;
        }
        var angle = Mathf.Atan2(Input.GetAxis("RightStickX"), Input.GetAxis("RightStickY")) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);


    }

    void FireGrapple()
    {
        if (CanGrapple = true)
        {

            Debug.Log("Shooting");
            Vector3 offset = transform.rotation * hookOffset;
            Instantiate(Hook, transform.position + offset, transform.rotation);
        }

    }
}