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

    GameObject[] quiver = new GameObject[6];
    int currentArrow = 0;
    GameObject balloon1;

    bool fired = false;

    private void Start()
    {
        midWidth = Screen.width / 2;
        origX = Input.GetAxis("Mouse X");
        origY = Input.GetAxis("Mouse Y");
        origPosition = Input.mousePosition;

        GameObject balloon1 = Instantiate(balloon, new Vector3(0, 6f, 0), Quaternion.identity);
        balloon1.GetComponent<Rigidbody2D>().mass = 0.0001f;
        balloon1.GetComponent<Rigidbody2D>().gravityScale = 0.02f;
        SpriteRenderer[] sprites = balloon1.GetComponentsInChildren<SpriteRenderer>();
        SpriteRenderer balloonImg = sprites[sprites.Length - 1];
        balloonImg.GetComponent<SpriteRenderer>().color = Color.green;

        quiver[0] = Instantiate(arrow, new Vector3(-0.03f, -3.57f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(quiver[currentArrow].transform.position.y > 6f || quiver[currentArrow].transform.position.x > Screen.width)
        {
            Debug.Log("Arrow out of bounds");
            fired = false;
            Destroy(quiver[currentArrow]);
            currentArrow++;
            if(currentArrow < 5)
            {
                quiver[currentArrow] = Instantiate(arrow, new Vector3(-0.03f, -3.57f, 0), Quaternion.identity);
                gameObject.transform.rotation = new Quaternion(0, 0, -45f, 0);
                gameObject.transform.position = new Vector3(-0.05f, -4.09f, 0);
                //gameObject.transform.rotation = Quaternion.identity;
            } else
            {
                Debug.Log("Out of arrows");
            }
        }

        if(fired)
        {
            /*
            Vector3 arrowPos = quiver[currentArrow].transform.position;
            Vector3 newPos = new Vector3(arrowPos.x + 0.01f, arrowPos.y + 0.1f, arrowPos.z);
            quiver[currentArrow].transform.position = newPos;
            */
            //quiver[currentArrow].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            quiver[currentArrow].GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f);
            //Debug.Log(quiver[currentArrow].GetComponentInChildren<Rigidbody2D>());
            //quiver[currentArrow].GetComponent<Rigidbody2D>().velocity = quiver[currentArrow].GetComponentInChildren<Rigidbody2D>().GetRelativeVector(Vector2.up * 10f);
            //quiver[currentArrow].GetComponent<Rigidbody2D>().velocity = quiver[currentArrow].GetComponent<Rigidbody2D>().GetRelativeVector(Vector2.up * 10f);
        }

        if(Input.GetMouseButton(0))
        {
        
            Debug.Log("Left mouse button pressed");

            if(Input.mousePosition.x != origPosition.x || Input.mousePosition.y != Input.mousePosition.y)
            {

                Debug.Log("Mouse Position Differs");

                if (Input.mousePosition.x < origPosition.x)
                {
                    Debug.Log("Mouse moved left");

                    BoxCollider2D collider = GetComponent<BoxCollider2D>();
                    Vector3 centre = collider.bounds.center;
                    transform.RotateAround(centre, Vector3.forward, 2);
                    quiver[currentArrow].transform.RotateAround(centre, Vector3.forward, 2);
                }

                if (Input.mousePosition.x > origPosition.x)
                {
                    Debug.Log("Mouse moved right");

                    BoxCollider2D collider = GetComponent<BoxCollider2D>();
                    Vector3 centre = collider.bounds.center;
                    transform.RotateAround(centre, Vector3.forward, -2);
                    quiver[currentArrow].transform.RotateAround(centre, Vector3.forward, -2);

                    Debug.Log("Z euler angle of bow: " + gameObject.transform.rotation.eulerAngles.z);
                }

                origPosition = Input.mousePosition;
            }

        }

        if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse button released");
            fired = true;
        }

    }
}
