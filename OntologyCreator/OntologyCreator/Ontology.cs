using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using OntologyCreator.Concepts;
using OntologyCreator.Relations;

namespace OntologyCreator
{
    [DataContract]
    [KnownType(typeof(Concept))]
    public class Ontology
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public SubjectArea subjectArea { get; set; }

        [DataMember]
        public List<Concept> Concepts { get; set; } = new List<Concept>();

        [DataMember]
        public List<Relation> Relations { get; set; } = new List<Relation>();

        public static int globalOntologyID; //для индексирования

        //for serialization
        public Ontology()
        {
            Id = Interlocked.Increment(ref globalOntologyID);
            Name = "";
        }

        public Ontology(string name, string description)
        {
            Id = OntologyManager.getManager().GetNewID();
            Name = name;
            Description = description;
            subjectArea = new SubjectArea();
        }
    }
}
