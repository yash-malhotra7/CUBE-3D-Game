using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    //public Vector3 offset;
    public float smoothening;
    public float rotationSmoothening;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, smoothening);
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, rotationSmoothening);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    }
}
