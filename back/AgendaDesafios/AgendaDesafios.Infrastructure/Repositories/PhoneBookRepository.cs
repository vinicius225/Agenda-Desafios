using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Domain.Entities;
using AgendaDesafios.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaDesafios.Infrastructure.Repositories
{
    public class PhoneBookRepository : IPhonebookRepository
    {
        private readonly AppDbContext _context;

        public PhoneBookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Phonebook> Add(Phonebook obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            _context.Phonebooks.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task Delete(int id)
        {
            var phonebook = await _context.Phonebooks.FirstAsync(a => a.Id == id); ;

            phonebook.UpdateStatus(Domain.Enums.StatussEnum.Inactive);
            _context.Phonebooks.Update(phonebook);
            await _context.SaveChangesAsync();


        }



        public async Task<Phonebook> Update(Phonebook obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var phonebook = await _context.Phonebooks.FindAsync(obj.Id);
            if (phonebook == null)
                throw new ArgumentException();
            _context.Phonebooks.Update(obj);

            await _context.SaveChangesAsync();

            return phonebook;
        }
    }
}
