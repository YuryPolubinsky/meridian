﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using LastFmLib.Core.Album;
using LastFmLib.Core.Artist;
using Meridian.Model;
using VkLib.Core.Groups;

namespace Meridian.Converters
{
    public class SearchResultTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TrackTemplate { get; set; }

        public DataTemplate AlbumTemplate { get; set; }

        public DataTemplate ArtistTemplate { get; set; }

        public DataTemplate SocietyTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Audio)
                return TrackTemplate;
            else if (item is LastFmAlbum)
                return AlbumTemplate;
            else if (item is LastFmArtist)
                return ArtistTemplate;
            else if (item is VkGroup)
                return SocietyTemplate;
            return null;
        }
    }

    public class SearchResultStyleSelector : StyleSelector
    {
        public Style TrackStyle { get; set; }

        public Style AlbumStyle { get; set; }

        public Style ArtistStyle { get; set; }

        public Style SocietyStyle { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item is Audio)
                return TrackStyle;
            else if (item is LastFmAlbum)
                return AlbumStyle;
            else if (item is LastFmArtist)
                return ArtistStyle;
            else if (item is VkGroup)
                return SocietyStyle;
            return null;
        }
    }

    public class SearchListBoxStyleSelector : IValueConverter
    {
        public Style TracksStyle { get; set; }

        public Style AlbumsStyle { get; set; }

        public Style ArtistsStyle { get; set; }

        public Style SocietiesStyle { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var index = (int)value;
            switch (index)
            {
                case 0:
                    return TracksStyle;
                case 1:
                    return AlbumsStyle;
                case 2:
                    return ArtistsStyle;
                case 3:
                    return SocietiesStyle;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
