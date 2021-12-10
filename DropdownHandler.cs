using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    public Text textBox; 
    // Start is called before the first frame update
    void Start() //Pour afficher la selection actuelle de la liste déroulante
    {
        var drop_down = transform.GetComponent<Dropdown>(); //Le composant déroulant de la transformation
        drop_down.options.Clear(); //Effacé toutes les options pour être du bon côté

        List<string> items = new List<string>(); //Liste qui contient tous les items
        items.Add("Bouchon 1");
        items.Add("Bouchon 2");
        items.Add("Bouchon 3");

        foreach(var item in items) //Boucle pour ajouter chaque items à une option
        {
            drop_down.options.Add(new Dropdown.OptionData() { text = item });
        }
        //Appel de la méthode afin que le texte du premier élement soit affiché dans le champs texte
        DropdownItemSelected(drop_down);

        drop_down.onValueChanged.AddListener(delegate { DropdownItemSelected(drop_down); });
    }

    void DropdownItemSelected(Dropdown drop_down) //Appelé quand la value de drop_down a changé
    {
        int index = drop_down.value;
        textBox.text = drop_down.options[index].text; //texte actuel de la liste et affectation au texte du champ dfe texte
    }
}
