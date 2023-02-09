using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public int damagePlayer = 34;
    
    private Rigidbody2D rb;
    private PlayerController player;
    private float moveSpeed;
    private Vector3 directionToPlayer;
    private Vector3 localScale;


    private void Start()
    {
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        moveSpeed = 2f;
        localScale = transform.localScale;

    }

 

    private void FixedUpdate(){
        MoveEnemy();
    }

    private void MoveEnemy(){
        directionToPlayer = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed;
    }

    private void LateUpdate(){
        if(rb.velocity.x > 0){
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        }
        else if(rb.velocity.x < 0){
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
    }

 


    public void TakeDamage(int damage){
        currentHealth -= damage;

        if(currentHealth <= 0){
            Die();
        }
    }

    void Die() 
    {
        Destroy(gameObject);
        KillerCount.instance.killCount++;
        KillerCount.instance.UpdateKillCounter();
    }

    
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Health playerHealth  = hitInfo.GetComponent<Health>();

        if(playerHealth != null){
            playerHealth.TakeDamage(damagePlayer);
        }
    }

   
}
