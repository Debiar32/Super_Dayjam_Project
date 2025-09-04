using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CheckList : MonoBehaviour
{
    [SerializeField] private GameObject clFlowerUnchecked;
    [SerializeField] private GameObject clFlowerChecked;
    [SerializeField] private GameObject clWaterUnchecked;
    [SerializeField] private GameObject clWaterChecked;
    [SerializeField] private GameObject clHoneyUnchecked;
    [SerializeField] private GameObject clHoneyChecked;
    private bool flower = false;
    private bool water = false;
    private bool honey = false;

    public void Update()
    {
        Check();
    }

    public void FlowerCheck()
    {
        clFlowerUnchecked.SetActive(false);
        clFlowerChecked.SetActive(true);
        flower = true;
        Check();
    }

    public void WaterCheck()
    {
        clWaterUnchecked.SetActive(false);
        clWaterChecked.SetActive(true);
        water = true;
        Check();
    }

    public void HoneyCheck()
    {
        clHoneyUnchecked.SetActive(false);
        clHoneyChecked.SetActive(true);
        honey = true;
        Check();
    }

    private void Check()
    {
        if (flower && honey && water)
        {
           Application.Quit();
        }
    }
    
}
