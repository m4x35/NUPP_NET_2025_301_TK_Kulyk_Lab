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

    // метод
    public string GetInfo()
    {
        return $"Id: {Id} | Reader: {FullName} | Phone: {Phone} | Card: {ReaderCardNumber}";
    }
}
