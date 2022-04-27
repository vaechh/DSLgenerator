using System;
using System.Collections.Generic;
using System.Linq;
using OntologyCreator.Attributes;
using System.Runtime.Serialization;

namespace OntologyCreator.Concepts
{
    [DataContract]
    public class Concept
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int ParentID { get; set; }

        [DataMember]
        public int OntologyID { get; set; }

        [DataMember]
        public List<Property> Properties { get; set; } = new List<Property>();

        [DataMember]
        public List<Concept> Child { get; set; }

        //for serialization
        public Concept()
        { }

        public Concept(int ontologyId, int parentId = -1)
        {
            OntologyID = ontologyId;
            ID = getID();
            ParentID = parentId;
            Child = new List<Concept>();
        }

        private int getID()
        {
            var onto = OntologyManager.getManager().GetById(OntologyID);
            if (onto.Concepts.Count() == 0)
                return 0;
            else
                return Utils.FindMaxConceptId(onto.Concepts) + 1;
        }

        public virtual void Add(Concept concept)
        {
            Child.Add(concept);
        }

        public virtual void Remove(Concept concept)
        {
            Child.Remove(concept);
        }

        public object Clone(int ontologyId, int Id, int parentId = -1)
        {
            var propertyId = 1;
            var thisId = Id;
            return new Concept
            {
                ID = Id++,
                Name = this.Name,
                Description = this.Description,
                ParentID = parentId,
                OntologyID = ontologyId,
                Properties = this.Properties.Select(item => (Property)item.Clone(propertyId++, thisId, ontologyId)).ToList(),
                Child = this.Child.Select(item => (Concept)item.Clone(ontologyId, Id++, thisId)).ToList()
            };
        }
    }
}
