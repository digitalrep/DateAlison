using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollScript : MonoBehaviour
{

    public ScrollRect scrollView;
    public GameObject scrollContent;

    public GameObject alisonScrollItemPrefab;
    public GameObject playerScrollItemPrefab;
    public GameObject alisonScrollItemPrefab2;
    public GameObject playerScrollItemPrefab2;
    public GameObject alisonScrollItemPrefab3;
    public GameObject playerScrollItemPrefab3;

    public Button buttonOption1;
    public Button buttonOption2;

    GameObject scrollItemObj;

    private int counter = 0;

    private string[] playerDialogues = {
        "Hello, Alison. I found your profile intriguing... If a little... Mysterious.",
        "Hey Alison, how are you?"
    };
    private string[] alisonDialogues = {
        "Hi! Thanks for messaging me. Yeah, I guess it is mysterious. Does that bother you ?",
        "Hey there, I'm good. How are you?"
    };

    private string[] buttonOption1s =
    {
        "No, not at all. A little mystery never hurt anyone.",
        "That's ok. I find reading boring anyway."
    };

    private string[] buttonOption2s =
    {
        "Well I'm glad to hear that, because I'm really not an open book.",
        "Me too. I always prefer watching the movie to reading the book."
    };

    private int suspicionCounter = 0;

    void Start()
    {

    }

    void Update()
    {

    }

    public void printDialogue(int option)
    {
        float beginTime = Time.time; 
        int lineLength = 41;

        int playerLength = playerDialogues[option].Length;
        int alisonLength = alisonDialogues[option].Length;

        int numLines = (int)Math.Ceiling((double)playerLength / lineLength);

        Debug.Log(playerLength);
        Debug.Log(playerLength / lineLength);
        Debug.Log((int)Math.Ceiling((double)playerLength / lineLength));

        StartCoroutine(PrintPlayerDialogue(option, numLines));

        StartCoroutine(ForceScrollDown());

        numLines = (int)Math.Ceiling((double)alisonLength / lineLength);

        StartCoroutine(PrintAlisonDialogue(option, numLines));

        //StartCoroutine(ForceScrollDown());
    }

    IEnumerator PrintPlayerDialogue(int option, int numLines)
    {

        if (numLines == 1)
        {
            scrollItemObj = Instantiate(playerScrollItemPrefab);
            scrollItemObj.transform.SetParent(scrollContent.transform, false);
            scrollItemObj.transform.localScale = Vector3.one * 0.8f;
            scrollItemObj.transform.Find("num").gameObject.GetComponent<Text>().text = playerDialogues[option];
        }

        if (numLines == 2)
        {
            scrollItemObj = Instantiate(playerScrollItemPrefab2);
            scrollItemObj.transform.SetParent(scrollContent.transform, false);
            scrollItemObj.transform.localScale = Vector3.one * 0.8f;
            scrollItemObj.transform.Find("num").gameObject.GetComponent<Text>().text = playerDialogues[option];
        }

        if (numLines == 3)
        {
            scrollItemObj = Instantiate(playerScrollItemPrefab3);
            scrollItemObj.transform.SetParent(scrollContent.transform, false);
            scrollItemObj.transform.localScale = Vector3.one * 0.8f;
            scrollItemObj.transform.Find("num").gameObject.GetComponent<Text>().text = playerDialogues[option];
        }

        yield return null;
    }

    IEnumerator PrintAlisonDialogue(int option, int numLines)
    {
        yield return new WaitForSeconds(2);

        if (numLines == 1)
        {
            scrollItemObj = Instantiate(alisonScrollItemPrefab);
            scrollItemObj.transform.SetParent(scrollContent.transform, false);
            scrollItemObj.transform.localScale = Vector3.one * 0.8f;
            scrollItemObj.transform.Find("num").gameObject.GetComponent<Text>().text = alisonDialogues[option];
        }

        if (numLines == 2)
        {
            scrollItemObj = Instantiate(alisonScrollItemPrefab2);
            scrollItemObj.transform.SetParent(scrollContent.transform, false);
            scrollItemObj.transform.localScale = Vector3.one * 0.8f;
            scrollItemObj.transform.Find("num").gameObject.GetComponent<Text>().text = alisonDialogues[option];
        }

        if (numLines == 3)
        {
            scrollItemObj = Instantiate(alisonScrollItemPrefab3);
            scrollItemObj.transform.SetParent(scrollContent.transform, false);
            scrollItemObj.transform.localScale = Vector3.one * 0.8f;
            scrollItemObj.transform.Find("num").gameObject.GetComponent<Text>().text = alisonDialogues[option];
        }

        StartCoroutine(ForceScrollDown());

    }


    IEnumerator ForceScrollDown()
    {
        // Wait for end of frame AND force update all canvases before setting to bottom.
        yield return new WaitForEndOfFrame();
        Canvas.ForceUpdateCanvases();
        scrollView.verticalNormalizedPosition = 0f;
        Canvas.ForceUpdateCanvases();
    }

    public void goToProfile()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("profile");
    }
}
