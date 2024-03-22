using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerRotation : MonoBehaviour
{
    public Transform ennemyTarget;

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = ennemyTarget.position - transform.position;
        transform.up = dir.normalized;
    }
}
