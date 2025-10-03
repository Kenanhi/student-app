namespace StudentLibrary.Tests;

public class StudentLibraryTests
{
    [Test]
    public void SetDone_ValidValue_UptadesIsDone()
    {
        var task = new ToDoItem("Go to sleep", false);
        task.IsDone=true;
        Assert.That(task.IsDone, Is.EqualTo(true));
    }

    [Test]
    public void SetTask_InvalidValues_ThrowsArgumentOutOfRangeException()
    {
        var task = new ToDoItem("Go to sleep", false);
        Assert.Throws<ArgumentException>(() => task.SetTitle(""));
    }
}