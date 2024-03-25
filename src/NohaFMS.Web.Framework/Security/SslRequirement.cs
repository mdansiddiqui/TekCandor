/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Web.Framework.Security
{
    public enum SslRequirement
    {
        /// <summary>
        /// Page should be secured
        /// </summary>
        Yes,
        /// <summary>
        /// Page should not be secured
        /// </summary>
        No,
        /// <summary>
        /// It doesn't matter (as requested)
        /// </summary>
        NoMatter,
    }
}
