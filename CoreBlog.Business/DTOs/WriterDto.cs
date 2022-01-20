using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Business.DTOs
{
    public class WriterDto
    {
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }
        public string WriterMail { get; set; }
        //[DataType(DataType.Password)]
        public string WriterPassword { get; set; }
        public string WriterConfirmPassword { get; set; }
        public bool WriterStatus { get; set; }
    }
}
