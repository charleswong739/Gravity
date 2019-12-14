using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{

    [SerializeField]
    private float mass = 20f;

    [SerializeField]
    private float force = 10f;
    
    private float v;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            v += force / mass * Time.deltaTime;
        }

        transform.position += Vector3.right * v;
    }
}
