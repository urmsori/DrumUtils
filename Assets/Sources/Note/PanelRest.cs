using UnityEngine;
using UnityEngine.UI;

public class PanelRest : ANoteElement
{
    public GameObject[] images;
    public override void Set(NoteModel note)
    {
        for (int i = 0; i < images.Length; i++)
        {
            int len = (int)Mathf.Pow(2, i);
			images[i].SetActive(len == (int)note.LengthType);
            images[i].GetComponent<Image>().color = note.NoteColor;
        }
    }
}
