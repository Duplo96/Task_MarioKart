using ASP_lez03_EF_Manuale_Ferramenta.Models;
using Microsoft.EntityFrameworkCore;
using Task_MarioKart.Models;

namespace Task_MarioKart.Repositories
{
    public class SquadraRepo : IRepo<Squadra>
    {
        private readonly MarioKartContext _context;
        public SquadraRepo(MarioKartContext context)
        {
            _context = context;
        }
        public bool Create(Squadra entity)
        {
            try
            {
                _context.Squadra.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Squadra? temp = Get(id);
                if (temp != null)
                {
                    _context.Squadra.Remove(temp);
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public Squadra? Get(int id)
        {
            return _context.Squadra.Find(id);
        }

        public IEnumerable<Squadra> GetAll()
        {
            return _context.Squadra.Include(s => s.Personaggis).ToList();
        }

        public Squadra? GetByCodice(string codice)
        {
            try
            {
                return _context.Squadra.FirstOrDefault(p => p.Codice == codice);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public bool Update(Squadra entity)
        {
            try
            {
                _context.Squadra.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
