using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoPanel : MonoBehaviour
{
    public GameObject main_panel, reglages_panel, tuto_panel, nuances, attaque, shakeVibrato, slider1, slider2, slider3, tangage, roulis, modeMvt;
    // Start is called before the first frame update
    void Start()
    {
        nuances.SetActive(false);
        attaque.SetActive(false);
        shakeVibrato.SetActive(false);
        slider1.SetActive(false);
        slider2.SetActive(false);
        slider3.SetActive(false);
        tangage.SetActive(false);
        roulis.SetActive(false);
        modeMvt.SetActive(false);
        reglages_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowPanelTutoriels(int id)
    {
        switch (id)
        {
            case 1:
                nuances.SetActive(true);
                break;
            case 2:
                attaque.SetActive(true);
                break;
            case 3:
                shakeVibrato.SetActive(true);
                break;
            case 4:
                slider1.SetActive(true);
                break;
            case 5:
                slider2.SetActive(true);
                break;
            case 6:
                slider3.SetActive(true);
                break;
            case 7:
                tangage.SetActive(true);
                break;
            case 8:
                roulis.SetActive(true);
                break;
            case 9:
                modeMvt.SetActive(true);
                break;
            default:
                break;
        }
    }
  /*  public void GoToNuance()
    {
        nuances.SetActive(true);
        tuto_panel.SetActive(false);
    }
    public void GoToAttaques()
    {
        attaque.SetActive(true);
        tuto_panel.SetActive(false);
    }
    public void GoToTangage()
    {
        tangage.SetActive(true);
        tuto_panel.SetActive(false);
    }
    public void GoToShakeVibrato()
    {
        shakeVibrato.SetActive(true);
        tuto_panel.SetActive(false);
    }
  */
    public void GoToReglages()
    {
        reglages_panel.SetActive(true);
        tuto_panel.SetActive(false);
        nuances.SetActive(false);
        attaque.SetActive(false);
    }
    public void GoToHome()
    {
        main_panel.SetActive(true);
        tuto_panel.SetActive(false);
        nuances.SetActive(false);
        attaque.SetActive(false);
    }
}
