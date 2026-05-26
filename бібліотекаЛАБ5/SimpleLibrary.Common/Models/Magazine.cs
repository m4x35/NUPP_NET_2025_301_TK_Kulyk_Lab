namespace SimpleLibrary.Common.Models;

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

    // статичний метод створення нового об'єкта з випадковими даними
    public static Magazine CreateNew()
    {
        Random random = new Random();

        return new Magazine(
            "Журнал " + random.Next(1, 10000),
            random.Next(2000, 2026),
            true,
            random.Next(1, 500),
            "Видавництво " + random.Next(1, 50),
            "Тема " + random.Next(1, 20)
        );
    }

    // метод
    public override string GetInfo()
    {
        return base.GetInfo() + $" | Issue: {IssueNumber} | Publisher: {Publisher} | Topic: {Topic}";
    }
}