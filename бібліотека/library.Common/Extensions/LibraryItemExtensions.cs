using SimpleLibrary.Common.Models;

namespace SimpleLibrary.Common.Extensions;

public static class LibraryItemExtensions
{
    // метод розширення
    public static string AvailabilityText(this LibraryItem item)
    {
        return item.IsAvailable ? "Status: available" : "Status: not available";
    }
}
