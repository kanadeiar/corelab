namespace SportStore.Models.WebModels;

public class PagingInfoWebModel
{
    public int TotalItems { get; set; }
    public int ItemsPerPage { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
}