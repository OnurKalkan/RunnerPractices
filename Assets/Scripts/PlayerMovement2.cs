using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    float speed = 0.05f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed);
    }
}
