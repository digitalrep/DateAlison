using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    //Game Data
    public int level = 1;
    public int current_wrong = 0;
    public int current_question = 0;

    public string[] questions =
    {
        "What does Alison do for a living?",
        "Why is that her occupation?",
        "What is Alison afraid of?",
        "What is Alison's drink of choice?",
        "Why is Breakfast at Tiffany's her favourite movie?"
    };
    public string[] answers = 
    { 
        "nothing",
        "relocation",
        "dogs", 
        "beer", 
        "new life" 
    };

    public List<DialogueOption> chosenOptions = new List<DialogueOption>();

    private void Awake()
    {

        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        //Do not destroy this object when we load a new scene
        DontDestroyOnLoad(gameObject);
    }
   
}
