using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ANoteDot : ANoteElement
{
    public override void Set(NoteModel note)
    {
        gameObject.SetActive(note.IsDot);
        GetComponent<Image>().color = note.NoteColor;
    }
}
