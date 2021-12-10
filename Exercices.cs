using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exercices : MonoBehaviour
{
    public GameObject main_panel, reglage_panel, niveau1_panel, niveau2_panel, exercice1_1, exercice2_1, exercice3_1, exercice1_2, exercice2_2, exercice3_2;
    // Start is called before the first frame update
    void Start()
    {
        exercice1_1.SetActive(false);
        exercice2_1.SetActive(false);
        exercice3_1.SetActive(false);
        exercice1_2.SetActive(false);
        exercice2_2.SetActive(false);
        exercice3_2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToExo1_1()
    {
        exercice1_1.SetActive(true);
        niveau1_panel.SetActive(false);
    }
    public void GoToExo2_1()
    {
        exercice2_1.SetActive(true);
        niveau1_panel.SetActive(false);
    }
    public void GoToExo3_1()
    {
        exercice2_1.SetActive(true);
        niveau1_panel.SetActive(false);
    }
    public void GoToExo1_2()
    {
        exercice1_2.SetActive(true);
        niveau2_panel.SetActive(false);
    }
    public void GoToExo2_2()
    {
        exercice2_2.SetActive(true);
        niveau2_panel.SetActive(false);
    }
    public void GoToExo3_2()
    {
        exercice2_2.SetActive(true);
        niveau2_panel.SetActive(false);
    }
    public void GoToReglages()
    {
        reglage_panel.SetActive(true);
        niveau1_panel.SetActive(false);
        niveau2_panel.SetActive(false);
        exercice1_1.SetActive(false);
        exercice2_1.SetActive(false);
        exercice3_1.SetActive(false);
        exercice1_2.SetActive(false);
        exercice2_2.SetActive(false);
        exercice3_2.SetActive(false);
    }
    public void GoToHome()
    {
        main_panel.SetActive(true);
        niveau1_panel.SetActive(false);
        niveau2_panel.SetActive(false);
        exercice1_1.SetActive(false);
        exercice2_1.SetActive(false);
        exercice3_1.SetActive(false);
        exercice1_2.SetActive(false);
        exercice2_2.SetActive(false);
        exercice3_2.SetActive(false);

    }
}
