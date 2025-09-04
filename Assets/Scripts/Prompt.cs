using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Prompt : MonoBehaviour
{
    
    private GameObject Player;
    public GameObject promptObj;
    public GameObject promptText;
    private GameObject currentObject;
    
    void Start()
    {
        Player = GameObject.Find("Player");
        promptText = GameObject.Find("Prompt Text");
        promptText.GetComponent<TMP_Text>().text = "Test";
    }
    
    void Update()
    {
   
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Honey")
        {
            promptText.GetComponent<TMP_Text>().text = "Press E to pickup Honey";
            promptObj.SetActive(true);
            currentObject = other.gameObject;
        }
        else if (other.gameObject.name == "Leaf")
        {
            promptText.GetComponent<TMP_Text>().text = "Press E to pickup Leaf";
            promptObj.SetActive(true);
            currentObject = other.gameObject;
        }
        print(other.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == currentObject.name)
        {
            promptObj.SetActive(false);
        }
    }
}
