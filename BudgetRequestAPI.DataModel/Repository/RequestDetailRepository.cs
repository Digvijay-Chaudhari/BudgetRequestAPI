﻿
using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.DataModel.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace BudgetRequestAPI.DataModel.Repository
{
    public class RequestDetailRepository : IRequestDetailRepository
    {
        private readonly Budget_RequestContext _context;

        public RequestDetailRepository(Budget_RequestContext budget_RequestContext)
        {
            _context = budget_RequestContext;
        }
        public List<RequestDetail> GetAllRequestDetails()
        {
            return _context.RequestDetails.ToList();
        }

        public List<RequestDetail> GetRequestById(int id)
        {
            return _context.RequestDetails.Where(x => x.UserId == id).ToList();
        }

        public RequestDetail GetRequest(int id)
        {
            RequestDetail Request1 = _context.RequestDetails.FirstOrDefault(x => x.RequestId == id);
            if (Request1 != null)
            {
                //_bookStoreContex.Entry(book).State = EntityState.Detached;
                //return book;
                _context.Entry(Request1).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                return Request1;
            }
            return null;
        }
        public int AddRequest(RequestDetail requestDetail)
        {
            _context.RequestDetails.Add(requestDetail);
            _context.SaveChanges();
            return 1;
        }

        public int UpdateRequest(RequestDetail requestDetail)
        {
            _context.Entry(requestDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return 1;
        }

        public int DeleteRequest(int id)
        {
            RequestDetail requestDetail = GetRequest(id);
            if (requestDetail != null)
            {
                _context.RequestDetails.Remove(requestDetail);
                _context.SaveChanges(true);
                return 1;
            }
            return 0;
        }
    }
}