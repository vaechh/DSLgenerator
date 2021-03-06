using System;
using System.Collections;
using System.IO;

namespace OwlDotNetApi
{
	/// <summary>
	/// Represents an OWL Parser
	/// </summary>
	public interface IOwlParser
	{
		/// <summary>
		/// Indicates whether the parser should throw an exception and stop when it encounters an error
		/// </summary>
		bool StopOnErrors
		{
			get;
			set;
		}
		
		/// <summary>
		/// Indicates whether the parser should throw an exception and stop when it encounters a warning
		/// </summary>
		bool StopOnWarnings
		{
			get;
			set;
		}

		/// <summary>
		/// Represents a list of warning messages generated by the parser
		/// </summary>
		ArrayList Warnings
		{
			get;
		}

		/// <summary>
		/// Represents a list of error messages generated by the parser
		/// </summary>
		ArrayList Errors
		{
			get;
		}

		/// <summary>
		/// Represents a list of logging messages
		/// </summary>
		ArrayList Messages
		{
			get;
		}

		/// <summary>
		/// When implemented by a class, parses the OWL at the given URI, into an existing graph
		/// </summary>
		/// <param name="uri">The Uri of the document to parse</param>
		/// <param name="graph">An object that implements the IOwlGraph interface that will be used as the destination graph</param>
		/// <returns>An object that implements the IOwlGraph interface</returns>
		IOwlGraph ParseOwl(string uri, IOwlGraph graph);

		/// <summary>
		/// When implemented by a class, parses the OWL at the given URI
		/// </summary>
		/// <param name="uri">The Uri of the document to parse</param>
		/// <returns>An object that implements the IOwlGraph interface</returns>
		IOwlGraph ParseOwl(string uri);

		/// <summary>
		/// When implemented by a class, parses the OWL at the given URI, into an existing graph
		/// </summary>
		/// <param name="uri">The Uri of the document to parse</param>
		/// <param name="graph">An object that implements the IOwlGraph interface that will be used as the destination graph</param>
		/// <returns>An object that implements the IOwlGraph interface</returns>
		IOwlGraph ParseOwl(Uri uri, IOwlGraph graph);

		/// <summary>
		/// When implemented by a class, parses the OWL at the given URI
		/// </summary>
		/// <param name="uri">The Uri of the document to parse</param>
		/// <returns>An object that implements the IOwlGraph interface</returns>
		IOwlGraph ParseOwl(Uri uri);

		/// <summary>
		/// When implemented by a class, parses the OWL from a stream into an existing Graph
		/// </summary>
		/// <param name="inStream">The input stream for data</param>
		/// <param name="graph">An object that implements the IOwlGraph interface that will be used as the destination graph</param>
		/// <returns>An object that implements the IOwlGraph interface</returns>
		IOwlGraph ParseOwl(Stream inStream, IOwlGraph graph);

		/// <summary>
		/// When implemented by a class, parses the OWL from a stream
		/// </summary>
		/// <param name="inStream">The input stream for data</param>
		/// <returns>An object that implements the IOwlGraph interface</returns>
		IOwlGraph ParseOwl(Stream inStream);
	}
}
