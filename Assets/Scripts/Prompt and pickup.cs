using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Prompt : MonoBehaviour
{
    
    private GameObject Player;
    public GameObject promptObj;
    private GameObject promptText;
    private GameObject currentColObject;
    
    void Start()
    {
        Player = GameObject.Find("Player");
        promptText = GameObject.Find("Prompt Text");
    }
    
    private bool holding = false;
    private GameObject holdingObject;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && holding == false)
        {
            currentColObject.GetComponent<Collider2D>().enabled = false;
            holdingObject = currentColObject;
            holding = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && holding == true)
        {
            holding = false;
            currentColObject.GetComponent<Collider2D>().enabled = true;
            currentColObject.transform.position = Player.transform.position;
        }

        if (holding == true)
        {
            currentColObject.transform.position = Player.transform.position;
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (holding == false)
        {
            if (other.gameObject.name == "Honey")
            {
                promptText.GetComponent<TMP_Text>().text = "Press E to pickup Honey";
                promptObj.SetActive(true);
                currentColObject = other.gameObject;
            }
            else if (other.gameObject.name == "Leaf")
            {
                promptText.GetComponent<TMP_Text>().text = "Press E to pickup Leaf";
                promptObj.SetActive(true);
                currentColObject = other.gameObject;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == currentColObject.name)
        {
            promptObj.SetActive(false);
        }
    }
    
}
