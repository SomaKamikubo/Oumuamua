using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class round : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.centerOfMass = new Vector3(0, 10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.angularVelocity = new Vector3(0, 1, 0);
    }
}
