using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    public int damage = 25;
    
    public float Damage { get; set; }
    private void Update()
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime));
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if(enemy != null){
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
