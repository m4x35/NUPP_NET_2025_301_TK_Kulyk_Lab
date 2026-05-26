namespace SimpleLibrary.REST.Models;

public class ReaderRequest
{
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int ReaderCardNumber { get; set; }
}