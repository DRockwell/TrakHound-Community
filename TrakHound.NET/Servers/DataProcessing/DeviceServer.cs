﻿// Copyright (c) 2017 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using NLog;
using System;
using System.Collections.Generic;
using System.Threading;
using TrakHound.Configurations;
using TrakHound.Plugins.Server;

namespace TrakHound.Servers.DataProcessing
{
    /// <summary>
    /// Data Processing Server for individual device. Handles plugins and events related to the device.
    /// </summary>
    public partial class DeviceServer
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public DeviceConfiguration Configuration { get; set; }

        private bool _isRunning = false;
        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                _isRunning = value;
                if (_isRunning && Started != null) Started(this);
                else Stopped?.Invoke(this);
            }
        }

        public delegate void StatusChanged_Handler(DeviceServer server);
        public event StatusChanged_Handler Started;
        public event StatusChanged_Handler Stopped;

        public event SendData_Handler SendData;

        private ManualResetEvent stop;

        private List<IServerPlugin> plugins { get; set; }


        public DeviceServer(DeviceConfiguration config, List<IServerPlugin> serverPlugins)
        {
            Configuration = config;
            plugins = serverPlugins;
        }

        public void Start()
        {
            IsRunning = true;
            stop = new ManualResetEvent(false);

            Initialize(Configuration);

            StartPlugins();
        }

        public void Stop()
        {
            stop.Set();

            ClosePlugins();

            IsRunning = false;
        }


        private void Initialize(DeviceConfiguration config)
        {
            Configuration = config;

            InitializePlugins(config);
        }

        private void InitializePlugins(DeviceConfiguration config)
        {
            if (plugins != null && config != null)
            {
                foreach (var plugin in plugins)
                {
                    try
                    {
                        plugin.SendData -= SendPluginData;
                        plugin.SendData += SendPluginData;
                        plugin.Initialize(config);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                }
            }
        }


        private class SendDataInfo
        {
            public SendDataInfo(IServerPlugin plugin, EventData data)
            {
                Plugin = plugin;
                EventData = data;
            }

            public IServerPlugin Plugin { get; set; }
            public EventData EventData { get; set; }
        }

        public void SendPluginData(string id, string message)
        {
            var data = new EventData(this);
            data.Id = id;
            data.Data01 = message;

            SendPluginData(data);
        }

        public void SendPluginData(string id, object obj)
        {
            var data = new EventData(this);
            data.Id = id;
            data.Data01 = obj;

            SendPluginData(data);
        }

        private void SendPluginData(EventData data)
        {
            if (plugins != null)
            {
                foreach (var plugin in plugins)
                {
                    try
                    {
                        plugin.GetSentData(data);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                }
            }

            SendData?.Invoke(data);
        }


        private void PluginSendData(object o)
        {
            if (o != null)
            {
                var sendDataInfo = (SendDataInfo)o;

                try
                {
                    sendDataInfo.Plugin.GetSentData(sendDataInfo.EventData);
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }  
        }


        private void StartPlugins()
        {
            if (plugins != null)
            {
                foreach (var plugin in plugins)
                {
                    try
                    {
                        plugin.Starting();
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                }
            }
        }

        private void ClosePlugins()
        {
            if (plugins != null)
            {
                foreach (var plugin in plugins)
                {
                    try
                    {
                        plugin.Closing();
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                }
            }
        }

    }
}
