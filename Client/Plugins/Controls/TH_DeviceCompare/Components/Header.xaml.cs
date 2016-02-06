﻿// Copyright (c) 2015 Feenux LLC, All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Threading;
using System.Windows.Media.Animation;

using TH_Configuration;
using TH_UserManagement.Management;

namespace TH_DeviceCompare.Components
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
            DataContext = this;
        }

        public Column column;

        public int Index;

        public Database_Settings userDatabaseSettings;

        public bool Connected
        {
            get { return (bool)GetValue(ConnectedProperty); }
            set { SetValue(ConnectedProperty, value); }
        }

        public static readonly DependencyProperty ConnectedProperty =
            DependencyProperty.Register("Connected", typeof(bool), typeof(Header), new PropertyMetadata(false));


        public string LastUpdatedTimestamp
        {
            get { return (string)GetValue(LastUpdatedTimestampProperty); }
            set { SetValue(LastUpdatedTimestampProperty, value); }
        }

        public static readonly DependencyProperty LastUpdatedTimestampProperty =
            DependencyProperty.Register("LastUpdatedTimestamp", typeof(string), typeof(Header), new PropertyMetadata("Never"));

        


        public int ProductionLevelCount
        {
            get { return (int)GetValue(ProductionLevelCountProperty); }
            set { SetValue(ProductionLevelCountProperty, value); }
        }

        public static readonly DependencyProperty ProductionLevelCountProperty =
            DependencyProperty.Register("ProductionLevelCount", typeof(int), typeof(Header), new PropertyMetadata(0));


        public int ProductionLevel
        {
            get { return (int)GetValue(ProductionLevelProperty); }
            set { SetValue(ProductionLevelProperty, value); }
        }

        public static readonly DependencyProperty ProductionLevelProperty =
            DependencyProperty.Register("ProductionLevel", typeof(int), typeof(Header), new PropertyMetadata(0));




        public string Device_Description
        {
            get { return (string)GetValue(Device_DescriptionProperty); }
            set { SetValue(Device_DescriptionProperty, value); }
        }

        public static readonly DependencyProperty Device_DescriptionProperty =
            DependencyProperty.Register("Device_Description", typeof(string), typeof(Header), new PropertyMetadata(""));


        public string Device_Manufacturer
        {
            get { return (string)GetValue(Device_ManufacturerProperty); }
            set { SetValue(Device_ManufacturerProperty, value); }
        }

        public static readonly DependencyProperty Device_ManufacturerProperty =
            DependencyProperty.Register("Device_Manufacturer", typeof(string), typeof(Header), new PropertyMetadata(""));


        public string Device_Model
        {
            get { return (string)GetValue(Device_ModelProperty); }
            set { SetValue(Device_ModelProperty, value); }
        }

        public static readonly DependencyProperty Device_ModelProperty =
            DependencyProperty.Register("Device_Model", typeof(string), typeof(Header), new PropertyMetadata(""));


        public string Device_Serial
        {
            get { return (string)GetValue(Device_SerialProperty); }
            set { SetValue(Device_SerialProperty, value); }
        }

        public static readonly DependencyProperty Device_SerialProperty =
            DependencyProperty.Register("Device_Serial", typeof(string), typeof(Header), new PropertyMetadata(""));



        public ImageSource Device_Image
        {
            get { return (ImageSource)GetValue(Device_ImageProperty); }
            set { SetValue(Device_ImageProperty, value); }
        }

        public static readonly DependencyProperty Device_ImageProperty =
            DependencyProperty.Register("Device_Image", typeof(ImageSource), typeof(Header), new PropertyMetadata(null));


        public ImageSource Device_Logo
        {
            get { return (ImageSource)GetValue(Device_LogoProperty); }
            set { SetValue(Device_LogoProperty, value); }
        }

        public static readonly DependencyProperty Device_LogoProperty =
            DependencyProperty.Register("Device_Logo", typeof(ImageSource), typeof(Header), new PropertyMetadata(null));


        public string Device_ID
        {
            get { return (string)GetValue(Device_IDProperty); }
            set { SetValue(Device_IDProperty, value); }
        }

        public static readonly DependencyProperty Device_IDProperty =
            DependencyProperty.Register("Device_ID", typeof(string), typeof(Header), new PropertyMetadata(""));




        public bool Production
        {
            get { return (bool)GetValue(ProductionProperty); }
            set { SetValue(ProductionProperty, value); }
        }

        public static readonly DependencyProperty ProductionProperty =
            DependencyProperty.Register("Production", typeof(bool), typeof(Header), new PropertyMetadata(false));


        public bool Idle
        {
            get { return (bool)GetValue(IdleProperty); }
            set { SetValue(IdleProperty, value); }
        }

        public static readonly DependencyProperty IdleProperty =
            DependencyProperty.Register("Idle", typeof(bool), typeof(Header), new PropertyMetadata(false));


        public bool Alert
        {
            get { return (bool)GetValue(AlertProperty); }
            set { SetValue(AlertProperty, value); }
        }

        public static readonly DependencyProperty AlertProperty =
            DependencyProperty.Register("Alert", typeof(bool), typeof(Header), new PropertyMetadata(false));



        public bool ScheduledDowntime
        {
            get { return (bool)GetValue(ScheduledDowntimeProperty); }
            set { SetValue(ScheduledDowntimeProperty, value); }
        }

        public static readonly DependencyProperty ScheduledDowntimeProperty =
            DependencyProperty.Register("ScheduledDowntime", typeof(bool), typeof(Header), new PropertyMetadata(false));


        public string ScheduledDowntime_Text
        {
            get { return (string)GetValue(ScheduledDowntime_TextProperty); }
            set { SetValue(ScheduledDowntime_TextProperty, value); }
        }

        public static readonly DependencyProperty ScheduledDowntime_TextProperty =
            DependencyProperty.Register("ScheduledDowntime_Text", typeof(string), typeof(Header), new PropertyMetadata(null));


        public string ScheduledDowntime_Times
        {
            get { return (string)GetValue(ScheduledDowntime_TimesProperty); }
            set { SetValue(ScheduledDowntime_TimesProperty, value); }
        }

        public static readonly DependencyProperty ScheduledDowntime_TimesProperty =
            DependencyProperty.Register("ScheduledDowntime_Times", typeof(string), typeof(Header), new PropertyMetadata(null));

        
        

        //public bool Break
        //{
        //    get { return (bool)GetValue(BreakProperty); }
        //    set { SetValue(BreakProperty, value); }
        //}

        //public static readonly DependencyProperty BreakProperty =
        //    DependencyProperty.Register("Break", typeof(bool), typeof(Header), new PropertyMetadata(false));

        

        public bool Minimized
        {
            get { return (bool)GetValue(MinimizedProperty); }
            set { SetValue(MinimizedProperty, value); }
        }

        public static readonly DependencyProperty MinimizedProperty =
            DependencyProperty.Register("Minimized", typeof(bool), typeof(Header), new PropertyMetadata(true));



        public bool Collapsed
        {
            get { return (bool)GetValue(CollapsedProperty); }
            set 
            {
                SetValue(CollapsedProperty, value);
            }
        }

        public static readonly DependencyProperty CollapsedProperty =
            DependencyProperty.Register("Collapsed", typeof(bool), typeof(Header), new PropertyMetadata(false));

        

        public void Collapse()
        {
            DoubleAnimation animation = new DoubleAnimation();

            animation.From = Main_GRID.RenderSize.Height;
            animation.To = 30;
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            Main_GRID.BeginAnimation(HeightProperty, animation);

            Collapsed = true;
        }

        public void Minimize()
        {
            DoubleAnimation animation = new DoubleAnimation();

            animation.From = Main_GRID.RenderSize.Height;
            animation.To = 150;
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            animation.BeginTime = TimeSpan.FromMilliseconds(200);
            Main_GRID.BeginAnimation(HeightProperty, animation);

            Collapsed = false;
            Minimized = true;
        }

        public void Expand()
        {
            DoubleAnimation animation = new DoubleAnimation();

            animation.From = Main_GRID.RenderSize.Height;
            animation.To = 300;
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            Main_GRID.BeginAnimation(HeightProperty, animation);

            Collapsed = false;
            Minimized = false;
        }




        
        public SolidColorBrush AccentBrush
        {
            get { return (SolidColorBrush)GetValue(AccentBrushProperty); }
            set { SetValue(AccentBrushProperty, value); }
        }

        public static readonly DependencyProperty AccentBrushProperty =
            DependencyProperty.Register("AccentBrush", typeof(SolidColorBrush), typeof(Header), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(180, 180, 180))));


        #region "Mouse Over"

        public bool MouseOver
        {
            get { return (bool)GetValue(MouseOverProperty); }
            set { SetValue(MouseOverProperty, value); }
        }

        public static readonly DependencyProperty MouseOverProperty =
            DependencyProperty.Register("MouseOver", typeof(bool), typeof(Header), new PropertyMetadata(false));

        private void Control_MouseEnter(object sender, MouseEventArgs e)
        {
            MouseOver = true;
            if (column != null) column.MouseOver = true;
        }

        private void Control_MouseLeave(object sender, MouseEventArgs e)
        {
            MouseOver = false;
            if (column != null) column.MouseOver = false;
        }

        #endregion

        #region "IsSelected"

        public delegate void Clicked_Handler(int Index);
        public event Clicked_Handler Clicked;

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(Header), new PropertyMetadata(false));

        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Clicked != null) Clicked(Index);
        }

        #endregion


        #region "Device Logo"

        public bool ManufacturerLogoLoading
        {
            get { return (bool)GetValue(ManufacturerLogoLoadingProperty); }
            set { SetValue(ManufacturerLogoLoadingProperty, value); }
        }

        public static readonly DependencyProperty ManufacturerLogoLoadingProperty =
            DependencyProperty.Register("ManufacturerLogoLoading", typeof(bool), typeof(Header), new PropertyMetadata(false));


        const System.Windows.Threading.DispatcherPriority priority = System.Windows.Threading.DispatcherPriority.Background;


        Thread LoadManufacturerLogo_THREAD;

        public void LoadManufacturerLogo(string filename)
        {
            ManufacturerLogoLoading = true;

            if (LoadManufacturerLogo_THREAD != null) LoadManufacturerLogo_THREAD.Abort();

            LoadManufacturerLogo_THREAD = new Thread(new ParameterizedThreadStart(LoadManufacturerLogo_Worker));
            LoadManufacturerLogo_THREAD.Start(filename);
        }

        void LoadManufacturerLogo_Worker(object o)
        {
            if (o != null)
            {
                string filename = o.ToString();

                System.Drawing.Image img = Images.GetImage(filename, userDatabaseSettings);

                this.Dispatcher.BeginInvoke(new Action<System.Drawing.Image>(LoadManufacturerLogo_GUI), priority, new object[] { img });
            }
            else this.Dispatcher.BeginInvoke(new Action<System.Drawing.Image>(LoadManufacturerLogo_GUI), priority, new object[] { null });
        }

        void LoadManufacturerLogo_GUI(System.Drawing.Image img)
        {
            if (img != null)
            {
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);

                IntPtr bmpPt = bmp.GetHbitmap();
                BitmapSource bmpSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bmpPt, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

                bmpSource.Freeze();

                if (bmpSource.PixelWidth > bmpSource.PixelHeight)
                {
                    Device_Logo = TH_WPF.Image_Functions.SetImageSize(bmpSource, 180);
                }
                else
                {
                    Device_Logo = TH_WPF.Image_Functions.SetImageSize(bmpSource, 0, 80);
                }

                //ManufacturerLogoSet = true;
            }
            else
            {
                Device_Logo = null;
                //ManufacturerLogoSet = false;
            }

            ManufacturerLogoLoading = false;
        }

        #endregion

        #region "Device Image"

        public bool DeviceImageLoading
        {
            get { return (bool)GetValue(DeviceImageLoadingProperty); }
            set { SetValue(DeviceImageLoadingProperty, value); }
        }

        public static readonly DependencyProperty DeviceImageLoadingProperty =
            DependencyProperty.Register("DeviceImageLoading", typeof(bool), typeof(Header), new PropertyMetadata(false));

        

        Thread LoadDeviceImage_THREAD;

        public void LoadDeviceImage(string filename)
        {
            ManufacturerLogoLoading = true;

            if (LoadDeviceImage_THREAD != null) LoadDeviceImage_THREAD.Abort();

            LoadDeviceImage_THREAD = new Thread(new ParameterizedThreadStart(LoadDeviceImage_Worker));
            LoadDeviceImage_THREAD.Start(filename);
        }

        void LoadDeviceImage_Worker(object o)
        {
            if (o != null)
            {
                string filename = o.ToString();

                System.Drawing.Image img = Images.GetImage(filename, userDatabaseSettings);

                this.Dispatcher.BeginInvoke(new Action<System.Drawing.Image>(LoadDeviceImage_GUI), priority, new object[] { img });
            }
            else this.Dispatcher.BeginInvoke(new Action<System.Drawing.Image>(LoadDeviceImage_GUI), priority, new object[] { null });
        }

        void LoadDeviceImage_GUI(System.Drawing.Image img)
        {
            if (img != null)
            {
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);

                IntPtr bmpPt = bmp.GetHbitmap();
                BitmapSource bmpSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bmpPt, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

                bmpSource.Freeze();

                if (bmpSource.PixelWidth > bmpSource.PixelHeight)
                {
                    Device_Image = TH_WPF.Image_Functions.SetImageSize(bmpSource, 250);
                }
                else
                {
                    Device_Image = TH_WPF.Image_Functions.SetImageSize(bmpSource, 0, 250);
                }

                //if (bmpSource.PixelWidth > bmpSource.PixelHeight)
                //{
                //    Device_Image = TH_WPF.Image_Functions.SetImageSize(bmpSource, 140);
                //}
                //else
                //{
                //    Device_Image = TH_WPF.Image_Functions.SetImageSize(bmpSource, 0, 140);
                //}

                //ManufacturerLogoSet = true;
            }
            else
            {
                Device_Image = null;
                //ManufacturerLogoSet = false;
            }

            ManufacturerLogoLoading = false;
        }

        #endregion

    }

    public class DesignTime_Header : Header
    {
        public DesignTime_Header()
        {
            //Minimized = false;
            //Collapsed = false;
            Connected = true;
            Production = true;
            Idle = false;
            Alert = false;
            ScheduledDowntime = true;
            LastUpdatedTimestamp = DateTime.Now.ToString();
            Device_Description = "Device Description";
            Device_Manufacturer = "Manufacturer";
            Device_Model = "Model";
            Device_Serial = "Serial";
            Device_ID = "01";

            //Device_Logo = new BitmapImage(new Uri(@"C:\TrakHound\Configuration Files\Mazak1-1\Images\Mazak-Logo1.png"));

            //Device_Image = new BitmapImage(new Uri(@"C:\TrakHound\Configuration Files\Mazak1-1\Images\mazak1.png"));
        }
    }
}
