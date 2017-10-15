using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATimeSig : ATimeSigElement
{
    public Transform inner;
    public GameObject timeSigPrefab;
    public GameObject notePrefab;

    public override void Set(TimeSignatureModel ts)
    {
        List<GameObject> forDestroy = new List<GameObject>();
        for (int i = 0; i < inner.childCount; i++)
        {
            forDestroy.Add(inner.GetChild(i).gameObject);
        }
        foreach (var item in forDestroy)
        {
            Destroy(item);
        }

        switch (ts.TypeTS)
        {
            case TimeSignatureType.None:
                CreateChildTS(ts.Segments);
                break;
            case TimeSignatureType.Connector:
                break;
            case TimeSignatureType.Note:
                CreateNote(ts.Note);
                break;
        }
    }

    private void CreateNote(NoteModel note)
    {
        StartCoroutine(CreateNoteWorker(note));
    }

    private IEnumerator CreateNoteWorker(NoteModel note)
    {
        var target = Instantiate(notePrefab);
        target.SetActive(true);
        target.transform.SetParent(inner);

        yield return 0;

        target.GetComponent<ANote>().Set(note);
    }

    private void CreateChildTS(TimeSignatureModel[] segments)
    {
        if (segments == null)
            return;

        List<KeyValuePair<ATimeSig, TimeSignatureModel>> tslist = new List<KeyValuePair<ATimeSig, TimeSignatureModel>>();
        foreach (var seg in segments)
        {
            var target = Instantiate(timeSigPrefab);
            target.SetActive(true);
            target.transform.SetParent(inner);
            tslist.Add(new KeyValuePair<ATimeSig, TimeSignatureModel>(target.GetComponent<ATimeSig>(), seg));
        }

        inner.GetComponent<HorizontalLayoutGroup>().enabled = false;
        inner.GetComponent<HorizontalLayoutGroup>().enabled = true;

        foreach (var item in tslist)
        {
            item.Key.Set(item.Value);
        }
    }
}
