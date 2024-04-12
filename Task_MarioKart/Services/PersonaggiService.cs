using Microsoft.EntityFrameworkCore;
using Task_MarioKart.DTO;
using Task_MarioKart.Models;
using Task_MarioKart.Repositories;

namespace Task_MarioKart.Services
{
    public class PersonaggiService : IService<Personaggi>
    {
        private readonly PersonaggiRepo _repository;
        public PersonaggiService(PersonaggiRepo repository) 
        {

            _repository = repository;
        
        }

        public IEnumerable<Personaggi> PrendiTutto()
        {
            return _repository.GetAll();
        }


        public bool InserisciPersonaggio(PersonaggiDTO oPer) 
        {
            Personaggi per = new Personaggi()
            {
                Nome=oPer.Nom,
                Costo = oPer.Cos,
                Categoria = oPer.Cat,
                Codice = Guid.NewGuid().ToString().ToUpper(),
                Img = oPer.Img,
                SquadraRif = oPer.SquadraRif,

            };

            return _repository.Create(per);


        
        
        }

        public List<PersonaggiDTO> GetAllPer()
        {
            List<PersonaggiDTO> elenco = _repository.GetAll().Select(p => new PersonaggiDTO()
            {
                Cos = p.Costo,

                Cod = p.Codice,

                Nom = p.Nome,

                Cat = p.Categoria,

                Img = p.Img,

                SquadraRif = p.SquadraRif,

                Squad = p.SquadraRifNavigation
            }).ToList();

            return elenco;
        }

        public bool EliminaPersonaggio(PersonaggiDTO oPro)
        {
            if (oPro.Cod is not null)
            {
                Personaggi? temp = _repository.GetByCodice(oPro.Cod);

                if (temp is not null)
                    return _repository.Delete(temp.PersonaggioId);
            }
            return false;
        }

        
        public bool ModificaPersonaggio(PersonaggiDTO oPro) {

            if (oPro.Cod is not null)
            {
                Personaggi? temp = _repository.GetByCodice(oPro.Cod);

                if (temp is not null) {

                   temp.Nome=oPro.Nom;
                    temp.Categoria=oPro.Cat;
                    temp.Costo=oPro.Cos;
                    temp.Img=oPro.Img;  
                    return _repository.Update(temp);
                }
            }
            return false;
        }
    }
}
