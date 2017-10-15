public enum TimeSignatureType
{
	None,
	Note,
	Connector,
}

public class TimeSignatureModel
{
    public TimeSignatureModel[] Segments;
    public NoteModel Note;
    public TimeSignatureType TypeTS;

    public TimeSignatureModel(TimeSignatureModel[] segment)
    {
		TypeTS = TimeSignatureType.None;
        Segments = segment;
        Note = null;
    }
    public TimeSignatureModel(NoteModel note)
    {
		TypeTS = TimeSignatureType.Note;
		Note = note;
        Segments = null;
    }
}
