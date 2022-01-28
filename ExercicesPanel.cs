using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExercicesPanel : MonoBehaviour
{
    public GameObject main_panel, reglage_panel, exercice1_cat1_1, exercice2_cat1_1, exercice3_cat1_1, exercice4_cat1_1, exercice5_cat1_1, exercice1_cat1_2, exercice2_cat1_2, exercice3_cat1_2, exercice4_cat1_2, exercice5_cat1_2, exercice1_cat1_3, exercice2_cat1_3, exercice3_cat1_3, exercice4_cat1_3, eval_cat1_panel;
    // Start is called before the first frame update
    void Start()
    {
        exercice1_cat1_1.SetActive(false);
        exercice2_cat1_1.SetActive(false);
        exercice3_cat1_1.SetActive(false);
        exercice4_cat1_1.SetActive(false);
        exercice5_cat1_1.SetActive(false);
        exercice1_cat1_2.SetActive(false);
        exercice2_cat1_2.SetActive(false);
        exercice3_cat1_2.SetActive(false);
        exercice4_cat1_2.SetActive(false);
        exercice5_cat1_2.SetActive(false);
        exercice1_cat1_3.SetActive(false);
        exercice2_cat1_3.SetActive(false);
        exercice3_cat1_3.SetActive(false);
        exercice4_cat1_3.SetActive(false);
        eval_cat1_panel.SetActive(false);
    }

    public void ShowPanelExercices(int id)
    {
        switch (id)
        {
            case 1:
                exercice1_cat1_1.SetActive(true);
                break;
            case 2:
                exercice2_cat1_1.SetActive(true);
                break;
            case 3:
                exercice3_cat1_1.SetActive(true);
                break;
            case 4:
                exercice1_cat1_2.SetActive(true);
                break;
            case 5:
                exercice2_cat1_2.SetActive(true);
                break;
            case 6:
                exercice3_cat1_2.SetActive(true);
                break;
            case 7:
                exercice1_cat1_3.SetActive(true);
                break;
            case 8:
                exercice2_cat1_3.SetActive(true);
                break;
            case 9:
                exercice3_cat1_3.SetActive(true);
                break;
            case 10:
                eval_cat1_panel.SetActive(true);
                break;
            case 11:
                exercice4_cat1_1.SetActive(true);
                break;
            case 12:
                exercice5_cat1_1.SetActive(true);
                break;
            case 13:
                exercice4_cat1_2.SetActive(true);
                break;
            case 14:
                exercice5_cat1_2.SetActive(true);
                break;
            case 15:
                exercice4_cat1_3.SetActive(true);
                break;
            case 16:
                reglage_panel.SetActive(true);
                break;
            default:
                break;
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }

 /*   public void GoToReglages()
    {
        reglage_panel.SetActive(true);
        exercice1_cat1_1.SetActive(false);
        exercice2_cat1_1.SetActive(false);
        exercice3_cat1_1.SetActive(false);
        exercice1_cat1_2.SetActive(false);
        exercice2_cat1_2.SetActive(false);
        exercice3_cat1_2.SetActive(false);
        exercice1_cat1_3.SetActive(false);
        exercice2_cat1_3.SetActive(false);
        exercice3_cat1_3.SetActive(false);
        eval_cat1_panel.SetActive(false);
    }
    public void GoToHome()
    {
        main_panel.SetActive(true);
       cat1_panel.SetActive(false);
        cat2_panel.SetActive(false);
        cat2_panel.SetActive(false);
        cat2_panel.SetActive(false);
        exercice1_cat1_1.SetActive(false);
        exercice2_cat1_1.SetActive(false);
        exercice3_cat1_1.SetActive(false);
        exercice1_cat1_2.SetActive(false);
        exercice2_cat1_2.SetActive(false);
        exercice3_cat1_2.SetActive(false);
        exercice1_cat1_3.SetActive(false);
        exercice2_cat1_3.SetActive(false);
        exercice3_cat1_3.SetActive(false);
        eval_cat1_panel.SetActive(false);

    }*/
}
