﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToChat()
    {
        Debug.Log("Clicked");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Chat");
    }
}
