using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelFader : MonoBehaviour
{
    public GameObject Panel;
    int counter;

    public void showhidePanel()
    {
        counter++;
        if(counter % 2 == 1)
        {
            Panel.gameObject.SetActive(false);
        } else
        {
            Panel.gameObject.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
