using System.Runtime.Serialization;

namespace OntologyCreator
{
    [DataContract]
    public class SubjectArea
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Goals { get; set; }

        [DataMember]
        public string User { get; set; }

        //for serialization
        public SubjectArea()
        { }

        public SubjectArea(string name, string goals, string user)
        {
            Name = name;
            Goals = goals;
            User = user;
        }
    }
}
