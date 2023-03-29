using System.Runtime.CompilerServices;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interface.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Implementations.Services;

public class CommentService : ICommentService
{
    ICommentRepo _repository;
    ICustomerRepo _customerRepo;
    public CommentService(ICommentRepo repository, ICustomerRepo customerRepo)
    {
        _repository = repository;
        _customerRepo = customerRepo;
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
        var customer = await _customerRepo.GetById(comment.CustomerId);
        if (comment != null)
        {
            return new CommentResponseModel()
            {
                Data = GetDetails(comment, customer),
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
    public GetCommentDto GetDetails(Comment comment, Customer customer)
    {
        return new GetCommentDto()
        {
            Id = comment.Id,
            PostId = comment.PostId,
            CustomerName = $"{customer.UserDetails.LastName} {customer.UserDetails.FirstName}",
            CustomerImageUrl = customer.UserDetails.ImageUrl,
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
