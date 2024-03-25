/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.ComponentModel.DataAnnotations.Schema;

namespace NohaFMS.Core.Domain
{
    [System.ComponentModel.DataAnnotations.Schema.Table("ReturnReason")]
    public class ReturnReason : BaseEntity
    {

        [Column(TypeName = "varchar")]
        public string code { get; set; }
        [Column(TypeName = "varchar")]
        public string AlphaReturnCodes { get; set; }
        [Column(TypeName = "int")]
        public int NumericReturnCodes { get; set; }
       
        [Column(TypeName = "nvarchar")]
        public string DescriptionWithReturnCodes { get; set; }

        [Column(TypeName = "varchar")]
        public string Status { get; set; }




    }
}

