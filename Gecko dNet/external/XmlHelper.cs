/*
 * AMS.Profile Class Library
 * 
 * Written by Alvaro Mendez
 * Copyright (c) 2005. All Rights Reserved.
 * 
 * The AMS.Profile namespace contains interfaces and classes that 
 * allow reading and writing of user-profile data.
 * This file contains the helper classes for the Xml-based Profile classes.
 * 
 * The code is thoroughly documented, however, if you have any questions, 
 * feel free to email me at alvaromendez@consultant.com.  Also, if you 
 * decide to this in a commercial application I would appreciate an email 
 * message letting me know.
 *
 * This code may be used in compiled form in any way you desire. This
 * file may be redistributed unmodified by any means providing it is 
 * not sold for profit without the authors written consent, and 
 * providing that this notice and the authors name and all copyright 
 * notices remains intact. This file and the accompanying source code 
 * may not be hosted on a website or bulletin board without the author's 
 * written permission.
 * 
 * This file is provided "as is" with no expressed or implied warranty.
 * The author accepts no liability for any damage/loss of business that
 * this product may cause.
 *
 * Last Updated: Feb. 17, 2005
 */


using System;
using System.Xml;
using System.Text;
using System.IO;
using System.Security;

namespace AMS.Profile
{
	/// <summary>
	///   Abstract base class for all XML-based Profile classes. </summary>
	/// <remarks>
	///   This class provides common methods and properties for the XML-based Profile classes 
	///   (<see cref="Xml" />, <see cref="Config" />). </remarks>
	public abstract class XmlBased : Profile
	{
		private Encoding m_encoding = Encoding.UTF8;
		internal XmlBuffer m_buffer;

		/// <summary>
		///   Initializes a new instance of the XmlBased class by setting the <see cref="Profile.Name" /> to <see cref="Profile.DefaultName" />. </summary>
		protected XmlBased()
		{
		}

		/// <summary>
		///   Initializes a new instance of the XmlBased class by setting the <see cref="Profile.Name" /> to the given file name. </summary>
		/// <param name="fileName">
		///   The name of the file to initialize the <see cref="Profile.Name" /> property with. </param>
		protected XmlBased(string fileName) :
			base(fileName)
		{
		}

		/// <summary>
		///   Initializes a new instance of the XmlBased class based on another XmlBased object. </summary>
		/// <param name="profile">
		///   The XmlBased profile object whose properties and events are used to initialize the object being constructed. </param>
		protected XmlBased(XmlBased profile) :
			base(profile)
		{
			m_encoding = profile.Encoding;
		}

		/// <summary>
		///   Retrieves an XmlDocument object based on the <see cref="Profile.Name" /> of the file. </summary>
		/// <returns>
		///   If <see cref="Buffering" /> is not enabled, the return value is the XmlDocument object loaded with the file, 
		///   or null if the file does not exist. If <see cref="Buffering" /> is enabled, the return value is an 
		///   XmlDocument object, which will be loaded with the file if it already exists.</returns>
		/// <exception cref="InvalidOperationException">
		///	  <see cref="Profile.Name" /> is null or empty. </exception>
		/// <exception cref="XmlException">
		///	  Parse error in the XML being loaded from the file. </exception>
		protected XmlDocument GetXmlDocument()
		{
			if (m_buffer != null)
				return m_buffer.XmlDocument;

			VerifyName();
			if (!File.Exists(Name))
				return null;

			XmlDocument doc = new XmlDocument();
			doc.Load(Name);
			return doc;
		}

		/// <summary>
		///   Saves any changes pending on an XmlDocument object, unless <see cref="Buffering" /> is enabled. </summary>
		/// <exception cref="XmlException">
		///	  The resulting XML document would not be well formed. </exception>
		/// <remarks>
		///   If <see cref="Buffering" /> is enabled, this method sets the <see cref="XmlBuffer.NeedsFlushing" /> property to true 
		///   and the changes are not saved until the buffer is flushed (or closed).  If the Buffer is not active
		///   the contents of the XmlDocument object are saved to the file. </remarks>
		protected void Save(XmlDocument doc)
		{
			if (m_buffer != null)
				m_buffer.m_needsFlushing = true;
			else
				doc.Save(Name);

		}

		/// <summary>
		///   Activates buffering on this XML-based profile object, if not already active. </summary>
		/// <param name="lockFile">
		///   If true, the file is locked when the buffer is activated so that no other processes can write to it.  
		///   If false, other processes can continue writing to it and the actual contents of the file can get 
		///   out of synch with the contents of the buffer. </param>
		/// <returns>
		///   The return value is an <see cref="XmlBuffer" /> object that may be used to control the buffer used
		///   to read/write values from this XmlBased profile.  </returns>
		/// <exception cref="InvalidOperationException">
		///	  Attempting to lock the file  and the name is null or empty. </exception>
		/// <exception cref="SecurityException">
		///	  Attempting to lock the file without the required permission. </exception>
		/// <exception cref="UnauthorizedAccessException">
		///	  Attempting to lock the file and ReadWrite access is not permitted by the operating system. </exception>
		/// <remarks>
		///   <i>Buffering</i> is the caching of an <see cref="XmlDocument" /> object so that subsequent reads or writes
		///   are all done through it.  This dramatically increases the performance of those operations, but it requires
		///   that the buffer is flushed (or closed) to commit any changes done to the underlying file.
		///   <para>
		///   The XmlBuffer object is created and attached to this XmlBased profile object, if not already present.
		///   If it is already attached, the same object is returned in subsequent calls, until the object is closed. </para>
		///   <para>
		///   Since the XmlBuffer class implements <see cref="IDisposable" />, the <c>using</c> keyword in C# can be 
		///   used to conveniently create the buffer, write to it, and then automatically flush it (when it's disposed).  
		///   Here's an example:
		///   <code> 
		///   using (profile.Buffer(true))
		///   {
		///      profile.SetValue("A Section", "An Entry", "A Value");
		///      profile.SetValue("A Section", "Another Entry", "Another Value");
		///      ...
		///   }
		///   </code></para></remarks>
		/// <seealso cref="XmlBuffer" />
		/// <seealso cref="Buffering" />
		public XmlBuffer Buffer(bool lockFile)
		{
			if (m_buffer == null)
				m_buffer = new XmlBuffer(this, lockFile);
			return m_buffer; 
		}

		/// <summary>
		///   Activates <i>locked</i> buffering on this XML-based profile object, if not already active. </summary>
		/// <returns>
		///   The return value is an <see cref="XmlBuffer" /> object that may be used to control the buffer used
		///   to read/write values from this XmlBased profile.  </returns>
		/// <exception cref="InvalidOperationException">
		///	  Attempting to lock the file  and the name is null or empty. </exception>
		/// <exception cref="SecurityException">
		///	  Attempting to lock the file without the required permission. </exception>
		/// <exception cref="UnauthorizedAccessException">
		///	  Attempting to lock the file and ReadWrite access is not permitted by the operating system. </exception>
		/// <remarks>
		///   <i>Buffering</i> refers to the caching of an <see cref="XmlDocument" /> object so that subsequent reads or writes
		///   are all done through it.  This dramatically increases the performance of those operations, but it requires
		///   that the buffer is flushed (or closed) to commit any changes done to the underlying file.
		///   <para>
		///   The XmlBuffer object is created and attached to this XmlBased profile object, if not already present.
		///   If it is already attached, the same object is returned in subsequent calls, until the object is closed. </para>
		///   <para>
		///   If the buffer is created, the underlying file (if any) is locked so that no other processes 
		///   can write to it. This is equivalent to calling Buffer(true). </para>
		///   <para>
		///   Since the XmlBuffer class implements <see cref="IDisposable" />, the <c>using</c> keyword in C# can be 
		///   used to conveniently create the buffer, write to it, and then automatically flush it (when it's disposed).  
		///   Here's an example:
		///   <code> 
		///   using (profile.Buffer())
		///   {
		///      profile.SetValue("A Section", "An Entry", "A Value");
		///      profile.SetValue("A Section", "Another Entry", "Another Value");
		///      ...
		///   }
		///   </code></para></remarks>
		/// <seealso cref="XmlBuffer" />
		/// <seealso cref="Buffering" />
		public XmlBuffer Buffer()
		{
			return Buffer(true);
		}

		/// <summary>
		///   Gets whether buffering is active or not. </summary>
		/// <remarks>
		///   <i>Buffering</i> is the caching of an <see cref="XmlDocument" /> object so that subsequent reads or writes
		///   are all done through it.  This dramatically increases the performance of those operations, but it requires
		///   that the buffer is flushed (or closed) to commit any changes done to the underlying file.
		///   <para>
		///   This property may be used to determine if the buffer is active without actually activating it.  
		///   The <see cref="Buffer" /> method activates the buffer, which then needs to be flushed (or closed) to update the file. </para></remarks>
		/// <seealso cref="Buffer" />
		/// <seealso cref="XmlBuffer" />
		public bool Buffering
		{
			get 
			{
				return m_buffer != null;
			}
		}

		/// <summary>
		///   Gets or sets the encoding, to be used if the file is created. </summary>
		/// <exception cref="InvalidOperationException">
		///   Setting this property if <see cref="Profile.ReadOnly" /> is true. </exception>
		/// <remarks>
		///   By default this property is set to <see cref="System.Text.Encoding.UTF8">Encoding.UTF8</see>, but it is only 
		///   used when the file is not found and needs to be created to write the value. 
		///   If the file exists, the existing encoding is used and this value is ignored. 
		///   The <see cref="Profile.Changing" /> event is raised before changing this property.  
		///   If its <see cref="ProfileChangingArgs.Cancel" /> property is set to true, this method 
		///   returns immediately without changing this property.  After the property has been changed, 
		///   the <see cref="Profile.Changed" /> event is raised. </remarks>
		public Encoding Encoding
		{
			get 
			{ 
				return m_encoding; 
			}
			set 
			{ 
				VerifyNotReadOnly();
				if (m_encoding == value)
					return;
						
				if (!RaiseChangeEvent(true, ProfileChangeType.Other, null, "Encoding", value))
					return;

				m_encoding = value; 				
				RaiseChangeEvent(false, ProfileChangeType.Other, null, "Encoding", value);				
			}
		}
	}

	/// <summary>
	///   Buffer class for all <see cref="XmlBased" /> Profile classes. </summary>
	/// <remarks>
	///   This class provides buffering functionality for the <see cref="XmlBased" /> classes.
	///   <i>Buffering</i> refers to the caching of an <see cref="XmlDocument" /> object so that subsequent reads or writes
	///   are all done through it.  This dramatically increases the performance of those operations, but it requires
	///   that the buffer is flushed (or closed) to commit any changes done to the underlying file. 
	///   <para>
	///   Since an XmlBased object can only have one buffer attached to it at a time, this class may not
	///   be instanciated directly.  Instead, use the <see cref="XmlBased.Buffer" /> method of the profile object. </para></remarks>
	/// <seealso cref="XmlBased.Buffer" />
	public class XmlBuffer : IDisposable
	{
		private XmlBased m_profile;
		private XmlDocument m_doc;
		private FileStream m_file;
		internal bool m_needsFlushing;

		/// <summary>
		///   Initializes a new instance of the XmlBuffer class and optionally locks the file. </summary>
		/// <param name="profile">
		///   The XmlBased object to associate with the buffer and to assign this object to. </param>
		/// <param name="lockFile">
		///   If true and the file exists, the file is locked to prevent other processes from writing to it
		///   until the buffer is closed. </param>
		/// <exception cref="InvalidOperationException">
		///	  Attempting to lock the file  and the name is null or empty. </exception>
		/// <exception cref="SecurityException">
		///	  Attempting to lock the file without the required permission. </exception>
		/// <exception cref="UnauthorizedAccessException">
		///	  Attempting to lock the file and ReadWrite access is not permitted by the operating system. </exception>
		internal XmlBuffer(XmlBased profile, bool lockFile)
		{
			m_profile = profile;

			if (lockFile)
			{
				m_profile.VerifyName();
				if (File.Exists(m_profile.Name))
					m_file = new FileStream(m_profile.Name, FileMode.Open, m_profile.ReadOnly ? FileAccess.Read : FileAccess.ReadWrite, FileShare.Read);
			}
		}

		/// <summary>
		///   Loads the XmlDocument object with the contents of an XmlTextWriter object. </summary>
		/// <param name="writer">
		///   The XmlTextWriter object to load the XmlDocument with. </param>
		/// <remarks>
		///   This method is used to load the buffer with new data. </remarks>
		internal void Load(XmlTextWriter writer)
		{
			writer.Flush();
			writer.BaseStream.Position = 0;
			m_doc.Load(writer.BaseStream);

			m_needsFlushing = true;
		}

		/// <summary>
		///   Gets the XmlDocument object associated with this buffer, based on the profile's Name. </summary>
		/// <exception cref="InvalidOperationException">
		///	  <see cref="Profile.Name" /> is null or empty. </exception>
		/// <exception cref="XmlException">
		///	  Parse error in the XML being loaded from the file. </exception>
		internal XmlDocument XmlDocument
		{
			get
			{
				if (m_doc == null)
				{
					m_doc = new XmlDocument();

					if (m_file != null)
					{
						m_file.Position = 0;
						m_doc.Load(m_file);
					}
					else
					{
						m_profile.VerifyName();
						if (File.Exists(m_profile.Name))
							m_doc.Load(m_profile.Name);
					}
				}
				return m_doc;
			}
		}

		/// <summary>
		///   Gets whether the buffer's XmlDocument object is empty. </summary>
		internal bool IsEmpty
		{
			get
			{
				return XmlDocument.InnerXml == String.Empty;
			}
		}

		/// <summary>
		///   Gets whether changes have been made to the XmlDocument object that require
		///   the buffer to be flushed so that the file gets updated. </summary>
		/// <remarks>
		///   This property returns true when the XmlDocument object has been changed and the 
		///   <see cref="Flush" /> (or <see cref="Close" />) method needs to be called to 
		///   update the file. </remarks>
		/// <seealso cref="Flush" />
		/// <seealso cref="Close" />
		public bool NeedsFlushing
		{
			get
			{
				return m_needsFlushing;
			}
		}

		/// <summary>
		///   Gets whether the file associated with the buffer's profile is locked. </summary>
		/// <remarks>
		///   This property returns true when this object has been created with the <i>lockFile</i> parameter set to true,
		///   provided the file exists.  When locked, other processes will not be allowed to write to the profile's
		///   file until the buffer is closed. </remarks>
		/// <seealso cref="Close" />
		public bool Locked
		{
			get
			{
				return m_file != null;
			}
		}

		/// <summary>
		///   Writes the contents of the XmlDocument object to the file associated with this buffer's profile. </summary>
		/// <remarks>
		///   This method may be used to explictly commit any changes made to the <see cref="XmlBased" /> profile from the time 
		///   the buffer was last flushed or created.  It writes the contents of the XmlDocument object to the profile's file.
		///   When the buffer is being closed (with <see cref="Close" /> or <see cref="Dispose" />) this method is 
		///   called if <see cref="NeedsFlushing" /> is true. After the buffer is closed, this method may not be called. </remarks>
		/// <exception cref="InvalidOperationException">
		///   This object is closed. </exception>
		/// <seealso cref="Close" />
		/// <seealso cref="Reset" />
		public void Flush()
		{
			if (m_profile == null)
				throw new InvalidOperationException("Cannot flush an XmlBuffer object that has been closed.");

			if (m_doc == null)
				return;

			if (m_file == null)
				m_doc.Save(m_profile.Name);
			else
			{
				m_file.SetLength(0);
				m_doc.Save(m_file);
			}

			m_needsFlushing = false;
		}

		/// <summary>
		///   Resets the buffer by discarding its XmlDocument object. </summary>
		/// <remarks>
		///   This method may be used to rollback any changes made to the <see cref="XmlBased" /> profile from the time 
		///   the buffer was last flushed or created. After the buffer is closed, this method may not be called. </remarks>
		/// <exception cref="InvalidOperationException">
		///   This object is closed. </exception>
		/// <seealso cref="Flush" />
		/// <seealso cref="Close" />
		public void Reset()
		{
			if (m_profile == null)
				throw new InvalidOperationException("Cannot reset an XmlBuffer object that has been closed.");

			m_doc = null;
			m_needsFlushing = false;
		}

		/// <summary>
		///   Closes the buffer by flushing the contents of its XmlDocument object (if necessary) and dettaching itself 
		///   from its <see cref="XmlBased" /> profile. </summary>
		/// <remarks>
		///   This method may be used to explictly deactivate the <see cref="XmlBased" /> profile buffer. 
		///   This means that the buffer is flushed (if <see cref="NeedsFlushing" /> is true) and it gets 
		///   dettached from the profile. The <see cref="Dispose" /> method automatically calls this method. </remarks>
		/// <seealso cref="Flush" />
		/// <seealso cref="Dispose" />
		public void Close()
		{
			if (m_profile == null)
				return;
				
			if (m_needsFlushing)
				Flush();

			m_doc = null;
		
			if (m_file != null)
			{
				m_file.Close();
				m_file = null;
			}

			if (m_profile != null)
				m_profile.m_buffer = null;
			m_profile = null;
		}

		/// <summary>
		///   Disposes of this object's resources by closing the buffer. </summary>
		/// <remarks>
		///   This method calls <see cref="Close" />, which flushes the buffer and dettaches it from the profile. </remarks>
		/// <seealso cref="Close" />
		/// <seealso cref="Flush" />
		public void Dispose()
		{
			Close();
		}
	}
}
