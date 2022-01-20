using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Business.DTOs
{
    public class BlogDto
    {
        public int BlogID { get; set; }
 
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreatedDate { get; set; }
        public bool BlogStatus { get; set; }
        public int WriterID { get; set; }
        public int CategoryID { get; set; }
        public List<SelectListItem> Category { get; set; }
       
      
    }
}
