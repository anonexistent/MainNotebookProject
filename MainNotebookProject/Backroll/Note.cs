namespace MainNotebookProject.Backroll
{
    public class Note
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public System.DateTime Date { get; set; }
        public bool IsText { get; set; }

        public Note()
        {

        }

        public Note(string a, object b, System.DateTime c, bool d)
        {
            Name = a;
            Value = b;
            Date = c;
            IsText = d;
        }

        public string[] GetNote() => new string[] { Name, Value.ToString(), Date.ToString(), };

        public override string ToString() => Name + "\t" + Date + "\t" + new string(IsText ? "text" : "paint");
    }
}
