using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    public static GameControl instance;

    public int level = 1;
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
