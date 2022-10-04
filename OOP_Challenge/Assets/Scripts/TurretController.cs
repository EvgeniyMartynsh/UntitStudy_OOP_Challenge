using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class TurretController : MonoBehaviour
{

    //float turretRotationSpeed = 10f;
    //float searchTime = 0.5f;
    //Transform other;
    //float closeDistance = 5.0f;

    string enemyTag = "Enemy";

    private void Start()
    {
        Debug.Log(transform.position);
    }

    private void Update()
    {
        FindNearestTarget();
    }

    private void FindNearestTarget()
    {

        Transform nearestTarget = null;
        float distance = float.MaxValue;
        
        GameObject[] targetArray = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject item in targetArray)
        {
            Vector3 offset = transform.position - item.transform.position;
            float sqrLen = offset.sqrMagnitude;
            
            Debug.Log("Item.name: " + item.name + " " + sqrLen);

            if (sqrLen < distance)
            {
                nearestTarget = item.transform;
                distance = sqrLen;
            }    
            
        }
        
        Debug.Log(nearestTarget);
        



    }
}
