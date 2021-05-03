using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BalloonScript : MonoBehaviour
{
    public Sprite deflated_balloon;
    public Sprite health_hollow;

    string[] answers = { "dogs", "0", };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Enter detected");
        Debug.Log(gameObject.GetComponentsInChildren<Image>().Length);  // returns 0
        Debug.Log(transform.GetChild(2));
        transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = deflated_balloon;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.02f;

        int current_answer = GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().current_question;

        Debug.Log(transform.GetChild(1));

        if (transform.GetChild(1).GetComponent<TextMeshPro>().text != answers[current_answer])
        {
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
                    break;
                default:
                    Debug.Log("Default on switch");
                    break;
            }
        }

        GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().current_wrong++;

        if(GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().current_wrong == 5)
        {
            //Game over?
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
