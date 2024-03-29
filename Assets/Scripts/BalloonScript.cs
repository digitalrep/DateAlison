﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BalloonScript : MonoBehaviour
{
    public Sprite deflated_balloon;
    public Sprite health_hollow;
    public Sprite health_full;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Collision detected on balloon AND an arrow has been fired
        if (GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().fired)
        {
            //Let's see what collision was detected...
            Debug.Log("Trigger Enter detected with: " + collision.gameObject.name);

            //If the collision with the balloon was with an arrow:
            if(collision.gameObject.name == "SecondArrow(Clone)")
            {
                //Make the balloon look deflated and increase its gravity so it falls more quickly
                transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = deflated_balloon;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.02f;

                //Debug.Log("Length correct answers: " + GameObject.Find("StaticGameObject").GetComponent<GameControl>().question_answers.Length);
                //Debug.Log("Answer on card: " + transform.GetChild(1).GetComponent<TextMeshPro>().text);
                //Debug.Log("Answers[0]: " + GameObject.Find("StaticGameObject").GetComponent<GameControl>().question_answers[0]);
                //Debug.Log("Answers array: ");

                //int i = 0;
                //foreach(string answer in GameObject.Find("StaticGameObject").GetComponent<GameControl>().question_answers)
                //{
                //    Debug.Log(i + ": " + answer);
                //    i++;
                //}

                //If the 'answer' written on this balloon DOES NOT match the answer to the question:
                //if (transform.GetChild(1).GetComponent<TextMeshPro>().text != GameObject.Find("StaticGameObject").GetComponent<GameControl>().question_answers[GameObject.Find("StaticGameObject").GetComponent<GameControl>().level])
                if(transform.GetChild(1).GetComponent<TextMeshPro>().text != GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().question_answers[GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().level])
                {
                    //Take away a heart/health object
                    //switch (GameObject.Find("StaticGameObject").GetComponent<GameControl>().current_wrong)
                    switch(GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().current_wrong) 
                    {
                        case 0:
                            GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().health1.GetComponent<SpriteRenderer>().sprite = health_hollow;
                            break;
                        case 1:
                            GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().health2.GetComponent<SpriteRenderer>().sprite = health_hollow;
                            break;
                        case 2:
                            GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().health3.GetComponent<SpriteRenderer>().sprite = health_hollow;
                            break;
                        case 3:
                            GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().health4.GetComponent<SpriteRenderer>().sprite = health_hollow;
                            break;
                        case 4:
                            GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().health5.GetComponent<SpriteRenderer>().sprite = health_hollow;
                            GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().out_button.SetActive(true);
                            break;
                        default:
                            Debug.Log("Default on switch");
                            break;
                    }

                    //INCORRECT ANSWER
                    //increment current_wrong and check if we've used up all our health
                    //If so destroy all the other balloons

                    //GameObject.Find("StaticGameObject").GetComponent<GameControl>().current_wrong++;
                    GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().current_wrong++;

                    //if (GameObject.Find("StaticGameObject").GetComponent<GameControl>().current_wrong == 5)
                    if(GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().current_wrong == 5)
                    {
                        GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().out_button.SetActive(true);
                        GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().status_text.SetActive(true);
                        GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().status_text.transform.GetComponent<Text>().text = "No Health Left!";

                        GameObject[] balloons = GameObject.FindGameObjectsWithTag("balloon");
                        foreach (GameObject balloon in balloons)
                        {
                            Destroy(balloon);
                        }
                    }

                }
                else
                {
                    //CORRECT ANSWER
                    //the text on the balloon matches the answer to the question

                    GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().correct_button.SetActive(true);
                    GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().status_text.SetActive(true);
                    GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().status_text.transform.GetComponent<Text>().text = "You got it!";

                    GameObject[] balloons = GameObject.FindGameObjectsWithTag("balloon");
                    foreach (GameObject balloon in balloons)
                    {
                        Destroy(balloon);
                    }
                }

            }
        }

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void restartShooterCorrect()
    {
        //GameObject.Find("StaticGameObject").GetComponent<GameControl>().level++;
        GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().level++;
        GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().level_changed = true;
        //SceneManager.LoadScene("Shooter");
    }

    public void restartShooter()
    {
        //GameObject.Find("StaticGameObject").GetComponent<GameControl>().current_wrong = 0;
        GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().current_wrong = 0;
        GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().health1.GetComponent<SpriteRenderer>().sprite = health_full;
        GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().health2.GetComponent<SpriteRenderer>().sprite = health_full;
        GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().health3.GetComponent<SpriteRenderer>().sprite = health_full;
        GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().health4.GetComponent<SpriteRenderer>().sprite = health_full;
        GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().health5.GetComponent<SpriteRenderer>().sprite = health_full;
        //SceneManager.LoadScene("Shooter");
        GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().level_changed = true;
    }

}
