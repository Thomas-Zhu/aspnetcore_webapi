using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBook.Models
{
    /// <summary>
    /// 图书DTO
    /// </summary>
    public class BookDTO
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 出版日期
        /// </summary>
        public DateTime PublicationDate { get; set; }
    }
}
