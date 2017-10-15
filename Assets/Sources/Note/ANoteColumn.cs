using UnityEngine;
using UnityEngine.UI;

public class ANoteColumn : ANoteElement
{
    public Image column;

    public override void Set(NoteModel note)
    {
        column.gameObject.SetActive(note.LengthType != NoteLengthType.T1);
        column.color = note.NoteColor;
    }
}
