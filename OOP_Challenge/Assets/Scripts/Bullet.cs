using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rbBullet;   
    
    
    void Start()
    {
        rbBullet = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rbBullet.AddRelativeForce(Vector3.forward, ForceMode.Impulse);
    }
}
