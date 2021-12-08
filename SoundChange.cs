using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class SoundChange : MidiSend
{
    /// <summary>
    /// Subclass of MidiSend
    /// Sends a Patch Change with Controller BankSelectMSB to ProcessEvent in order to change the Sylhpyo's sound
    /// soundIndex goes from 0 to 33
    /// </summary>

    public int soundIndex;

    public void ChangeSound()
    {
        if (soundIndex <= 33)
        {
            MPTKEvent changeSound;
            changeSound = new MPTKEvent()
            {
                Command = MPTKCommand.PatchChange,
                Value = soundIndex,
            };
            SendEvent(changeSound);
        }

        else
            Debug.Log("Error : Only 34 sounds available");
        
    }
}
