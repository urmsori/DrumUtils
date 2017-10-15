using UnityEngine;
using UnityEngine.UI;

public class PanelTailLeftRight : ANoteElement
{
    public Image[] shortTails;
    public Image[] longTails;
    public bool isLeft;

    public override void Set(NoteModel note)
    {
        if (note.ConnectedNotes == null)
        {
            gameObject.SetActive(false);
            return;
        }
        if (note.ConnectedNotes[0] == NoteLengthType.None && note.ConnectedNotes[1] == NoteLengthType.None)
        {
            gameObject.SetActive(false);
            return;
        }
        gameObject.SetActive(true);

        NoteLengthType leftType = note.ConnectedNotes[0];
        NoteLengthType rightType = note.ConnectedNotes[1];

        if (leftType < NoteLengthType.T8 && isLeft)
        {
            gameObject.SetActive(false);
            return;
        }
        if (rightType < NoteLengthType.T8 && !isLeft)
        {
            gameObject.SetActive(false);
            return;
        }

        if (leftType == rightType && leftType == note.LengthType)
        {
            Work(note, note.LengthType, note.LengthType);
            return;
        }

        if (isLeft)
        {
            if (leftType < note.LengthType)
            {
                if (rightType > leftType)
                {
                    Work(note, leftType, leftType);
                    return;
                }
                Work(note, note.LengthType, leftType);
                return;
            }
            Work(note, note.LengthType, note.LengthType);
            return;
        }
        else
        {
            if (rightType < note.LengthType)
            {
                if (leftType >= rightType)
                {
                    Work(note, rightType, rightType);
                    return;
                }
                Work(note, note.LengthType, rightType);
                return;
            }
            Work(note, note.LengthType, note.LengthType);
            return;
        }
    }

    private void Work(NoteModel note, NoteLengthType totalType, NoteLengthType longType)
    {
        for (int i = 0; i < shortTails.Length; i++)
        {
            longTails[i].gameObject.SetActive(false);
            shortTails[i].gameObject.SetActive(false);

            bool isEnable = (int)totalType >= (int)Mathf.Pow(2, i + 3);
            bool isLong = (int)longType >= (int)Mathf.Pow(2, i + 3);

            if (isEnable && isLong)
            {
                longTails[i].gameObject.SetActive(true);
                longTails[i].color = note.NoteColor;
            }
            else if (isEnable)
            {
                shortTails[i].gameObject.SetActive(true);
                shortTails[i].color = note.NoteColor;
            }
        }
    }
}
