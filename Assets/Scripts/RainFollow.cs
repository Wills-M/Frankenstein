using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFollow : MonoBehaviour
{
    [SerializeField]
    private Transform followTarget;

    private Vector3 positionOffset;

    void Start()
    {
        positionOffset = transform.position;
    }
    
    void Update()
    {
        float x = followTarget.position.x + positionOffset.x * followTarget.right.x;
        float y = positionOffset.y;
        float z = followTarget.position.z + positionOffset.z * followTarget.forward.z;

        transform.position = new Vector3(x, y, z);
    }
}
