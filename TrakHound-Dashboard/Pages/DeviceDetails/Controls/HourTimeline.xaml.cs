﻿// Copyright (c) 2016 Feenux LLC, All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using TrakHound.API;
using TrakHound.Configurations;

namespace TrakHound_Dashboard.Pages.DeviceDetails.Controls
{
    /// <summary>
    /// Interaction logic for Row.xaml
    /// </summary>
    public partial class HourTimeline : UserControl
    {
        public HourTimeline()
        {
            InitializeComponent();
            root.DataContext = this;
        }

        //public HourTimeline(DeviceDescription device)
        //{
        //    InitializeComponent();
        //    root.DataContext = this;

        //    Device = device;

        //    HourDatas = new List<HourData>();
        //    for (var x = 0; x < 24; x++) HourDatas.Add(new HourData(x, x + 1));
        //}

        #region "Dependency Properties"

        //public DeviceDescription Device
        //{
        //    get { return (DeviceDescription)GetValue(DeviceProperty); }
        //    set { SetValue(DeviceProperty, value); }
        //}

        //public static readonly DependencyProperty DeviceProperty =
        //    DependencyProperty.Register("Device", typeof(DeviceDescription), typeof(HourTimeline), new PropertyMetadata(null));


        //public bool Connected
        //{
        //    get { return (bool)GetValue(ConnectedProperty); }
        //    set { SetValue(ConnectedProperty, value); }
        //}

        //public static readonly DependencyProperty ConnectedProperty =
        //    DependencyProperty.Register("Connected", typeof(bool), typeof(HourTimeline), new PropertyMetadata(false));


        //public string DeviceStatus
        //{
        //    get { return (string)GetValue(DeviceStatusProperty); }
        //    set { SetValue(DeviceStatusProperty, value); }
        //}

        //public static readonly DependencyProperty DeviceStatusProperty =
        //    DependencyProperty.Register("DeviceStatus", typeof(string), typeof(HourTimeline), new PropertyMetadata(null));


        public List<HourData> HourDatas
        {
            get { return (List<HourData>)GetValue(HourDatasProperty); }
            set { SetValue(HourDatasProperty, value); }
        }

        public static readonly DependencyProperty HourDatasProperty =
            DependencyProperty.Register("HourDatas", typeof(List<HourData>), typeof(HourTimeline), new PropertyMetadata(null));


        public string ValueFormat
        {
            get { return (string)GetValue(ValueFormatProperty); }
            set { SetValue(ValueFormatProperty, value); }
        }

        public static readonly DependencyProperty ValueFormatProperty =
            DependencyProperty.Register("ValueFormat", typeof(string), typeof(HourTimeline), new PropertyMetadata("P0"));

        #endregion

        public DateTime CurrentTime { get; set; }

        //public void UpdateData(Data.StatusInfo info)
        //{
        //    if (info != null)
        //    {
        //        Connected = info.Connected == 1;
        //        DeviceStatus = info.DeviceStatus;
        //    }
        //}

        //public void UpdateData(List<Data.HourInfo> hours)
        //{
        //    if (hours != null)
        //    {
        //        foreach (var hourData in HourDatas) hourData.Reset();

        //        foreach (var hour in hours)
        //        {
        //            // Probably a more elegant way of getting the Time Zone Offset could be done here
        //            int timeZoneOffset = (DateTime.UtcNow - DateTime.Now).Hours;
        //            int h = hour.Hour - timeZoneOffset;
        //            if (h < 0) h = 24 - Math.Abs(h);

        //            //var match = HourDatas.Find(o => o.StartHour == h);
        //            //if (match != null)
        //            //{
        //            //    //match.Oee = hour.Oee;

        //            //    //if (hour.PlannedProductionTime > 0)
        //            //    //{
        //            //    //    if (hour.Oee > 0.75) match.Status = 2;
        //            //    //    else if (hour.Oee > 0.5) match.Status = 1;
        //            //    //    else if (hour.Oee >= 0) match.Status = 0;
        //            //    //}
        //            //    //else match.Status = -1;
        //            //}
        //        }
        //    }          
        //}
        
    }
}