using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class Computing : MonoBehaviour
{
    /// <summary>
    /// Processes all computing and analyzing tasks
    /// <summary>


    ////////////////MEMBERS////////////////
    // FOR ANALYSIS //
    private float userScore, maxPotentialScore;
    // STATIC //
    private int nuanceTolerance, tangageTolerance, roulisTolerance, sliderUpTolerance, sliderMidTolerance, sliderLowTolerance; 

    // sliderUpTolerance = MPTKCommande.PitchWheelChange = [0, 16383], valeur centrale 8192 : pas entre 0 et 127

    ////////////////METHODS////////////////

    public Computing(int nuanceWind, int tangageWind, int roulisWind, int sliderUpWind, int sliderMidWind, int sliderLowWind)
    {
        userScore = 0f;
        maxPotentialScore = 0f;

        //timeBuffer = new int[timeBufferSizeInFrames];
        nuanceTolerance     = nuanceWind;
        tangageTolerance    = tangageWind;
        roulisTolerance     = roulisWind;
        sliderUpTolerance   = sliderUpWind;
        sliderMidTolerance  = sliderMidWind;
        sliderLowTolerance  = sliderLowWind;
    }

    public bool AccuracyAnalysis(EventsBufferType midiEventsCurrent, EventsBufferType midiEventsRef)
    {
        maxPotentialScore += 1f;

        bool pitchTest      = TestingNoteOnAccuracy(midiEventsCurrent.pitchEvents,        midiEventsRef.pitchEvents);

        bool nuanceTest     = TestingAccuracy(midiEventsCurrent.nuanceEvents,       midiEventsRef.nuanceEvents,     nuanceTolerance);
        bool tangageTest    = TestingAccuracy(midiEventsCurrent.tangageEvents,      midiEventsRef.tangageEvents,    tangageTolerance);
        bool roulisTest     = TestingAccuracy(midiEventsCurrent.roulisEvents,       midiEventsRef.roulisEvents,     roulisTolerance);
        bool sliderUpTest   = TestingAccuracy(midiEventsCurrent.sliderUpEvents,     midiEventsRef.sliderUpEvents,   sliderUpTolerance);
        bool sliderMidTest  = TestingAccuracy(midiEventsCurrent.sliderMidEvents,    midiEventsRef.sliderMidEvents,  sliderMidTolerance);
        bool sliderLowTest  = TestingAccuracy(midiEventsCurrent.sliderLowEvents,    midiEventsRef.sliderLowEvents,  sliderLowTolerance);

        midiEventsCurrent.ClearBuffers();
        midiEventsRef.ClearBuffers();

        if (pitchTest == true && nuanceTest == true && tangageTest == true && roulisTest == true && sliderUpTest == true && sliderMidTest == true && sliderLowTest == true)
        {
            userScore += 1f;
            return true;
        }
        else
            return false;
    }

    private bool TestingNoteOnAccuracy(int[] midiEventCurrent, int[] midiEventRef)
    {
        int correctFrames = 0;
        for ( int i = 0; i < midiEventCurrent.Length, i++)
        {
            if (midiEventCurrent[i] == midiEventRef[i])
                correctFrames +=1;
        }

        if (correctFrames >= 4)
            return true;
        else
            return false;
    }


    private bool TestingAccuracy(int[] midiEventCurrent, int[] midiEventRef, int tolerance)
    {
        float midiEventCurrentMean = 0;
        float midiEventRefMean = 0;

        for ( int i = 0 ; i < midiEventCurrent.Length ; i++)
        {
            midiEventCurrentMean += (float)midiEventCurrent[i];
            midiEventRefMean += (float)midiEventRef[i];
        }

        int midiEventCurrentMeanInt, midiEventRefMeanInt;

        midiEventCurrentMeanInt = (int)Math.Round( midiEventCurrentMean /midiEventCurrent.Length );
        midiEventRefMeanInt = (int)Math.Round( midiEventRefMean /midiEventRef.Length );

        if ( Math.Abs( midiEventRefMeanInt - midiEventCurrentMeanInt ) <= tolerance)
        {
            return true;
        }
        else
            return false;
    }
    

    public float GetScore()
    {
        return ( userScore / maxPotentialScore ) * 100f;
    }

    /*
    public bool HighScore( float score, float score_max )
    {
        if ( score > score_max )
            return true;
        else
            return false;
    }*/
   

    public void End()
    {
        userScore = 0f;
        maxPotentialScore = 0f;
    }
}