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
        if (tapToStart)
            transform.Translate(Vector3.forward * speed);//movement code
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("enter pressed");//shows a enter pressed message on console when space pressed
            //transform.Find("Warrior").GetComponent<Animator>().SetBool("RunStart", true);//search the warrior in children
            //GameObject.Find("Warrior").GetComponent<Animator>().SetBool("RunStart", true);//search the warrior in game scene
            warrior.GetComponent<Animator>().SetBool("RunStart", true);//reference to the warrior with a game object variable
            tapToStart = true;
        }
        if (Input.GetKeyDown(KeyCode.A))//if I press A it will slide to left
        {
            if(warrior.transform.localPosition.x > -2)
            {
                warrior.transform.DOLocalMoveX(warrior.transform.localPosition.x - 2, 0.25f);
            }
                //warrior.transform.localPosition -= new Vector3(2,0,0);//obselete
        }
        if (Input.GetKeyDown(KeyCode.D))//if I press D it will slide to right
        {
            if (warrior.transform.localPosition.x < 2)
            {
                warrior.transform.DOLocalMoveX(warrior.transform.localPosition.x + 2, 0.25f);
            }
                //warrior.transform.localPosition += new Vector3(2, 0, 0);//obselete
        }
    }
}
