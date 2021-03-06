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
    public class WriterValidator:AbstractValidator<WriterDto>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Resim boş geçilemez");
            RuleFor(x => x.WriterPassword).Equal(w => w.WriterConfirmPassword).WithMessage("Şifre eşleşmemektedir");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik giriş yapınız");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz");
        }
    }
}
