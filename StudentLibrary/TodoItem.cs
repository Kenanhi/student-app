
public class ToDoItem
{
    public string Title { get; private set; }
    public bool IsDone { get; set; }
    public ToDoItem(string title, bool isdone)
    {
        SetTitle(title);
        IsDone = isdone;
    }
    public void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("You should set Title", nameof(title));
        }
        Title = title;
    }
}