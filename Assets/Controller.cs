using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody body;
    CollisionCheck check;
    Vector3 trackingOffsetXZ, trackingOffsetY;

    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.Find("Ball").GetComponent<Rigidbody>();
        check = GameObject.Find("Ball").GetComponent<CollisionCheck>();

        Vector3 trackingOffset = transform.position - body.position;
        trackingOffsetXZ = new Vector3(trackingOffset.x, 0, trackingOffset.z);
        trackingOffsetY = new Vector3(0, trackingOffset.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && check.IsColliding)
        {
            body.AddForce(Vector3.up * 10, ForceMode.Impulse);
            check.IsColliding = false;
        }

        if (Input.GetKey("w"))
        {
            body.AddForce(transform.forward * 2.3f, ForceMode.Force);
        }

        if (Input.GetKey("a"))
        {
            body.AddForce(-transform.right * 1.5f, ForceMode.Force);
        }

        if (Input.GetKey("d"))
        {
            body.AddForce(transform.right * 1.5f, ForceMode.Force);
        }

        Track();
    }

    void Track() {
        Vector3 heading = body.velocity;
        heading.y = 0;
        heading = heading.normalized;

        if (heading.magnitude == 0) heading = transform.forward;

        transform.position = Vector3.Lerp(
            transform.position, body.position + trackingOffsetY - heading * trackingOffsetXZ.magnitude,
            0.99f * Time.deltaTime);
        transform.forward = Vector3.Slerp(transform.forward, heading, 0.98f * Time.deltaTime);
    }
}
