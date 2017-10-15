using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelANote : ANoteElement
{
    public ANoteElement[] elements;
    
    NoteModel mNote;
    public NoteModel Note
    {
        get
        {
            return mNote;
        }
        set
        {
            mNote = value;
            Set(mNote);
        }
    }

    public override void Set(NoteModel note)
    {
        mNote = note;

        foreach (var elem in elements)
        {
            elem.Set(mNote);
        }
    }
}
