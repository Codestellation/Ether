//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Codestellation.Mailer.Config
{
    
    
    /// <summary>
    /// The MailNotifierConfigSection Configuration Section.
    /// </summary>
    public partial class MailNotifierConfigSection : global::System.Configuration.ConfigurationSection
    {
        
        #region Singleton Instance
        /// <summary>
        /// The XML name of the MailNotifierConfigSection Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string MailNotifierConfigSectionSectionName = "mailNotifier";
        
        /// <summary>
        /// Gets the MailNotifierConfigSection instance.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public static global::Codestellation.Mailer.Config.MailNotifierConfigSection Instance
        {
            get
            {
                return ((global::Codestellation.Mailer.Config.MailNotifierConfigSection)(global::System.Configuration.ConfigurationManager.GetSection(global::Codestellation.Mailer.Config.MailNotifierConfigSection.MailNotifierConfigSectionSectionName)));
            }
        }
        #endregion
        
        #region Xmlns Property
        /// <summary>
        /// The XML name of the <see cref="Xmlns"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string XmlnsPropertyName = "xmlns";
        
        /// <summary>
        /// Gets the XML namespace of this Configuration Section.
        /// </summary>
        /// <remarks>
        /// This property makes sure that if the configuration file contains the XML namespace,
        /// the parser doesn't throw an exception because it encounters the unknown "xmlns" attribute.
        /// </remarks>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Mailer.Config.MailNotifierConfigSection.XmlnsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string Xmlns
        {
            get
            {
                return ((string)(base[global::Codestellation.Mailer.Config.MailNotifierConfigSection.XmlnsPropertyName]));
            }
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region TemplatesFolder Property
        /// <summary>
        /// The XML name of the <see cref="TemplatesFolder"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string TemplatesFolderPropertyName = "templatesFolder";
        
        /// <summary>
        /// Gets or sets the TemplatesFolder.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The TemplatesFolder.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Mailer.Config.MailNotifierConfigSection.TemplatesFolderPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string TemplatesFolder
        {
            get
            {
                return ((string)(base[global::Codestellation.Mailer.Config.MailNotifierConfigSection.TemplatesFolderPropertyName]));
            }
            set
            {
                base[global::Codestellation.Mailer.Config.MailNotifierConfigSection.TemplatesFolderPropertyName] = value;
            }
        }
        #endregion
        
        #region FromAddress Property
        /// <summary>
        /// The XML name of the <see cref="FromAddress"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string FromAddressPropertyName = "fromAddress";
        
        /// <summary>
        /// Gets or sets the FromAddress.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The FromAddress.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Mailer.Config.MailNotifierConfigSection.FromAddressPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string FromAddress
        {
            get
            {
                return ((string)(base[global::Codestellation.Mailer.Config.MailNotifierConfigSection.FromAddressPropertyName]));
            }
            set
            {
                base[global::Codestellation.Mailer.Config.MailNotifierConfigSection.FromAddressPropertyName] = value;
            }
        }
        #endregion
        
        #region MailingRules Property
        /// <summary>
        /// The XML name of the <see cref="MailingRules"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string MailingRulesPropertyName = "rules";
        
        /// <summary>
        /// Gets or sets the MailingRules.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The MailingRules.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Mailer.Config.MailNotifierConfigSection.MailingRulesPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public global::Codestellation.Mailer.Config.MailingRulesConfigElementCollection MailingRules
        {
            get
            {
                return ((global::Codestellation.Mailer.Config.MailingRulesConfigElementCollection)(base[global::Codestellation.Mailer.Config.MailNotifierConfigSection.MailingRulesPropertyName]));
            }
            set
            {
                base[global::Codestellation.Mailer.Config.MailNotifierConfigSection.MailingRulesPropertyName] = value;
            }
        }
        #endregion
        
        #region MailingGroups Property
        /// <summary>
        /// The XML name of the <see cref="MailingGroups"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string MailingGroupsPropertyName = "groups";
        
        /// <summary>
        /// Gets or sets the MailingGroups.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The MailingGroups.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Mailer.Config.MailNotifierConfigSection.MailingGroupsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public global::Codestellation.Mailer.Config.GroupConfigElementCollection MailingGroups
        {
            get
            {
                return ((global::Codestellation.Mailer.Config.GroupConfigElementCollection)(base[global::Codestellation.Mailer.Config.MailNotifierConfigSection.MailingGroupsPropertyName]));
            }
            set
            {
                base[global::Codestellation.Mailer.Config.MailNotifierConfigSection.MailingGroupsPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Codestellation.Mailer.Config
{
    
    
    /// <summary>
    /// A collection of MailingRuleConfigurationElement instances.
    /// </summary>
    [global::System.Configuration.ConfigurationCollectionAttribute(typeof(global::Codestellation.Mailer.Config.MailingRuleConfigurationElement), CollectionType=global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate, AddItemName=global::Codestellation.Mailer.Config.MailingRulesConfigElementCollection.MailingRuleConfigurationElementPropertyName)]
    public partial class MailingRulesConfigElementCollection : global::System.Configuration.ConfigurationElementCollection
    {
        
        #region Constants
        /// <summary>
        /// The XML name of the individual <see cref="global::Codestellation.Mailer.Config.MailingRuleConfigurationElement"/> instances in this collection.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string MailingRuleConfigurationElementPropertyName = "rule";
        #endregion
        
        #region Overrides
        /// <summary>
        /// Gets the type of the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>The <see cref="global::System.Configuration.ConfigurationElementCollectionType"/> of this collection.</returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override string ElementName
        {
            get
            {
                return global::Codestellation.Mailer.Config.MailingRulesConfigElementCollection.MailingRuleConfigurationElementPropertyName;
            }
        }
        
        /// <summary>
        /// Indicates whether the specified <see cref="global::System.Configuration.ConfigurationElement"/> exists in the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="elementName">The name of the element to verify.</param>
        /// <returns>
        /// <see langword="true"/> if the element exists in the collection; otherwise, <see langword="false"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override bool IsElementName(string elementName)
        {
            return (elementName == global::Codestellation.Mailer.Config.MailingRulesConfigElementCollection.MailingRuleConfigurationElementPropertyName);
        }
        
        /// <summary>
        /// Gets the element key for the specified configuration element.
        /// </summary>
        /// <param name="element">The <see cref="global::System.Configuration.ConfigurationElement"/> to return the key for.</param>
        /// <returns>
        /// An <see cref="object"/> that acts as the key for the specified <see cref="global::System.Configuration.ConfigurationElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override object GetElementKey(global::System.Configuration.ConfigurationElement element)
        {
            return ((global::Codestellation.Mailer.Config.MailingRuleConfigurationElement)(element)).Name;
        }
        
        /// <summary>
        /// Creates a new <see cref="global::Codestellation.Mailer.Config.MailingRuleConfigurationElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="global::Codestellation.Mailer.Config.MailingRuleConfigurationElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override global::System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new global::Codestellation.Mailer.Config.MailingRuleConfigurationElement();
        }
        #endregion
        
        #region Indexer
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Mailer.Config.MailingRuleConfigurationElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::Codestellation.Mailer.Config.MailingRuleConfigurationElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::Codestellation.Mailer.Config.MailingRuleConfigurationElement this[int index]
        {
            get
            {
                return ((global::Codestellation.Mailer.Config.MailingRuleConfigurationElement)(base.BaseGet(index)));
            }
        }
        
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Mailer.Config.MailingRuleConfigurationElement"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::Codestellation.Mailer.Config.MailingRuleConfigurationElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::Codestellation.Mailer.Config.MailingRuleConfigurationElement this[object name]
        {
            get
            {
                return ((global::Codestellation.Mailer.Config.MailingRuleConfigurationElement)(base.BaseGet(name)));
            }
        }
        #endregion
        
        #region Add
        /// <summary>
        /// Adds the specified <see cref="global::Codestellation.Mailer.Config.MailingRuleConfigurationElement"/> to the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="rule">The <see cref="global::Codestellation.Mailer.Config.MailingRuleConfigurationElement"/> to add.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public void Add(global::Codestellation.Mailer.Config.MailingRuleConfigurationElement rule)
        {
            base.BaseAdd(rule);
        }
        #endregion
        
        #region Remove
        /// <summary>
        /// Removes the specified <see cref="global::Codestellation.Mailer.Config.MailingRuleConfigurationElement"/> from the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="rule">The <see cref="global::Codestellation.Mailer.Config.MailingRuleConfigurationElement"/> to remove.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public void Remove(global::Codestellation.Mailer.Config.MailingRuleConfigurationElement rule)
        {
            base.BaseRemove(this.GetElementKey(rule));
        }
        #endregion
        
        #region GetItem
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Mailer.Config.MailingRuleConfigurationElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::Codestellation.Mailer.Config.MailingRuleConfigurationElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::Codestellation.Mailer.Config.MailingRuleConfigurationElement GetItemAt(int index)
        {
            return ((global::Codestellation.Mailer.Config.MailingRuleConfigurationElement)(base.BaseGet(index)));
        }
        
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Mailer.Config.MailingRuleConfigurationElement"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::Codestellation.Mailer.Config.MailingRuleConfigurationElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::Codestellation.Mailer.Config.MailingRuleConfigurationElement GetItemByKey(string name)
        {
            return ((global::Codestellation.Mailer.Config.MailingRuleConfigurationElement)(base.BaseGet(((object)(name)))));
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }
}
namespace Codestellation.Mailer.Config
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region Name Property
        /// <summary>
        /// The XML name of the <see cref="Name"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string NamePropertyName = "name";
        
        /// <summary>
        /// Gets the Name.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Name.")]
        [global::System.ComponentModel.ReadOnlyAttribute(true)]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Mailer.Config.MailingRuleConfigurationElement.NamePropertyName, IsRequired=true, IsKey=true, IsDefaultCollection=false)]
        public string Name
        {
            get
            {
                return ((string)(base[global::Codestellation.Mailer.Config.MailingRuleConfigurationElement.NamePropertyName]));
            }
        }
        #endregion
        
        #region Recepients Property
        /// <summary>
        /// The XML name of the <see cref="Recepients"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string RecepientsPropertyName = "recepients";
        
        /// <summary>
        /// Gets the Recepients.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Recepients.")]
        [global::System.ComponentModel.ReadOnlyAttribute(true)]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Mailer.Config.MailingRuleConfigurationElement.RecepientsPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public string Recepients
        {
            get
            {
                return ((string)(base[global::Codestellation.Mailer.Config.MailingRuleConfigurationElement.RecepientsPropertyName]));
            }
        }
        #endregion
    }
}
namespace Codestellation.Mailer.Config
{
    
    
    /// <summary>
    /// A collection of GroupConfigElement instances.
    /// </summary>
    [global::System.Configuration.ConfigurationCollectionAttribute(typeof(global::Codestellation.Mailer.Config.GroupConfigElement), CollectionType=global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate, AddItemName=global::Codestellation.Mailer.Config.GroupConfigElementCollection.GroupConfigElementPropertyName)]
    public partial class GroupConfigElementCollection : global::System.Configuration.ConfigurationElementCollection
    {
        
        #region Constants
        /// <summary>
        /// The XML name of the individual <see cref="global::Codestellation.Mailer.Config.GroupConfigElement"/> instances in this collection.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string GroupConfigElementPropertyName = "group";
        #endregion
        
        #region Overrides
        /// <summary>
        /// Gets the type of the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>The <see cref="global::System.Configuration.ConfigurationElementCollectionType"/> of this collection.</returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override string ElementName
        {
            get
            {
                return global::Codestellation.Mailer.Config.GroupConfigElementCollection.GroupConfigElementPropertyName;
            }
        }
        
        /// <summary>
        /// Indicates whether the specified <see cref="global::System.Configuration.ConfigurationElement"/> exists in the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="elementName">The name of the element to verify.</param>
        /// <returns>
        /// <see langword="true"/> if the element exists in the collection; otherwise, <see langword="false"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override bool IsElementName(string elementName)
        {
            return (elementName == global::Codestellation.Mailer.Config.GroupConfigElementCollection.GroupConfigElementPropertyName);
        }
        
        /// <summary>
        /// Gets the element key for the specified configuration element.
        /// </summary>
        /// <param name="element">The <see cref="global::System.Configuration.ConfigurationElement"/> to return the key for.</param>
        /// <returns>
        /// An <see cref="object"/> that acts as the key for the specified <see cref="global::System.Configuration.ConfigurationElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override object GetElementKey(global::System.Configuration.ConfigurationElement element)
        {
            return ((global::Codestellation.Mailer.Config.GroupConfigElement)(element)).Name;
        }
        
        /// <summary>
        /// Creates a new <see cref="global::Codestellation.Mailer.Config.GroupConfigElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="global::Codestellation.Mailer.Config.GroupConfigElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override global::System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new global::Codestellation.Mailer.Config.GroupConfigElement();
        }
        #endregion
        
        #region Indexer
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Mailer.Config.GroupConfigElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::Codestellation.Mailer.Config.GroupConfigElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::Codestellation.Mailer.Config.GroupConfigElement this[int index]
        {
            get
            {
                return ((global::Codestellation.Mailer.Config.GroupConfigElement)(base.BaseGet(index)));
            }
        }
        
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Mailer.Config.GroupConfigElement"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::Codestellation.Mailer.Config.GroupConfigElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::Codestellation.Mailer.Config.GroupConfigElement this[object name]
        {
            get
            {
                return ((global::Codestellation.Mailer.Config.GroupConfigElement)(base.BaseGet(name)));
            }
        }
        #endregion
        
        #region Add
        /// <summary>
        /// Adds the specified <see cref="global::Codestellation.Mailer.Config.GroupConfigElement"/> to the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="group">The <see cref="global::Codestellation.Mailer.Config.GroupConfigElement"/> to add.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public void Add(global::Codestellation.Mailer.Config.GroupConfigElement group)
        {
            base.BaseAdd(group);
        }
        #endregion
        
        #region Remove
        /// <summary>
        /// Removes the specified <see cref="global::Codestellation.Mailer.Config.GroupConfigElement"/> from the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="group">The <see cref="global::Codestellation.Mailer.Config.GroupConfigElement"/> to remove.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public void Remove(global::Codestellation.Mailer.Config.GroupConfigElement group)
        {
            base.BaseRemove(this.GetElementKey(group));
        }
        #endregion
        
        #region GetItem
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Mailer.Config.GroupConfigElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::Codestellation.Mailer.Config.GroupConfigElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::Codestellation.Mailer.Config.GroupConfigElement GetItemAt(int index)
        {
            return ((global::Codestellation.Mailer.Config.GroupConfigElement)(base.BaseGet(index)));
        }
        
        /// <summary>
        /// Gets the <see cref="global::Codestellation.Mailer.Config.GroupConfigElement"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::Codestellation.Mailer.Config.GroupConfigElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::Codestellation.Mailer.Config.GroupConfigElement GetItemByKey(string name)
        {
            return ((global::Codestellation.Mailer.Config.GroupConfigElement)(base.BaseGet(((object)(name)))));
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }
}
namespace Codestellation.Mailer.Config
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region Name Property
        /// <summary>
        /// The XML name of the <see cref="Name"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string NamePropertyName = "name";
        
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Name.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Mailer.Config.GroupConfigElement.NamePropertyName, IsRequired=true, IsKey=true, IsDefaultCollection=false)]
        public string Name
        {
            get
            {
                return ((string)(base[global::Codestellation.Mailer.Config.GroupConfigElement.NamePropertyName]));
            }
            set
            {
                base[global::Codestellation.Mailer.Config.GroupConfigElement.NamePropertyName] = value;
            }
        }
        #endregion
        
        #region Participants Property
        /// <summary>
        /// The XML name of the <see cref="Participants"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string ParticipantsPropertyName = "participants";
        
        /// <summary>
        /// Gets or sets the Participants.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Participants.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Codestellation.Mailer.Config.GroupConfigElement.ParticipantsPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public string Participants
        {
            get
            {
                return ((string)(base[global::Codestellation.Mailer.Config.GroupConfigElement.ParticipantsPropertyName]));
            }
            set
            {
                base[global::Codestellation.Mailer.Config.GroupConfigElement.ParticipantsPropertyName] = value;
            }
        }
        #endregion
    }
}