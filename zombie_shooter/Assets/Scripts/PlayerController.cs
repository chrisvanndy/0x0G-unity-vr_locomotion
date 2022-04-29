using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int MaxHealth = 100; 
    public int playerHealth;
    public int zkill = 0;

    public Text health;
    public Text score;
    public GameObject winCanvas;

    public HealthBar healthbar;
    public ZombieController zombie;
    public Timer finalTime;


    // Start is called before the first frame update
    void Start()
    {

        health.text = MaxHealth.ToString();
        playerHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
        
    }

    public void OnCollisionEnter(Collision collision)  
    {
        if (collision.gameObject.tag == "enemy")
        {
            PlayerDamage(10);
        }
    }


    // Update is called once per frame
    void Update()
    {
        score.text = zkill.ToString();
        
        if (zkill == 3)
        {
            Win();
        }
    }

    public void Win()
    {
        winCanvas.SetActive(true);
        
    }
     

    void PlayerDamage(int damage)
    {
        playerHealth -= damage;
        healthbar.SetHealth(playerHealth);
        health.text = playerHealth.ToString();
    }

}
