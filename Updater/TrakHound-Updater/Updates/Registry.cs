﻿// Copyright (c) 2016 Feenux LLC, All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Win32;
using System;

using TH_Global;

namespace TrakHound_Updater
{
    /// <summary>
    /// Functions to Set/Get/Delete Registry Keys for TrakHound Updater
    /// </summary>
    static class Registry
    {

        public const string WOW64_KEY = "WOW6432Node";
        public const string ROOT_KEY = "Software";
        public const string APP_KEY = "TrakHound";

        public const string UPDATE_PATH = "update_path";
        public const string INSTALL_PATH = "install_path";
        public const string UPDATE_URL = "update_url";
        public const string UPDATE_VERSION = "update_version";
        public const string INSTALL_VERSION = "install_version";


        public static void SetKey(string keyName, object keyValue, string groupName = null)
        {
            try
            {
                // Open LOCAL_MACHINE/Software Key
                RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(ROOT_KEY, true);

                // Create/Open LOCAL_MACHINE/Software/TrakHound Key
                key = key.OpenSubKey(APP_KEY);

                // Try looking for 64 bit version in WOW6432Node key
                if (key == null)
                {
                    key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(ROOT_KEY, true);
                    if (key != null) key = key.OpenSubKey(WOW64_KEY);
                    if (key != null) key = key.OpenSubKey(APP_KEY, true);
                }

                // Create/Open LOCAL_MACHINE/Software/TrakHound/[groupName] Key
                if (groupName != null && key != null) key = key.CreateSubKey(groupName);

                // Update value for [keyName] to [keyValue]
                if (key != null) key.SetValue(keyName, keyValue);
            }
            catch(Exception ex) { Logger.Log("SetKey() :: Exception :: " + ex.Message, Logger.LogLineType.Debug); }
        }

        public static string GetValue(string keyName, string groupName = null)
        {
            string result = null;

            try
            {
                // Open LOCAL_MACHINE/Software Key
                RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(ROOT_KEY, true);

                // Create/Open LOCAL_MACHINE/Software/TrakHound Key
                if (key != null) key = key.OpenSubKey(APP_KEY);

                // Try looking for 64 bit version in WOW6432Node key
                if (key == null)
                {
                    key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(ROOT_KEY, true);
                    if (key != null) key = key.OpenSubKey(WOW64_KEY, true);
                    if (key != null) key = key.OpenSubKey(APP_KEY);
                }

                // Open LOCAL_MACHINE/Software/TrakHound/[groupName] Key
                if (groupName != null && key != null) key = key.OpenSubKey(groupName);

                // Read value for [keyName] to [keyValue]
                if (key != null)
                {
                    var val = key.GetValue(keyName);
                    if (val != null) result = val.ToString();
                }
            }
            catch (Exception ex) { Logger.Log("GetValue() :: Exception :: keyName = " + keyName + " :: groupName = " + groupName + " :: " + ex.Message, Logger.LogLineType.Debug); }

            return result;
        }

        public static string[] GetValueNames(string groupName = null)
        {
            string[] result = null;

            try
            {
                // Open LOCAL_MACHINE/Software Key
                RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(ROOT_KEY, true);

                // Create/Open LOCAL_MACHINE/Software/TrakHound Key
                if (key != null) key = key.OpenSubKey(APP_KEY);

                // Try looking for 64 bit version in WOW6432Node key
                if (key == null)
                {
                    key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(ROOT_KEY, true);
                    if (key != null) key = key.OpenSubKey(WOW64_KEY, true);
                    if (key != null) key = key.OpenSubKey(APP_KEY);
                }

                // Open LOCAL_MACHINE/Software/TrakHound/[groupName] Key
                if (groupName != null && key != null) key = key.OpenSubKey(groupName);

                if (key != null) result = key.GetValueNames();
            }
            catch (Exception ex) { Logger.Log("GetValueNames() :: Exception :: " + ex.Message, Logger.LogLineType.Debug); }

            return result;
        }

        public static string[] GetKeyNames(string groupName = null)
        {
            string[] result = null;

            try
            {
                // Open LOCAL_MACHINE/Software Key
                RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(ROOT_KEY, true);

                // Create/Open LOCAL_MACHINE/Software/TrakHound Key
                if (key != null) key = key.OpenSubKey(APP_KEY);

                // Try looking for 64 bit version in WOW6432Node key
                if (key == null)
                {
                    key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(ROOT_KEY, true);
                    if (key != null) key = key.OpenSubKey(WOW64_KEY, true);
                    if (key != null) key = key.OpenSubKey(APP_KEY);
                }

                // Open LOCAL_MACHINE/Software/TrakHound/[groupName] Key
                if (groupName != null && key != null) key = key.OpenSubKey(groupName);

                if (key != null) result = key.GetSubKeyNames();
            }
            catch (Exception ex) { Logger.Log("GetSubKeyNames() :: Exception :: " + ex.Message, Logger.LogLineType.Debug); }

            return result;
        }

        public static void DeleteValue(string keyName, string groupName = null)
        {
            try
            {
                // Open LOCAL_MACHINE/Software Key
                RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(ROOT_KEY, true);

                // Create/Open LOCAL_MACHINE/Software/TrakHound Key
                if (key != null) key = key.OpenSubKey(APP_KEY);

                // Try looking for 64 bit version in WOW6432Node key
                if (key == null)
                {
                    key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(ROOT_KEY, true);
                    if (key != null) key = key.OpenSubKey(WOW64_KEY, true);
                    if (key != null) key = key.OpenSubKey(APP_KEY, true);
                }

                // Open LOCAL_MACHINE/Software/TrakHound/[groupName] Key
                if (groupName != null && key != null) key = key.OpenSubKey(groupName, true);

                // Delete LOCAL_MACHINE/Software/TrakHound/[groupName]/[keyName] Key
                if (key != null) key.DeleteValue(keyName, false);
            }
            catch (Exception ex) { Logger.Log("DeleteValue() :: Exception :: " + ex.Message, Logger.LogLineType.Debug); }
        }

        public static void DeleteKey(string keyName, string groupName = null)
        {
            try
            {
                // Open LOCAL_MACHINE/Software Key
                RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(ROOT_KEY, true);

                // Create/Open LOCAL_MACHINE/Software/TrakHound Key
                if (key != null) key = key.OpenSubKey(APP_KEY);

                // Try looking for 64 bit version in WOW6432Node key
                if (key == null)
                {
                    key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(ROOT_KEY, true);
                    if (key != null) key = key.OpenSubKey(WOW64_KEY, true);
                    if (key != null) key = key.OpenSubKey(APP_KEY, true);
                }

                // Open LOCAL_MACHINE/Software/TrakHound/[groupName] Key
                if (groupName != null && key != null) key = key.OpenSubKey(groupName, true);

                // Delete LOCAL_MACHINE/Software/TrakHound/[groupName]/[keyName] Key
                if (key != null) key.DeleteSubKey(keyName);
            }
            catch (Exception ex) { Logger.Log("DeleteKey() :: Exception :: " + ex.Message, Logger.LogLineType.Debug); }
        }

    }
}
