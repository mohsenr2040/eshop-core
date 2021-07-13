using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using eshop.Domain.Entities.MongoDb;
using eshop.Common.Dto;
using Microsoft.AspNetCore.Http;
using eshop.Domain.Entities.Users;
using System.Security.Claims;
using System.Linq;

namespace eshop.Application.Services.MongoDb
{
    public class CommentService
    {
        private readonly IMongoCollection<Comment> _comments;

        public CommentService(IeshopCommentsSettings settings )
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _comments = database.GetCollection<Comment>(settings.CommentsCollectionName);
        }
        public ResultDto<List<Comment>> Get(string PId)
        {
            return new ResultDto<List<Comment>>()
            {
                Data =  _comments.Find(c=>c.ProductId==PId).ToList(),
            };

        }

        //public Comment Get(string Id) => _comments.Find<Comment>(c => c.Id == Id).FirstOrDefault();

        public ResultDto<Comment> Create(string PId, string Text,string UserId ,string FullName)
        {
            Comment comment = new Comment();
            comment.ProductId = PId;
            comment.UserId = UserId;
            comment.text =  Encoding.UTF8.GetString(Encoding.Default.GetBytes(Text));
            comment.user = FullName;
            _comments.InsertOne(comment);
            return new ResultDto<Comment>()
            {
                Data= comment,
                IsSuccess = true,
                Message = "نظر شما ثبت گردید",
            };
        }

        public ResultDto Delete(string Id)
        {
            Comment comment = _comments.Find(c => c.Id == Id).FirstOrDefault();
            _comments.DeleteOne(c => c.Id == Id);
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کامنت با موفقیت حذف گردید !",
            };
        }

        public ResultDto AddReply(string Id,string rpy_user,string rpy_text)
        {
            Comment comment = _comments.Find(c => c.Id == Id).FirstOrDefault();
            Reply reply = new Reply() { user = rpy_user, text = rpy_text };
            var update = Builders<Comment>.Update.Push(c => c.Replies,reply);
            _comments.UpdateOne(c => c.Id == Id, update);
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "پاسخ افزوده شد",
            };

        }

        public class CommentReplyDto
        {
            public List<Comment> Comments { get; set; }
            public List<Reply> Replies { get; set; }
        }

    }
}
