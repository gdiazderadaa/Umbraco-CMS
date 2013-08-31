﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Umbraco.Core.Configuration;

namespace Umbraco.Tests.TestHelpers
{
    class SettingsForTests
    {
        // umbracoSettings

        public static int UmbracoLibraryCacheDuration
        {
            get { return LegacyUmbracoSettings.UmbracoLibraryCacheDuration; }
            set { LegacyUmbracoSettings.UmbracoLibraryCacheDuration = value; }
        }

        public static bool UseLegacyXmlSchema
        {
            get { return LegacyUmbracoSettings.UseLegacyXmlSchema; }
            set { LegacyUmbracoSettings.UseLegacyXmlSchema = value; }
        }

        public static bool AddTrailingSlash
        {
            get { return LegacyUmbracoSettings.AddTrailingSlash; }
            set { LegacyUmbracoSettings.AddTrailingSlash = value; }
        }

        public static bool UseDomainPrefixes
        {
            get { return LegacyUmbracoSettings.UseDomainPrefixes; }
            set { LegacyUmbracoSettings.UseDomainPrefixes = value; }
        }

        public static string SettingsFilePath
        {
            get { return LegacyUmbracoSettings.SettingsFilePath; }
            set { LegacyUmbracoSettings.SettingsFilePath = value; }
        }

        public static bool ForceSafeAliases
        {
            get { return LegacyUmbracoSettings.ForceSafeAliases; }
            set { LegacyUmbracoSettings.ForceSafeAliases = value; }
        }

        // from appSettings

        private static readonly IDictionary<string, string> SavedAppSettings = new Dictionary<string, string>();

        static void SaveSetting(string key)
        {
            SavedAppSettings[key] = ConfigurationManager.AppSettings[key];
        }

        static void SaveSettings()
        {
            SaveSetting("umbracoHideTopLevelNodeFromPath");
            SaveSetting("umbracoUseDirectoryUrls");
            SaveSetting("umbracoPath");
            SaveSetting("umbracoReservedPaths");
            SaveSetting("umbracoReservedUrls");
            SaveSetting("umbracoConfigurationStatus");
        }

        public static bool HideTopLevelNodeFromPath
        {
            get { return GlobalSettings.HideTopLevelNodeFromPath; }
            set { ConfigurationManager.AppSettings.Set("umbracoHideTopLevelNodeFromPath", value ? "true" : "false"); }
        }

        public static bool UseDirectoryUrls
        {
            get { return GlobalSettings.UseDirectoryUrls; }
            set { ConfigurationManager.AppSettings.Set("umbracoUseDirectoryUrls", value ? "true" : "false"); }
        }

        public static string UmbracoPath
        {
            get { return GlobalSettings.Path; }
            set { ConfigurationManager.AppSettings.Set("umbracoPath", value); }
        }

        public static string ReservedPaths
        {
            get { return GlobalSettings.ReservedPaths; }
            set { GlobalSettings.ReservedPaths = value; }
        }

        public static string ReservedUrls
        {
            get { return GlobalSettings.ReservedUrls; }
            set { GlobalSettings.ReservedUrls = value; }
        }

        public static string ConfigurationStatus
        {
            get { return GlobalSettings.ConfigurationStatus; }
            set { ConfigurationManager.AppSettings.Set("umbracoConfigurationStatus", value); }
        }

        // reset & defaults

        static SettingsForTests()
        {
            SaveSettings();
        }

        public static void Reset()
        {
            LegacyUmbracoSettings.Reset();
            GlobalSettings.Reset();

            foreach (var kvp in SavedAppSettings)
                ConfigurationManager.AppSettings.Set(kvp.Key, kvp.Value);

            // set some defaults that are wrong in the config file?!
            // this is annoying, really
            HideTopLevelNodeFromPath = false;
        }
    }
}
