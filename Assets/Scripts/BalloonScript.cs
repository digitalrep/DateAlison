﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonScript : MonoBehaviour
{
    public Sprite deflated_balloon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Enter detected");
        Debug.Log(gameObject.GetComponentsInChildren<Image>().Length);  // returns 0
        Debug.Log(transform.GetChild(2));
        transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = deflated_balloon;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.02f;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}