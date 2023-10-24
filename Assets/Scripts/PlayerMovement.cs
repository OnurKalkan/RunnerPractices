using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0,0,1) * speed);
    }
}
