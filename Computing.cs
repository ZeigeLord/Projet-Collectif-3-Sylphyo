using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InstrumentData : MonoBehaviour
{
    public string instrument;

    public InstrumentData()

    public InstrumentData( string instrumentChosen )
    {
        instrument = instrumentChosen;

        string dataSeparated = File.ReadAllText( Application.dataPath + "/FingeringCharts/" + instrument + ".txt" );

        string[] dataLineSeparated = dataSeparated.Split( new[] { lineSeparator }, System.StringSplitOptions.None);

        string[] dataTemp;

        for ( int j = 0; j < 128; j++)
        {
            dataTemp = dataLineSeparated[j].Split(new[] { columnSeparator }, System.StringSplitOptions.None);

            for (int i = 0; i < 9; i++)
                fingeringChart[j, i] = int.Parse( dataTemp[i] );            //conversion en int
        }
                   
    }

    public int[] GetFingeringChart()
    {
        fingeringChart;
    }

    private:
        string lineSeparator = "\n";
        string columnSeparator = "  ";

        int[128, 9] fingeringChart;
}
