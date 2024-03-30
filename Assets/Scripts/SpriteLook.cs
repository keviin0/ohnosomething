using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLook : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<FPSController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToTarget = target.position - transform.position;
        directionToTarget.y = 0;
        Quaternion newRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = newRotation;
    }
}
