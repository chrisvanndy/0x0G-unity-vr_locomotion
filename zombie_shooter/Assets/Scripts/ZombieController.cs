using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ZombieController : MonoBehaviour
{
    public Animator anim;
    public GameObject damageCollider;

    public int killCount = 0;

    public GameObject enemyCanvas;
    //

    int MaxHealth = 10; 
    public int currentHealth;

    public Text health;

    public HealthBar healthbar;
    public PlayerController pCon;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        health.text = MaxHealth.ToString();
        currentHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Attack1", true);
           
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Attack1", false);
        }
    }

     public void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("bullet"))
        {
            TakeDamage(10);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    
    }

    // use current health of enemy to start death anim, + score
    void Die()
    {
        anim.SetBool("Death", true);
        pCon.zkill += 1;
        enemyCanvas.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = false;
        currentHealth = -1;
        
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        health.text = currentHealth.ToString();

         if (currentHealth == 0)
        {
            Die();
        }

    }

}
