using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class MoveBowAndArrow : MonoBehaviour
{
    //Prefabs
    public GameObject arrow;
    public GameObject balloon;

    float midWidth;
    float origX, origY;
    Vector3 origPosition;
    
    int currentArrow = 0;
    int question = 1;

    GameObject[] quiver = new GameObject[6];
    GameObject[] balloons = new GameObject[10];

    bool fired = false;

    public Sprite arrow_back;

    private void Start()
    {
        midWidth = Screen.width / 2;
        origX = Input.GetAxis("Mouse X");
        origY = Input.GetAxis("Mouse Y");
        origPosition = Input.mousePosition;

        GameObject balloon1 = Instantiate(balloon, new Vector3(1.2f, 6f, 0), Quaternion.identity);
        balloon1.GetComponent<Rigidbody2D>().mass = 0.01f;
        balloon1.GetComponent<Rigidbody2D>().gravityScale = 0.02f;
        SpriteRenderer[] sprites = balloon1.GetComponentsInChildren<SpriteRenderer>();
        SpriteRenderer balloonImg = sprites[sprites.Length - 1];
        balloonImg.GetComponent<SpriteRenderer>().color = Color.green;

        GameObject balloon2 = Instantiate(balloon, new Vector3(0, 1f, 0), Quaternion.identity);
        balloon2.GetComponent<Rigidbody2D>().mass = 0.01f;
        balloon2.GetComponent<Rigidbody2D>().gravityScale = 0.02f;
        sprites = balloon2.GetComponentsInChildren<SpriteRenderer>();
        balloonImg = sprites[sprites.Length - 1];
        balloonImg.GetComponent<SpriteRenderer>().color = Color.red;

        GameObject balloon3 = Instantiate(balloon, new Vector3(-1.8f, 12f, 0), Quaternion.identity);
        balloon3.GetComponent<Rigidbody2D>().mass = 0.01f;
        balloon3.GetComponent<Rigidbody2D>().gravityScale = 0.02f; 
        sprites = balloon3.GetComponentsInChildren<SpriteRenderer>();
        balloonImg = sprites[sprites.Length - 1];
        balloonImg.GetComponent<SpriteRenderer>().color = Color.blue;

        balloons[0] = balloon1;
        balloons[1] = balloon2;
        balloons[2] = balloon3;

        quiver[0] = Instantiate(arrow, new Vector3(-1.22f, -3.57f, 0), Quaternion.identity);
        quiver[0].transform.Rotate(0, 0, -26.409f);
    }

    // Update is called once per frame
    void Update()
    {
        if(quiver[currentArrow].transform.position.y > 6f || quiver[currentArrow].transform.position.x > Screen.width)
        {
            fired = false;
            Destroy(quiver[currentArrow]);
            currentArrow++;
            if(currentArrow < 5)
            {
                quiver[currentArrow] = Instantiate(arrow, new Vector3(-1.22f, -3.57f, 0), Quaternion.identity);
                quiver[currentArrow].transform.Rotate(0, 0, -26.409f);
                gameObject.transform.position = new Vector3(-1.34f, -3.98f, 0);
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.transform.Rotate(0, 0, -26.909f);
            } else
            {
                Debug.Log("Out of arrows");
            }
        }

        if(fired)
        {
            quiver[currentArrow].GetComponent<Rigidbody2D>().velocity = quiver[currentArrow].GetComponentInChildren<Rigidbody2D>().GetRelativeVector(Vector2.up * 10f);
        }

        if(Input.GetMouseButton(0))
        {
            // Change image from arrow to arrow_back.png
            quiver[currentArrow].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = arrow_back;

            if (Input.mousePosition.x != origPosition.x || Input.mousePosition.y != Input.mousePosition.y)
            {
                if (Input.mousePosition.x < origPosition.x)
                {
                    BoxCollider2D collider = GetComponent<BoxCollider2D>();
                    Vector3 centre = collider.bounds.center;
                    transform.RotateAround(centre, Vector3.forward, 2);
                    quiver[currentArrow].transform.RotateAround(centre, Vector3.forward, 2);
                }

                if (Input.mousePosition.x > origPosition.x)
                {
                    BoxCollider2D collider = GetComponent<BoxCollider2D>();
                    Vector3 centre = collider.bounds.center;
                    transform.RotateAround(centre, Vector3.forward, -2);
                    quiver[currentArrow].transform.RotateAround(centre, Vector3.forward, -2);
                }

                origPosition = Input.mousePosition;
            }

        }

        if(Input.GetMouseButtonUp(0))
        {
            fired = true;
        }

    }
}
