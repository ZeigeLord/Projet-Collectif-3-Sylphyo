using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;


public class InstrumentData : MonoBehaviour
{
    public string instrument;
    public int[] fingeringCurrent = new int[9];
    private int[,] fingeringChart = new int[128, 9];

    public InstrumentData() { }

    public InstrumentData(string instrumentChosen)
    {
        instrument = instrumentChosen;

        string dataSeparated = File.ReadAllText(Application.dataPath + "/FingeringCharts/" + instrument + ".txt");

        string[] dataLineSeparated = dataSeparated.Split(new[] { lineSeparator }, System.StringSplitOptions.None);

        string[] dataTemp;

        for (int j = 0; j < 128; j++)
        {
            dataTemp = dataLineSeparated[j].Split(new[] { columnSeparator }, System.StringSplitOptions.None);

            for (int i = 0; i < 9; i++)
                fingeringChart[j, i] = int.Parse(dataTemp[i]);            //conversion en int
        }

    }

    /*public int[,] GetFingeringChart()
    {
        return fingeringChart;
    }*/

    public void AssignFingeringChart(string instrumentChosen)
    {
        instrument = instrumentChosen;

        string dataSeparated = File.ReadAllText(Application.dataPath + "/FingeringCharts/" + instrument + ".txt");

        string[] dataLineSeparated = dataSeparated.Split(new[] { lineSeparator }, System.StringSplitOptions.None);

        string[] dataTemp;

        for (int j = 0; j < 128; j++)
        {
            dataTemp = dataLineSeparated[j].Split(new[] { columnSeparator }, System.StringSplitOptions.None);

            for (int i = 0; i < 9; i++)
            {
                fingeringChart[j, i] = int.Parse(dataTemp[i]);
            }
           //conversion en int

        }
    }
    
    public int[] MidiToFingering(int midiValue)
    {
        for (int i = 0; i < 9; i++)
        {
            fingeringCurrent[i] = fingeringChart[midiValue, i];
        }

        return fingeringCurrent;
    }

    private
        string lineSeparator = "\n";
        string columnSeparator = "\t";
}