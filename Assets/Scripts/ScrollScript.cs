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
        new DialogueOption(8, "Challenge", "Really? How can someone go about getting to know you, then?", "Just by chatting to me.", 17, 18, "neutral"),
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
        new DialogueOption(19, "Talk About Self", "Oh, okay. Well... Let's see... I like dogs... And working out at the gym. And skiing.", "Fun fact: I was bitten by a dog once.", 39, 40, "neutral"),
        new DialogueOption(20, "Ask More Questions", "Why are you so secretive?", "", 41, 42, "neutral"),
        new DialogueOption(21, "Admit it", "Uh, yeah, actually I do. Is that so bad?", "Haha I knew it!", 43, 44, "neutral"),
        new DialogueOption(22, "Deny it", "No. Not at all. But if a game proves too difficult to play, I would probably just walk away from it.", "Are you the kind of person who needs an instruction manual to operate a microwave?", 45, 46, "shocked"),
        new DialogueOption(23, "Question More", "You had to have done something... Did you make the bed at least?", "You ask a lot of questions.", 47, 48, "disappointed"),
        new DialogueOption(24, "", "", "", 49, 50, "neutral"),
        new DialogueOption(25, "", "", "", 51, 52, "neutral"),
        new DialogueOption(26, "", "", "", 53, 54, "neutral"),
        new DialogueOption(27, "", "", "", 55, 56, "neutral"),
        new DialogueOption(28, "", "", "", 57, 58, "neutral"),
        new DialogueOption(29, "Miss her?", "You miss her? What happened? You get fired?", "No. I had to relocate. I couldn't keep my old job.", 59, 60, "disappointed"),
        new DialogueOption(30, "Joke", "Yeah sure - I miss my boss, too - though I should really just put my foot right down on the accelerator.", "Haha! Wow. You really hate him, hey?", 61, 62, "shocked"),
        new DialogueOption(31, "Support Group", "Talk about our troubled childhoods, sort out all our issues...", "Who says I have any?", 63, 64, "shocked"),
        new DialogueOption(32, "Drink", "Drink copious amounts of alcohol.", "Sounds like my kind of book club!", 65, 66, "neutral"),
        new DialogueOption(33, "Question", "Why is that your favourite?", "I think I like it because it reminds me that anyone can start anew, create a new life.", 67, 68, "neutral"),
        new DialogueOption(34, "Share Favourite", "I think mine would have to be 'Marnie.'", "Err... Is that a Hitchcock movie? I don't like thrillers.", 69, 70, "shocked"),
        new DialogueOption(35, "", "", "", 71, 72, "neutral"),
        new DialogueOption(36, "", "", "", 73, 74, "neutral"),
        new DialogueOption(37, "", "", "", 75, 76, "neutral"),
        new DialogueOption(38, "", "", "", 77, 78, "neutral"),
        new DialogueOption(39, "Sympathise", "That's no good. Are you afraid of dogs now?", "Actually, yeah. I am a little bit. What about you? Are you afraid of anything?", 79, 80, "neutral"),
        new DialogueOption(40, "Joke", "What did you do to it?", "Haha. Well, I insulted its mother. After that it didn't like me much at all.", 81, 82, "neutral"),
        new DialogueOption(41, "", "", "", 83, 84, "neutral"),
        new DialogueOption(42, "", "", "", 85, 86, "neutral"),
        new DialogueOption(43, "", "", "", 87, 88, "neutral"),
        new DialogueOption(44, "", "", "", 89, 90, "neutral"),
        new DialogueOption(45, "Yes", "Of course. I like to know how to utilise things properly. For instance, I know how to defrost a whole chicken in my microwave without ruining it. Do you?", "Uh, no. Probably not.", 91, 92, "neutral"),
        new DialogueOption(46, "No", "Of course not. Are you the kind of person who makes fun of people who read instruction manuals?", "Mabye I am.", 93, 94, "neutral"),
        new DialogueOption(47, "Apologise", "I do, I'm sorry. I'm just trying to make conversation.", "", 95, 96, "neutral"),
        new DialogueOption(48, "Defend", "You dodge a lot of questions.", "I think we should stop talking.", 100, 100, "neutral"),
        new DialogueOption(49, "", "", "", 97, 98, "neutral"),
        new DialogueOption(50, "", "", "", 101, 102, "neutral"),
        new DialogueOption(51, "", "", "", 103, 104, "neutral"),
        new DialogueOption(52, "", "", "", 105, 106, "neutral"),
        new DialogueOption(53, "", "", "", 107, 108, "neutral"),
        new DialogueOption(54, "", "", "", 109, 110, "neutral"),
        new DialogueOption(55, "", "", "", 111, 112, "neutral"),
        new DialogueOption(56, "", "", "", 113, 114, "neutral"),
        new DialogueOption(57, "", "", "", 115, 116, "neutral"),
        new DialogueOption(58, "", "", "", 117, 118, "neutral"),
        new DialogueOption(59, "", "", "", 119, 120, "neutral"),
        new DialogueOption(60, "", "", "", 121, 122, "neutral"),
        new DialogueOption(61, "", "", "", 123, 124, "neutral"),
        new DialogueOption(62, "", "", "", 125, 126, "neutral"),
        new DialogueOption(63, "Challenge", "Oh, I'm sure you do. Everyone has at least some.", "Yes, okay. I guess you're right.", 127, 128, "neutral"),
        new DialogueOption(64, "Agree", "", "", 129, 130, "neutral"),
        new DialogueOption(65, "Ask Favourite Drink", "Oh, really? What's your drink of choice?", "I like an ice cold beer at the end of a hard day.", 131, 132, "neutral"),
        new DialogueOption(66, "Meetings", "We can hold the meetings at the local pub.", "Haha! Okay.", 133, 134, "neutral"),
        new DialogueOption(67, "Why Start Anew?", "Do you want to start new?", "You ask too many questions.", 135, 136, "neutral"),
        new DialogueOption(68, "", "", "", 137, 138, "neutral"),
        new DialogueOption(69, "", "", "", 139, 140, "neutral"),
        new DialogueOption(70, "", "", "", 141, 142, "neutral"),
        new DialogueOption(71, "", "", "", 143, 144, "neutral"),
        new DialogueOption(72, "", "", "", 145, 146, "neutral"),
        new DialogueOption(73, "", "", "", 147, 148, "neutral"),
        new DialogueOption(74, "", "", "", 149, 150, "neutral"),
        new DialogueOption(75, "", "", "", 151, 152, "neutral"),
        new DialogueOption(76, "", "", "", 153, 154, "neutral"),
        new DialogueOption(77, "", "", "", 155, 156, "neutral"),
        new DialogueOption(78, "", "", "", 157, 158, "neutral"),
        new DialogueOption(79, "Joke", "Papercuts. I am deathly afraid of papercuts. To the point where I will not use paper anymore.", "Damn. How do you send gift cards?", 159, 160, "neutral"),
        new DialogueOption(80, "Admit Fear", "Heights. I hate heights. I get very dizzy.", "Good to know... Though a little concerning given you just told me you like to ski. How do you deal with ski lifts?", 161, 162, "neutral"),
        new DialogueOption(81, "", "", "", 163, 164, "neutral"),
        new DialogueOption(82, "", "", "", 165, 166, "neutral"),
        new DialogueOption(83, "", "", "", 167, 168, "neutral"),
        new DialogueOption(84, "", "", "", 169, 170, "neutral"),
        new DialogueOption(85, "", "", "", 171, 172, "neutral"),
        new DialogueOption(86, "", "", "", 173, 174, "neutral"),
        new DialogueOption(87, "", "", "", 175, 176, "neutral"),
        new DialogueOption(88, "", "", "", 177, 178, "neutral"),
        new DialogueOption(89, "", "", "", 179, 180, "neutral"),
        new DialogueOption(90, "", "", "", 181, 182, "neutral"),
        new DialogueOption(91, "Defensive", "Well, just don't come crying to me when you need help figuring out how change a setting on your phone, or something!", "Haha. Okay. I won't!", 183, 184, "neutral"),
        new DialogueOption(92, "Pun", "Do you tend to just 'wing it'?", "Oh my. You remind me of my Dad with jokes like that.", 185, 186, "neutral"),
        new DialogueOption(93, "", "", "", 187, 188, "neutral"),
        new DialogueOption(94, "Serious", "", "", 189, 190, "neutral"),
        new DialogueOption(95, "", "", "", 191, 192, "neutral"),
        new DialogueOption(96, "", "", "", 193, 194, "neutral"),
        new DialogueOption(97, "", "", "", 195, 196, "neutral"),
        new DialogueOption(98, "", "", "", 197, 198, "neutral"),
        new DialogueOption(99, "", "", "", 199, 200, "neutral"),
        new DialogueOption(100, "Continue", " ", " ", 0, 0, "neutral"),
        new DialogueOption(101, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(102, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(103, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(104, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(105, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(106, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(107, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(108, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(109, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(110, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(111, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(112, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(113, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(114, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(115, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(116, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(117, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(118, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(119, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(120, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(121, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(122, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(123, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(124, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(125, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(126, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(127, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(128, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(129, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(130, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(131, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(132, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(133, "Ask Local Pub", "So what is your local pub? Maybe we can meet there for our inaugural book club meeting.", "Whoa. Slow down. I don't even know you!", 0, 0, "shocked"),
        new DialogueOption(134, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(135, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(136, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(137, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(138, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(139, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(140, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(141, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(142, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(143, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(144, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(145, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(146, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(147, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(148, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(149, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(150, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(151, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(152, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(153, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(154, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(155, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(156, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(157, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(158, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(159, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(160, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(161, "Truth", "I don't. I just don't use them.", "You walk up all the slopes? You must be pretty fit.", 0, 0, "neutral"),
        new DialogueOption(162, "Joke", "Copious amounts of alcohol and drugs.", "Remind me never to go skiing with you.", 0, 0, "neutral"),
        new DialogueOption(163, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(164, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(165, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(166, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(167, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(168, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(169, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(170, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(171, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(172, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(173, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(174, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(175, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(176, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(177, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(178, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(179, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(180, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(181, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(182, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(183, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(184, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(185, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(186, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(187, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(188, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(189, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(190, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(191, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(192, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(193, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(194, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(195, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(196, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(197, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(198, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(199, "", " ", " ", 0, 0, "neutral"),
        new DialogueOption(200, "", " ", " ", 0, 0, "neutral"),
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
            if(option == 16 || option == 29 || option == 65)
            {
                GetComponent<AudioSource>().PlayOneShot(success, 1);
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

            Debug.Log(dialogueOptions[current_index]);
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