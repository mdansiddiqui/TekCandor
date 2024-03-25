namespace NohaFMS.Core.Domain
{
    /// <summary>
    /// Represents a setting
    /// </summary>
    public partial class PasswordPolicy : BaseEntity
    {
        public PasswordPolicy() { }


        /// <summary>
        /// Gets or sets the value
        /// </summary>
        /// 
        public string Name { get; set; }

        public string NameOther { get; set; }
        public string Description { get; set; }
        public int CountHistory { get; set; }
        public int ExpiryDays { get; set; }
        public int NotifyDays { get; set; }
        public int AccountDisableDays { get; set; }
        public int InvalidLoginEntry { get; set; }
        public bool FirstReset { get; set; }
        public bool CyclicPassword { get; set; }


        //public override string ToString()
        //{
        //    return Name;
        //}
    }
}
