﻿/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Core.Domain
{
    /// <summary>
    /// Represents the user login result enumeration
    /// </summary>
    public enum UserLoginResults
    {
        /// <summary>
        /// Login successful
        /// </summary>
        Successful = 1,
        /// <summary>
        /// User dies not exist (email or username)
        /// </summary>
        UserNotExist = 2,
        /// <summary>
        /// Wrong password
        /// </summary>
        WrongPassword = 3,
        /// <summary>
        /// Account have not been activated
        /// </summary>
        NotActive = 4,
        /// <summary>
        /// User has been deleted 
        /// </summary>
        Deleted = 5,
        /// <summary>
        /// User not registered 
        /// </summary>
        NotRegistered = 6,


        PasswordExpire=7,

        UserBlocked = 8,

        CaptchaNotValid = 9,

    }
}
