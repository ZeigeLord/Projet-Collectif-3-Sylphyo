using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_logic : MonoBehaviour
{

    public GameObject user_panel, creer_profil, charger_profil, main_panel, jouer_panel, reglages_panel, exos_panel, cat1_panel, cat2_panel, cat3_panel, cat4_panel, eval_panel, demo_panel, tuto_panel;

    // Start is called before the first frame update
    void Start()
    {
        user_panel.SetActive(true);
        creer_profil.SetActive(false);
        charger_profil.SetActive(false);
        main_panel.SetActive(false);
        jouer_panel.SetActive(false); //Pour être sur qu'au début le seul panel actif, soit le main panel, pour ne pas que le panel jouer ne recouvre notre notre principal panel
        reglages_panel.SetActive(false);
        exos_panel.SetActive(false);
        cat1_panel.SetActive(false);
        cat2_panel.SetActive(false);
        cat3_panel.SetActive(false);
        cat4_panel.SetActive(false);
        demo_panel.SetActive(false);
        tuto_panel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowPanel(int id)
    {
        switch (id)
        {
            case 1:
                jouer_panel.SetActive(true);
                break;
            case 2:
                reglages_panel.SetActive(true);
                break;
            case 3:
                exos_panel.SetActive(true);
                break;
            case 4:
                cat1_panel.SetActive(true);
                break;
            case 5:
                cat3_panel.SetActive(true);
                break;
            case 6:
                cat4_panel.SetActive(true);
                break;
            case 7:
                demo_panel.SetActive(true);
                break;
            case 8:
                tuto_panel.SetActive(true);
                break;
            case 9:
                main_panel.SetActive(true);
                break;
            case 10:
                cat2_panel.SetActive(true);
                break;
            case 11:
                creer_profil.SetActive(true);
                break;
            case 12:
                charger_profil.SetActive(true);
                break;
            default:
                break;
        }
    }
   /* public void GoToPlay()
    {
        jouer_panel.SetActive(true);
        main_panel.SetActive(false);
    }

    public void GoToReglages()
    {
        reglages_panel.SetActive(true);
        jouer_panel.SetActive(false);
        exos_panel.SetActive(false);
        cat1_pannel.SetActive(false);
        cat2_pannel.SetActive(false);
        cat3_pannel.SetActive(false);
        cat4_pannel.SetActive(false);
        eval_panel.SetActive(false);
        demo_panel.SetActive(false);
        tuto_panel.SetActive(false);
    }

    public void GoToTuto()
    {
        tuto_panel.SetActive(true);
        jouer_panel.SetActive(false);

    }

    public void GoToCategorie()
    {
        exos_panel.SetActive(true);
        jouer_panel.SetActive(false);
    }
    public void GoToCategorie1()
    {
        cat1_pannel.SetActive(true);
        exos_panel.SetActive(false);
    }
    public void GoToCategorie2()
    {
        cat2_pannel.SetActive(true);
        exos_panel.SetActive(false);
    }
    public void GoToCategorie3()
    {
        cat3_pannel.SetActive(true);
        exos_panel.SetActive(false);
    }
    public void GoToCategorie4()
    {
        cat4_pannel.SetActive(true);
        exos_panel.SetActive(false);
    }

    public void GoToEval()
    {
        eval_panel.SetActive(true);
        exos_panel.SetActive(false);
    }

    public void GoToDemo()
    {
        demo_panel.SetActive(true);
        reglages_panel.SetActive(false);
    }

    public void GoToHome()
    {
        main_panel.SetActive(true);
        jouer_panel.SetActive(false);
        reglages_panel.SetActive(false);
        exos_panel.SetActive(false);
        cat1_pannel.SetActive(false);
        cat2_pannel.SetActive(false);
        cat3_pannel.SetActive(false);
        cat4_pannel.SetActive(false);
        eval_panel.SetActive(false);
        demo_panel.SetActive(false);
        tuto_panel.SetActive(false);
    */

   public void GoToURL()
    {
        Application.OpenURL("https://downloads.aodyo.com/sylphyo/sylphyo-userguide-fr.pdf");
    }

}
