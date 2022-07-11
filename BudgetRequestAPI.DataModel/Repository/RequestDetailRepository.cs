
using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.DataModel.Helper;
using BudgetRequestAPI.DataModel.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetRequestAPI.DataModel.Repository
{
    public class RequestDetailRepository : IRequestDetailRepository
    {
        private readonly Budget_RequestContext _context;

        public RequestDetailRepository(Budget_RequestContext budget_RequestContext)
        {
            _context = budget_RequestContext;
        }
        public async Task<List<RequestDetail>> GetAllRequestDetails()
        {
            return await _context.RequestDetails.Where(x => x.IsDeleted == false).OrderByDescending(x => x.RequestId).ToListAsync();
        }

        public List<RequestDetail> GetRequestByUserId(int id)
        {
            var Request = _context.RequestDetails.Where(x => x.UserId == id && x.IsDeleted == false).OrderByDescending(x => x.RequestId).ToList();
            if (Request != null)
            {
                return Request;
            }
            return null;
        }

        public List<RequestDetail> GetRequestByMangerId(int id)
        {
            var Request = _context.RequestDetails.Where(x => x.ManagerId == id && x.IsDeleted == false).OrderByDescending(x => x.RequestId).ToList();
            if (Request != null)
            {
                return Request;
            }
            return null;
        }

        public RequestDetail GetRequest(int id)
        {
            var Request1 = _context.RequestDetails.FirstOrDefault(x => x.RequestId == id && x.IsDeleted == false);
            if (Request1 != null)
            {
                _context.Entry(Request1).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                return Request1;
            }
            return null;
        }

        public async Task<List<RequestDetail>> GetHistoryOfRequestByUserId(int id)
        {
            return await _context.RequestDetails.Where(x => x.UserId == id && x.RequestStatus != 0).OrderByDescending(x => x.RequestId).ToListAsync();
        }

        public async Task<int> AddRequest(RequestDetail requestDetail)
        {
            _context.RequestDetails.Add(requestDetail);
            var employeeEmail = _context.UserInfos.Where(x => x.UserId == requestDetail.UserId).Select(y => y.EmailId);
            var managerEmail = _context.UserInfos.Where(x => x.UserId == requestDetail.ManagerId).Select(y => y.EmailId);
            EmailNotificationHelper.EmailNotification(employeeEmail.ToString(), managerEmail.ToString());
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<int> UpdateRequest(RequestDetail requestDetail)
        {
            try
            {
                _context.Entry(requestDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync(true);
                return 1;
            }
            catch
            {
                Exception ex;
                return -1;

            }
        }

        public async Task<int> DeleteRequest(int id)
        {
            if (id != 0)
            {
                var requestDetail = new RequestDetail { RequestId = id, IsDeleted = true };
                _context.RequestDetails.Attach(requestDetail).Property(x => x.IsDeleted).IsModified = true;
                await _context.SaveChangesAsync(true);
                return 1;
            }
            return 0;
        }

        public async Task<int> RequestDecisonByManager(int id, int? statusId)
        {
            var requestDetail = new RequestDetail { RequestId = id, RequestStatus = statusId };
            _context.RequestDetails.Attach(requestDetail).Property(x => x.RequestStatus).IsModified = true;
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<int> RejectionCommentByManager(int id, string comment)
        {

            var requestDetail = new RequestDetail { RequestId = id, Comments = comment };
            _context.RequestDetails.Attach(requestDetail).Property(x => x.Comments).IsModified = true;
            await _context.SaveChangesAsync();
            return 1;
        }

    }
}
