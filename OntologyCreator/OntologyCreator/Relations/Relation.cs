using System.Linq;
using System.Runtime.Serialization;
using OntologyCreator.Concepts;

namespace OntologyCreator.Relations
{
    [DataContract]
    public class Relation : IRelation
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string RelationType { get; set; }

        [DataMember]
        public Concept MainConcept { get; set; }

        [DataMember]
        public Concept SecondaryConcept { get; set; }

        [DataMember]
        public int OntologyId { get; set; }

        //for serialization
        public Relation()
        { }

        public Relation(int ontologyId, Concept mainCon, Concept secCon)
        {
            OntologyId = ontologyId;
            ID = getID();
            MainConcept = mainCon;
            SecondaryConcept = secCon;
            Name = mainCon.Name + "-" + secCon.Name;
        }

        private int getID()
        {
            var onto = OntologyManager.getManager().GetById(OntologyId);
            if (onto.Relations.Count == 0)
                return 1;
            else
                return onto.Relations.Max(r => r.ID + 1);
        }

        public object Clone(int ontologyId, Concept main, Concept secondary)
        {
            return new Relation
            {
                ID = Utils.GetRelationIdFromOntology(ontologyId),
                Name = this.Name,
                Description = this.Description,
                RelationType = this.RelationType,
                OntologyId = ontologyId,
                MainConcept = main,
                SecondaryConcept = secondary
            };
        }
    }
}
