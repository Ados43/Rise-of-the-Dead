using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(new Vector3(transform.position.x, 0.5f, transform.position.z), "wayPoint.png");
    }
}
