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

        public async Task<Phonebook> Delete(int id)
        {
            var phonebook = await _context.Phonebooks.FindAsync(id);
            if (phonebook == null)
                return null;

            _context.Phonebooks.Remove(phonebook);
            await _context.SaveChangesAsync();

            return phonebook;
        }

        public async Task<Phonebook> GetAsync(int id)
        {
            return await _context.Phonebooks.FindAsync(id);
        }

        public async Task<IEnumerable<Phonebook>> GetAsync()
        {
            return await _context.Phonebooks.ToListAsync();
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
