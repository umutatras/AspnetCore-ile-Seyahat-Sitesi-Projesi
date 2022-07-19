using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Boş geçemezsiniz").MaximumLength(250).WithMessage("Lütfen en fazla 250 karakterlik" +
                "açıklama giriniz").MinimumLength(20).WithMessage("Lütfen en az 20 karakterlik açıklama giriniz");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Boş geçemezsiniz");
        }
    }
}
