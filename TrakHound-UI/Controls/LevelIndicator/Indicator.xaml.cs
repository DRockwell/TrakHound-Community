﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Collections.ObjectModel;

namespace TrakHound_UI.LevelIndicator
{
    /// <summary>
    /// Interaction logic for Indicator.xaml
    /// </summary>
    public partial class Indicator : UserControl
    {
        public Indicator()
        {
            InitializeComponent();
            root.DataContext = this;
        }

        public Indicator(int totalLevelCount)
        {
            InitializeComponent();
            root.DataContext = this;

            TotalLevelCount = totalLevelCount;
        }

        public int TotalLevelCount
        {
            get { return (int)GetValue(TotalLevelCountProperty); }
            set 
            {
                SetValue(TotalLevelCountProperty, value);
                Init(value);
            }
        }

        public static readonly DependencyProperty TotalLevelCountProperty =
            DependencyProperty.Register("TotalLevelCount", typeof(int), typeof(Indicator), new PropertyMetadata(0, new PropertyChangedCallback(TotalLevelCountPropertyChanged)));

        private static void TotalLevelCountPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var o = (Indicator)dependencyObject;
            o.Init((int)eventArgs.NewValue);
        }


        public int ActiveLevelCount
        {
            get { return (int)GetValue(ActiveLevelCountProperty); }
            set 
            { 
                SetValue(ActiveLevelCountProperty, value);
                SetActiveLevels(value);
            }
        }

        public static readonly DependencyProperty ActiveLevelCountProperty =
            DependencyProperty.Register("ActiveLevelCount", typeof(int), typeof(Indicator), new PropertyMetadata(0, new PropertyChangedCallback(ActiveLevelCountPropertyChanged)));

        private static void ActiveLevelCountPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var o = (Indicator)dependencyObject;
            o.SetActiveLevels((int)eventArgs.NewValue);
        }



        public Brush ActiveLevelBrush
        {
            get { return (Brush)GetValue(ActiveLevelBrushProperty); }
            set { SetValue(ActiveLevelBrushProperty, value); }
        }

        public static readonly DependencyProperty ActiveLevelBrushProperty =
            DependencyProperty.Register("ActiveLevelBrush", typeof(Brush), typeof(Indicator), new PropertyMetadata(new SolidColorBrush(Colors.Black), new PropertyChangedCallback(LevelBrushFormatPropertyChanged)));


        public Brush InactiveLevelBrush
        {
            get { return (Brush)GetValue(InactiveLevelBrushProperty); }
            set { SetValue(InactiveLevelBrushProperty, value); }
        }

        public static readonly DependencyProperty InactiveLevelBrushProperty =
            DependencyProperty.Register("InactiveLevelBrush", typeof(Brush), typeof(Indicator), new PropertyMetadata(new SolidColorBrush(Colors.Gray), new PropertyChangedCallback(LevelBrushFormatPropertyChanged)));


        private static void LevelBrushFormatPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var o = (Indicator)dependencyObject;
            o.SetActiveLevels(o.ActiveLevelCount);
        }


        ObservableCollection<Segment> segments;
        public ObservableCollection<Segment> Segments
        {
            get
            {
                if (segments == null) segments = new ObservableCollection<Segment>();
                return segments;
            }
            set
            {
                segments = value;
            }
        }

        public void Init(int levelCount)
        {
            double controlHeight = this.ActualHeight;

            for (var x = 0; x <= levelCount - 1; x++)
            {
                Segment segment = new Segment();
                segment.Width = controlHeight * 0.25;
                segment.Height = controlHeight * 0.25;
                segment.Height += x * (controlHeight * 0.25);
                Segments.Add(segment);
            }

            SetActiveLevels(ActiveLevelCount);
        }

        void SetActiveLevels(int activeLevelCount)
        {
            if (Segments.Count > 0)
            {
                for (var x = 0; x <= TotalLevelCount - 1; x++)
                {
                    if (x < activeLevelCount) Segments[x].Foreground = ActiveLevelBrush;
                    else Segments[x].Foreground = InactiveLevelBrush;
                }
            }
        }

        void CalculateSizes()
        {
            double controlHeight = this.ActualHeight;
            double controlWidth = controlHeight * 0.25;
            double margin = controlWidth * 0.10;

            if (Segments.Count > 0)
            {
                for (var x = 0; x <= TotalLevelCount - 1; x++)
                {
                    double increment = (double)1 / TotalLevelCount;

                    Segments[x].Width = controlWidth;
                    Segments[x].Height = controlHeight * increment;
                    Segments[x].Height += x * (controlHeight * increment);
                    Segments[x].Margin = new Thickness(margin, 0, margin, 0);
                }
            }
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CalculateSizes();
        }

    }
}
