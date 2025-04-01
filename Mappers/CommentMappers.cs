using WebApplication6.Dtos.Comment;
using WebApplication6.Models;

public static class CommentMappers
{
    public static CommentDto ToCommentDto(this Comment commentModel)
    {
        return new CommentDto
        {
            Id = commentModel.Id,
            Title = commentModel.Title,
            Content = commentModel.Content,
            CreatedOn = commentModel.CreatedOn,
            CreatedBy = commentModel.AppUser.UserName,
            StockId = commentModel.StockId,
        };
    }

    public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto, int stockId)
    {
        return new Comment
        {
            Title = commentDto.Title,
            Content = commentDto.Content,
            StockId = stockId // Ensure stockId is set
        };
    }

    // ✅ New method for CreateCommentDto
    public static Comment ToComment(this CreateCommentDto commentDto, int stockId)
    {
        return new Comment
        {
            Title = commentDto.Title,
            Content = commentDto.Content,
            StockId = stockId,
            CreatedOn = DateTime.UtcNow
        };
    }
}
