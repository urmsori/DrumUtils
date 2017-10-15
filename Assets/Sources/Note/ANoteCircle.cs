using UnityEngine;
using UnityEngine.UI;

public class ANoteCircle : ANoteElement
{
    public Image circle2th;
    public Image circle4th;

    public override void Set(NoteModel note)
    {
        bool is2th = note.LengthType <= NoteLengthType.T2;
        circle2th.gameObject.SetActive(is2th);
        circle4th.gameObject.SetActive(!is2th);

        circle2th.color = note.NoteColor;
        circle4th.color = note.NoteColor;
    }
}
