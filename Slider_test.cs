using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slider_test : MonoBehaviour
{
    public Slider slider, slider2;
    public float[] valeurs = new float[] {25, 56, 102, 84};
    private int myInt;
    
    void Start()
    {
        slider.GetComponent<Slider>();
        slider2.GetComponent<Slider>();
        myInt = 1;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void ButtonClicked()
    {
        if (myInt < 4)
        {
            slider.value = valeurs[myInt-1];
            Debug.Log(valeurs[myInt-1]);
            myInt++;
        }
        else
        {
            Debug.Log("Exercice fini");
        }
         
          
     }
        
}
