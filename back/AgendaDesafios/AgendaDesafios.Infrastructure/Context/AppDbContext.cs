using AgendaDesafios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaDesafios.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Phonebook> Phonebooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.Created).IsRequired();
                entity.Property(e => e.Updated).IsRequired();

                entity.HasData(
                     new User
                     (
                          1,
                         "Admin",
                         "admin@blue.com",
                         "yourpassword", // Preencha com a senha
                         Domain.Enums.StatussEnum.active,
                        DateTime.Now,
                         DateTime.Now
                     )
                 );
            });


            modelBuilder.Entity<Calendar>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.StartEvent).IsRequired();
                entity.Property(e => e.EndEvent).IsRequired();
                entity.Property(e => e.SendEmail).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.SituationEvent).IsRequired();
                entity.HasOne<User>(e => e.User).WithMany(a => a.Calendar);

                var events = new List<Calendar>
        {
            new Calendar(1, "Reunião de Planejamento", "Reunião para planejamento do próximo trimestre", new DateTime(2024, 6, 3, 9, 0, 0), new DateTime(2024, 6, 3, 11, 0, 0), true, Domain.Enums.StatussEnum.active, Domain.Enums.SituationEventEnum.Participated, 1),
            new Calendar(2, "Almoço com Cliente", "Almoço com cliente para discutir detalhes do projeto", new DateTime(2024, 6, 5, 12, 0, 0), new DateTime(2024, 6, 5, 14, 0, 0), true, Domain.Enums.StatussEnum.active, Domain.Enums.SituationEventEnum.Participated, 1)
        };

                entity.HasData(events);
            });
            modelBuilder.Entity<Phonebook>(entity =>
            {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Phone).IsRequired();
            entity.Property(e => e.Status).IsRequired();
            entity.Property(e => e.IdUser).IsRequired();

                // Insira alguns contatos na tabela de contatos
                var contacts = new List<Phonebook>
    {
        new Phonebook(1, "João", "joao@example.com", Domain.Enums.StatussEnum.active, "(11) 1234-5678", 1),
        new Phonebook(2, "Maria", "maria@example.com", Domain.Enums.StatussEnum.active, "(11) 9876-5432",1),
            new Phonebook(3, "Pedro", "pedro@example.com", Domain.Enums.StatussEnum.active, "(11) 4567-8901", 1)
    };

                entity.HasData(contacts);
            });

        }
    }
}
