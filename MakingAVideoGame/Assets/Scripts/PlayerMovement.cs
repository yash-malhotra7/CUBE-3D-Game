using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GamePlayUI gamePlayUI;

    public Rigidbody rb;
    public float forwardForce = 700f;
    public float sidewaysForce = 500f;
    public PlayerMovement movement;

    private void Start()
    {
        movement.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {        

        if(Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

        if(Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }

        if (rb.position.y < -0.5f)
        {
            FindObjectOfType<Gamemanager>().PlayerFell();
            movement.enabled = false;
        }
    }
}
