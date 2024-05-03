using MediatR;
using Microsoft.AspNetCore.Hosting;
using News.Application.Abstractions;
using News.Application.UseCases.NewsCases.Commands;
using News.Domain.Entities;


// private readonly IRumassaDbContext _context;
// private readonly IWebHostEnvironment _webHostEnvironment;
//
// public CreateNewsCommandHandler(IRumassaDbContext context, IWebHostEnvironment webHostEnvironment)
// {
//     _context = context;
//     _webHostEnvironment = webHostEnvironment;
// }

namespace News.Application.UseCases.NewsCases.Handlers.CommandHandlers
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, ResponseModel>
    {
        private readonly INewsDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateNewsCommandHandler(INewsDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            
            string fileName = "";
            string filePath = "";

            if (request.AddAttachment is not null)
            {
                var file = request.AddAttachment;


                try
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "NewsHUB", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                }
                catch (Exception ex)
                {
                    return new ResponseModel()
                    {
                        Message = ex.Message,
                        StatusCode = 500,
                        IsSuccess = false
                    };
                }
            }
            
            if (request != null)
            {
                var News = new NewsModel()
                {
                    Category = request.Category,
                    PostedDate = request.PostedDate,
                    NewsTitle = request.NewsTitle,
                    NewsBody = request.NewsBody,
                    AttachmentFile = filePath
                    
                };

                await _context.News.AddAsync(News, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = "News is succesfully created!",
                    IsSuccess = true,
                    StatusCode = 201
                };
            }

            return new ResponseModel
            {
                Message = "News isn't Created",
                StatusCode = 400
            };
        }
        
        
    }
}
