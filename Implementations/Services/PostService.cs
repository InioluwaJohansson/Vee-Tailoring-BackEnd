using Vee_Tailoring.Entities;
using Vee_Tailoring.Implementations.Respositories;
using Vee_Tailoring.Interface.Services;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Models.DTOs;
namespace Vee_Tailoring.Implementations.Services;

public class PostService : IPostService
{
    IPostRepo _repository;
    ICommentRepo _commentrepository;
    ICustomerRepo _customerrepository;
    IStaffRepo _staffrepository;
    ICategoryRepo _categoryrepository;
    public PostService(IPostRepo repository, ICommentRepo commentrepository, ICustomerRepo customerrepository, IStaffRepo staffrepository, ICategoryRepo categoryrepository)
    {
        _repository = repository;
        _commentrepository = commentrepository;
        _customerrepository = customerrepository;
        _staffrepository = staffrepository;
        _categoryrepository = categoryrepository;
    }
    public async Task<BaseResponse> Create(CreatePostDto createPostDto)
    {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Post\\");
        if (!System.IO.Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        var imagePath = "";
        if (createPostDto.PostImage != null)
        {
            var fileName = Path.GetFileNameWithoutExtension(createPostDto.PostImage.FileName);
            var filePath = Path.Combine(folderPath, createPostDto.PostImage.FileName);
            var extension = Path.GetExtension(createPostDto.PostImage.FileName);
            if (!System.IO.Directory.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await createPostDto.PostImage.CopyToAsync(stream);
                }
                imagePath = fileName;
            }
        }
        var post = new Post()
        {
            PostDescription = createPostDto.PostDescription,
            PostImage = imagePath,
            CategoryId = createPostDto.CategoryId,
            StaffId = createPostDto.StaffId,
            PostTitle = createPostDto.PostTitle,
            PublishDate = DateTime.Now,
            IsDeleted = false
        };
        await _repository.Create(post);
        return new BaseResponse()
        {
            Message = "Post Created Successfully",
            Status = true
        };
    }
    public async Task<BaseResponse> Update(int id, UpdatePostDto updatePostDto)
    {
        var post = await _repository.GetById(id);
        var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Post\\");
        if (!System.IO.Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        var imagePath = "";
        if (updatePostDto.PostImage != null)
        {
            var fileName = Path.GetFileNameWithoutExtension(updatePostDto.PostImage.FileName);
            var filePath = Path.Combine(folderPath, updatePostDto.PostImage.FileName);
            var extension = Path.GetExtension(updatePostDto.PostImage.FileName);
            if (!System.IO.Directory.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await updatePostDto.PostImage.CopyToAsync(stream);
                }
                imagePath = fileName;
            }
        }
        if (post != null)
        {
            post.CategoryId = updatePostDto.CategoryId ;
            post.PostTitle = updatePostDto.PostTitle ?? post.PostTitle;
            post.PostImage = imagePath ?? post.PostImage;
            post.PostDescription = updatePostDto.PostDescription ?? post.PostDescription;
            post.ReadTime = updatePostDto.ReadTime;
            await _repository.Update(post);
            return new BaseResponse()
            {
                Message = "Post Updated Successfully",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Update Post Successfully",
            Status = false
        };
    }
    public async Task<BaseResponse> UpdateLikes(int id)
    {
        var post = await _repository.GetById(id);
        if (post != null)
        {
            post.Likes += 1;
            await _repository.Update(post);
            return new BaseResponse()
            {
                Message = "Post Updated Successfully",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Update Post Successfully",
            Status = false
        };
    }
    public async Task<PostResponseModel> GetById(int id)
    {
        var post = await _repository.GetById(id);
        var comments = await _commentrepository.GetByPostId(post.Id);
        var category = await _categoryrepository.GetById(post.CategoryId);
        List<GetCommentDto> CommentList = new List<GetCommentDto>();
        foreach (var comment in comments)
        {
            var customer = await _customerrepository.GetById(comment.CustomerId); 
            CommentList.Add(GetCommentDetails(comment, customer));
        }
        var staff = await _staffrepository.GetById(post.StaffId);
        if(post != null)
        {
            return new PostResponseModel()
            {
                Data = GetDetails(post, category, CommentList, staff),
                Message = "Post Retrieved Successfully",
                Status = true
            };
        }
        return new PostResponseModel()
        {
            Data = GetDetails(post, category, CommentList, staff),
            Message = "Unable To Retrieve Post Successfully",
            Status = false
        };
    }
    public async Task<PostsResponseModel> GetByPostTitle(string postTitle)
    {
        var posts = await _repository.GetByTitle(postTitle);
        if (posts != null)
        {
            List<GetPostDto> PostList = new List<GetPostDto>();
            foreach (var post in posts)
            {
                var comments = await _commentrepository.GetByPostId(post.Id);
                var category = await _categoryrepository.GetById(post.CategoryId);
                List<GetCommentDto> CommentList = new List<GetCommentDto>();
                foreach (var comment in comments)
                {
                    var customer = await _customerrepository.GetById(comment.CustomerId);
                    CommentList.Add(GetCommentDetails(comment, customer));
                }
                var staff = await _staffrepository.GetById(post.StaffId);
                PostList.Add(GetDetails(post, category, CommentList, staff));
            }
            return new PostsResponseModel()
            {
                Data = PostList,
                Message = "Post Retrieved Successfully",
                Status = true
            };
        }
        return new PostsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Post Successfully",
            Status = false
        };
    }
    public async Task<PostsResponseModel> GetAllPosts()
    {
        var posts = await _repository.GetAll();
        if (posts != null)
        {
            List<GetPostDto> PostList = new List<GetPostDto>();
            foreach (var post in posts)
            {
                var comments = await _commentrepository.GetByPostId(post.Id);
                var category = await _categoryrepository.GetById(post.CategoryId);
                List<GetCommentDto> CommentList = new List<GetCommentDto>();
                foreach (var comment in comments)
                {
                    var customer = await _customerrepository.GetById(comment.CustomerId);
                    CommentList.Add(GetCommentDetails(comment, customer));
                }
                var staff = await _staffrepository.GetById(post.StaffId);
                PostList.Add(GetDetails(post, category, CommentList, staff));
             }
            return new PostsResponseModel()
            {
                Data = PostList,
                Message = "Posts List Retrieved Successfully",
                Status = true
            };
        }
        return new PostsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Posts List Successfully",
            Status = false
        };
    }
    public async Task<PostsResponseModel> GetByCategoryId(int categoryId)
    {
        var posts = await _repository.GetByCategoryId(categoryId);
        if (posts != null)
        {
            List<GetPostDto> PostList = new List<GetPostDto>();
            foreach (var post in posts)
            {
                var comments = await _commentrepository.GetByPostId(post.Id);
                var category = await _categoryrepository.GetById(post.CategoryId);
                List<GetCommentDto> CommentList = new List<GetCommentDto>();
                foreach (var comment in comments)
                {
                    var customer = await _customerrepository.GetById(comment.CustomerId);
                    CommentList.Add(GetCommentDetails(comment, customer));
                }
                var staff = await _staffrepository.GetById(post.StaffId);
                PostList.Add(GetDetails(post, category, CommentList, staff));
            }
            return new PostsResponseModel()
            {
                Data = PostList,
                Message = "Posts List Retrieved Successfully",
                Status = true
            };
        }
        return new PostsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Posts List Successfully",
            Status = false
        };
    }
    public GetCommentDto GetCommentDetails(Comment comment, Customer customer)
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
    public GetPostDto GetDetails(Post post, Category category, List<GetCommentDto> comments, Staff staff)
    {
        return new GetPostDto()
        {
            Id = post.Id,
            GetCategoryDto = new GetCategoryDto()
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                CategoryDescription =  category.CategoryDescription,
            },
            PostTitle = post.PostTitle,
            PostImage = post.PostImage,
            PostDescription = post.PostDescription,
            PublishDate = post.PublishDate,
            ReadTime = post.ReadTime,
            Likes = post.Likes,
            StaffName = $"{staff.UserDetails.LastName} {staff.UserDetails.FirstName}",
            StaffImage = staff.UserDetails.ImageUrl,
            GetCommentDtos = comments,
        };
    }
    public async Task<DashBoardResponse> PostsDashboard()
    {
        int total = (await _repository.GetAll()).Count;
        int active = (await _repository.GetByExpression(x => x.IsDeleted == false)).Count;
        int inActive = (await _repository.GetByExpression(x => x.IsDeleted == true)).Count;
        if (total != 0)
        {
            return new DashBoardResponse
            {
                Total = total,
                Active = active,
                InActive = inActive,
                Status = true,
            };
        }
        return new DashBoardResponse
        {
            Message = "No Posts Yet!",
            Status = false,
        };
    }
    public async Task<BaseResponse> DeActivatePost(int id)
    {
        var post = await _repository.GetById(id);
        if (post != null)
        {
            post.IsDeleted = true;
            await _repository.Update(post);
            return new BaseResponse()
            {
                Message = "Post Deleted Successfully",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Delete Post Successfully",
            Status = false
        };
    }
}
