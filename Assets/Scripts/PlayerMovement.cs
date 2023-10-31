using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float speed = 0.15f;
    public GameObject warrior;
    bool tapToStart = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (tapToStart == true)
            transform.Translate(Vector3.forward * speed);//movement code
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            warrior.GetComponent<Animator>().SetBool("Idle", false);
            warrior.GetComponent<Animator>().SetBool("RunStart", true);//reference to the warrior with a game object variable
            tapToStart = true;
        }
        if (Input.GetKeyDown(KeyCode.A))//if I press A it will slide to left
        {
            if(warrior.transform.localPosition.x > -2)
            {
                warrior.transform.DOLocalMoveX(warrior.transform.localPosition.x - 2, 0.5f);//.SetDelay(0.2f);
                warrior.GetComponent<Animator>().SetTrigger("RunLeft");
            }
        }
        if (Input.GetKeyDown(KeyCode.D))//if I press D it will slide to right
        {
            if (warrior.transform.localPosition.x < 2)
            {
                warrior.transform.DOLocalMoveX(warrior.transform.localPosition.x + 2, 0.5f);
                warrior.GetComponent<Animator>().SetTrigger("RunRight");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LevelFinish")
        {
            warrior.GetComponent<Animator>().SetBool("RunStart", false);
            warrior.GetComponent<Animator>().SetBool("Idle", true);
            tapToStart = false;
            Invoke(nameof(Level2), 2);
        }
    }

    void Level2()
    {
        SceneManager.LoadScene(1);
    }
}
