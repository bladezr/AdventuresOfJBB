using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private GameObject
        deathChunkParticle,
        deathBloodParticle;

    private float currentHealth;

    private GameManager GM;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        //GM.Respawn();
        Destroy(gameObject);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        currentHealth += 50;
        healthBar.SetHealth(currentHealth);
    }
    

    public void Heal()
    {
        if (currentHealth < maxHealth) 
        {
            currentHealth += 10;
            healthBar.SetHealth(currentHealth);
        }
    
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("HP"))
        {
            Heal();
            Destroy(coll.gameObject);
        }
    }
}
