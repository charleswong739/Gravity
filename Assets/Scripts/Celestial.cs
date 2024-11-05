using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celestial : MonoBehaviour
{
    public float mass;
    public Vector3 initialVelocity;

    public Vector3 rotationAxis;
    public float angularVelocity;

    private Vector3 v;

    /**
     * F = ma, a = F/m * direction
     * v = u + at
     * s = 
     */

    private void Start()
    {
        v = initialVelocity;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + initialVelocity);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + rotationAxis * 8);
        Gizmos.DrawLine(transform.position, transform.position - rotationAxis * 8);
    }

    public void UpdateRotation(float timestep)
    {
        transform.Rotate(rotationAxis, angularVelocity * timestep, Space.World);
    }

    public void UpdateVelocity(Vector3 acceleration, float timestep)
    {
        v += acceleration * timestep;
    }

    public void UpdatePosition(float timestep)
    {
        transform.position += v * timestep;
    }
}
