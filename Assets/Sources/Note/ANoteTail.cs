using UnityEngine;

public class ANoteTail : ANoteElement
{
    public PanelTailLeftRight left;
    public PanelTailLeftRight right;
    public PanelTailNone none;

    public override void Set(NoteModel note)
    {
        left.Set(note);
        right.Set(note);
        none.Set(note);
    }
}
