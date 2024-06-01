using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Domain.Entities;
using AgendaDesafios.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Infrastructure.Repositories
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly AppDbContext _context;
        public CalendarRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<Calendar> Add(Calendar obj)
        {
           var result  = await  _context.Calendars.AddAsync(obj);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Calendar> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Calendar> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Calendar>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Calendar> Update(Calendar obj)
        {
            var result = await _context.Calendars.Update(obj);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
