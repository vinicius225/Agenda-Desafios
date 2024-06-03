using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Domain.Entities;
using AgendaDesafios.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
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

        public async Task Delete(int id)
        {
            _context.Calendars.Where(a => a.Id == id).FirstOrDefault().UpdateStatus(Domain.Enums.StatussEnum.Inactive);
            await _context.SaveChangesAsync();
        }


        public async Task<Calendar> Update(Calendar obj)
        {
            _context.Calendars.Update(obj);
            await _context.SaveChangesAsync(); 
            return obj; 
        }
    }
}
