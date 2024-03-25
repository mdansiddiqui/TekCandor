/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NohaFMS.Web.Framework.CustomField
{
    public class FieldHelper
    {
        public static List<SelectListItem> GetChoices(FieldModel model)
        {
            var choices = new List<SelectListItem>();
            if(model.ControlType == FieldControlType.DropDownList
                || model.ControlType == FieldControlType.MultiSelectList)
            {
                string value = model.Value == null ? "" : model.Value.ToString();
                if(model.DataSource == FieldDataSource.CSV)
                {
                    string[] valueList = model.CsvValueList.Split(',');
                    string[] textList = model.CsvTextList.Split(',');

                    for (int i = 0; i < valueList.Count(); i++)
                    {
                        choices.Add(new SelectListItem
                        {
                            Value = valueList[i],
                            Text = textList[i],
                            Selected = valueList[i] == value
                        });
                    }
                }

                //add empty value
                if(choices.Count > 0)
                {
                    choices.Insert(0, new SelectListItem { Value = "", Text = "" });
                }
            }
            return choices;
        }
    }
}
