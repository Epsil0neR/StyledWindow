using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace StyledWindow
{
    public class DebugConverter: IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class WindowStyle
    {

        public static readonly DependencyProperty LeftContentProperty = DependencyProperty.RegisterAttached(
            "LeftContent",
            typeof(object),
            typeof(WindowStyle),
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.AffectsArrange |
                FrameworkPropertyMetadataOptions.AffectsMeasure)
        );

        public static void SetLeftContent(UIElement element, object value)
        {
            element.SetValue(LeftContentProperty, value);
        }

        public static object GetLeftContent(UIElement element)
        {
            return element.GetValue(LeftContentProperty);
        }

        public static readonly DependencyProperty MenuProperty = DependencyProperty.RegisterAttached(
            "Menu",
            typeof(Menu),
            typeof(WindowStyle),
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.AffectsArrange |
                FrameworkPropertyMetadataOptions.AffectsMeasure)
        );

        public static void SetMenu(UIElement element, Menu value)
        {
            element.SetValue(MenuProperty, value);
        }

        public static Menu GetMenu(UIElement element)
        {
            return (Menu)element.GetValue(MenuProperty);
        }

        public static readonly DependencyProperty ShowTitleProperty = DependencyProperty.RegisterAttached(
            "ShowTitle",
            typeof(bool),
            typeof(WindowStyle),
            new FrameworkPropertyMetadata(true,
                FrameworkPropertyMetadataOptions.AffectsArrange |
                FrameworkPropertyMetadataOptions.AffectsMeasure));

        public static void SetShowTitle(UIElement element, bool value)
        {
            element.SetValue(ShowTitleProperty, value);
        }

        public static bool GetShowTitle(UIElement element)
        {
            return (bool)element.GetValue(ShowTitleProperty);
        }


        public static readonly DependencyProperty RightContentProperty = DependencyProperty.RegisterAttached(
            "RightContent",
            typeof(object),
            typeof(WindowStyle),
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.AffectsArrange |
                FrameworkPropertyMetadataOptions.AffectsMeasure)
        );

        public static void SetRightContent(UIElement element, object value)
        {
            element.SetValue(RightContentProperty, value);
        }

        public static object GetRightContent(UIElement element)
        {
            return element.GetValue(RightContentProperty);
        }
    }
}