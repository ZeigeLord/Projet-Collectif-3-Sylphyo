using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InstrumentData : MonoBehaviour
{
    public string instrument;
    private string dataSeparator = "%SEPARATOR%";
    private int[128,9] fingeringChart;

    public InstrumentData( string instrumentChosen )
    {
        instrument = instrumentChosen;

        string dataSeparated = File.ReadAllText( Application.dataPath + "/FingeringCharts/" + instrument + ".txt" );

        string[] data = dataSeparated.Split(new[] { dataSeparator }, System.StringSplitOptions.None);

        for ( int i = 0; i < 128; i++ )
        {
            for( int j = 0; j < 8; j++ )
            {
                fingeringChart[j,i] = data[9*i+j];
            }
        }
    }

    public int[] GetFingeringChart()
    {
        fingeringChart;
    }
}
}
