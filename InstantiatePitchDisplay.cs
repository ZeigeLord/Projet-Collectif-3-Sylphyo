using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePitchDisplay : MonoBehaviour
{
    public GameObject pitchDisplayPointPrefab;
    public GameObject[] pitchDisplayPoints = new GameObject[500];

    public GraphicInterface gI;

    // Start is called before the first frame update
    void Start()
    {
        gI.StartReading();
        for (int i = 0; i< pitchDisplayPoints.Length; i++)
        {
            pitchDisplayPoints[i] = GameObject.Instantiate(pitchDisplayPointPrefab);
            pitchDisplayPoints[i].GetComponent<RectTransform>().localPosition = new Vector3(10+i*10, 500, 0);
            pitchDisplayPoints[i].transform.SetParent(transform);
        }        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < pitchDisplayPoints.Length; i++)
        {
            pitchDisplayPoints[i].transform.position = new Vector3(10 + i * 10, 500 + 10* gI.pitchHistory[i], 0);
        }
    }
    
}
