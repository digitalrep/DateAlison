using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class MoveBowAndArrow : MonoBehaviour
{
    //Prefabs
    public GameObject arrow;
    public GameObject balloon;
    public GameObject out_button;
    public GameObject correct_button;
    public GameObject no_balloons_button;
    public GameObject no_arrows_button;
    public GameObject status_text;
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;
    public GameObject health5;
    public GameObject question_text;

    //Game Data
    public int level = 0;
    public int current_wrong = 0;
    public string[] questions =
    {
        "What does Alison do for a living?",
        "Why is that her occupation?",
        "What is Alison afraid of?",
        "What is Alison's drink of choice?",
        "Why is Breakfast at Tiffany's her favourite movie?"
    };
    public string[] question_answers =
    {
        "nothing",
        "relocation",
        "dogs",
        "beer",
        "new life"
    };

    Vector3 origPosition;
    
    int currentArrow = 0;

    GameObject[] quiver = new GameObject[200];
    GameObject[] balloons = new GameObject[40];
    public GameObject[] hearts = new GameObject[5];

    public bool fired = false;
    public bool level_changed = false;

    public Sprite arrow_back;
    public Sprite bow_cocked;
    public Sprite bow;

    private void Start()
    {
        origPosition = Input.mousePosition;

        correct_button.SetActive(false);
        out_button.SetActive(false);
        no_balloons_button.SetActive(false);
        no_arrows_button.SetActive(false);
        status_text.SetActive(false);

        quiver[0] = Instantiate(arrow, new Vector3(-1.22f, -3.57f, 0), Quaternion.identity);
        quiver[0].transform.Rotate(0, 0, -26.409f);

        int numBalloon = 0;

        Color newSky = new Color();
        ColorUtility.TryParseHtmlString("#7FADEF", out newSky);
        Camera.main.backgroundColor = newSky;

        string seventies_orange = "#C17A2A"; // //
        string bright_seventies_orange = "#F9A834"; //
        string pastel_orange = "#FFD083"; // //
        string reddish_orange = "#C86218"; // //
        string pink_orange = "#FE9866"; // //
        string transparent_salmon = "#FCCEB2"; //
        string bright_pink = "#EC5064"; // //
        string candy_pink = "#FFAAB0"; // //
        string pale_pink = "#FFDEE6"; // //
        string strong_teal = "#03919B"; // //
        string sky_blue = "#BCEAF6"; // //
        string forest_green = "#0A5947"; // //
        string dark_grass_green = "#007043"; // //
        string light_grass_green = "#B4CF68"; // //
        string pale_green = "#E6F48E"; // //
        string dark_aqua = "#1F8276"; // //
        string mid_aqua = "#40BAA4"; // //
        string mid_sky_blue = "#9DDED6"; // //

        makeBalloon(-0.2f, 3.9f, 0, numBalloon++, seventies_orange, 0.04f, "teacher");
        makeBalloon(-1.4f, 5.7f, 0, numBalloon++, light_grass_green, 0.06f, "childcarer");
        makeBalloon(1.2f, 6f, 0, numBalloon++, pale_pink, 0.02f, "nothing");
        makeBalloon(0.1f, 8f, 0, numBalloon++, reddish_orange, 0.03f, "writer");
        makeBalloon(1.0f, 10f, 0, numBalloon++, mid_aqua, 0.02f, "uber driver");
        makeBalloon(-1.8f, 12f, 0, numBalloon++, forest_green, 0.02f, "dog trainer");
        makeBalloon(-1.6f, 13f, 0, numBalloon++, sky_blue, 0.03f, "police officer");
        makeBalloon(1.2f, 13f, 0, numBalloon++, transparent_salmon, 0.016f, "clown");
        makeBalloon(-0.9f, 14f, 0, numBalloon++, dark_aqua, 0.02f, "mom");
        makeBalloon(-2.0f, 16f, 0, numBalloon++, pastel_orange, 0.016f, "police officer2");
        makeBalloon(-0.8f, 18f, 0, numBalloon++, bright_seventies_orange, 0.02f, "zoologist");
        makeBalloon(-0.3f, 18.2f, 0f, numBalloon++, bright_pink, 0.015f, "clown2");
        makeBalloon(0.8f, 19f, 0, numBalloon++, pale_green, 0.01f, "pilot");
        makeBalloon(0.8f, 21f, 0, numBalloon++, mid_sky_blue, 0.008f, "artist");
        makeBalloon(-1.4f, 22f, 0, numBalloon++, pink_orange, 0.008f, "nothing2");
        makeBalloon(0.3f, 23.5f, 0, numBalloon++, candy_pink, 0.005f, "uber driver2");
        makeBalloon(-0.6f, 24.8f, 0, numBalloon++, strong_teal, 0.007f, "childcarer2");
        makeBalloon(0.3f, 25f, 0, numBalloon++, dark_grass_green, 0.008f, "zoologist2");
        makeBalloon(2f, 26.7f, 0, numBalloon++, mid_aqua, 0.009f, "writer2");
        makeBalloon(1.2f, 28f, 0, numBalloon++, sky_blue, 0.008f, "teacher2");
        makeBalloon(0.3f, 31.6f, 0, numBalloon++, pastel_orange, 0.0009f, "uber driver3");
        makeBalloon(-0.5f, 32.2f, 0, numBalloon++, candy_pink, 0.005f, "artist2");
        makeBalloon(-1.2f, 33.4f, 0, numBalloon++, strong_teal, 0.006f, "mom2");
        makeBalloon(1.4f, 35f, 0f, numBalloon++, pale_green, 0.008f, "pilot2");
        makeBalloon(1.0f, 34.8f, 0f, numBalloon++, pale_pink, 0.009f, "dog trainer2");
        makeBalloon(-2.0f, 36f, 0f, numBalloon++, pink_orange, 0.009f, "mom3");
        makeBalloon(-2.1f, 37.2f, 0f, numBalloon++, dark_aqua, 0.008f, "zoologist3");
        makeBalloon(0.3f, 37.9f, 0f, numBalloon++, forest_green, 0.0005f, "teacher3");
        makeBalloon(1.2f, 43f, 0f, numBalloon++, light_grass_green, 0.0006f, "pilot3");
        makeBalloon(-0.8f, 45.4f, 0f, numBalloon++, reddish_orange, 0.0007f, "artist3");
        makeBalloon(-0.2f, 46f, 0f, numBalloon++, dark_grass_green, 0.0005f, "clown3");
        makeBalloon(1.4f, 47.6f, 0f, numBalloon++, seventies_orange, 0.0008f, "writer3");
        makeBalloon(1.05f, 48f, 0f, numBalloon++, bright_pink, 0.0009f, "police officer3");
        makeBalloon(-1.05f, 49f, 0f, numBalloon++, mid_sky_blue, 0.0007f, "nothing3");
        //question_text.transform.GetComponent<Text>().text = GameObject.Find("StaticGameObject").GetComponent<GameControl>().questions[GameObject.Find("StaticGameObject").GetComponent<GameControl>().level];
        question_text.transform.GetComponent<Text>().text = questions[level];

        // need to manually reset the static object variables
        // hopefully should only need to do it once
        /*
        GameObject.Find("StaticGameObject").GetComponent<GameControl>().level = 0;
        string[] answers = {
            "nothing",
            "relocation",
            "dogs",
            "beer",
            "new life"
        };
        GameObject.Find("StaticGameObject").GetComponent<GameControl>().question_answers = answers;
        string[] questions =
        {
            "What does Alison do for a living?",
            "Why is that her occupation?",
            "What is Alison afraid of?",
            "What is Alison's drink of choice?",
            "Why is Breakfast at Tiffany's her favourite movie?"
        };
        GameObject.Find("StaticGameObject").GetComponent<GameControl>().questions = questions;
        */

        //switch (GameObject.Find("StaticGameObject").transform.GetComponent<GameControl>().level)
        /*
        switch (level)
        {
            case 0:
                Color newSky = new Color();
                ColorUtility.TryParseHtmlString("#7FADEF", out newSky);
                Camera.main.backgroundColor = newSky;

                string seventies_orange = "#C17A2A"; // //
                string bright_seventies_orange = "#F9A834"; //
                string pastel_orange = "#FFD083"; // //
                string reddish_orange = "#C86218"; // //
                string pink_orange = "#FE9866"; // //
                string transparent_salmon = "#FCCEB2"; //
                string bright_pink = "#EC5064"; // //
                string candy_pink = "#FFAAB0"; // //
                string pale_pink = "#FFDEE6"; // //
                string strong_teal = "#03919B"; // //
                string sky_blue = "#BCEAF6"; // //
                string forest_green = "#0A5947"; // //
                string dark_grass_green = "#007043"; // //
                string light_grass_green = "#B4CF68"; // //
                string pale_green = "#E6F48E"; // //
                string dark_aqua = "#1F8276"; // //
                string mid_aqua = "#40BAA4"; // //
                string mid_sky_blue = "#9DDED6"; // //

                makeBalloon(-0.2f, 3.9f, 0, numBalloon++, seventies_orange, 0.04f, "teacher");
                makeBalloon(-1.4f, 5.7f, 0, numBalloon++, light_grass_green, 0.06f, "childcarer");
                makeBalloon(1.2f, 6f, 0, numBalloon++, pale_pink, 0.02f, "nothing");
                makeBalloon(0.1f, 8f, 0, numBalloon++, reddish_orange, 0.03f, "writer");
                makeBalloon(1.0f, 10f, 0, numBalloon++, mid_aqua, 0.02f, "uber driver");
                makeBalloon(-1.8f, 12f, 0, numBalloon++, forest_green, 0.02f, "dog trainer");
                makeBalloon(-1.6f, 13f, 0, numBalloon++, sky_blue, 0.03f, "police officer");
                makeBalloon(1.2f, 13f, 0, numBalloon++, transparent_salmon, 0.016f, "clown");
                makeBalloon(-0.9f, 14f, 0, numBalloon++, dark_aqua, 0.02f, "mom");
                makeBalloon(-2.0f, 16f, 0, numBalloon++, pastel_orange, 0.016f, "police officer2");
                makeBalloon(-0.8f, 18f, 0, numBalloon++, bright_seventies_orange, 0.02f, "zoologist");
                makeBalloon(-0.3f, 18.2f, 0f, numBalloon++, bright_pink, 0.015f, "clown2");
                makeBalloon(0.8f, 19f, 0, numBalloon++, pale_green, 0.01f, "pilot");
                makeBalloon(0.8f, 21f, 0, numBalloon++, mid_sky_blue, 0.008f, "artist");
                makeBalloon(-1.4f, 22f, 0, numBalloon++, pink_orange, 0.008f, "nothing2");
                makeBalloon(0.3f, 23.5f, 0, numBalloon++, candy_pink, 0.005f, "uber driver2");
                makeBalloon(-0.6f, 24.8f, 0, numBalloon++, strong_teal, 0.007f, "childcarer2");
                makeBalloon(0.3f, 25f, 0, numBalloon++, dark_grass_green, 0.008f, "zoologist2");
                makeBalloon(2f, 26.7f, 0, numBalloon++, mid_aqua, 0.009f, "writer2");
                makeBalloon(1.2f, 28f, 0, numBalloon++, sky_blue, 0.008f, "teacher2");
                makeBalloon(0.3f, 31.6f, 0, numBalloon++, pastel_orange, 0.0009f, "uber driver3");
                makeBalloon(-0.5f, 32.2f, 0, numBalloon++, candy_pink, 0.005f, "artist2");
                makeBalloon(-1.2f, 33.4f, 0, numBalloon++, strong_teal, 0.006f, "mom2");
                makeBalloon(1.4f, 35f, 0f, numBalloon++, pale_green, 0.008f, "pilot2");
                makeBalloon(1.0f, 34.8f, 0f, numBalloon++, pale_pink, 0.009f, "dog trainer2");
                makeBalloon(-2.0f, 36f, 0f, numBalloon++, pink_orange, 0.009f, "mom3");
                makeBalloon(-2.1f, 37.2f, 0f, numBalloon++, dark_aqua, 0.008f, "zoologist3");
                makeBalloon(0.3f, 37.9f, 0f, numBalloon++, forest_green, 0.0005f, "teacher3");
                makeBalloon(1.2f, 43f, 0f, numBalloon++, light_grass_green, 0.0006f, "pilot3");
                makeBalloon(-0.8f, 45.4f, 0f, numBalloon++, reddish_orange, 0.0007f, "artist3");
                makeBalloon(-0.2f, 46f, 0f, numBalloon++, dark_grass_green, 0.0005f, "clown3");
                makeBalloon(1.4f, 47.6f, 0f, numBalloon++, seventies_orange, 0.0008f, "writer3");
                makeBalloon(1.05f, 48f, 0f, numBalloon++, bright_pink, 0.0009f, "police officer3");
                makeBalloon(-1.05f, 49f, 0f, numBalloon++, mid_sky_blue, 0.0007f, "nothing3");
                //question_text.transform.GetComponent<Text>().text = GameObject.Find("StaticGameObject").GetComponent<GameControl>().questions[GameObject.Find("StaticGameObject").GetComponent<GameControl>().level];
                question_text.transform.GetComponent<Text>().text = questions[level];
                break;
            case 1:
                makeBalloon(-0.2f, 3.9f, 0, numBalloon++, "#F27969", 0.04f, "");
                makeBalloon(-1.4f, 5.7f, 0, numBalloon++, "#4DB466", 0.06f, "");
                makeBalloon(1.2f, 6f, 0, numBalloon++, "#91D77B", 0.02f, "");
                makeBalloon(0.1f, 8f, 0, numBalloon++, "#E0C25A", 0.03f, "");
                makeBalloon(1.0f, 10f, 0, numBalloon++, "#B54C4C", 0.02f, "");
                makeBalloon(-1.8f, 12f, 0, numBalloon++, "#B894E5", 0.02f, "");
                makeBalloon(-1.6f, 13f, 0, numBalloon++, "#8D97E0", 0.03f, "");
                makeBalloon(1.2f, 13f, 0, numBalloon++, "#358E8C", 0.016f, "");
                makeBalloon(-0.9f, 14f, 0, numBalloon++, "#7028CB", 0.02f, "");
                makeBalloon(-2.0f, 16f, 0, numBalloon++, "#8E4233", 0.016f, "");
                makeBalloon(-0.8f, 18f, 0, numBalloon++, "#EB5692", 0.02f, "");
                makeBalloon(-0.3f, 18.2f, 0f, numBalloon++, "#4C8BF3", 0.015f, "");
                makeBalloon(0.8f, 19f, 0, numBalloon++, "#F3864B", 0.01f, "");
                makeBalloon(0.8f, 21f, 0, numBalloon++, "#4D4C55", 0.008f, "");
                makeBalloon(-1.4f, 22f, 0, numBalloon++, "#A05EDB", 0.008f, "");
                makeBalloon(0.3f, 23.5f, 0, numBalloon++, "#5F8CDB", 0.005f, "");
                makeBalloon(-0.6f, 24.8f, 0, numBalloon++, "#C66868", 0.007f, "");
                makeBalloon(0.3f, 25f, 0, numBalloon++, "#9EDB5F", 0.008f, "");
                makeBalloon(2f, 26.7f, 0, numBalloon++, "#DB5F97", 0.009f, "");
                makeBalloon(1.2f, 28f, 0, numBalloon++, "#5D8254", 0.008f, "");
                makeBalloon(0.3f, 31.6f, 0, numBalloon++, "#158780", 0.0009f, "");
                makeBalloon(-0.5f, 32.2f, 0, numBalloon++, "#9D808A", 0.005f, "");
                makeBalloon(-1.2f, 33.4f, 0, numBalloon++, "#BBD758", 0.006f, "");
                makeBalloon(1.4f, 35f, 0f, numBalloon++, "#745656", 0.008f, "");
                makeBalloon(1.0f, 34.8f, 0f, numBalloon++, "#95948C", 0.009f, "");
                makeBalloon(-2.0f, 36f, 0f, numBalloon++, "#605673", 0.009f, "");
                makeBalloon(-2.1f, 37.2f, 0f, numBalloon++, "#566F73", 0.008f, "");
                makeBalloon(0.3f, 37.9f, 0f, numBalloon++, "#56735C", 0.0005f, "");
                makeBalloon(1.2f, 43f, 0f, numBalloon++, "#CFCF6B", 0.0006f, "");
                makeBalloon(-0.8f, 45.4f, 0f, numBalloon++, "#CF6AC7", 0.0007f, "");
                makeBalloon(-0.2f, 46f, 0f, numBalloon++, "#6ACFCD", 0.0005f, "");
                makeBalloon(1.4f, 47.6f, 0f, numBalloon++, "#CF6A84", 0.0008f, "");
                makeBalloon(1.05f, 48f, 0f, numBalloon++, "#000000", 0.0009f, "");
                makeBalloon(-1.05f, 49f, 0f, numBalloon++, "#ffffff", 0.0007f, "");
                //question_text.transform.GetComponent<Text>().text = GameObject.Find("StaticGameObject").GetComponent<GameControl>().questions[GameObject.Find("StaticGameObject").GetComponent<GameControl>().level];
                question_text.transform.GetComponent<Text>().text = questions[level];
                break;
            case 2: 
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
                //question_text.transform.GetComponent<Text>().text = GameObject.Find("StaticGameObject").GetComponent<GameControl>().questions[GameObject.Find("StaticGameObject").GetComponent<GameControl>().level];
                question_text.transform.GetComponent<Text>().text = questions[level];
                break;
        }
        */
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
        balloons[num].name = fear + x + y;
    }

    // Update is called once per frame
    void Update()
    {
        if (level_changed)
        {
            origPosition = Input.mousePosition;

            correct_button.SetActive(false);
            out_button.SetActive(false);
            no_balloons_button.SetActive(false);
            no_arrows_button.SetActive(false);
            status_text.SetActive(false);

            quiver[0] = Instantiate(arrow, new Vector3(-1.22f, -3.57f, 0), Quaternion.identity);
            quiver[0].transform.Rotate(0, 0, -26.409f);

            int numBalloon = 0;

            switch (level)
            {
                case 0:
                    Color newSky = new Color();
                    ColorUtility.TryParseHtmlString("#7FADEF", out newSky);
                    Camera.main.backgroundColor = newSky;

                    string seventies_orange = "#C17A2A";
                    string bright_seventies_orange = "#F9A834";
                    string pastel_orange = "#FFD083";
                    string reddish_orange = "#C86218";
                    string pink_orange = "#FE9866";
                    string transparent_salmon = "#FCCEB2";
                    string bright_pink = "#EC5064";
                    string candy_pink = "#FFAAB0";
                    string pale_pink = "#FFDEE6";
                    string strong_teal = "#03919B";
                    string sky_blue = "#BCEAF6";
                    string forest_green = "#0A5947";
                    string dark_grass_green = "#007043";
                    string light_grass_green = "#B4CF68";
                    string pale_green = "#E6F48E";
                    string dark_aqua = "#1F8276";
                    string mid_aqua = "#40BAA4";
                    string mid_sky_blue = "#9DDED6";

                    makeBalloon(-0.2f, 3.9f, 0, numBalloon++, seventies_orange, 0.04f, "teacher");
                    makeBalloon(-1.4f, 5.7f, 0, numBalloon++, light_grass_green, 0.06f, "childcarer");
                    makeBalloon(1.2f, 6f, 0, numBalloon++, pale_pink, 0.02f, "nothing");
                    makeBalloon(0.1f, 8f, 0, numBalloon++, reddish_orange, 0.03f, "writer");
                    makeBalloon(1.0f, 10f, 0, numBalloon++, mid_aqua, 0.02f, "uber driver");
                    makeBalloon(-1.8f, 12f, 0, numBalloon++, forest_green, 0.02f, "dog trainer");
                    makeBalloon(-1.6f, 13f, 0, numBalloon++, sky_blue, 0.03f, "police officer");
                    makeBalloon(1.2f, 13f, 0, numBalloon++, transparent_salmon, 0.016f, "clown");
                    makeBalloon(-0.9f, 14f, 0, numBalloon++, dark_aqua, 0.02f, "mom");
                    makeBalloon(-2.0f, 16f, 0, numBalloon++, pastel_orange, 0.016f, "police officer2");
                    makeBalloon(-0.8f, 18f, 0, numBalloon++, bright_seventies_orange, 0.02f, "zoologist");
                    makeBalloon(-0.3f, 18.2f, 0f, numBalloon++, bright_pink, 0.015f, "clown2");
                    makeBalloon(0.8f, 19f, 0, numBalloon++, pale_green, 0.01f, "pilot");
                    makeBalloon(0.8f, 21f, 0, numBalloon++, mid_sky_blue, 0.008f, "artist");
                    makeBalloon(-1.4f, 22f, 0, numBalloon++, pink_orange, 0.008f, "nothing2");
                    makeBalloon(0.3f, 23.5f, 0, numBalloon++, candy_pink, 0.005f, "uber driver2");
                    makeBalloon(-0.6f, 24.8f, 0, numBalloon++, strong_teal, 0.007f, "childcarer2");
                    makeBalloon(0.3f, 25f, 0, numBalloon++, dark_grass_green, 0.008f, "zoologist2");
                    makeBalloon(2f, 26.7f, 0, numBalloon++, mid_aqua, 0.009f, "writer2");
                    makeBalloon(1.2f, 28f, 0, numBalloon++, sky_blue, 0.008f, "teacher2");
                    makeBalloon(0.3f, 31.6f, 0, numBalloon++, pastel_orange, 0.0009f, "uber driver3");
                    makeBalloon(-0.5f, 32.2f, 0, numBalloon++, candy_pink, 0.005f, "artist2");
                    makeBalloon(-1.2f, 33.4f, 0, numBalloon++, strong_teal, 0.006f, "mom2");
                    makeBalloon(1.4f, 35f, 0f, numBalloon++, pale_green, 0.008f, "pilot2");
                    makeBalloon(1.0f, 34.8f, 0f, numBalloon++, pale_pink, 0.009f, "dog trainer2");
                    makeBalloon(-2.0f, 36f, 0f, numBalloon++, pink_orange, 0.009f, "mom3");
                    makeBalloon(-2.1f, 37.2f, 0f, numBalloon++, dark_aqua, 0.008f, "zoologist3");
                    makeBalloon(0.3f, 37.9f, 0f, numBalloon++, forest_green, 0.0005f, "teacher3");
                    makeBalloon(1.2f, 43f, 0f, numBalloon++, light_grass_green, 0.0006f, "pilot3");
                    makeBalloon(-0.8f, 45.4f, 0f, numBalloon++, reddish_orange, 0.0007f, "artist3");
                    makeBalloon(-0.2f, 46f, 0f, numBalloon++, dark_grass_green, 0.0005f, "clown3");
                    makeBalloon(1.4f, 47.6f, 0f, numBalloon++, seventies_orange, 0.0008f, "writer3");
                    makeBalloon(1.05f, 48f, 0f, numBalloon++, bright_pink, 0.0009f, "police officer3");
                    makeBalloon(-1.05f, 49f, 0f, numBalloon++, mid_sky_blue, 0.0007f, "nothing3");
                    question_text.transform.GetComponent<Text>().text = questions[level];
                    break;
                case 1:
                    makeBalloon(-0.2f, 3.9f, 0, numBalloon++, "#F27969", 0.04f, "");
                    makeBalloon(-1.4f, 5.7f, 0, numBalloon++, "#4DB466", 0.06f, "");
                    makeBalloon(1.2f, 6f, 0, numBalloon++, "#91D77B", 0.02f, "");
                    makeBalloon(0.1f, 8f, 0, numBalloon++, "#E0C25A", 0.03f, "");
                    makeBalloon(1.0f, 10f, 0, numBalloon++, "#B54C4C", 0.02f, "");
                    makeBalloon(-1.8f, 12f, 0, numBalloon++, "#B894E5", 0.02f, "");
                    makeBalloon(-1.6f, 13f, 0, numBalloon++, "#8D97E0", 0.03f, "");
                    makeBalloon(1.2f, 13f, 0, numBalloon++, "#358E8C", 0.016f, "");
                    makeBalloon(-0.9f, 14f, 0, numBalloon++, "#7028CB", 0.02f, "");
                    makeBalloon(-2.0f, 16f, 0, numBalloon++, "#8E4233", 0.016f, "");
                    makeBalloon(-0.8f, 18f, 0, numBalloon++, "#EB5692", 0.02f, "");
                    makeBalloon(-0.3f, 18.2f, 0f, numBalloon++, "#4C8BF3", 0.015f, "");
                    makeBalloon(0.8f, 19f, 0, numBalloon++, "#F3864B", 0.01f, "");
                    makeBalloon(0.8f, 21f, 0, numBalloon++, "#4D4C55", 0.008f, "");
                    makeBalloon(-1.4f, 22f, 0, numBalloon++, "#A05EDB", 0.008f, "");
                    makeBalloon(0.3f, 23.5f, 0, numBalloon++, "#5F8CDB", 0.005f, "");
                    makeBalloon(-0.6f, 24.8f, 0, numBalloon++, "#C66868", 0.007f, "");
                    makeBalloon(0.3f, 25f, 0, numBalloon++, "#9EDB5F", 0.008f, "");
                    makeBalloon(2f, 26.7f, 0, numBalloon++, "#DB5F97", 0.009f, "");
                    makeBalloon(1.2f, 28f, 0, numBalloon++, "#5D8254", 0.008f, "");
                    makeBalloon(0.3f, 31.6f, 0, numBalloon++, "#158780", 0.0009f, "");
                    makeBalloon(-0.5f, 32.2f, 0, numBalloon++, "#9D808A", 0.005f, "");
                    makeBalloon(-1.2f, 33.4f, 0, numBalloon++, "#BBD758", 0.006f, "");
                    makeBalloon(1.4f, 35f, 0f, numBalloon++, "#745656", 0.008f, "");
                    makeBalloon(1.0f, 34.8f, 0f, numBalloon++, "#95948C", 0.009f, "");
                    makeBalloon(-2.0f, 36f, 0f, numBalloon++, "#605673", 0.009f, "");
                    makeBalloon(-2.1f, 37.2f, 0f, numBalloon++, "#566F73", 0.008f, "");
                    makeBalloon(0.3f, 37.9f, 0f, numBalloon++, "#56735C", 0.0005f, "");
                    makeBalloon(1.2f, 43f, 0f, numBalloon++, "#CFCF6B", 0.0006f, "");
                    makeBalloon(-0.8f, 45.4f, 0f, numBalloon++, "#CF6AC7", 0.0007f, "");
                    makeBalloon(-0.2f, 46f, 0f, numBalloon++, "#6ACFCD", 0.0005f, "");
                    makeBalloon(1.4f, 47.6f, 0f, numBalloon++, "#CF6A84", 0.0008f, "");
                    makeBalloon(1.05f, 48f, 0f, numBalloon++, "#000000", 0.0009f, "");
                    makeBalloon(-1.05f, 49f, 0f, numBalloon++, "#ffffff", 0.0007f, "");
                    question_text.transform.GetComponent<Text>().text = questions[level];
                    break;
                case 2:
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
                    question_text.transform.GetComponent<Text>().text = questions[level];
                    break;
            }
            level_changed = false;
        }

        if (balloons[21] != null && balloons[21].transform.position.y < -6.8f)
        {
            Debug.Log("Last balloon has left the building");
            no_balloons_button.SetActive(true);
            status_text.SetActive(true);
            status_text.transform.GetComponent<Text>().text = "No Balloons Left!";
            level_changed = true;
        }

        if(quiver[currentArrow].transform.position.y > 4.2f || quiver[currentArrow].transform.position.x > 1.9f || quiver[currentArrow].transform.position.y < -5.0f || quiver[currentArrow].transform.position.x < -2.5f)
        {
            fired = false;
            Destroy(quiver[currentArrow]);
            currentArrow++;
            
            if(currentArrow == 50)
            {
                status_text.SetActive(true);
                status_text.transform.GetComponent<Text>().text = "No Arrows Left!";
                no_arrows_button.SetActive(true);
                level_changed = true;
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
