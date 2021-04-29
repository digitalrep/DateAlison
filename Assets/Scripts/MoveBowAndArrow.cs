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

        //gameObject.transform.rotation.eulerAngles.z
        quiver[0] = Instantiate(arrow, new Vector3(-1.22f, -3.57f, 0), Quaternion.identity);
        quiver[0].transform.Rotate(0, 0, -26.409f);
    }

    // Update is called once per frame
    void Update()
    {
        if(quiver[currentArrow].transform.position.y > 6f || quiver[currentArrow].transform.position.x > Screen.width)
        {
            //Debug.Log("Arrow out of bounds");
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
        
            //Debug.Log("Left mouse button pressed");

            //quiver[currentArrow].GetComponent<Rigidbody2D>().transform.position = new Vector3(-1.37f, -3.50f, 0);

            if (Input.mousePosition.x != origPosition.x || Input.mousePosition.y != Input.mousePosition.y)
            {

                //Debug.Log("Mouse Position Differs");

                if (Input.mousePosition.x < origPosition.x)
                {
                    //Debug.Log("Mouse moved left");

                    BoxCollider2D collider = GetComponent<BoxCollider2D>();
                    Vector3 centre = collider.bounds.center;
                    transform.RotateAround(centre, Vector3.forward, 2);
                    quiver[currentArrow].transform.RotateAround(centre, Vector3.forward, 2);
                }

                if (Input.mousePosition.x > origPosition.x)
                {
                    //Debug.Log("Mouse moved right");

                    BoxCollider2D collider = GetComponent<BoxCollider2D>();
                    Vector3 centre = collider.bounds.center;
                    transform.RotateAround(centre, Vector3.forward, -2);
                    quiver[currentArrow].transform.RotateAround(centre, Vector3.forward, -2);

                    //Debug.Log("Z euler angle of bow: " + gameObject.transform.rotation.eulerAngles.z);
                }

                origPosition = Input.mousePosition;
            }

        }

        if(Input.GetMouseButtonUp(0))
        {
            //Debug.Log("Mouse button released");
            fired = true;
        }

    }
}
