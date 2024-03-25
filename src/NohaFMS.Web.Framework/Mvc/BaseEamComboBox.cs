/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/


namespace NohaFMS.Web.Framework.Mvc
{
    public class BaseEamComboBox
    {
        public string HtmlId { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Area { get; set; }
        public bool IsRequired { get; set; }
        public string DbTable { get; set; }
        public string DbTextColumn { get; set; }
        public string DbValueColumn { get; set; }

        //pass additional field, value
        public string AdditionalField { get; set; }
        public string AdditionalValue { get; set; }

        public string OptionalField { get; set; }

        /// <summary>
        /// The values of this field will depend
        /// on the current value of the parent field
        /// </summary>
        public string ParentFieldName { get; set; }

        public bool Multiple { get; set; }
    }
}
