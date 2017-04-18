using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {

    [SerializeField]
    private bool IsGrappling = false;
    [SerializeField]
    private bool CanGrapple = true;
    [SerializeField]
    private Vector2 Rinput;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Rinput = new Vector2(Input.GetAxis("RightStickX"), Input.GetAxis("RightStickY"));

        if (Rinput.sqrMagnitude < 0.1f)
        {
            return;
        }
        var angle = Mathf.Atan2(Input.GetAxis("RightStickX"), Input.GetAxis("RightStickY")) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(angle, 0, 0);


    }
}
