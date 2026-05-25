namespace SimpleLibrary.Common.Models;

public class Reader : IEntity
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public int ReaderCardNumber { get; set; }

    // конструктор
    public Reader(string fullName, string phone, int readerCardNumber)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Phone = phone;
        ReaderCardNumber = readerCardNumber;
    }

    // статичний метод створення нового об'єкта з випадковими даними
    public static Reader CreateNew()
    {
        Random random = new Random();

        return new Reader(
            "Читач " + random.Next(1, 10000),
            "+380" + random.Next(100000000, 999999999),
            random.Next(1000, 9999)
        );
    }

    // метод
    public string GetInfo()
    {
        return $"Id: {Id} | Reader: {FullName} | Phone: {Phone} | Card: {ReaderCardNumber}";
    }
}