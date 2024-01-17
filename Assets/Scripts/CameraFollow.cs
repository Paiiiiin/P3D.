using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform follow;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        dir = this.transform.position - follow.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        this.transform.position = follow.position + dir;
         
    }
}
