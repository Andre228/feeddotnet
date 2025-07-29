namespace Feed.Dto
{
    public record NewsItemDto(string Title,
                                    string Description,
                                    string? ImageUrl = null);
}
