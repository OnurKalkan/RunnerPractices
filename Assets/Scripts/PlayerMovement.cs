using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 0.05f;
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
            warrior.GetComponent<Animator>().SetBool("RunStart", true);//reference to the warrior with a game object variable
            tapToStart = true;
        }
        if (Input.GetKeyDown(KeyCode.A))//if I press A it will slide to left
        {
            if(warrior.transform.localPosition.x > -2)
            {
                warrior.transform.DOLocalMoveX(warrior.transform.localPosition.x - 2, 0.5f);
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
}
