using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidePanel : MonoBehaviour
{
    public GameObject panel, previousPanel;

    void Start()
    {
        //panel.SetActive(true);
        previousPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hidePanel()
    {
        panel.SetActive(false);
        previousPanel.gameObject.SetActive(true);
        /*switch (id)
        {
            case 1:
                panel.gameObject.SetActive(false);
                previousPanel.gameObject.SetActive(true);
                break;
            default:
                break;
        }*/
    }

}
