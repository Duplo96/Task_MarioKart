using Task_MarioKart.DTO;
using Task_MarioKart.Models;
using Task_MarioKart.Repositories;

namespace Task_MarioKart.Services
{
    public class SquadraService : IService<Squadra>
    {

        private readonly SquadraRepo _repository;
        private readonly PersonaggiRepo _personaggiRepo;
        public SquadraService(SquadraRepo repository, PersonaggiRepo _perRepository)
        {
            _repository = repository;
            _personaggiRepo = _perRepository;
        }
        public IEnumerable<Squadra> PrendiTutto()
        {
            return _repository.GetAll();
        }

        public bool InserisciSquadra(SquadraDTO oSqu)
        {
            Squadra squ = new Squadra()
            {
                Codice = Guid.NewGuid().ToString().ToUpper(),
                NomeSquadra = oSqu.NomeSq,
                NomeUtente = oSqu.NomeUt,
                Crediti = oSqu.Crediti,
            };

            return _repository.Create(squ);




        }

        public List<SquadraDTO> GetAllSqua()
        {
            List<SquadraDTO> elenco = _repository.GetAll().Select(s => new SquadraDTO()
            {
                Codice = s.Codice,
                NomeSq = s.NomeSquadra,
                NomeUt = s.NomeUtente,
                Crediti = s.Crediti,
                ListaPersonaggi = s.Personaggis

            }).ToList();

            return elenco;
        }

        public bool EliminaSquadra(SquadraDTO oSqu)
        {
            if (oSqu.Codice is not null)
            {
                Squadra? temp = _repository.GetByCodice(oSqu.Codice);

                if (temp is not null)
                    return _repository.Delete(temp.SquadraId);
            }
            return false;
        }


        public bool ModificaSquadra(SquadraDTO oSqu)
        {

            if (oSqu.Codice is not null)
            {
                Squadra? temp = _repository.GetByCodice(oSqu.Codice);

                if (temp is not null)
                {
                    temp.NomeSquadra = oSqu.NomeSq;
                    temp.NomeUtente = oSqu.NomeUt;
                    temp.Crediti = oSqu.Crediti;
                    return _repository.Update(temp);
                }
            }
            return false;
        }

        public bool InsertPersonaggio(string oPer, string codSqua)
        {
            Squadra? squadra = _repository.GetByCodice(codSqua);

            if (squadra is not null)
            {
                Personaggi? per = _personaggiRepo.GetByCodice(oPer);
               
      
                    if(per!=null && squadra.Crediti > per.Costo)
                        squadra.Personaggis.Add(per);
                    if(_repository.Update(squadra))
                    return true;
          
                return false;
            }
            else
            {
                return false;
            }
        }














    }



}