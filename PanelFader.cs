using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelFader : MonoBehaviour
{
    public GameObject panel, previousPanel, aidePanel; //, previous_panel;
    //int counter;

    public void hidePanel(int id)
    {
        switch(id)
        {
            case 1:
                panel.gameObject.SetActive(false);
                previousPanel.gameObject.SetActive(true);
                break;
            default:
                break;
        }
        /*counter++;
        if(counter % 2 == 1)
        {
            panel.gameObject.SetActive(false);
        } else
        {
            panel.gameObject.SetActive(true);
        }*/
    }

    public void aide(int id)
    {
        switch(id)
        {
            case 1:
                aidePanel.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void cross(int id)
    {
        switch(id)
        {
            case 1:
                aidePanel.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       aidePanel.gameObject.SetActive(false);
        //previous_panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public void hidePanel()
    {
        panel.gameObject.SetActive(false);
        previous_panel.gameObject.SetActive(true);
    }*/
}
