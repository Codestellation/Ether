//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Codestellation.Ether.Config
{
    
    
    /// <summary>
    /// The EtherConfigSection Configuration Section.
    /// </summary>
    public partial class EtherConfigSection : global::System.Configuration.ConfigurationSection
    {
        
        #region Singleton Instance
        /// <summary>
        /// The XML name of the EtherConfigSection Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        internal const string EtherConfigSectionSectionName = "ether";
        
        /// <summary>
        /// Gets the EtherConfigSection instance.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public static global::Codestellation.Ether.Config.EtherConfigSection Instance
        {
            get
            {
                return ((global::Codestellation.Ether.Config.EtherConfigSection)(global::System.Configuration.ConfigurationManager.GetSection(global::Codestellation.Ether.Config.EtherConfigSection.EtherConfigSectionSectionName)));
            }
        }
        #endregion
        
        #region Xmlns Property
        /// <summary>
        /// The XML name of the <see cref="Xmlns"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        internal const string XmlnsPropertyName = "xmlns";
        
        /// <summary>
        /// Gets the XML namespace of this Configuration Section.
        /// </summary>
        /// <remarks>
        /// This property makes sure that if the configuration file contains the XML namespace,
        /// the parser doesn't throw an exception because it encounters the unknown "xmlns" attribute.
        /// </remarks>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Ether.Config.EtherConfigSection.XmlnsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string Xmlns
        {
            get
            {
                return ((string)(base[global::Codestellation.Ether.Config.EtherConfigSection.XmlnsPropertyName]));
            }
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region TemplatesFolder Property
        /// <summary>
        /// The XML name of the <see cref="TemplatesFolder"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        internal const string TemplatesFolderPropertyName = "templatesFolder";
        
        /// <summary>
        /// Gets or sets the TemplatesFolder.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        [global::System.ComponentModel.DescriptionAttribute("The TemplatesFolder.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Ether.Config.EtherConfigSection.TemplatesFolderPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual string TemplatesFolder
        {
            get
            {
                return ((string)(base[global::Codestellation.Ether.Config.EtherConfigSection.TemplatesFolderPropertyName]));
            }
            set
            {
                base[global::Codestellation.Ether.Config.EtherConfigSection.TemplatesFolderPropertyName] = value;
            }
        }
        #endregion
        
        #region FromAddress Property
        /// <summary>
        /// The XML name of the <see cref="FromAddress"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        internal const string FromAddressPropertyName = "fromAddress";
        
        /// <summary>
        /// Gets or sets the FromAddress.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        [global::System.ComponentModel.DescriptionAttribute("The FromAddress.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Ether.Config.EtherConfigSection.FromAddressPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual string FromAddress
        {
            get
            {
                return ((string)(base[global::Codestellation.Ether.Config.EtherConfigSection.FromAddressPropertyName]));
            }
            set
            {
                base[global::Codestellation.Ether.Config.EtherConfigSection.FromAddressPropertyName] = value;
            }
        }
        #endregion
        
        #region MailingRules Property
        /// <summary>
        /// The XML name of the <see cref="MailingRules"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        internal const string MailingRulesPropertyName = "rules";
        
        /// <summary>
        /// Gets or sets the MailingRules.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        [global::System.ComponentModel.DescriptionAttribute("The MailingRules.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Ether.Config.EtherConfigSection.MailingRulesPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Codestellation.Ether.Config.MailingRulesConfigElementCollection MailingRules
        {
            get
            {
                return ((global::Codestellation.Ether.Config.MailingRulesConfigElementCollection)(base[global::Codestellation.Ether.Config.EtherConfigSection.MailingRulesPropertyName]));
            }
            set
            {
                base[global::Codestellation.Ether.Config.EtherConfigSection.MailingRulesPropertyName] = value;
            }
        }
        #endregion
        
        #region MailingGroups Property
        /// <summary>
        /// The XML name of the <see cref="MailingGroups"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        internal const string MailingGroupsPropertyName = "groups";
        
        /// <summary>
        /// Gets or sets the MailingGroups.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        [global::System.ComponentModel.DescriptionAttribute("The MailingGroups.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Ether.Config.EtherConfigSection.MailingGroupsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Codestellation.Ether.Config.GroupConfigElementCollection MailingGroups
        {
            get
            {
                return ((global::Codestellation.Ether.Config.GroupConfigElementCollection)(base[global::Codestellation.Ether.Config.EtherConfigSection.MailingGroupsPropertyName]));
            }
            set
            {
                base[global::Codestellation.Ether.Config.EtherConfigSection.MailingGroupsPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Codestellation.Ether.Config
{
    
    
    /// <summary>
    /// A collection of MailingRuleConfigurationElement instances.
    /// </summary>
    [global::System.Configuration.ConfigurationCollectionAttribute(typeof(global::Codestellation.Ether.Config.MailingRuleConfigurationElement), CollectionType=global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate, AddItemName=global::Codestellation.Ether.Config.MailingRulesConfigElementCollection.MailingRuleConfigurationElementPropertyName)]
    public partial class MailingRulesConfigElementCollection : global::System.Configuration.ConfigurationElementCollection
    {
        
        #region Constants
        /// <summary>
        /// The XML name of the individual <see cref="global::Codestellation.Ether.Config.MailingRuleConfigurationElement"/> instances in this collection.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        internal const string MailingRuleConfigurationElementPropertyName = "rule";
        #endregion
        
        #region Overrides
        /// <summary>
        /// Gets the type of the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>The <see cref="global::System.Configuration.ConfigurationElementCollectionType"/> of this collection.</returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public override global::System.Configuration.ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        
        /// <summary>
        /// Gets the name used to identify this collection of elements
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        protected override string ElementName
        {
            get
            {
                return global::Codestellation.Ether.Config.MailingRulesConfigElementCollection.MailingRuleConfigurationElementPropertyName;
            }
        }
        
        /// <summary>
        /// Indicates whether the specified <see cref="global::System.Configuration.ConfigurationElement"/> exists in the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="elementName">The name of the element to verify.</param>
        /// <returns>
        /// <see langword="true"/> if the element exists in the collection; otherwise, <see langword="false"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        protected override bool IsElementName(string elementName)
        {
            return (elementName == global::Codestellation.Ether.Config.MailingRulesConfigElementCollection.MailingRuleConfigurationElementPropertyName);
        }
        
        /// <summary>
        /// Gets the element key for the specified configuration element.
        /// </summary>
        /// <param name="element">The <see cref="global::System.Configuration.ConfigurationElement"/> to return the key for.</param>
        /// <returns>
        /// An <see cref="object"/> that acts as the key for the specified <see cref="global::System.Configuration.ConfigurationElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        protected override object GetElementKey(global::System.Configuration.ConfigurationElement element)
        {
            return ((global::Codestellation.Ether.Config.MailingRuleConfigurationElement)(element)).Name;
        }
        
        /// <summary>
        /// Creates a new <see cref="global::Codestellation.Ether.Config.MailingRuleConfigurationElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="global::Codestellation.Ether.Config.MailingRuleConfigurationElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        protected override global::System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new global::Codestellation.Ether.Config.MailingRuleConfigurationElement();
        }
        #endregion
        
        #region Indexer
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Ether.Config.MailingRuleConfigurationElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::Codestellation.Ether.Config.MailingRuleConfigurationElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public global::Codestellation.Ether.Config.MailingRuleConfigurationElement this[int index]
        {
            get
            {
                return ((global::Codestellation.Ether.Config.MailingRuleConfigurationElement)(base.BaseGet(index)));
            }
        }
        
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Ether.Config.MailingRuleConfigurationElement"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::Codestellation.Ether.Config.MailingRuleConfigurationElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public global::Codestellation.Ether.Config.MailingRuleConfigurationElement this[object name]
        {
            get
            {
                return ((global::Codestellation.Ether.Config.MailingRuleConfigurationElement)(base.BaseGet(name)));
            }
        }
        #endregion
        
        #region Add
        /// <summary>
        /// Adds the specified <see cref="global::Codestellation.Ether.Config.MailingRuleConfigurationElement"/> to the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="rule">The <see cref="global::Codestellation.Ether.Config.MailingRuleConfigurationElement"/> to add.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public void Add(global::Codestellation.Ether.Config.MailingRuleConfigurationElement rule)
        {
            base.BaseAdd(rule);
        }
        #endregion
        
        #region Remove
        /// <summary>
        /// Removes the specified <see cref="global::Codestellation.Ether.Config.MailingRuleConfigurationElement"/> from the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="rule">The <see cref="global::Codestellation.Ether.Config.MailingRuleConfigurationElement"/> to remove.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public void Remove(global::Codestellation.Ether.Config.MailingRuleConfigurationElement rule)
        {
            base.BaseRemove(this.GetElementKey(rule));
        }
        #endregion
        
        #region GetItem
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Ether.Config.MailingRuleConfigurationElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::Codestellation.Ether.Config.MailingRuleConfigurationElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public global::Codestellation.Ether.Config.MailingRuleConfigurationElement GetItemAt(int index)
        {
            return ((global::Codestellation.Ether.Config.MailingRuleConfigurationElement)(base.BaseGet(index)));
        }
        
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Ether.Config.MailingRuleConfigurationElement"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::Codestellation.Ether.Config.MailingRuleConfigurationElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public global::Codestellation.Ether.Config.MailingRuleConfigurationElement GetItemByKey(string name)
        {
            return ((global::Codestellation.Ether.Config.MailingRuleConfigurationElement)(base.BaseGet(((object)(name)))));
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }
}
namespace Codestellation.Ether.Config
{
    
    
    /// <summary>
    /// The MailingRuleConfigurationElement Configuration Element.
    /// </summary>
    public partial class MailingRuleConfigurationElement : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region Name Property
        /// <summary>
        /// The XML name of the <see cref="Name"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        internal const string NamePropertyName = "name";
        
        /// <summary>
        /// Gets the Name.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        [global::System.ComponentModel.DescriptionAttribute("The Name.")]
        [global::System.ComponentModel.ReadOnlyAttribute(true)]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Ether.Config.MailingRuleConfigurationElement.NamePropertyName, IsRequired=true, IsKey=true, IsDefaultCollection=false)]
        public virtual string Name
        {
            get
            {
                return ((string)(base[global::Codestellation.Ether.Config.MailingRuleConfigurationElement.NamePropertyName]));
            }
        }
        #endregion
        
        #region Recepients Property
        /// <summary>
        /// The XML name of the <see cref="Recepients"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        internal const string RecepientsPropertyName = "recepients";
        
        /// <summary>
        /// Gets the Recepients.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        [global::System.ComponentModel.DescriptionAttribute("The Recepients.")]
        [global::System.ComponentModel.ReadOnlyAttribute(true)]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Ether.Config.MailingRuleConfigurationElement.RecepientsPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual string Recepients
        {
            get
            {
                return ((string)(base[global::Codestellation.Ether.Config.MailingRuleConfigurationElement.RecepientsPropertyName]));
            }
        }
        #endregion
    }
}
namespace Codestellation.Ether.Config
{
    
    
    /// <summary>
    /// A collection of GroupConfigElement instances.
    /// </summary>
    [global::System.Configuration.ConfigurationCollectionAttribute(typeof(global::Codestellation.Ether.Config.GroupConfigElement), CollectionType=global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate, AddItemName=global::Codestellation.Ether.Config.GroupConfigElementCollection.GroupConfigElementPropertyName)]
    public partial class GroupConfigElementCollection : global::System.Configuration.ConfigurationElementCollection
    {
        
        #region Constants
        /// <summary>
        /// The XML name of the individual <see cref="global::Codestellation.Ether.Config.GroupConfigElement"/> instances in this collection.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        internal const string GroupConfigElementPropertyName = "group";
        #endregion
        
        #region Overrides
        /// <summary>
        /// Gets the type of the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>The <see cref="global::System.Configuration.ConfigurationElementCollectionType"/> of this collection.</returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public override global::System.Configuration.ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        
        /// <summary>
        /// Gets the name used to identify this collection of elements
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        protected override string ElementName
        {
            get
            {
                return global::Codestellation.Ether.Config.GroupConfigElementCollection.GroupConfigElementPropertyName;
            }
        }
        
        /// <summary>
        /// Indicates whether the specified <see cref="global::System.Configuration.ConfigurationElement"/> exists in the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="elementName">The name of the element to verify.</param>
        /// <returns>
        /// <see langword="true"/> if the element exists in the collection; otherwise, <see langword="false"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        protected override bool IsElementName(string elementName)
        {
            return (elementName == global::Codestellation.Ether.Config.GroupConfigElementCollection.GroupConfigElementPropertyName);
        }
        
        /// <summary>
        /// Gets the element key for the specified configuration element.
        /// </summary>
        /// <param name="element">The <see cref="global::System.Configuration.ConfigurationElement"/> to return the key for.</param>
        /// <returns>
        /// An <see cref="object"/> that acts as the key for the specified <see cref="global::System.Configuration.ConfigurationElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        protected override object GetElementKey(global::System.Configuration.ConfigurationElement element)
        {
            return ((global::Codestellation.Ether.Config.GroupConfigElement)(element)).Name;
        }
        
        /// <summary>
        /// Creates a new <see cref="global::Codestellation.Ether.Config.GroupConfigElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="global::Codestellation.Ether.Config.GroupConfigElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        protected override global::System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new global::Codestellation.Ether.Config.GroupConfigElement();
        }
        #endregion
        
        #region Indexer
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Ether.Config.GroupConfigElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::Codestellation.Ether.Config.GroupConfigElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public global::Codestellation.Ether.Config.GroupConfigElement this[int index]
        {
            get
            {
                return ((global::Codestellation.Ether.Config.GroupConfigElement)(base.BaseGet(index)));
            }
        }
        
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Ether.Config.GroupConfigElement"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::Codestellation.Ether.Config.GroupConfigElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public global::Codestellation.Ether.Config.GroupConfigElement this[object name]
        {
            get
            {
                return ((global::Codestellation.Ether.Config.GroupConfigElement)(base.BaseGet(name)));
            }
        }
        #endregion
        
        #region Add
        /// <summary>
        /// Adds the specified <see cref="global::Codestellation.Ether.Config.GroupConfigElement"/> to the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="group">The <see cref="global::Codestellation.Ether.Config.GroupConfigElement"/> to add.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public void Add(global::Codestellation.Ether.Config.GroupConfigElement group)
        {
            base.BaseAdd(group);
        }
        #endregion
        
        #region Remove
        /// <summary>
        /// Removes the specified <see cref="global::Codestellation.Ether.Config.GroupConfigElement"/> from the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="group">The <see cref="global::Codestellation.Ether.Config.GroupConfigElement"/> to remove.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public void Remove(global::Codestellation.Ether.Config.GroupConfigElement group)
        {
            base.BaseRemove(this.GetElementKey(group));
        }
        #endregion
        
        #region GetItem
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Ether.Config.GroupConfigElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::Codestellation.Ether.Config.GroupConfigElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public global::Codestellation.Ether.Config.GroupConfigElement GetItemAt(int index)
        {
            return ((global::Codestellation.Ether.Config.GroupConfigElement)(base.BaseGet(index)));
        }
        
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Ether.Config.GroupConfigElement"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::Codestellation.Ether.Config.GroupConfigElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public global::Codestellation.Ether.Config.GroupConfigElement GetItemByKey(string name)
        {
            return ((global::Codestellation.Ether.Config.GroupConfigElement)(base.BaseGet(((object)(name)))));
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }
}
namespace Codestellation.Ether.Config
{
    
    
    /// <summary>
    /// The GroupConfigElement Configuration Element.
    /// </summary>
    public partial class GroupConfigElement : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region Name Property
        /// <summary>
        /// The XML name of the <see cref="Name"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        internal const string NamePropertyName = "name";
        
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        [global::System.ComponentModel.DescriptionAttribute("The Name.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Ether.Config.GroupConfigElement.NamePropertyName, IsRequired=true, IsKey=true, IsDefaultCollection=false)]
        public virtual string Name
        {
            get
            {
                return ((string)(base[global::Codestellation.Ether.Config.GroupConfigElement.NamePropertyName]));
            }
            set
            {
                base[global::Codestellation.Ether.Config.GroupConfigElement.NamePropertyName] = value;
            }
        }
        #endregion
        
        #region Participants Property
        /// <summary>
        /// The XML name of the <see cref="Participants"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        internal const string ParticipantsPropertyName = "participants";
        
        /// <summary>
        /// Gets or sets the Participants.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.5")]
        [global::System.ComponentModel.DescriptionAttribute("The Participants.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Ether.Config.GroupConfigElement.ParticipantsPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual string Participants
        {
            get
            {
                return ((string)(base[global::Codestellation.Ether.Config.GroupConfigElement.ParticipantsPropertyName]));
            }
            set
            {
                base[global::Codestellation.Ether.Config.GroupConfigElement.ParticipantsPropertyName] = value;
            }
        }
        #endregion
    }
}