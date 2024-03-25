/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Services.Pdf
{
    public interface IPdfConverter
    {
        /// <summary>
        /// Converts html content to PDF
        /// </summary>
        /// <param name="settings">The settings to be used for the conversion process</param>
        /// <returns>The PDF binary data</returns>
        byte[] Convert(PdfConvertSettings settings);
    }
}
