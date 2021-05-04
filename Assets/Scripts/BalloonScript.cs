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

    private IEnumerator StartCounter()
    {
        float countDown = 2f;
        for(int i=0; i<2000; i++)
        {
            while(countDown >= 0)
            {
                countDown -= Time.smoothDeltaTime;
                yield return null;
            }
        }
        GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().correct_button.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Enter detected with: ");
        Debug.Log(collision.gameObject.name);

        if (GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().fired)
        {
            transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = deflated_balloon;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.02f;

            int current_answer = GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().current_question;

            Debug.Log(transform.GetChild(1));

            if (transform.GetChild(1).GetComponent<TextMeshPro>().text != answers[current_answer])
            {
                switch (GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().current_wrong)
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
            }
            else
            {
                GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().correct_button.SetActive(true);
                StartCoroutine(StartCounter());
            }

            GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().current_wrong++;

            if (GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().current_wrong == 5)
            {
                GameObject.Find("SecondBow").GetComponent<MoveBowAndArrow>().out_button.SetActive(true);
                GameObject[] balloons = GameObject.FindGameObjectsWithTag("balloon");
                foreach(GameObject balloon in balloons)
                {
                    Destroy(balloon);
                }
            }
        }

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
