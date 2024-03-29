﻿using System;
using System.Windows.Data;

namespace SGSTakePhoto.App
{
    public class EnableColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return "#FF009309";//绿色 #FFDC1720:红色

            string tmp = (string)value;
            return tmp == "1" ? "#FF009309" : "#FFDC1720";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
