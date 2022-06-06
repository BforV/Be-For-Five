using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerManager : MonoBehaviour
{
    public float health;
    public bool death = false;
    //private GameManager gm;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



public void getDamage(float damage)
    {
        if (health-damage>=0)
        {
            health -= damage;
        }
        
        iamdead();
    }

    void iamdead()
    {
        if (health==0)
        {


            death = true;
           restartGame();

        }
    }
}
