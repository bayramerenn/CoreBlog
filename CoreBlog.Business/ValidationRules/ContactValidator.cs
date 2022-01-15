using CoreBlog.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Business.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {

            RuleFor(x => x.ContactUserName).NotEmpty().WithMessage("Ad ve soyad alanı boş geçilemez"); 
            RuleFor(x => x.ContactMessage).NotEmpty().WithMessage("Mesaj alanı boş geçilemez"); 
            RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("Konu alanı boş geçilemez"); 
            RuleFor(x => x.ContactMail).NotEmpty().WithMessage("Mail alanı boş geçilemez"); 
            RuleFor(x => x.ContactMail).EmailAddress().WithMessage("Mail adresi alanı doğru formatta değil"); 
        }
    }
}
