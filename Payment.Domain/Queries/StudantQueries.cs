using PaymentContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Payment.Domain.Queries
{
    public static class StudantQueries
    {
        public static Expression<Func<Student, bool>> GetStudantInfo(string document) { 
            return x => x.Document.Number == document;    
        }
    }
}
