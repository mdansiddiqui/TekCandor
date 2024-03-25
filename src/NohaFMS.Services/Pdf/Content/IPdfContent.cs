/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Text;

namespace NohaFMS.Services.Pdf
{
    public interface IPdfContent
    {
        PdfContentKind Kind { get; }

        string Process(string flag);

        void WriteArguments(string flag, StringBuilder builder);

        void Teardown();
    }

    public enum PdfContentKind
    {
        Html,
        Url
    }
}
