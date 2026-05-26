namespace SimpleLibrary.REST.Models;

public class ReaderResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int ReaderCardNumber { get; set; }
}