using Core.DataAccess.IEntityFramework;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, MyCarDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new MyCarDbContext())
            {
                var result = from o in context.OperationClaims
                             join uoc in context.UserOperationClaims
                             on o.Id equals uoc.OperationClaimId
                             where uoc.UserId == user.UserId
                             select new OperationClaim { Id = o.Id, Name = o.Name };

                return result.ToList();
            }
        }
    }
}
