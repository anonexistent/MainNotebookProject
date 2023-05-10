namespace MainNotebookProject.Backroll
{
    public class Сensurer
    {
        NoteBook value { get; set; }

        public Сensurer(NoteBook v) => value = v;
        public void ContentSet(Note a) => value.notes.Add(a);
        public System.Collections.Generic.List<Note>  ContentGet() => value.notes;
    }
}
