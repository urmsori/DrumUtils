using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ANoteAccent : ANoteElement {

    public override void Set(NoteModel note)
    {
        gameObject.SetActive(note.IsAccent);
        GetComponent<Image>().color = note.NoteColor;
    }
}
