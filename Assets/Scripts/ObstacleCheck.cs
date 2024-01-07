using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCheck : MonoBehaviour
{
    public int health = 100;
    public int timer = 30;

    private void Start()
    {        
        health = PlayerPrefs.GetInt("HealthValue", 100);
        print(health);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RedObstacle")
        {
            health -= 5;
            PlayerPrefs.SetInt("HealthValue", health);
            print(health);
            if(health == 0)
            {
                //reset the scene, reset the health
                PlayerPrefs.DeleteKey("HealthValue");
                SceneManager.LoadScene(0);
            }
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BlueObstacle")
        {
            health -= 10;
            PlayerPrefs.SetInt("HealthValue", health);
            print(health);
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        if (timer > 0)
        {
            timer--;
            StartCoroutine(Timer());
        }            
        else
        {
            //endgame
        }
    }
}
