using CoreBlog.Business.DTOs;
using CoreBlog.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Business.ValidationRules
{
    public class BLogValidator:AbstractValidator<BlogDto>
    {
        public BLogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriğini boş geçemezsiniz");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görselini boş geçemezsiniz");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapınız");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen 4 karakterden daha az veri girişi yapınız");
            RuleFor(x => x.CategoryID).GreaterThan(0).WithMessage("Lütfen bir kategori seçiniz");
     
            //RuleFor(x => x.CategoryID).GreaterThan(0).WithMessage("Kategori içeriğini boş geçemezsiniz");

     
        
        }
    }
}
