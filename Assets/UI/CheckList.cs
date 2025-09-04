using UnityEngine;
using UnityEngine.UI;


public class CheckList : MonoBehaviour
{
    [SerializeField] private GameObject clFlowerUnchecked;
    [SerializeField] private GameObject clFlowerChecked;
    [SerializeField] private GameObject clWaterUnchecked;
    [SerializeField] private GameObject clWaterChecked;
    [SerializeField] private GameObject clHoneyUnchecked;
    [SerializeField] private GameObject clHoneyChecked;
    
    public void FlowerCheck()
    {
        clFlowerUnchecked.SetActive(false);
        clFlowerChecked.SetActive(true);
    }

    public void WaterCheck()
    {
        clWaterUnchecked.SetActive(false);
        clWaterChecked.SetActive(true);
    }

    public void HoneyCheck()
    {
        clHoneyUnchecked.SetActive(false);
        clHoneyChecked.SetActive(true);
    }
}
