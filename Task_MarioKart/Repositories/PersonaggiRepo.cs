using ASP_lez03_EF_Manuale_Ferramenta.Models;
using Task_MarioKart.Models;

namespace Task_MarioKart.Repositories
{
    public class PersonaggiRepo : IRepo<Personaggi>
    {

        private readonly MarioKartContext _context;
        public PersonaggiRepo(MarioKartContext context)
        {
            _context = context;
        }
        public bool Create(Personaggi entity)
        {
            try 
            { 
                _context.Personaggi.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool Delete(int id)
        {
            try 
            {

                Personaggi? temp = Get(id);
                    if (temp != null)
                {
                    _context.Personaggi.Remove(temp);
                    _context.SaveChanges();

                    return true;    
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public Personaggi? Get(int id)
        {
            return _context.Personaggi.Find(id);
        }

        public IEnumerable<Personaggi> GetAll()
        {
            return _context.Personaggi.ToList();
        }

        public bool Update(Personaggi entity)
        {
            try
            {
                _context.Personaggi.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        public Personaggi? GetByCodice(string codice)
        {
            try
            {
                return _context.Personaggi.FirstOrDefault(p => p.Codice == codice);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
