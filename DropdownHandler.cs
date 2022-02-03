using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    public GameObject bouchon1, bouchon2, bouchon3;
    public Dropdown myDropdownBouchon, myDropdownInstrument;
    public InstrumentData myInstrumentData;
    List<string> mesInstruments = new List<string>() { "Flûte à bec", "Saxophone", "Clarinette", "flûte traversière", "flûte traversière(alt)", "Saxophone(alt)", "Sapxophone(alt.2)", "Hautbois", "Trompette(EVI)", "EWI", "Hulusi", "Celtique", "Clarinette Orientale", "Saxophone (ancien)", "Whistle", "Flûte amérindienne", };

    void Start()
    {
        bouchon1.SetActive(false);
        bouchon2.SetActive(false);
        bouchon3.SetActive(false);

        myDropdownInstrument = transform.GetComponent<Dropdown>();
        myDropdownInstrument.options.Clear();
        foreach(var item in mesInstruments)
            myDropdownInstrument.options.Add(new Dropdown.OptionData(){ text = item});
    }

    public void PanelBouchon(int index)
    {
        if (index == 0)
            bouchon1.SetActive(true);
        else if (index == 1)
            bouchon2.SetActive(true);
        else if (index == 3)
            bouchon3.SetActive(true);
    }
    public void SetInstrument()
    {
        for(int i = 0; i <=34; i++)
            myInstrumentData.instrument = mesInstruments[i];
    }
    // Start is called before the first frame update

}
