/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;
using HandlebarsDotNet;

namespace NohaFMS.Services
{
    public class Template
    {
        public static string Render(string source, object data)
        {
            string result = "";
            if(!string.IsNullOrEmpty(source))
            {
                var template = Handlebars.Compile(source);
                result = template(data);
            }

            return result;
        }

        public static string Render(string source, BaseEntity entity, object param)
        {
            string result = "";
            if (!string.IsNullOrEmpty(source))
            {
                var template = Handlebars.Compile(source);
                var data = new
                {
                    entity = entity,
                    param = param
                };
                result = template(data);
            }

            return result;
        }
    }
}
