namespace SimpleLibrary.Infrastructure.Models;

public class ReaderModel
{
    public int Id { get; set; }

    public Guid OriginalId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public int ReaderCardNumber { get; set; }

    public ICollection<LoanModel> Loans { get; set; } = new List<LoanModel>();
}