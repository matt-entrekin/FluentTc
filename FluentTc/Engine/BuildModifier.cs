using System;
using FluentTc.Locators;
using EasyHttp.Http;

namespace FluentTc.Engine
{
    internal interface IBuildModifier
    {
        IBuildModifier Pin(Action<IBuildHavingBuilder> buildHavingBuilder, string comment);
        IBuildModifier Tag(Action<IBuildHavingBuilder> buildHavingBuilder, string tag);
    }

    internal class BuildModifier : IBuildModifier
    {
        private readonly IBuildHavingBuilderFactory m_BuildHavingBuilderFactory;
        private readonly ITeamCityCaller m_TeamCityCaller;

        public BuildModifier(ITeamCityCaller teamCityCaller, IBuildHavingBuilderFactory buildConfigurationHavingBuilderFactory)
        {
            m_TeamCityCaller = teamCityCaller;
            m_BuildHavingBuilderFactory = buildConfigurationHavingBuilderFactory;
        }

        public IBuildModifier Pin(Action<IBuildHavingBuilder> buildHavingBuilder, string comment)
        {
            var locator = GetLocator(buildHavingBuilder);
            m_TeamCityCaller.PutFormat(comment, HttpContentTypes.TextPlain,
                $"/app/rest/builds/{locator}/pin/");
            return this;
        }

        public IBuildModifier Tag(Action<IBuildHavingBuilder> buildHavingBuilder, string tag)
        {
            var locator = GetLocator(buildHavingBuilder);
            m_TeamCityCaller.PostFormat(tag, HttpContentTypes.TextPlain,
                $"/app/rest/builds/{locator}/tags/");
            return this;
        }

        private string GetLocator(Action<IBuildHavingBuilder> buildHavingBuilder)
        {
            var buildConfigurationHavingBuilder = m_BuildHavingBuilderFactory.CreateBuildHavingBuilder();
            buildHavingBuilder(buildConfigurationHavingBuilder);
            return buildConfigurationHavingBuilder.GetLocator();
        }
    }
}