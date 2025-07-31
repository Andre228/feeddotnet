
using System.ComponentModel.DataAnnotations;

namespace Feed.Dto
{
    public record NewsItemPostDto(
                              [Required(ErrorMessage = "Title is required")]
                              [StringLength(100, MinimumLength = 3)]
                              string Title,

                              [StringLength(1000, ErrorMessage = "Description can't be longer than 1000 characters")]
                              string? Description,

                              string? ImageUrl) : INewsItemDto;

    public record NewsItemPatchDto(
                              Guid Id,
                              [StringLength(100, MinimumLength = 3)] 
                              string? Title,

                              [StringLength(1000, ErrorMessage = "Description can't be longer than 1000 characters")]
                              string? Description,

                              string? ImageUrl) : INewsItemDto;

    public record NewsItemPutDto(
                              Guid Id,

                              [Required(ErrorMessage = "Title is required")]
                              [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters")]
                              string Title,

                              [Required(ErrorMessage = "Description is required")]
                              [StringLength(1000, ErrorMessage = "Description can't be longer than 1000 characters")]
                              string Description,

                              [Required(ErrorMessage = "ImageUrl is required")]
                              string ImageUrl) : INewsItemDto;
}
