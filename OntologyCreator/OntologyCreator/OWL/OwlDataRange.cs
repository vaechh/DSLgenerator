using System;
using System.Runtime.InteropServices;

namespace OwlDotNetApi
{
	/// <summary>
	/// Represents an OWL resource of type owl:Class.
	/// </summary>
	public class OwlDataRange : OwlResource, IOwlDataRange
	{
		#region Creators
		/// <summary>
		/// Initializes a new instance of the OwlDataRange class
		/// </summary>
		/// <remarks>This constructor creates a new OwlNode with Uri owl:DataRange and sets it as the child node of an edge with URI rdf:type</remarks>	
		public OwlDataRange()
		{
//			_typeEdge = new OwlEdge(OwlNamespaceCollection.RdfNamespace+"type");
//			_typeEdge.AttachChildNode(new OwlNode(OwlNamespaceCollection.OwlNamespace+"DataRange"));
//			AttachChildEdge(_typeEdge);
		}

		/// <summary>
		/// Initializes a new instance of the OwlClass class with the given Uri and TypeNode
		/// </summary>
		/// <param name="nodeUri">A string representing the Uri of this Resource</param>
		/// <param name="typeNode">The OwlNode object to attach to the edge specifying the type. This is usually a node with ID owl:Class.</param>
		/// <exception cref="ArgumentNullException">typeNode is a null reference</exception>
		public OwlDataRange(string nodeUri, OwlNode typeNode)
		{
			if(typeNode == null)
				throw(new ArgumentNullException());
			ID = nodeUri;
			_typeEdge = new OwlEdge(OwlNamespaceCollection.RdfNamespace+"type");
			_typeEdge.AttachChildNode(typeNode);
			AttachChildEdge(_typeEdge);
		}
		/// <summary>
		/// Initializes a new instance of the OwlDataRange class with the given Uri
		/// </summary>
		/// <param name="nodeUri">A string representing the URI of this Resource</param>
		/// <remarks>This constructor creates a new OwlNode with URI owl:DataRange and sets it as the child node of an edge with URI rdf:type</remarks>	
		public OwlDataRange(string nodeUri)
		{
			ID = nodeUri;
//			_typeEdge = new OwlEdge(OwlNamespaceCollection.RdfNamespace+"type");
//			_typeEdge.AttachChildNode(new OwlNode(OwlNamespaceCollection.OwlNamespace+"DataRange"));
//			AttachChildEdge(_typeEdge);
		}

		#endregion

		#region Manipulators
		/// <summary>
		/// This is the accept method in the visitor pattern used for performing an action on the node.
		/// </summary>
		/// <param name="visitor">The visitor object itself</param>
		/// <param name="parent">The parent object of the node</param>
		public override void Accept(IOwlVisitor visitor, Object parent) 
		{
			visitor.Visit(this, parent);
		}

		#endregion
	}
}