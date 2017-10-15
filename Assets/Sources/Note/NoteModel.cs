using System;
using UnityEngine;

public enum NoteLengthType
{
    None = 0,
    T1 = 1,
    T2 = 2,
    T4 = 4,
    T8 = 8,
    T16 = 16,
    T32 = 32,
}

[Serializable]
public class NoteModel
{
    public bool IsRest;
    public bool IsDot;
    public bool IsAccent;
    public NoteLengthType LengthType;
    public NoteLengthType[] ConnectedNotes;
    public Color NoteColor = Color.black;

    public double Length
    {
        get
        {
            double len = 1 / (int)LengthType;
            return IsDot ? len * 1.5 : len;
        }
    }

    public NoteModel(bool isRest, NoteLengthType lengthType, bool isDot, bool isAccent, NoteLengthType[] connectedNotes)
    {
        Init(isRest, lengthType, isDot, isAccent, connectedNotes, Color.black);
    }
    public NoteModel(bool isRest, NoteLengthType lengthType, bool isDot, bool isAccent, NoteLengthType[] connectedNotes, Color color)
    {
        Init(isRest, lengthType, isDot, isAccent, connectedNotes, color);
    }
    private void Init(bool isRest, NoteLengthType lengthType, bool isDot, bool isAccent, NoteLengthType[] connectedNotes, Color color)
    {
        IsRest = isRest;
        LengthType = lengthType;
        IsDot = isDot;
        IsAccent = isAccent;
        ConnectedNotes = connectedNotes;
        NoteColor = color;
    }
}
