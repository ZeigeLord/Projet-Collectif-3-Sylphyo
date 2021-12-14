using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiPlayerTK;

public class Tutorial : MonoBehaviour
{
    //Nuances, Attaques, Shake vibrato, Slider, Tangage, Roulis, Mode Mouvement
    bool isFinished = false;
    public Slider_test sliderTest;


    private void Start()
    {
        sliderTest.GetComponent<Slider_test>();
    }

    void Update()
    {
        if (sliderTest.referenceSlider.value == sliderTest.playerSlider.value)
        {
            Debug.Log("Bretagne");
            sliderTest.ChangeValue();
        }
    }
}