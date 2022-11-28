﻿using System;
using Editor.Utilities.FileWriters;

namespace Editor.Utilities
{
    public static class UITYPEExtensions
    {
        public static string GetAsString(this UXMLGenerator.UITYPE uitype)
        {
            switch (uitype)
            {
                case UXMLGenerator.UITYPE.UI:
                    return "ui";
                case UXMLGenerator.UITYPE.UIE:
                    return "uie";
                default:
                    throw new ArgumentOutOfRangeException(nameof(uitype), uitype, null);
            }
        }
    }
}