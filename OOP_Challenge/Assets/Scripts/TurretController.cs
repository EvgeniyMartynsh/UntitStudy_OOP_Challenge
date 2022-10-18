using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using static UnityEngine.GraphicsBuffer;

public class TurretController : MonoBehaviour
{

    //float turretRotationSpeed = 10f;
    //float searchTime = 0.5f;
    //Transform other;
    //float closeDistance = 5.0f;

    string enemyTag = "Enemy";
    Transform nearestTarget = null;
    [SerializeField] float rotationSpeed = 75f;

    bool isAttack = true;
    bool isReadyToShot = false;
    bool isTargenOnField = false;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletSpawnPosition;

    Vector3 directionTurretToTarget;



    private void Start()
    {
        InvokeRepeating("InstansiateBullet", 0.01f, 1f);
    }

    private void Update()
    {
        FindNearestTarget();

        TurretRotation();

        

        
    }

    private void FindNearestTarget()
    {

        float distance = float.MaxValue;
        
        GameObject[] targetArray = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject item in targetArray)
        {
            Vector3 offset = transform.position - item.transform.position;
            float sqrLen = offset.sqrMagnitude;
            
            //Debug.Log("Item.name: " + item.name + " " + sqrLen);

            if (sqrLen < distance)
            {
                nearestTarget = item.transform;
                distance = sqrLen;
                isTargenOnField = true; // возможно надо будет добавить false в destroyOnCollision
            }    
        }
    }

    private void TurretRotation()
    {
        if (isAttack && isTargenOnField)
        {
            directionTurretToTarget = nearestTarget.position - transform.position;
            directionTurretToTarget.y = 0;

            Quaternion rotateQuaternion = Quaternion.LookRotation(directionTurretToTarget);

            float angle = Quaternion.Angle(gameObject.transform.localRotation, rotateQuaternion);


            gameObject.transform.localRotation = Quaternion.Slerp(gameObject.transform.localRotation, rotateQuaternion,
            Mathf.Min(1f, Time.deltaTime * rotationSpeed / angle));

            if (angle == 0)
            {
                isReadyToShot = true;
            }
            else
            {
                isReadyToShot = false;
            }

        }
    }



    private void InstansiateBullet()
    {
        if (isReadyToShot)
        {
            Instantiate(bulletPrefab, bulletSpawnPosition.transform.position, bulletSpawnPosition.transform.rotation);
        }
    }
}
