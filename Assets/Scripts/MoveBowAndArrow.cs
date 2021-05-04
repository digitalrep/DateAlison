using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class MoveBowAndArrow : MonoBehaviour
{
    //Prefabs
    public GameObject arrow;
    public GameObject balloon;

    public GameObject health1;
    public GameObject health2; 
    public GameObject health3;
    public GameObject health4;
    public GameObject health5;

    public GameObject out_button;
    public GameObject correct_button;
    public GameObject no_balloons_button;
    public GameObject no_arrows_button;

    float midWidth;
    float origX, origY;
    Vector3 origPosition;
    
    int currentArrow = 0;

    GameObject[] quiver = new GameObject[200];
    GameObject[] balloons = new GameObject[40];
    public GameObject[] hearts = new GameObject[5];

    public bool fired = false;

    public Sprite arrow_back;
    public Sprite bow_cocked;
    public Sprite bow;

    public int current_wrong = 0;
    public int current_question = 0;

    private void Start()
    {
        midWidth = Screen.width / 2;
        origX = Input.GetAxis("Mouse X");
        origY = Input.GetAxis("Mouse Y");
        origPosition = Input.mousePosition;

        correct_button.SetActive(false);
        out_button.SetActive(false);
        no_balloons_button.SetActive(false);
        no_arrows_button.SetActive(false);

        quiver[0] = Instantiate(arrow, new Vector3(-1.22f, -3.57f, 0), Quaternion.identity);
        quiver[0].transform.Rotate(0, 0, -26.409f);

        int numBalloon = 0;

        makeBalloon(-0.2f, 3.9f, 0, numBalloon++, "#F27969", 0.04f, "heights");
        makeBalloon(-1.4f, 5.7f, 0, numBalloon++, "#4DB466", 0.06f, "spoons");
        makeBalloon(1.2f, 6f, 0, numBalloon++, "#91D77B", 0.02f, "clowns");
        makeBalloon(0.1f, 8f, 0, numBalloon++, "#E0C25A", 0.03f, "snakes"); 
        makeBalloon(1.0f, 10f, 0, numBalloon++, "#B54C4C", 0.02f, "night driving");
        makeBalloon(-1.8f, 12f, 0, numBalloon++, "#B894E5", 0.02f, "dogs");
        makeBalloon(-1.6f, 13f, 0, numBalloon++, "#8D97E0", 0.03f, "authority"); 
        makeBalloon(1.2f, 13f, 0, numBalloon++, "#358E8C", 0.016f, "clowns");  
        makeBalloon(-0.9f, 14f, 0, numBalloon++, "#7028CB", 0.02f, "enclosed spaces");
        makeBalloon(-2.0f, 16f, 0, numBalloon++, "#8E4233", 0.016f, "authority2");
        makeBalloon(-0.8f, 18f, 0, numBalloon++, "#EB5692", 0.02f, "spiders");
        makeBalloon(-0.3f, 18.2f, 0f, numBalloon++, "#4C8BF3", 0.015f, "clowns2");
        makeBalloon(0.8f, 19f, 0, numBalloon++, "#F3864B", 0.01f, "flying");
        makeBalloon(0.8f, 21f, 0, numBalloon++, "#4D4C55", 0.008f, "open spaces");
        makeBalloon(-1.4f, 22f, 0, numBalloon++, "#A05EDB", 0.008f, "heights2");
        makeBalloon(0.3f, 23.5f, 0, numBalloon++, "#5F8CDB", 0.005f, "spoons2");
        makeBalloon(-0.6f, 24.8f, 0, numBalloon++, "#C66868", 0.007f, "enclosed spaces2");
        makeBalloon(0.3f, 25f, 0, numBalloon++, "#9EDB5F", 0.008f, "open spaces");
        makeBalloon(2f, 26.7f, 0, numBalloon++, "#DB5F97", 0.009f, "night driving2");
        makeBalloon(1.2f, 28f, 0, numBalloon++, "#5D8254", 0.008f, "dogs2");
        makeBalloon(0.3f, 31.6f, 0, numBalloon++, "#158780", 0.0009f, "spiders2");
        makeBalloon(-0.5f, 32.2f, 0, numBalloon++, "#9D808A", 0.005f, "flying2"); 
        makeBalloon(-1.2f, 33.4f, 0, numBalloon++, "#BBD758", 0.006f, "snakes");
        makeBalloon(1.4f, 35f, 0f, numBalloon++, "#745656", 0.008f, "enclosed spaces3");
        makeBalloon(1.0f, 34.8f, 0f, numBalloon++, "#95948C", 0.009f, "night driving3");
        makeBalloon(-2.0f, 36f, 0f, numBalloon++, "#605673", 0.009f, "authority3");
        makeBalloon(-2.1f, 37.2f, 0f, numBalloon++, "#566F73", 0.008f, "open spaces2");
        makeBalloon(0.3f, 37.9f, 0f, numBalloon++, "#56735C", 0.0005f, "spoons3");
        makeBalloon(1.2f, 43f, 0f, numBalloon++, "#CFCF6B", 0.0006f, "spiders3");
        makeBalloon(-0.8f, 45.4f, 0f, numBalloon++, "#CF6AC7", 0.0007f, "clowns3");
        makeBalloon(-0.2f, 46f, 0f, numBalloon++, "#6ACFCD", 0.0005f, "heights3");
        makeBalloon(1.4f, 47.6f, 0f, numBalloon++, "#CF6A84", 0.0008f, "dogs3");
        makeBalloon(1.05f, 48f, 0f, numBalloon++, "#000000", 0.0009f, "flying3"); 
        makeBalloon(-1.05f, 49f, 0f, numBalloon++, "#ffffff", 0.0007f, "open spaces3");
    }

    private void makeBalloon(float x, float y, float z, int num, string color, float gravity, string fear)
    {
        balloons[num] = Instantiate(balloon, new Vector3(x, y, z), Quaternion.identity);
        balloons[num].GetComponent<Rigidbody2D>().mass = 0.01f;
        balloons[num].GetComponent<Rigidbody2D>().gravityScale = gravity;
        SpriteRenderer[] sprites = balloons[num].GetComponentsInChildren<SpriteRenderer>();
        SpriteRenderer balloonImg = sprites[sprites.Length - 1];
        Color newColor = new Color();
        ColorUtility.TryParseHtmlString(color, out newColor);
        balloonImg.GetComponent<SpriteRenderer>().color = newColor;
        balloons[num].transform.GetChild(1).GetComponent<TMPro.TextMeshPro>().text = fear;
    }

    // Update is called once per frame
    void Update()
    {
        if(balloons[21].transform.position.y < -6.8f)
        {
            Debug.Log("Last balloon has left the building");
            no_balloons_button.SetActive(true);
        }

        if(quiver[currentArrow].transform.position.y > 6f || quiver[currentArrow].transform.position.x > Screen.width)
        {
            fired = false;
            Destroy(quiver[currentArrow]);
            currentArrow++;
            
            if(currentArrow == 50)
            {
                no_arrows_button.SetActive(true);
            }

            quiver[currentArrow] = Instantiate(arrow, new Vector3(-1.22f, -3.57f, 0), Quaternion.identity);
            quiver[currentArrow].transform.Rotate(0, 0, -26.409f);

            gameObject.transform.position = new Vector3(-1.34f, -3.98f, 0);
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.Rotate(0, 0, -26.909f);
        }

        if(fired)
        {
            quiver[currentArrow].GetComponent<Rigidbody2D>().velocity = quiver[currentArrow].GetComponentInChildren<Rigidbody2D>().GetRelativeVector(Vector2.up * 10f);
        }

        if(Input.GetMouseButton(0))
        {
            quiver[currentArrow].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = arrow_back;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = bow_cocked;

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
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = bow;
        }

    }
}
