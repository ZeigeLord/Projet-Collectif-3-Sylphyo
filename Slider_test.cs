using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slider_test : MonoBehaviour
{
    public Slider referenceSlider, playerSlider;
    public Text textField;
    public float[] valeurs = new float[] {25, 56, 102};
    private int myInt;
    bool crescendo;
    
    void Start()
    {
        referenceSlider.GetComponent<Slider>();
        playerSlider.GetComponent<Slider>();
        textField.GetComponent<Text>();
        myInt = 1;
        referenceSlider.value = valeurs[0];
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void ChangeValue()
    {
        if (myInt <= 3)
        {
            referenceSlider.value = valeurs[myInt-1];
            Debug.Log("Valeur à atteindre : " + valeurs[myInt-1]);
            myInt++;
        }
        else
        {
            referenceSlider.value = 0;
            crescendo = true;
            Debug.Log("Exercice fini");
        }
          
     }

    public void Message_good()
    {
        if (playerSlider.value <= referenceSlider.value + 15 && playerSlider.value >= referenceSlider.value - 15)
        {
            textField.text = "Bravo ! Vous avez réussi";
            textField.color = Color.green;
        }
            
        else
        {
            textField.text = "Vous êtes nuls ! ";
            textField.color = Color.red;
        }
            
    }

        
}
