using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicExercice : MonoBehaviour
{
    //Liste Exercices 
    public Exercice myExercices;
    public UserData myUserData;
    public Image exo1Cat1_1, exo2Cat1_1, exo3Cat1_1, exo1Cat1_2, exo2Cat1_2, exo3Cat1_2, exo1Cat1_3, exo2Cat1_3, exo3Cat1_3;
    public Image cadenasFerme;
    public Sprite cadenasOuvert;
    List<Image> mesImages = new List<Image>();

    void Start()
    {
        //Add exercices in a list
        mesImages.Add(exo1Cat1_1);
        mesImages.Add(exo2Cat1_1);
        mesImages.Add(exo3Cat1_1);
        mesImages.Add(exo1Cat1_2);
        mesImages.Add(exo2Cat1_2);
        mesImages.Add(exo3Cat1_2);
        mesImages.Add(exo1Cat1_3);
        mesImages.Add(exo2Cat1_3);
        mesImages.Add(exo3Cat1_3);
    }

    // Update is called once per frame
    void Update()
    {
        SetChangeColor();
        ChangeImage();
    }
    // ----- Change state Exercices ------

    public void SetChangeColor()
    {
        if (myExercices.GetIsFinished())
        {
            foreach (Image item in mesImages)
            {
                item.GetComponent<Image>().color = new Color32(124, 252, 0, 1);
            }
        }
        else
        {
            foreach (Image item in mesImages)
            {
                item.GetComponent<Image>().color = new Color32(255, 0, 0, 1);
            }
        }
    }
    int[] numExo;
    public void ChangeImage()
    {
        //Catégorie 1, 1-Les Gammes
        for(int i = 1; i < 4; i++)
        {
            numExo[i] = myExercices.exerciceId++;
            if(myUserData.exercicesFinished[numExo[i]])
                    cadenasFerme.sprite = cadenasOuvert;
        }
        //Catégorie 1, 2-Passage d'octaves
        for (int i = 4; i < 7; i++)
        {
            numExo[i] = myExercices.exerciceId++;
            if (myUserData.exercicesFinished[numExo[i]])
                cadenasFerme.sprite = cadenasOuvert;
        }
        //Catégorie 1, 3-Les intervalles
        for (int i = 7; i < 11; i++)
        {
            numExo[i] = myExercices.exerciceId++;
            if (myUserData.exercicesFinished[numExo[i]])
                cadenasFerme.sprite = cadenasOuvert;
        }
        //Catégorie 2, 1-Shake Vibrato
        for (int i = 11; i < 14; i++)
        {
            numExo[i] = myExercices.exerciceId++;
            if (myUserData.exercicesFinished[numExo[i]])
                cadenasFerme.sprite = cadenasOuvert;
        }
        //Catégorie 2, 2-Les nuances
        for (int i = 14; i < 17; i++)
        {
            numExo[i] = myExercices.exerciceId++;
            if (myUserData.exercicesFinished[numExo[i]])
                cadenasFerme.sprite = cadenasOuvert;
        }
        //Catégorie 3, 1-Slider
        for (int i = 17; i < 20; i++)
        {
            numExo[i] = myExercices.exerciceId++;
            if (myUserData.exercicesFinished[numExo[i]])
                cadenasFerme.sprite = cadenasOuvert;
        }
        //Catégorie 3, 2-Roulis
        for (int i = 20; i < 23; i++)
        {
            numExo[i] = myExercices.exerciceId++;
            if (myUserData.exercicesFinished[numExo[i]])
                cadenasFerme.sprite = cadenasOuvert;
        }
        //Catégorie 3, 3-Tangage
        for (int i = 23; i < 26; i++)
        {
            numExo[i] = myExercices.exerciceId++;
            if (myUserData.exercicesFinished[numExo[i]])
                cadenasFerme.sprite = cadenasOuvert;
        }
        //Catégorie 4, 1-Slider
        for (int i = 26; i < 29; i++)
        {
            numExo[i] = myExercices.exerciceId++;
            if (myUserData.exercicesFinished[numExo[i]])
                cadenasFerme.sprite = cadenasOuvert;
        }
        //Catégorie 4, 2-Roulis
        for (int i = 29; i < 32; i++)
        {
            numExo[i] = myExercices.exerciceId++;
            if (myUserData.exercicesFinished[numExo[i]])
                cadenasFerme.sprite = cadenasOuvert;
        }
        //Catégorie 4, 3-Les nuances
        for (int i = 32; i < 35; i++)
        {
            numExo[i] = myExercices.exerciceId++;
            if (myUserData.exercicesFinished[numExo[i]])
                cadenasFerme.sprite = cadenasOuvert;
        }
    }
}
