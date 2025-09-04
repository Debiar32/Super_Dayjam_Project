using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Prompt : MonoBehaviour
{
    
    private GameObject Player;
    public GameObject promptObj;
    public GameObject Checklistobj;
    private GameObject promptText;
    private GameObject currentColObject;
    
    void Start()
    {
        Player = GameObject.Find("Player");
        promptText = GameObject.Find("Prompt Text");
        promptObj.SetActive(false);
    }
    
    private bool holding = false;
    private GameObject holdingObject;
    void Update()
    {
        
        //if not holding anything pickup object
        if (Input.GetKeyDown(KeyCode.E) && holding == false && colliding == true)
        {
            currentColObject.GetComponent<Collider2D>().enabled = false; // disable prompt showing up
            holdingObject = currentColObject;
            holding = true;
        }
        //drop item
        else if (Input.GetKeyDown(KeyCode.E) && holding == true)
        {
            holding = false;
            currentColObject.GetComponent<Collider2D>().enabled = true;
            currentColObject.transform.position = Player.transform.position;
        }

        // make pickdup object follow
        if (holding == true)
        {
            currentColObject.transform.position = Player.transform.position;
        }
        
    }
    
    bool colliding = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (holding == false)
        {
            // set text, show prompt, save collided object
            if (other.gameObject.name == "Honey")
            {
                promptText.GetComponent<TMP_Text>().text = "Press E to pickup Honey";
                promptObj.SetActive(true);
                currentColObject = other.gameObject;
                colliding = true;
            }
            else if (other.gameObject.name == "Flower")
            {
                promptText.GetComponent<TMP_Text>().text = "Press E to pickup Flower";
                promptObj.SetActive(true);
                currentColObject = other.gameObject;
                colliding = true;
            }
            else if (other.gameObject.name == "Water")
            {
                promptText.GetComponent<TMP_Text>().text = "Press E to pickup Water";
                promptObj.SetActive(true);
                currentColObject = other.gameObject;
                colliding = true;
            }
            else if (other.gameObject.name == "Coffee")
            {
                promptText.GetComponent<TMP_Text>().text = "Press E to pickup Coffee";
                promptObj.SetActive(true);
                currentColObject = other.gameObject;
                colliding = true;
            }
        }
        else if (holding == true)
        {
            if (other.gameObject.name == "House")
            {
                holding = false;
                //call Checklist stuff here
                if (currentColObject.name == "Honey")
                {
                    Checklistobj.GetComponent<CheckList>().HoneyCheck();
                }
                if (currentColObject.name == "Flower")
                {
                    Checklistobj.GetComponent<CheckList>().FlowerCheck();
                }
                if (currentColObject.name == "Water")
                {
                    Checklistobj.GetComponent<CheckList>().WaterCheck();
                }
                currentColObject.GetComponent<Collider2D>().enabled = false;
                colliding = false;
                currentColObject.SetActive(false);
                
            }
        }
    }

    // hide prompt
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == currentColObject.name)
        {
            promptObj.SetActive(false);
            colliding = false;
        }
    }
    
}
