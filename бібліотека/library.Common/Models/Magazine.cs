namespace SimpleLibrary.Common.Models;

// клас Magazine наслідується від LibraryItem
public class Magazine : LibraryItem
{
    public int IssueNumber { get; set; }
    public string Publisher { get; set; }
    public string Topic { get; set; }

    // конструктор
    public Magazine(string title, int year, bool isAvailable, int issueNumber, string publisher, string topic)
        : base(title, year, isAvailable)
    {
        IssueNumber = issueNumber;
        Publisher = publisher;
        Topic = topic;
    }

    // метод
    public override string GetInfo()
    {
        return base.GetInfo() + $" | Issue: {IssueNumber} | Publisher: {Publisher} | Topic: {Topic}";
    }
}
