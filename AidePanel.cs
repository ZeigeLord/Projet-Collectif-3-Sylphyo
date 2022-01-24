using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidePanel : MonoBehaviour
{
    public GameObject aidePanel;
    // Start is called before the first frame update
    void Start()
    {
        aidePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Help(int id)
    {
        switch (id)
        {
            case 1:
                aidePanel.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void Cross(int id)
    {
        switch (id)
        {
            case 1:
                aidePanel.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
