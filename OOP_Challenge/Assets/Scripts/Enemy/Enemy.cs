using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected virtual int Health { get; set; } = 100;
    protected virtual float speed { get; set; } = 1f;
    
    int damage = 10;

    Vector3 playerPosition = new Vector3(0,0,0);


    private void Update()
    {
        Move();
    }

    void DealDamage()
    {
       GameManager.playerHealth -= damage;
    }

    void TakeDamage()
    {

    }

    void Move()
    {

        Vector3 direction = playerPosition - transform.position; 
        direction.Normalize();
        
        transform.Translate(direction * speed * Time.deltaTime);

        Debug.Log(playerPosition + " " + gameObject.name);

    }



    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Cannon"))
        {
            Destroy(gameObject);
            //DealDamage();

        }

    }
}
