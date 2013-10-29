<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="541d0f79-f3eb-462b-ac4b-63be4254ad1d" namespace="Codestellation.Ether.Config" xmlSchemaNamespace="urn:Codestellation.Ether.Config" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="EtherConfigSection" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="ether">
      <attributeProperties>
        <attributeProperty name="TemplatesFolder" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="templatesFolder" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/541d0f79-f3eb-462b-ac4b-63be4254ad1d/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="FromAddress" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="fromAddress" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/541d0f79-f3eb-462b-ac4b-63be4254ad1d/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="OutgoingEmailsFile" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="outgoingEmailsFile" isReadOnly="true">
          <type>
            <externalTypeMoniker name="/541d0f79-f3eb-462b-ac4b-63be4254ad1d/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="AutoReloadTemplates" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="autoReloadTemplates" isReadOnly="false" defaultValue="false">
          <type>
            <externalTypeMoniker name="/541d0f79-f3eb-462b-ac4b-63be4254ad1d/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="MailingRules" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="rules" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/541d0f79-f3eb-462b-ac4b-63be4254ad1d/MailingRulesConfigElementCollection" />
          </type>
        </elementProperty>
        <elementProperty name="MailingGroups" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="groups" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/541d0f79-f3eb-462b-ac4b-63be4254ad1d/GroupConfigElementCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElementCollection name="MailingRulesConfigElementCollection" xmlItemName="rule" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/541d0f79-f3eb-462b-ac4b-63be4254ad1d/MailingRuleConfigurationElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="MailingRuleConfigurationElement">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="true">
          <type>
            <externalTypeMoniker name="/541d0f79-f3eb-462b-ac4b-63be4254ad1d/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Recepients" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="recepients" isReadOnly="true">
          <type>
            <externalTypeMoniker name="/541d0f79-f3eb-462b-ac4b-63be4254ad1d/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElementCollection name="GroupConfigElementCollection" xmlItemName="group" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/541d0f79-f3eb-462b-ac4b-63be4254ad1d/GroupConfigElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="GroupConfigElement">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/541d0f79-f3eb-462b-ac4b-63be4254ad1d/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Participants" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="participants" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/541d0f79-f3eb-462b-ac4b-63be4254ad1d/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>