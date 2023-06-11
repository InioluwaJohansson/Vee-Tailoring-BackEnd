using System.Runtime.CompilerServices;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Implementations.Services;

public class CommentService : ICommentService
{
    ICommentRepo _repository;
    public CommentService(ICommentRepo repository)
    {
        _repository = repository;
    }
    public async Task<BaseResponse> Create(CreateCommentDto createCommentDto)
    {
        var comment = new Comment()
        {
            PostId = createCommentDto.PostId,
            CustomerId = createCommentDto.CustomerId,
            Comments = createCommentDto.Comment,
            IsDeleted = false
        };
        await _repository.Create(comment);
        return new BaseResponse()
        {
            Message = "U've Succesfully Commented On This Post",
            Status = true
        };
    }
    public async Task<BaseResponse> UpdateLikes(int id)
    {
        var comment = await _repository.GetById(id);
        if (comment != null)
        {
            comment.Likes += 1;
            await  _repository.Update(comment);
            return new BaseResponse()
            {
                Message = "Comment Liked",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Like Comment",
            Status = true
        };
    }
    public async Task<CommentResponseModel> GetById(int id)
    {
        var comment = await _repository.GetById(id);
        if (comment != null)
        {
            return new CommentResponseModel()
            {
                Data = GetDetails(comment),
                Message = "Comment Retrieved Successfully",
                Status = true
            };
        }
        return new CommentResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Comment Successfully",
            Status = true
        };
    }
    public GetCommentDto GetDetails(Comment comment)
    {
        return new GetCommentDto()
        {
            Id = comment.Id,
            PostId = comment.PostId,
            CustomerName = $"{comment.Customer.UserDetails.LastName} {comment.Customer.UserDetails.FirstName}",
            CustomerImageUrl = comment.Customer.UserDetails.ImageUrl,
            Comment = comment.Comments,
            Likes = comment.Likes,
            CommentDate = comment.CommentDate
        };
    }
    public async Task<BaseResponse> DeActivateComment(int id)
    {
        var comment = await _repository.GetById(id);
        comment.IsDeleted = true;
        await _repository.Update(comment);
        return new BaseResponse()
        {
            Message = "Comment Deleted Successfully",
            Status = true
        };
    }
}
