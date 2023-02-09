using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;
    
    public UnityEvent OnDeath;
    
    public float currentHealth;
    private bool isDead = false;

    public Slider slider;
    private void Start()
    {
        currentHealth = maxHealth;
        slider.value = 1;
    }
    
    float CalculateHealth(){
        return (float) currentHealth / maxHealth;
        
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        slider.value = CalculateHealth();   
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            OnDeath?.Invoke();
            Die();
              
        }

        
    }
    
    void Die() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
