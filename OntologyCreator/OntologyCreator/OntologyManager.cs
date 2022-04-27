using System.Collections.Generic;
using System.Linq;

namespace OntologyCreator
{
    /// <summary>
    /// Класс для работы с онтологиями
    /// </summary>
    public class OntologyManager
    {
        private static OntologyManager _manager;

        private int _currentOntologyId;

        private Ontology _currentOntology;

        public List<Ontology> _ontologies { get; set; }

        protected OntologyManager()
        {
            _ontologies = new List<Ontology>();
        }

        public static OntologyManager getManager()
        {
            if (_manager == null)
            {
                _manager = new OntologyManager();
            }
            return _manager;
        }

        public static void Clear()
        {
            _manager = null;
        }

        public void Add(Ontology ontology)
        {
            if (!_ontologies.Any(o => o.Id == ontology.Id))
                _ontologies.Add(ontology);
            _currentOntologyId = ontology.Id;
            _currentOntology = ontology;
        }

        public void Delete(int ontologyId)
        {
            _ontologies.RemoveAll(o => o.Id == ontologyId);
            _currentOntologyId = _ontologies.Last().Id;
            _currentOntology = GetById(_currentOntologyId);
        }

        public Ontology GetById(int id)
        {
            return _ontologies.Find(o => o.Id == id);
        }

        public Ontology GetCurrentOntology()
        {
            return _currentOntology;
        }

        public int GetCurrentID()
        {
            return _currentOntologyId;
        }

        public int GetNewID()
        {
            if (_ontologies.Count == 0)
                return 1;
            else
                return _ontologies[_ontologies.Count - 1].Id + 1;
        }

        public int Open(string name)
        {
            var onto = _ontologies.Find(o => o.Name == name);
            _currentOntologyId = onto.Id;
            _currentOntology = onto;
            return onto.Id;
        }
    }
}
