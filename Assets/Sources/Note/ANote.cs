using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANote : ANoteElement
{
    public NoteModel noteValue;
    public PanelANote realNote;
    public PanelANote restNote;

    GameObject noteObject = null;
    bool mIsRest;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        Set(noteValue);
    }

    public override void Set(NoteModel note)
    {
        if (mIsRest != note.IsRest && noteObject != null)
        {
            Destroy(noteObject);
            noteObject = null;
        }

        GameObject target;
        if (noteObject != null)
        {
            target = noteObject;
        }
        else
        {
            if (note.IsRest)
                target = Instantiate(restNote.gameObject);
            else
                target = Instantiate(realNote.gameObject);

            target.transform.SetParent(transform);
        }
        target.transform.localPosition = new Vector2(0, 0);

        var thisSize = GetComponent<RectTransform>().sizeDelta;
        // print(thisSize);
        var normalThis = thisSize.normalized;
        var targetSize = target.GetComponent<RectTransform>().sizeDelta;
        var normalTarget = targetSize.normalized;

        float rate = 1;
        if (normalTarget.x > normalThis.x)
        {
            rate = thisSize.x / targetSize.x;
        }
        else if (normalTarget.y > normalThis.y)
        {
            rate = thisSize.y / targetSize.y;
        }
        target.transform.localScale = new Vector3(rate, rate, rate);

        target.GetComponent<PanelANote>().Set(note);

        mIsRest = note.IsRest;
        noteValue = note;
        noteObject = target;
    }
}
