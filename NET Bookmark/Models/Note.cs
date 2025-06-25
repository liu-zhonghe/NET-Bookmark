// Models/Note.cs
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace WebBookmarkApp.Models
{
    public class Note
    {
        /// <summary>
        /// 笔记的唯一标识符
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// 笔记的标题
        /// </summary>
        [Required(ErrorMessage = "标题不能为空")]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// 笔记的内容
        /// </summary>
        [Required(ErrorMessage = "内容不能为空")]
        [JsonPropertyName("content")]
        public string Content { get; set; }

        /// <summary>
        /// 笔记的创建时间
        /// </summary>
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 笔记的更新时间
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// 是否为书签
        /// </summary>
        [JsonPropertyName("isBookmark")]
        public bool IsBookmark { get; set; } = false;

        /// <summary>
        /// 标签列表
        /// </summary>
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        /// <summary>
        /// 页数（仅书签用）
        /// </summary>
        [JsonPropertyName("pageNumber")]
        public int? PageNumber { get; set; }

        public Note()
        {
            // 默认构造函数
            Title = string.Empty;
            Content = string.Empty;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            IsBookmark = false;
            Tags = new List<string>();
            PageNumber = null;
        }

        public Note(int id, string title, string content, bool isBookmark = false, List<string>? tags = null, int? pageNumber = null)
        {
            Id = id;
            Title = title;
            Content = content;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            IsBookmark = isBookmark;
            Tags = tags ?? new List<string>();
            PageNumber = pageNumber;
        }
    }
}