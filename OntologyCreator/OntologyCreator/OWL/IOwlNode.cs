using System;

namespace OwlDotNetApi
{
    /// <summary>
    /// Represents a Node in the OWL Graph
    /// </summary>
    public interface IOwlNode
    {
        /// <summary>
        /// When implemented by a class, gets the Collection of child edges associated with this node
        /// </summary>
        IOwlEdgeCollection ChildEdges
        {
            get;
        }

        /// <summary>
        /// When implemented by a class, gets the collection of parent edges associated with this node
        /// </summary>
        IOwlEdgeCollection ParentEdges
        {
            get;
        }

        /// <summary>
        /// When implemented by a class, gets or sets the ID of this IOwlNode
        /// </summary>
        string ID
        {
            get;
            set;
        }

        /// <summary>
        /// When implemented by a class, gets or sets the Language ID of this node
        /// </summary>
        string LangID
        {
            get;
            set;
        }

        /// <summary>
        /// When implemented by a class, attaches a child edge to this IOwlNode
        /// </summary>
        /// <param name="edge">The edge to attach</param>
        void AttachChildEdge(IOwlEdge edge);

        /// <summary>
        /// When implemented by a class, attaches a parent edge to this node
        /// </summary>
        /// <param name="edge">The edge to attach</param>
        void AttachParentEdge(IOwlEdge edge);

        /// <summary>
        /// When implemented by a class, detaches a child edge from this node
        /// </summary>
        /// <param name="edge">The edge to detach</param>
        void DetachChildEdge(IOwlEdge edge);

        /// <summary>
        /// When implemented by a class, detaches a parent edge from this node
        /// </summary>
        /// <param name="edge">The edge to detach</param>
        void DetachParentEdge(IOwlEdge edge);

        /// <summary>
        /// When implemented by a class, it accepts a message and retransfers it back to the visitor
        /// </summary>
        /// <param name="visitor">The actual visitor in the pattern</param>
        /// <param name="parent">The parent object of the node to be generated</param>
        void Accept(IOwlVisitor visitor, Object parent);
    }
}
