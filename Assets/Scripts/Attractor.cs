using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    static public Vector3 POS = Vector3.zero;

    [Header("Set in Inspector")]
    public Vector3 range = new Vector3( 40, 10, 40 );
    public Vector3 phase = new Vector3( 0.5f, 0.4f, 0.1f );

    void FixedUpdate()
    {
        Vector3 tPos = Vector3.zero;
        Vector3 scale = transform.localScale;
        tPos.x = Mathf.Sin(phase.x * Time.time) * range.x * scale.x;
        tPos.y = Mathf.Sin(phase.y * Time.time) * range.y * scale.y;
        tPos.z = Mathf.Sin(phase.z * Time.time) * range.z * scale.z;
        transform.position = tPos;
        POS = tPos;
    }
}
