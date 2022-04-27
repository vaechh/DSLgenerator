using System.Linq;
using System.Runtime.Serialization;
using OntologyCreator.Concepts;

namespace OntologyCreator.Attributes
{
    [DataContract]
    public class Property : IProperty
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public object Value { get; set; }

        [DataMember]
        public TypeEnum ValueType { get; set; }        
        public enum TypeEnum { Integer = 1, Double = 2, String = 3}

        [DataMember]
        public int ParentId { get; set; }

        [DataMember]
        public int OntologyId { get; set; }

        //for serialization
        public Property()
        { }

        public Property(int parentId, int ontologyId)
        {
            ParentId = parentId;
            OntologyId = ontologyId;
            ID = getID();
        }

        public Property(int parentId, int ontologyId, string name, string description, TypeEnum type, object value)
        {
            ParentId = parentId;
            OntologyId = ontologyId;
            ID = getID();
            Name = name;
            Description = description;
            ValueType = type;
            Value = value;
        }

        private int getID()
        {
            var ontology = OntologyManager.getManager().GetById(OntologyId);
            var parent = Utils.FindConceptByID(ParentId, ontology.Concepts);
            int id = -1;
            if (parent != null)
            {
                if (parent.Properties.Count == 0)
                    id = 0;
                else
                    id = parent.Properties.Max(p => p.ID + 1);
            }
            return id;
        }

        public object Clone(int id, int parentId, int ontologyId)
        {
            return new Property
            {
                ID = id,
                Name = this.Name,
                Description = this.Description,
                ValueType = this.ValueType,
                Value = this.Value,
                ParentId = parentId,
                OntologyId = ontologyId
            };
        }
    }
}
