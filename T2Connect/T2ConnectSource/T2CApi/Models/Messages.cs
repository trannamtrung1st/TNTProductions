using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T2CApi.Models
{
    public class GlobalMsg
    {
        public static readonly string InternalError = "Có lỗi xảy ra ";
    }

    public class QuestionMsg
    {
        public static readonly string NotFound = "Không thể tìm thấy câu hỏi ";
    }

    public class AnswerMsg
    {
        public static readonly string NotFound = "Không thể tìm thấy câu trả lời ";
    }

    public class CommentMsg
    {
        public static readonly string NotFound = "Không thể tìm thấy bình luận ";
    }

    public static class UsersMsg
    {
        public static string NotFound { get; set; } = "Không thể tìm thấy user ";
    }

}