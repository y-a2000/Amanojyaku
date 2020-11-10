using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    // ★改良
    public Vector3 pos;

    private void OnTriggerEnter(Collider other)
    {
        // ★改良
        other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
