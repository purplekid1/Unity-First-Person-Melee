using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionClose : MonoBehaviour
{
    public bool touchingCollider;
    // Start is called before the first frame update
    void Start()
    {
        touchingCollider = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        touchingCollider = true;
    }
    private void OnTriggerExit(Collider other)
    {
        touchingCollider = false;
    }
}
