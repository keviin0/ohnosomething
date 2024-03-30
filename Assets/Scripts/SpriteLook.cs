using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLook : MonoBehaviour
{
    public Transform target;
    public float amplitude = 0.25f;
    public float frequency = 0.5f;

    private Vector3 startPosition;
    private float elapsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        target = FindObjectOfType<FPSController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float newY = startPosition.y + Mathf.Abs(Mathf.Sin(Time.time * Mathf.PI * frequency) * amplitude);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        Vector3 directionToTarget = target.position - transform.position;
        directionToTarget.y = 0;
        Quaternion newRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = newRotation;
    }
}
