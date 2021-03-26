using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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

    public GameObject alisonImage;

    public Sprite neutral;
    public Sprite shocked;
    public Sprite curious;
    public Sprite disappointed;

    public Button buttonOption1;
    public Button buttonOption2;

    public DialogueOption chosenDialogue;

    public GameObject gameOverPanel;
    public Text nameTxt;

    public AudioClip notification;
    public AudioClip success;

    private AudioSource notificationSource;
    private AudioSource successSource;

    GameObject scrollItemObj;

    private DialogueOption[] dialogueOptions = {
        new DialogueOption(0, "", "", "", 1, 2, "neutral"),
        new DialogueOption(1, "Curious Opening", "Hello, Alison. I found your profile intriguing... If a little... Mysterious.", "Hi! Thanks for messaging me. Yeah, I guess it is mysterious. Does that bother you?", 3, 4, "shocked"),
        new DialogueOption(2, "Normal Opening", "Hey Alison, how are you?", "Hey there, I'm good. How are you?", 5, 6, "neutral"),
        new DialogueOption(3, "Not Bothered", "No, not at all. A little mystery never hurt anyone.", "Well I'm glad to hear that, because I'm really not an open book.", 7, 8, "neutral"),
        new DialogueOption(4, "Bothered", "Yeah, actually, it kinda does. It makes it hard to know what to talk to you about.", "Hmm. I see. Well, you could always just ask me.", 9, 10, "curious"),
        new DialogueOption(5, "Lie", "Yeah, I'm great. What did you get up to today?", "Not much, to be honest. What about you?", 11, 12, "neutral"),
        new DialogueOption(6, "Truth", "I'm okay, but... Actually... I've had a bad day. My boss just blamed me for something that wasn't my fault.", "Oh, no. That sucks. I'm sorry that happened.", 13, 14, "disappointed"),
        new DialogueOption(7, "Reassure", "That's ok. I find reading boring anyway.", "Me too. I always prefer to wait for the movie to come out.", 15, 16, "neutral"),
        new DialogueOption(8, "Challenge", "", "", 17, 18, "neutral"),
        new DialogueOption(9, "Ask Interests", "Alright... What are some things you like to talk about?", "Hmm. I really asked for that, didn't I? Let's just talk about you, instead.", 19, 20, "neutral"),
        new DialogueOption(10, "Argue", "But I wouldn't have to ask if you just put it on your profile...", "You're the kind of person who uses walkthroughs when you play video games, aren't you?", 21, 22, "neutral"),
        new DialogueOption(11, "Question", "Not much?", "Yup. That's what I said.", 23, 24, "disappointed"),
        new DialogueOption(12, "Answer", "Just work... It was boring.", "I hope your day gets less boring now that you're talking to me.", 25, 26, "neutral"),
        new DialogueOption(13, "Play on Sympathy", "Yeah... He's had it in for me since day one. I try my hardest but it never seems good enough.", "", 27, 28, "neutral"),
        new DialogueOption(14, "Act Tough", "I shouldn't complain. It's no big deal! Isn't everyone's boss an asshole?", "No. Not all of them. I really miss my boss. She is an amazing woman.", 29, 30, "neutral"),
        new DialogueOption(15, "Bad Joke", "Maybe we should start our own book club.", "One where we don't read any books? That'd be weird. What would we do?", 31, 32, "disappointed"),
        new DialogueOption(16, "Ask Favourite Movie", "Speaking of movies, which one's your favourite?", "Hmm... Probably 'Breakfast at Tiffany's.'", 33, 34, "neutral"),
        new DialogueOption(17, "", "", "", 35, 36, "neutral"),
        new DialogueOption(18, "", "", "", 37, 38, "neutral"),
        new DialogueOption(19, "", "", "", 39, 40, "neutral"),
        new DialogueOption(20, "", "", "", 41, 42, "neutral"),
        new DialogueOption(21, "Admit it", "Uh, yeah, actually I do. Is that so bad?", "Haha I knew it!", 43, 44, "neutral"),
        new DialogueOption(22, "Deny it", "No. Not at all. But if a game proves too difficult to play, I would probably just walk away from it.", "Are you the kind of person who needs an instruction manual to operate a microwave?", 45, 46, "shocked"),
        new DialogueOption(23, "Question More", "You had to have done something... Did you make the bed at least?", "You ask a lot of questions.", 47, 48, "disappointed"),
        new DialogueOption(24, "", "", "", 0, 0, "neutral"),
        new DialogueOption(25, "", "", "", 0, 0, "neutral"),
        new DialogueOption(26, "", "", "", 0, 0, "neutral"),
        new DialogueOption(27, "", "", "", 0, 0, "neutral"),
        new DialogueOption(28, "", "", "", 0, 0, "neutral"),
        new DialogueOption(29, "Miss her?", "You miss her? What happened? You get fired?", "No. I had to relocate. I couldn't keep my old job.", 0, 0, "neutral"),
        new DialogueOption(30, "Joke", "Yeah sure - I miss my boss, too - though I should really just put my foot right down on the accelerator.", "Haha! Wow. You really hate him, hey?", 0, 0, "shocked"),
        new DialogueOption(31, "", "", "", 0, 0, "neutral"),
        new DialogueOption(32, "", "", "", 0, 0, "neutral"),
        new DialogueOption(33, "", "", "", 0, 0, "neutral"),
        new DialogueOption(34, "", "", "", 0, 0, "neutral"),
        new DialogueOption(35, "", "", "", 0, 0, "neutral"),
        new DialogueOption(36, "", "", "", 0, 0, "neutral"),
        new DialogueOption(37, "", "", "", 0, 0, "neutral"),
        new DialogueOption(38, "", "", "", 0, 0, "neutral"),
        new DialogueOption(39, "", "", "", 0, 0, "neutral"),
        new DialogueOption(40, "", "", "", 0, 0, "neutral"),
        new DialogueOption(41, "", "", "", 0, 0, "neutral"),
        new DialogueOption(42, "", "", "", 0, 0, "neutral"),
        new DialogueOption(43, "", "", "", 0, 0, "neutral"),
        new DialogueOption(44, "", "", "", 0, 0, "neutral"),
        new DialogueOption(45, "Yes", "Of course. I like to know how to best utilise things. I know how to defrost a whole chicken in my microwave without ruining it. Do you?", "Uh, no. Probably not.", 0, 0, "neutral"),
        new DialogueOption(46, "No", "Of course not. Are you the kind of person who makes fun of people who read instruction manuals?", "Mabye I am.", 0, 0, "neutral"),
        new DialogueOption(47, "Apologise", "I do, I'm sorry. I'm just trying to make conversation.", "", 0, 0, "neutral"),
        new DialogueOption(48, "Defend", "You dodge a lot of questions.", "I think we should stop talking.", 100, 100, "neutral"),
        new DialogueOption(49, "", "", "", 0, 0, ""),
        new DialogueOption(50, "", "", "", 0, 0, "neutral"),
        new DialogueOption(51, "", "", "", 0, 0, "neutral"),
        new DialogueOption(52, "", "", "", 0, 0, "neutral"),
        new DialogueOption(53, "", "", "", 0, 0, "neutral"),
        new DialogueOption(54, "", "", "", 0, 0, "neutral"),
        new DialogueOption(55, "", "", "", 0, 0, "neutral"),
        new DialogueOption(56, "", "", "", 0, 0, "neutral"),
        new DialogueOption(57, "", "", "", 0, 0, "neutral"),
        new DialogueOption(58, "", "", "", 0, 0, "neutral"),
        new DialogueOption(59, "", "", "", 0, 0, "neutral"),
        new DialogueOption(60, "", "", "", 0, 0, "neutral"),
        new DialogueOption(61, "", "", "", 0, 0, "neutral"),
        new DialogueOption(62, "", "", "", 0, 0, "neutral"),
        new DialogueOption(63, "", "", "", 0, 0, "neutral"),
        new DialogueOption(64, "", "", "", 0, 0, "neutral"),
        new DialogueOption(65, "", "", "", 0, 0, "neutral"),
        new DialogueOption(66, "", "", "", 0, 0, "neutral"),
        new DialogueOption(67, "", "", "", 0, 0, "neutral"),
        new DialogueOption(68, "", "", "", 0, 0, "neutral"),
        new DialogueOption(69, "", "", "", 0, 0, "neutral"),
        new DialogueOption(70, "", "", "", 0, 0, "neutral"),
        new DialogueOption(71, "", "", "", 0, 0, "neutral"),
        new DialogueOption(72, "", "", "", 0, 0, "neutral"),
        new DialogueOption(73, "", "", "", 0, 0, "neutral"),
        new DialogueOption(74, "", "", "", 0, 0, "neutral"),
        new DialogueOption(75, "", "", "", 0, 0, "neutral"),
        new DialogueOption(76, "", "", "", 0, 0, "neutral"),
        new DialogueOption(77, "", "", "", 0, 0, "neutral"),
        new DialogueOption(78, "", "", "", 0, 0, "neutral"),
        new DialogueOption(79, "", "", "", 0, 0, "neutral"),
        new DialogueOption(80, "", "", "", 0, 0, "neutral"),
        new DialogueOption(81, "", "", "", 0, 0, "neutral"),
        new DialogueOption(82, "", "", "", 0, 0, "neutral"),
        new DialogueOption(83, "", "", "", 0, 0, "neutral"),
        new DialogueOption(84, "", "", "", 0, 0, "neutral"),
        new DialogueOption(85, "", "", "", 0, 0, "neutral"),
        new DialogueOption(86, "", "", "", 0, 0, "neutral"),
        new DialogueOption(87, "", "", "", 0, 0, "neutral"),
        new DialogueOption(88, "", "", "", 0, 0, "neutral"),
        new DialogueOption(89, "", "", "", 0, 0, "neutral"),
        new DialogueOption(90, "", "", "", 0, 0, "neutral"),
        new DialogueOption(91, "", "", "", 0, 0, "neutral"),
        new DialogueOption(92, "", "", "", 0, 0, "neutral"),
        new DialogueOption(93, "", "", "", 0, 0, "neutral"),
        new DialogueOption(94, "", "", "", 0, 0, "neutral"),
        new DialogueOption(95, "", "", "", 0, 0, "neutral"),
        new DialogueOption(96, "", "", "", 0, 0, "neutral"),
        new DialogueOption(97, "", "", "", 0, 0, "neutral"),
        new DialogueOption(98, "", "", "", 0, 0, "neutral"),
        new DialogueOption(99, "", "", "", 0, 0, "neutral"),
        new DialogueOption(100, "Continue", " ", " ", 0, 0, "neutral"),
    };

    private int current_index = 0;
    private int suspicionCounter = 0;
    private int location = 0;
    private float ratio = 0f;

    void Start()
    {
        buttonOption1.onClick.AddListener(delegate { printDialogue(1); });
        buttonOption2.onClick.AddListener(delegate { printDialogue(2); });

        ratio = Screen.width / 1080f;

        Debug.Log("Level from GameControl.instance: " + GameControl.instance.level);
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    void Update()
    {

    }

    public void printDialogue(int option)
    {
        float beginTime = Time.time;
        int lineLength = 56;

        if(option != 100)
        {
            if(option == 29)
            {
                //successSource.Play();
                GetComponent<AudioSource>().PlayOneShot(success, 1);
                location++;
            }

            DialogueOption chosenDialogue = dialogueOptions[option];

            buttonOption1.onClick.RemoveAllListeners();
            buttonOption2.onClick.RemoveAllListeners();

            buttonOption1.GetComponentInChildren<Text>().text = dialogueOptions[chosenDialogue.get_option_1()].get_button_text();
            buttonOption1.onClick.AddListener(delegate { printDialogue(dialogueOptions[chosenDialogue.get_option_1()].get_id()); });

            buttonOption2.GetComponentInChildren<Text>().text = dialogueOptions[chosenDialogue.get_option_2()].get_button_text();
            buttonOption2.onClick.AddListener(delegate { printDialogue(dialogueOptions[chosenDialogue.get_option_2()].get_id()); });

            buttonOption1.interactable = false;
            buttonOption2.interactable = false;

            string mood = chosenDialogue.get_mood();

            switch (mood)
            {
                case "neutral":
                    alisonImage.GetComponent<Image>().sprite = neutral;
                    break;
                case "shocked":
                    alisonImage.GetComponent<Image>().sprite = shocked;
                    break;
                case "curious":
                    alisonImage.GetComponent<Image>().sprite = curious;
                    break;
                case "disappointed":
                    alisonImage.GetComponent<Image>().sprite = disappointed;
                    break;
                default:
                    alisonImage.GetComponent<Image>().sprite = neutral;
                    break;
            }

            int playerLength = chosenDialogue.get_player_dialogue().Length;
            int alisonLength = chosenDialogue.get_alison_dialogue().Length;

            int numLines = (int)Math.Ceiling((double)playerLength / lineLength);

            StartCoroutine(PrintPlayerDialogue(option, numLines, chosenDialogue.get_player_dialogue()));

            StartCoroutine(ForceScrollDown());

            numLines = (int)Math.Ceiling((double)alisonLength / lineLength);

            StartCoroutine(PrintAlisonDialogue(option, numLines, chosenDialogue.get_alison_dialogue()));

            current_index = option;
            GameControl.instance.chosenOptions.Add(dialogueOptions[current_index]);
        } else
        {
            // Alison has unmatched with you
            Image image = alisonImage.GetComponent<Image>();
            Color invisible = new Color(image.color.r, image.color.g, image.color.b, 0f);
            image.color = invisible;
            nameTxt.text = "";
            Image buttonImg = buttonOption1.GetComponent<Image>();
            buttonImg.color = invisible;
            Image button2Img = buttonOption2.GetComponent<Image>();
            button2Img.color = invisible;
            Image scrollbg = scrollView.GetComponent<Image>();
            scrollbg.color = invisible;
            GameObject[] clones = GameObject.FindGameObjectsWithTag("clone");
            foreach(GameObject clone in clones)
            {
                GameObject.Destroy(clone);
            }
            // Retry?
            gameOverPanel.GetComponent<CanvasGroup>().alpha = 1;
            // Show ad
        }

    }

    IEnumerator PrintPlayerDialogue(int option, int numLines, string dialogue)
    {

        if (numLines == 1)
        {
            scrollItemObj = Instantiate(playerScrollItemPrefab);
            scrollItemObj.transform.localScale = new Vector3(ratio, ratio, ratio);
            scrollItemObj.transform.SetParent(scrollContent.transform);
            scrollItemObj.transform.Find("num").gameObject.GetComponent<Text>().text = dialogue;
        }

        if (numLines == 2)
        {
            scrollItemObj = Instantiate(playerScrollItemPrefab2);
            scrollItemObj.transform.localScale = new Vector3(ratio, ratio, ratio);
            scrollItemObj.transform.SetParent(scrollContent.transform);
            scrollItemObj.transform.Find("num").gameObject.GetComponent<Text>().text = dialogue;
        }

        if (numLines == 3)
        {
            scrollItemObj = Instantiate(playerScrollItemPrefab3);
            scrollItemObj.transform.localScale = new Vector3(ratio, ratio, ratio);
            scrollItemObj.transform.SetParent(scrollContent.transform);
            scrollItemObj.transform.Find("num").gameObject.GetComponent<Text>().text = dialogue;
        }

        yield return null;
    }

    IEnumerator PrintAlisonDialogue(int option, int numLines, string dialogue)
    {
        yield return new WaitForSeconds(2);

        if (numLines == 1)
        {
            scrollItemObj = Instantiate(alisonScrollItemPrefab);
            scrollItemObj.transform.localScale = new Vector3(ratio, ratio, ratio);
            scrollItemObj.transform.SetParent(scrollContent.transform);
            scrollItemObj.transform.Find("num").gameObject.GetComponent<Text>().text = dialogue;
        }

        if (numLines == 2)
        {
            scrollItemObj = Instantiate(alisonScrollItemPrefab2);
            scrollItemObj.transform.localScale = new Vector3(ratio, ratio, ratio);
            scrollItemObj.transform.SetParent(scrollContent.transform);
            scrollItemObj.transform.Find("num").gameObject.GetComponent<Text>().text = dialogue;
        }

        if (numLines == 3)
        {
            scrollItemObj = Instantiate(alisonScrollItemPrefab3);
            scrollItemObj.transform.localScale = new Vector3(ratio, ratio, ratio);
            scrollItemObj.transform.SetParent(scrollContent.transform);
            scrollItemObj.transform.Find("num").gameObject.GetComponent<Text>().text = dialogue;
        }

        //notificationSource.Play();
        GetComponent<AudioSource>().PlayOneShot(notification, 1);
        StartCoroutine(ForceScrollDown());

        buttonOption1.interactable = true;
        buttonOption2.interactable = true;
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

    public void goToChat()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Chat");
    }

}