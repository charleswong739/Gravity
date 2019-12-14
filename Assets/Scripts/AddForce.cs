using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{

    [SerializeField]
    private float mass = 1f;

    // [SerializeField]
    // private float force = 10f;

    private Vector3 force;
    private Vector3 v;
    private GameObject planet;
    private Vector3 planetPos;
    private float planetM;

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.Find("TestPlanet");
        planetPos = planet.GetComponent<Transform>().position;
        planetM = 1E8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            force = 10 * Vector3.right;
        } else if (Input.GetKey(KeyCode.A))
        {
            force = -10 * Vector3.right;
        } else 
        {
            force = Vector3.zero;
        }

        force += (planetPos - transform.position) * (Constants.G * planetM * mass / (planetPos - transform.position).sqrMagnitude);

        v += force / mass * Time.deltaTime;

        transform.position += v;
    }
}
