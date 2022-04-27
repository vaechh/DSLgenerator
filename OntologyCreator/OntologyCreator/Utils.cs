using OntologyCreator.Attributes;
using OntologyCreator.Concepts;
using OntologyCreator.Relations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyCreator
{
    /// <summary>
    /// Класс с часто используемыми функциями программы
    /// </summary>
    public static class Utils
    {
        #region Concepts
        public static Concept FindConceptByName(string name, List<Concept> concepts)
        {
            Concept answer = null;
            if ((concepts != null) && (concepts.Count > 0))
                foreach (var c in concepts)
                {
                    if (c.Name == name)
                    {
                        answer = c;
                        break;
                    }
                    answer = FindConceptByName(name, c.Child);
                    if (answer != null)
                        break;
                }
            return answer;
        }

        public static Concept FindConceptByID(int id, List<Concept> concepts)
        {
            Concept answer = null;
            if ((concepts != null) && (concepts.Count > 0))
                foreach (var c in concepts)
                {
                    if (c.ID == id)
                    {
                        answer = c;
                        break;
                    }
                    answer = FindConceptByID(id, c.Child);
                    if (answer != null)
                        break;
                }
            return answer;
        }

        public static int CountConcept(List<Concept> concepts, int x = 0)
        {
            if ((concepts != null) && (concepts.Count != 0))
                foreach (var c in concepts)
                {
                    x++;
                    x += CountConcept(c.Child);
                }
            return x;
        }

        public static int FindMaxConceptId(List<Concept> concepts)
        {
            int max = -1;
            if ((concepts != null) && (concepts.Count > 0))
                foreach (var c in concepts)
                {
                    if (c.ID > max)
                        max = c.ID;
                    if (FindMaxConceptId(c.Child) > max)
                        max = FindMaxConceptId(c.Child);
                }
            return max;
        }

        public static bool ConceptNameExists(int id, string name, List<Concept> concepts)
        {
            bool answer = false;
            if ((concepts != null) && (concepts.Count > 0))
                foreach (var c in concepts)
                {
                    if (string.Compare(c.Name, name, true) == 0 && c.ID != id)
                    {
                        answer = true;
                        break;
                    }
                    answer = ConceptNameExists(id, name, c.Child);
                    if (answer == true)
                        break;
                }
            return answer;
        }

        public static List<ConceptCompareResult> CompareConceptNameLists(List<Concept> conceptsFirst, List<Concept> conceptsSecond)
        {
            var result = new List<ConceptCompareResult>();
            var expandedFirst = new List<Concept>();
            var expandedSecond = new List<Concept>();
            GetFullConceptList(conceptsFirst, expandedFirst);
            GetFullConceptList(conceptsSecond, expandedSecond);

            var except = expandedFirst.Select(c => c.Name).Except(expandedSecond.Select(c => c.Name)).ToList();

            foreach (var c in except)
            {
                result.Add(new ConceptCompareResult(c, Color.Crimson));
            }

            return result;
        }

        public static List<ConceptCompareResult> CompareConceptPropertyLists(List<Concept> conceptsFirst, List<Concept> conceptsSecond)
        {
            var result = new List<ConceptCompareResult>();
            var expandedFirst = new List<Concept>();
            var expandedSecond = new List<Concept>();
            GetFullConceptList(conceptsFirst, expandedFirst);
            GetFullConceptList(conceptsSecond, expandedSecond);

            foreach (var c in expandedFirst)
            {
                if (!expandedSecond.Any(q => CompareProperties(c.Properties, q.Properties)))
                    result.Add(new ConceptCompareResult(c.Name, Color.Crimson));
            }

            return result;
        }

        public static void GetFullConceptList(List<Concept> concepts, List<Concept> conceptsExpanded)
        {
            foreach (var c in concepts)
            {
                conceptsExpanded.Add(c);
                GetFullConceptList(c.Child, conceptsExpanded);
            }
        }
        #endregion

        #region Relations
        public static bool RelationNameExists(int id, string name, List<Relation> relations)
        {
            bool answer = false;
            if ((relations != null) && (relations.Count > 0))
                foreach (Relation r in relations)
                {
                    if (string.Compare(r.Name, name, true) == 0 && r.ID != id)
                        answer = true;
                }
            return answer;
        }

        public static int GetConceptIdFromOntology(int ontologyId)
        {
            var onto = OntologyManager.getManager().GetById(ontologyId);
            if (onto.Concepts.Count == 0)
                return 1;
            else
                return FindMaxConceptId(onto.Concepts) + 1;
        }

        public static int GetRelationIdFromOntology(int ontologyId)
        {
            var onto = OntologyManager.getManager().GetById(ontologyId);
            if (onto.Relations.Count == 0)
                return 1;
            else
                return onto.Relations[onto.Relations.Count - 1].ID + 1;
        }

        public static void CreateFamilyRelationsUp(Concept dad, Concept concept, int ontologyId)
        {
            var onto = OntologyManager.getManager().GetById(ontologyId);
            Relation relation = new Relation(ontologyId, dad, concept);
            relation.RelationType = "Наследование";
            onto.Relations.Add(relation);
            if (dad.ParentID != -1)
                CreateFamilyRelationsUp(FindConceptByID(dad.ParentID, onto.Concepts), concept, ontologyId);
        }

        public static void CreateFamilyRelationsDown(Concept dad, Concept concept, int ontologyId)
        {
            var onto = OntologyManager.getManager().GetById(ontologyId);
            Relation relation = new Relation(ontologyId, dad, concept);
            relation.RelationType = "Наследование";
            onto.Relations.Add(relation);
            if (concept.Child.Count != 0)
                foreach (var c in concept.Child)
                {
                    CreateFamilyRelationsDown(dad, c, ontologyId);
                }
        }

        #endregion

        #region Properties
        // true - если списки одинаковы
        public static bool CompareProperties(List<Property> propertiesFirst, List<Property> propertiesSecond)
        {
            var propCount = propertiesFirst.Count;
            foreach(var prop in propertiesFirst)
            {
                if (propertiesSecond.Any(p => p.Name == prop.Name && p.ValueType == prop.ValueType && p.Value == prop.Value))
                    propCount--;
            }
            return propCount == 0;
        }
        #endregion
    }

    public struct ConceptCompareResult
    {
        public string Name { get; set; }
        public Color color { get; set; }

        public ConceptCompareResult(string name, Color setColor)
        {
            Name = name;
            color = setColor;
        }
    }
}
