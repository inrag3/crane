using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{

    public Vector3 TopCenter()
    {
        var halfHeight = transform.localScale.y / 2f;
        var centerPosition = transform.position;
        return new Vector3(centerPosition.x, centerPosition.y + halfHeight, centerPosition.z);
    }
}
