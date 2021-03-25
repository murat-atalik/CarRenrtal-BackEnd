using Business.Concrete;
using System.Linq;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.UserId).NotEmpty();
            
            //Find better way
            //RuleFor(c => c.UserId).Must(Uniqe).WithMessage("Girmiş olduğunuz kullanıcı adı daha önce sisteme kayıt edilmiş.");
            //RuleFor(c => c.UserId).Must(UserIdValid).WithMessage("Lütfen geçerli bir kullanıcı id si giriniz.");

        }

        //private bool Uniqe(int arg)
        //{
        //    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        //    bool ca = customerManager.GetAll().Data.Where(c=>c.UserId==arg).Any();
        //    return !ca;
            
        //}

        //private bool UserIdValid(int arg)
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    bool item = userManager.GetAll().Data.Where(u => u.Id == arg).Any();
        //    return item;
            
        //}
    }
}
