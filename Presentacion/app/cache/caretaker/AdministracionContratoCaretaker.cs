
using Persistencia.lib.dao;
using Persitencia.lib.memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace Persistencia.lib.caretaker
{
    public class AdministracionContratoCaretaker
    {
        private CacheContratoDAO cacheContratoDAO;

        private List<AdministracionContratoMemento> _mementos;

        public List<AdministracionContratoMemento> Mementos
        {
            get { return _mementos; }
        }

        public AdministracionContratoCaretaker()
        {
            _mementos = new List<AdministracionContratoMemento>();

            cacheContratoDAO = new CacheContratoDAO();

            Timer PersistirTimer = new Timer(6 * 60 * 1000);

            PersistirTimer.Elapsed += (s, e) =>
            {
                Console.WriteLine("Guardando caché en base de datos.");
                this.PersistirMementos();
            };

            PersistirTimer.Start();
        }

        public void PersistirMementos()
        {

            cacheContratoDAO.BorrarTodo();

            foreach (AdministracionContratoMemento memento in Mementos)
            {
                cacheContratoDAO.Insertar(memento);
            }
        }

        public void RestaurarMementos()
        {
            _mementos = cacheContratoDAO.ObtenerTodos();
        }

        public void DesecharMementos()
        {
            _mementos = new List<AdministracionContratoMemento>();
            cacheContratoDAO.BorrarTodo();
        }

    }
}
