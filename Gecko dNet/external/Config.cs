/*
 * AMS.Profile Class Library
 * 
 * Written by Alvaro Mendez
 * Copyright (c) 2005. All Rights Reserved.
 * 
 * The AMS.Profile namespace contains interfaces and classes that 
 * allow reading and writing of user-profile data.
 * This file contains the Config class.
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
using System.IO;
using System.Text;
using System.Xml;
using System.Reflection;

namespace AMS.Profile
{
	/// <summary>
	///   Profile class that utilizes an XML-formatted .config file to retrieve and save its data. </summary>
	/// <remarks>
	///   Config files are used by Windows and Web apps to store application-specific configuration information.
	///   The System.Configuration namespace contains a variety of classes that may be used to retrieve the data
	///   from config files; however there is no provision for writing to such files.  The reason: they're only 
	///   meant to be read by the program, not written.  For this reason, I initially considered not writing a 
	///   Profile class for config files.  Instead, I created a separate <see cref="Xml" /> class that stores 
	///   profile data in its own XML format, meant for a separate file.  Although that is the preferred choice, 
	///   there may still be some developers who, for whatever reason, need a way to write to config files at 
	///   run-time.  If you're one of those, this class is for you.
	///   <para> 
	///   By default this class formats the data inside the config file as follows.  
	///   (Notice that XML elements cannot contain spaces so this class converts them to underscores.) </para> 
	///   <code> 
	///   &lt;configuration&gt;
	///     &lt;configSections&gt; 
	///       &lt;sectionGroup name="profile"&gt;
	///         &lt;section name="A_Section" type="System.Configuration.NameValueSectionHandler, System, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, Custom=null" /&gt;
	///         &lt;section name="Another_Section" type="System.Configuration.NameValueSectionHandler, System, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, Custom=null" /&gt;
	///       &lt;/sectionGroup&gt;
	///     &lt;/configSections&gt;
	///     &lt;appSettings&gt;
	///       &lt;add key="App Entry" value="App Value" /&gt;
	///     &lt;/appSettings&gt;
	///     &lt;profile&gt;
	///       &lt;A_Section&gt;
	///         &lt;add key="An Entry" value="Some Value" /&gt;
	///         &lt;add key="Another Entry" value="Another Value" /&gt;
	///       &lt;/A_Section&gt;
	///       &lt;Another_Section&gt;
	///         &lt;add key="This is cool" value="True" /&gt;
	///       &lt;/Another_Section&gt;
	///     &lt;/profile&gt;
	///   &lt;/configuration&gt;
	///   </code>
	///   <para> 
	///   If you wanted to read the value of "A_Section/An Entry" using the System.Configuration classes, you'd do it using the following code: </para>
	///   <code> 
	///   NameValueCollection section = (NameValueCollection)ConfigurationSettings.GetConfig("profile/A_Section");
	///   string value = section["An Entry"];
	///   </code>
	///   <para> 
	///   One thing to keep in mind is that .NET caches the config data as it reads it, so any subsequent 
	///   updates to it on the file will not be seen by the System.Configuration classes, at least for Windows apps.
	///   The Config class, however, has no such problem since the data is read from the file every time,
	///   unless <see cref="XmlBased.Buffering" /> is enabled.
	///   The equivalent of the above code would look like this: </para>
	///   <code> 
	///   Config config = new Config();
	///   string value = config.GetValue("A Section", "An Entry", null);
	///   </code> 
	///   <para> 
	///   As a bonus, you may use the Config class to access the "appSettings" section by clearing the
	///   GroupName property.  Here's an example: </para>
	///   <code> 
	///   Config config = new Config();
	///   config.GroupName = null;  // don't use a section group
	///   ...
	///   string value = config.GetValue("appSettings", "App Entry", null);
	///   config.SetValue("appSettings", "Update Date", DateTime.Today);
	///   </code>
	///   </remarks>
	public class Config : XmlBased
	{
		// Fields
		private string m_groupName = "profile";
		private const string SECTION_TYPE = "System.Configuration.NameValueSectionHandler, System, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, Custom=null";

		/// <summary>
		///   Initializes a new instance of the Config class by setting the <see cref="Profile.Name" /> to <see cref="Profile.DefaultName" />. </summary>
		public Config()
		{
		}

		/// <summary>
		///   Initializes a new instance of the Config class by setting the <see cref="Profile.Name" /> to the given file name. </summary>
		/// <param name="fileName">
		///   The name of the Config file to initialize the <see cref="Profile.Name" /> property with. </param>
		public Config(string fileName) :
			base(fileName)
		{
		}

		/// <summary>
		///   Initializes a new instance of the Config class based on another Config object. </summary>
		/// <param name="config">
		///   The Config object whose properties and events are used to initialize the object being constructed. </param>
		public Config(Config config) :
			base(config)
		{
			m_groupName = config.m_groupName;
		}

		/// <summary>
		///   Gets the default name for the Config file. </summary>
		/// <remarks>
		///   For Windows apps, this property returns the name of the executable plus .config ("program.exe.config").
		///   For Web apps, this property returns the full path of the <i>web.config</i> file.
		///   This property is used to set the <see cref="Profile.Name" /> property inside the default constructor.</remarks>
		public override string DefaultName
		{
			get
			{
				return DefaultNameWithoutExtension + ".config";
			}
		}

		/// <summary>
		///   Retrieves a copy of itself. </summary>
		/// <returns>
		///   The return value is a copy of itself as an object. </returns>
		/// <seealso cref="Profile.CloneReadOnly" />
		public override object Clone()
		{
			return new Config(this);
		}

		/// <summary>
		///   Gets or sets the name of the element under which all sections should be located. </summary>
		/// <exception cref="InvalidOperationException">
		///   Setting this property if <see cref="Profile.ReadOnly" /> is true. </exception>
		/// <exception cref="XmlException">
		///   The value being set contains an namespace prefix (eg, <b>prefix:</b>whatever). </exception>
		/// <remarks>
		///   By default this property is set to "profile".  This means that the sections come as
		///   descendants of "configuration\profile".  However, this property may be set to null so that
		///   all sections can be placed directly under "configuration".  This is useful for reading/writing
		///   the popular "appSettings" section, which may also be retrieved via the System.Configuration.ConfigurationSettings.AppSettings property.
		///   <para>The <see cref="Profile.Changing" /> event is raised before changing this property.  
		///   If its <see cref="ProfileChangingArgs.Cancel" /> property is set to true, this method 
		///   returns immediately without changing this property.  After the property has been changed, 
		///   the <see cref="Profile.Changed" /> event is raised.</para> </remarks>
		public string GroupName
		{
			get 
			{ 
				return m_groupName; 
			}
			set 
			{ 
				VerifyNotReadOnly();
				if (m_groupName == value)
					return;

				if (!RaiseChangeEvent(true, ProfileChangeType.Other, null, "GroupName", value))
					return;

				m_groupName = value; 
				if (m_groupName != null)
				{
					m_groupName = m_groupName.Replace(' ', '_');

					if (m_groupName.IndexOf(':') >= 0)
						throw new XmlException("GroupName may not contain a namespace prefix.");
				}

				RaiseChangeEvent(false, ProfileChangeType.Other, null, "GroupName", value);				
			}
		}

		/// <summary>
		///   Gets whether we have a valid GroupName. </summary>
		private bool HasGroupName
		{
			get
			{
				return m_groupName != null && m_groupName != "";
			}
		}
		
		/// <summary>
		///   Gets the name of the GroupName plus a slash or an empty string is HasGroupName is false. </summary>
		/// <remarks>
		///   This property helps us when retrieving sections. </remarks>
		private string GroupNameSlash
		{
			get 
			{ 
				return (HasGroupName ? (m_groupName + "/") : "");
			}
		}

		/// <summary>
		///   Retrieves whether we don't have a valid GroupName and a given section is 
		///   equal to "appSettings". </summary>
		/// <remarks>
		///   This method helps us determine whether we need to deal with the "configuration\configSections" element. </remarks>
		private bool IsAppSettings(string section)
		{
			return !HasGroupName && section != null && section == "appSettings";
		}

		/// <summary>
		///   Verifies the given section name is not null and trims it. </summary>
		/// <param name="section">
		///   The section name to verify and adjust. </param>
		/// <exception cref="ArgumentNullException">
		///   section is null. </exception>
		/// <remarks>
		///   This method first calls <see cref="Profile.VerifyAndAdjustSection">Profile.VerifyAndAdjustSection</see> 
		///   and then replaces any spaces in the section with underscores.  This is needed 
		///   because XML element names may not contain spaces.  </remarks>
		/// <seealso cref="Profile.VerifyAndAdjustEntry" />
		protected override void VerifyAndAdjustSection(ref string section)
		{
			base.VerifyAndAdjustSection(ref section);
			if (section.IndexOf(' ') >= 0)
				section = section.Replace(' ', '_');
		}

		/// <summary>
		///   Sets the value for an entry inside a section. </summary>
		/// <param name="section">
		///   The name of the section that holds the entry. </param>
		/// <param name="entry">
		///   The name of the entry where the value will be set. </param>
		/// <param name="value">
		///   The value to set. If it's null, the entry is removed. </param>
		/// <exception cref="InvalidOperationException">
		///   <see cref="Profile.Name" /> is null or empty, 
		///   <see cref="Profile.ReadOnly" /> is true, or
		///   the resulting XML document is invalid. </exception>
		/// <exception cref="ArgumentNullException">
		///   Either section or entry is null. </exception>
		/// <exception cref="XmlException">
		///	  Parse error in the XML being loaded from the file or
		///	  the resulting XML document would not be well formed. </exception>
		/// <remarks>
		///   If the Config file does not exist, it is created.
		///   The <see cref="Profile.Changing" /> event is raised before setting the value.  
		///   If its <see cref="ProfileChangingArgs.Cancel" /> property is set to true, this method 
		///   returns immediately without setting the value.  After the value has been set, 
		///   the <see cref="Profile.Changed" /> event is raised.
		///   <para>
		///   Note: If <see cref="XmlBased.Buffering" /> is enabled, the value is not actually written to the
		///   Config file until the buffer is flushed (or closed). </para></remarks>
		/// <seealso cref="GetValue" />
		public override void SetValue(string section, string entry, object value)
		{
			// If the value is null, remove the entry
			if (value == null)
			{
				RemoveEntry(section, entry);
				return;
			}

			VerifyNotReadOnly();
			VerifyName();
			VerifyAndAdjustSection(ref section);
			VerifyAndAdjustEntry(ref entry);

			if (!RaiseChangeEvent(true, ProfileChangeType.SetValue, section, entry, value))
				return;
			
			bool hasGroupName = HasGroupName;
			bool isAppSettings = IsAppSettings(section);
			
			// If the file does not exist, use the writer to quickly create it
			if ((m_buffer == null || m_buffer.IsEmpty) && !File.Exists(Name))
			{				
				XmlTextWriter writer = null;
				
				// If there's a buffer, write to it without creating the file
				if (m_buffer == null)
					writer = new XmlTextWriter(Name, Encoding);			
				else
					writer = new XmlTextWriter(new MemoryStream(), Encoding);			

				writer.Formatting = Formatting.Indented;
	            
	            writer.WriteStartDocument();
				
	            writer.WriteStartElement("configuration");			
				if (!isAppSettings)
				{
					writer.WriteStartElement("configSections");
					if (hasGroupName)
					{
						writer.WriteStartElement("sectionGroup");
						writer.WriteAttributeString("name", null, m_groupName);				
					}
					writer.WriteStartElement("section");
					writer.WriteAttributeString("name", null, section);				
					writer.WriteAttributeString("type", null, SECTION_TYPE);
        			writer.WriteEndElement();

					if (hasGroupName)
            			writer.WriteEndElement();
           			writer.WriteEndElement();
				}
				if (hasGroupName)
					writer.WriteStartElement(m_groupName);
				writer.WriteStartElement(section);
				writer.WriteStartElement("add");
				writer.WriteAttributeString("key", null, entry);				
				writer.WriteAttributeString("value", null, value.ToString());
    			writer.WriteEndElement();
    			writer.WriteEndElement();
				if (hasGroupName)
           			writer.WriteEndElement();
       			writer.WriteEndElement();
			
				if (m_buffer != null)
					m_buffer.Load(writer);
				writer.Close();   				

				RaiseChangeEvent(false, ProfileChangeType.SetValue, section, entry, value);
				return;
			}
			
			// The file exists, edit it
			
			XmlDocument doc = GetXmlDocument();
			XmlElement root = doc.DocumentElement;
			
			XmlAttribute attribute = null;
			XmlNode sectionNode = null;
			
			// Check if we need to deal with the configSections element
			if (!isAppSettings)
			{
				// Get the configSections element and add it if it's not there
				XmlNode sectionsNode = root.SelectSingleNode("configSections");
				if (sectionsNode == null)
					sectionsNode = root.AppendChild(doc.CreateElement("configSections"));			
	
				XmlNode sectionGroupNode = sectionsNode;
				if (hasGroupName)
				{
					// Get the sectionGroup element and add it if it's not there
					sectionGroupNode = sectionsNode.SelectSingleNode("sectionGroup[@name=\"" + m_groupName + "\"]");
					if (sectionGroupNode == null)
					{
						XmlElement element = doc.CreateElement("sectionGroup");
						attribute = doc.CreateAttribute("name");
						attribute.Value = m_groupName;
						element.Attributes.Append(attribute);			
						sectionGroupNode = sectionsNode.AppendChild(element);			
					}
				}
	
				// Get the section element and add it if it's not there
				sectionNode = sectionGroupNode.SelectSingleNode("section[@name=\"" + section + "\"]");
				if (sectionNode == null)
				{
					XmlElement element = doc.CreateElement("section");
					attribute = doc.CreateAttribute("name");
					attribute.Value = section;
					element.Attributes.Append(attribute);			
	
					sectionNode = sectionGroupNode.AppendChild(element);			
				}
	
				// Update the type attribute
				attribute = doc.CreateAttribute("type");
				attribute.Value = SECTION_TYPE;
				sectionNode.Attributes.Append(attribute);			
			}

			// Get the element with the sectionGroup name and add it if it's not there
			XmlNode groupNode = root;
			if (hasGroupName)
			{
				groupNode = root.SelectSingleNode(m_groupName);
				if (groupNode == null)
					groupNode = root.AppendChild(doc.CreateElement(m_groupName));			
			}

			// Get the element with the section name and add it if it's not there
			sectionNode = groupNode.SelectSingleNode(section);
			if (sectionNode == null)
				sectionNode = groupNode.AppendChild(doc.CreateElement(section));			

			// Get the 'add' element and add it if it's not there
			XmlNode entryNode = sectionNode.SelectSingleNode("add[@key=\"" + entry + "\"]");
			if (entryNode == null)
			{
				XmlElement element = doc.CreateElement("add");
				attribute = doc.CreateAttribute("key");
				attribute.Value = entry;
				element.Attributes.Append(attribute);			

				entryNode = sectionNode.AppendChild(element);			
			}

			// Update the value attribute
			attribute = doc.CreateAttribute("value");
			attribute.Value = value.ToString();
			entryNode.Attributes.Append(attribute);			

			// Save the file
			Save(doc);
			RaiseChangeEvent(false, ProfileChangeType.SetValue, section, entry, value);
		}

		/// <summary>
		///   Retrieves the value of an entry inside a section. </summary>
		/// <param name="section">
		///   The name of the section that holds the entry with the value. </param>
		/// <param name="entry">
		///   The name of the entry where the value is stored. </param>
		/// <returns>
		///   The return value is the entry's value, or null if the entry does not exist. </returns>
		/// <exception cref="InvalidOperationException">
		///	  <see cref="Profile.Name" /> is null or empty. </exception>
		/// <exception cref="ArgumentNullException">
		///   Either section or entry is null. </exception>
		/// <exception cref="XmlException">
		///	  Parse error in the XML being loaded from the file. </exception>
		/// <exception cref="NullReferenceException">
		///   'value' attribute is missing from the entry node. </exception>
		/// <seealso cref="SetValue" />
		/// <seealso cref="Profile.HasEntry" />
		public override object GetValue(string section, string entry)
		{
			VerifyAndAdjustSection(ref section);
			VerifyAndAdjustEntry(ref entry);

			try
			{
				XmlDocument doc = GetXmlDocument();
				XmlElement root = doc.DocumentElement;				
				
				XmlNode entryNode = root.SelectSingleNode(GroupNameSlash + section + "/add[@key=\"" + entry + "\"]");
				return entryNode.Attributes["value"].Value;
			}
			catch
			{				
				return null;
			}
		}

		/// <summary>
		///   Removes an entry from a section. </summary>
		/// <param name="section">
		///   The name of the section that holds the entry. </param>
		/// <param name="entry">
		///   The name of the entry to remove. </param>
		/// <exception cref="InvalidOperationException">
		///	  <see cref="Profile.Name" /> is null or empty or
		///   <see cref="Profile.ReadOnly" /> is true. </exception>
		/// <exception cref="ArgumentNullException">
		///   Either section or entry is null. </exception>
		/// <exception cref="XmlException">
		///	  Parse error in the XML being loaded from the file or
		///	  the resulting XML document would not be well formed. </exception>
		/// <remarks>
		///   The <see cref="Profile.Changing" /> event is raised before removing the entry.  
		///   If its <see cref="ProfileChangingArgs.Cancel" /> property is set to true, this method 
		///   returns immediately without removing the entry.  After the entry has been removed, 
		///   the <see cref="Profile.Changed" /> event is raised. 
		///   <para>
		///   Note: If <see cref="XmlBased.Buffering" /> is enabled, the entry is not removed from the
		///   Config file until the buffer is flushed (or closed). </para></remarks>
		/// <seealso cref="RemoveSection" />
		public override void RemoveEntry(string section, string entry)
		{
			VerifyNotReadOnly();
			VerifyAndAdjustSection(ref section);
			VerifyAndAdjustEntry(ref entry);

			// Verify the document exists
			XmlDocument doc = GetXmlDocument();
			if (doc == null)
				return;

			// Get the entry's node, if it exists
			XmlElement root = doc.DocumentElement;			
			XmlNode entryNode = root.SelectSingleNode(GroupNameSlash + section + "/add[@key=\"" + entry + "\"]");
			if (entryNode == null)
				return;

			if (!RaiseChangeEvent(true, ProfileChangeType.RemoveEntry, section, entry, null))
				return;
			
			entryNode.ParentNode.RemoveChild(entryNode);			
			Save(doc);
			RaiseChangeEvent(false, ProfileChangeType.RemoveEntry, section, entry, null);
		}

		/// <summary>
		///   Removes a section. </summary>
		/// <param name="section">
		///   The name of the section to remove. </param>
		/// <exception cref="InvalidOperationException">
		///	  <see cref="Profile.Name" /> is null or empty or
		///   <see cref="Profile.ReadOnly" /> is true. </exception>
		/// <exception cref="ArgumentNullException">
		///   section is null. </exception>
		/// <exception cref="XmlException">
		///	  Parse error in the XML being loaded from the file or
		///	  the resulting XML document would not be well formed. </exception>
		/// <remarks>
		///   The <see cref="Profile.Changing" /> event is raised before removing the section.  
		///   If its <see cref="ProfileChangingArgs.Cancel" /> property is set to true, this method 
		///   returns immediately without removing the section.  After the section has been removed, 
		///   the <see cref="Profile.Changed" /> event is raised.
		///   <para>
		///   Note: If <see cref="XmlBased.Buffering" /> is enabled, the section is not removed from the
		///   Config file until the buffer is flushed (or closed). </para></remarks>
		/// <seealso cref="RemoveEntry" />
		public override void RemoveSection(string section)
		{
			VerifyNotReadOnly();
			VerifyAndAdjustSection(ref section);

			// Verify the document exists
			XmlDocument doc = GetXmlDocument();
			if (doc == null)
				return;

			// Get the root node, if it exists
			XmlElement root = doc.DocumentElement;
			if (root == null)
				return;

			// Get the section's node, if it exists
			XmlNode sectionNode = root.SelectSingleNode(GroupNameSlash + section);
			if (sectionNode == null)
				return;
			
			if (!RaiseChangeEvent(true, ProfileChangeType.RemoveSection, section, null, null))
				return;
			
			sectionNode.ParentNode.RemoveChild(sectionNode);

			// Delete the configSections entry also			
			if (!IsAppSettings(section))
			{											
				sectionNode = root.SelectSingleNode("configSections/" + (HasGroupName ? ("sectionGroup[@name=\"" + m_groupName + "\"]") : "") + "/section[@name=\"" + section + "\"]");
				if (sectionNode == null)
					return;
			
				sectionNode.ParentNode.RemoveChild(sectionNode);
			}
			
			Save(doc);
			RaiseChangeEvent(false, ProfileChangeType.RemoveSection, section, null, null);
		}

		/// <summary>
		///   Retrieves the names of all the entries inside a section. </summary>
		/// <param name="section">
		///   The name of the section holding the entries. </param>
		/// <returns>
		///   If the section exists, the return value is an array with the names of its entries; 
		///   otherwise it's null. </returns>
		/// <exception cref="InvalidOperationException">
		///	  <see cref="Profile.Name" /> is null or empty. </exception>
		/// <exception cref="ArgumentNullException">
		///   section is null. </exception>
		/// <exception cref="XmlException">
		///	  Parse error in the XML being loaded from the file. </exception>
		/// <seealso cref="Profile.HasEntry" />
		/// <seealso cref="GetSectionNames" />
		public override string[] GetEntryNames(string section)
		{
			// Verify the section exists
			if (!HasSection(section))
				return null;
			    			
			VerifyAndAdjustSection(ref section);
			XmlDocument doc = GetXmlDocument();
			XmlElement root = doc.DocumentElement;
			
			// Get the entry nodes
			XmlNodeList entryNodes = root.SelectNodes(GroupNameSlash + section + "/add[@key]");
			if (entryNodes == null)
				return null;

			// Add all entry names to the string array			
			string[] entries = new string[entryNodes.Count];
			int i = 0;
			
			foreach (XmlNode node in entryNodes)
				entries[i++] = node.Attributes["key"].Value;
			
			return entries;
		}
		
		/// <summary>
		///   Retrieves the names of all the sections. </summary>
		/// <returns>
		///   If the Config file exists, the return value is an array with the names of all the sections;
		///   otherwise it's null. </returns>
		/// <exception cref="InvalidOperationException">
		///	  <see cref="Profile.Name" /> is null or empty. </exception>
		/// <exception cref="XmlException">
		///	  Parse error in the XML being loaded from the file. </exception>
		/// <seealso cref="Profile.HasSection" />
		/// <seealso cref="GetEntryNames" />
		public override string[] GetSectionNames()
		{
			// Verify the document exists
			XmlDocument doc = GetXmlDocument();
			if (doc == null)
				return null;

			// Get the root node, if it exists
			XmlElement root = doc.DocumentElement;
			if (root == null)
				return null;

			// Get the group node
			XmlNode groupNode = (HasGroupName ? root.SelectSingleNode(m_groupName) : root);
			if (groupNode == null)
				return null;

			// Get the section nodes
			XmlNodeList sectionNodes = groupNode.ChildNodes;
			if (sectionNodes == null)
				return null;

			// Add all section names to the string array			
			string[] sections = new string[sectionNodes.Count];			
			int i = 0;

			foreach (XmlNode node in sectionNodes)
				sections[i++] = node.Name;
			
			return sections;
		}		
	}
}
