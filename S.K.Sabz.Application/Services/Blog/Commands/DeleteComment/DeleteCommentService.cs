using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common.Dto;
using S.K.Sabz.Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Commands.DeleteComment
{
    public class DeleteCommentService
    {
        private readonly IDataBaseContext _context;
        public DeleteCommentService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> ExecuteAsync(long commentId)
        {
            var comment = await _context.PostComments.FindAsync(commentId);
            if (comment == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "نظر پیدا نشد"
                };
            }
            
            
            comment.IsRemoved = true;

            await _context.SaveChangesAsync();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "با موفقیت حذف شد"
            };
        }

    }
}
