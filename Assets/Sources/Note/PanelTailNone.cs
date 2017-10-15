using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class PanelTailNone : ANoteElement
{
    public GameObject prefab;

    private void Start()
    {
        prefab.SetActive(false);
    }

    public override void Set(NoteModel note)
    {
        if (note.ConnectedNotes != null)
        {
            if (note.ConnectedNotes[0] != NoteLengthType.None || note.ConnectedNotes[1] != NoteLengthType.None)
            {
                gameObject.SetActive(false);
                return;
            }
        }
        gameObject.SetActive(true);

        List<GameObject> forDestroy = new List<GameObject>();
        for (int i = 1; i < transform.childCount; i++)
        {
            forDestroy.Add(transform.GetChild(i).gameObject);
        }
        foreach (var item in forDestroy)
        {
            Destroy(item);
        }

        int tailNum = (int)Mathf.Log((int)note.LengthType, 2f) - 2;
        if (tailNum < 0)
            tailNum = 0;

        for (int i = 0; i < tailNum; i++)
        {
            var tail = Instantiate(prefab);
            tail.SetActive(true);
            tail.transform.SetParent(transform);
            tail.transform.localScale = new Vector3(1, 1, 1);
            tail.GetComponentInChildren<Image>().color = note.NoteColor;
        }

        GetComponent<VerticalLayoutGroup>().enabled = false;
        GetComponent<VerticalLayoutGroup>().enabled = true;
    }
}
