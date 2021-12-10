using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_logic : MonoBehaviour
{

    public GameObject main_panel, jouer_panel, reglages_panel, expert_panel, niv2_pannel, eval_panel, demo_panel, tuto_panel;

    // Start is called before the first frame update
    void Start()
    {
        jouer_panel.SetActive(false); //Pour être sur qu'au début le seul panel actif, soit le main panel, pour ne pas que le panel jouer ne recouvre notre notre principal panel
        reglages_panel.SetActive(false);
        expert_panel.SetActive(false);
        niv2_pannel.SetActive(false);
        eval_panel.SetActive(false);
        demo_panel.SetActive(false);
        tuto_panel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToPlay()
    {
        jouer_panel.SetActive(true);
        main_panel.SetActive(false);
    }

    public void GoToReglages()
    {
        reglages_panel.SetActive(true);
        jouer_panel.SetActive(false);
        expert_panel.SetActive(false);
        niv2_pannel.SetActive(false);
        eval_panel.SetActive(false);
        demo_panel.SetActive(false);
        tuto_panel.SetActive(false);
    }

    public void GoToTuto()
    {
        tuto_panel.SetActive(true);
        jouer_panel.SetActive(false);

    }

    public void GoToExpert()
    {
        expert_panel.SetActive(true);
        jouer_panel.SetActive(false);
    }

    public void GoToNiveau2()
    {
        niv2_pannel.SetActive(true);
        expert_panel.SetActive(false);
    }

    public void GoToEval()
    {
        eval_panel.SetActive(true);
        expert_panel.SetActive(false);
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
        expert_panel.SetActive(false);
        niv2_pannel.SetActive(false);
        eval_panel.SetActive(false);
        demo_panel.SetActive(false);
        tuto_panel.SetActive(false);
    }

   public void GoToURL()
    {
        Application.OpenURL("https://downloads.aodyo.com/sylphyo/sylphyo-userguide-fr.pdf");
    }

}
