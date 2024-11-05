using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialManager : MonoBehaviour
{
    public Celestial[] bodies;

    [Header("Debug")]
    public int steps;
    public float timestep;

    private void OnDrawGizmos()
    {
        Vector3[] positions = new Vector3[bodies.Length];
        Vector3[] velocities = new Vector3[bodies.Length];
        for (int i = 0; i < bodies.Length; i++)
        {
            positions[i] = bodies[i].transform.position;
            velocities[i] = bodies[i].initialVelocity;
        }


        Gizmos.color = Color.blue;
        for (int s = 0; s < steps; s++)
        {
            for (int i = 0; i < bodies.Length; i++) // self
            {
                for (int j = 0; j < bodies.Length; j++) // foreign
                {
                    if (i != j)
                    {
                        Vector3 diff = positions[j] - positions[i];

                        Vector3 a = diff.normalized * (Constants.G * bodies[j].mass / diff.sqrMagnitude);
                        velocities[i] += a * timestep;

                    }
                }
            }

            for (int i = 0; i < bodies.Length; i++) // self
            {
                Gizmos.DrawLine(positions[i], positions[i] + velocities[i] * timestep);
                positions[i] += velocities[i] * timestep;
            }
        }
    }

    void FixedUpdate()
    {
        foreach (Celestial body in bodies)
        {
            Vector3 a = CalcAcceleration(body);
            body.UpdateVelocity(a, timestep);
        }

        foreach (Celestial body in bodies)
        {
            body.UpdatePosition(timestep);
            body.UpdateRotation(timestep);
        }
    }

    Vector3 CalcAcceleration(Celestial body)
    {
        Vector3 a = Vector3.zero;
        foreach (Celestial foreign in bodies)
        {
            if (foreign != body)
            {
                Vector3 diff = foreign.transform.position - body.transform.position;

                a += diff.normalized * (Constants.G * foreign.mass / diff.sqrMagnitude);
            }
        }

        return a;
    }

}
