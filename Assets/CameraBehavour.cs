using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavour : MonoBehaviour
{
    // public Vector3 camOffset = new Vector3(0,4f,-6f);
    // private Transform target;

    public Vector3 offset;
    private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        // this.transform.position = target.TransformPoint(camOffset);
        this.transform.LookAt(target);
    }
}
