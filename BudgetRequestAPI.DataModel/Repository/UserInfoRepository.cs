using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.DataModel.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace BudgetRequestAPI.DataModel.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly Budget_RequestContext _context;

        public UserInfoRepository(Budget_RequestContext budget_RequestContext)
        {
            _context = budget_RequestContext;
        }

        public List<UserInfo> GetAllUserInfo()
        {
            return _context.UserInfos.ToList();
        }

        public UserInfo GetUserInfo(int id)
        {
            UserInfo userInfo = _context.UserInfos.FirstOrDefault(x => x.UserId == id);
            if (userInfo != null)
            {
                _context.Entry(userInfo).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                return userInfo;
            }
            return null;
        }

        public int AddUserInfo(UserInfo userInfo)
        {
            _context.UserInfos.Add(userInfo);
            _context.SaveChanges();
            return 1;
        }

        public int UpdateUserInfo(UserInfo userInfo)
        {
            _context.Entry(userInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return 1;
        }

    }
}
