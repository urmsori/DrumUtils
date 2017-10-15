using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSigTest : MonoBehaviour
{
    public ATimeSig sig;
    // Use this for initialization
    void Start()
    {
        sig.Set(new TimeSignatureModel(
            new TimeSignatureModel[4]{
            new TimeSignatureModel(new NoteModel(false, NoteLengthType.T16, true, true, new NoteLengthType[2]{NoteLengthType.None, NoteLengthType.T16})),
            new TimeSignatureModel(new NoteModel(false, NoteLengthType.T16, false, true, new NoteLengthType[2]{NoteLengthType.T16, NoteLengthType.T8})),
            new TimeSignatureModel(new NoteModel(false, NoteLengthType.T8, false, true, new NoteLengthType[2]{NoteLengthType.T16, NoteLengthType.None})),
            new TimeSignatureModel(new NoteModel(false, NoteLengthType.T32, false, true, null))
            }
        ));
        // sig.Set(new TimeSignatureModel(new NoteModel(false, NoteLengthType.T16, false, true, NoteConnectType.None)));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
