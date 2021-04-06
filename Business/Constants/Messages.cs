using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Constants
{
    public abstract class Messages
    {
        public static string IsAdded = " is added.";
        public static string NameInvalid = " name is invalid.";
        public static string FailureMessage = "A failure happened.";
        public static string SListed = "s are listed.";
        public static string CarPriceInvalid = "Daily fee cannot be lower than 0.";
        public static string IsDeleted = " is deleted.";
        public static string IsUpdated = " is updated.";
        public static string NotAvailable = " unit is not available.";
        public static string IsListed = " is listed.";
        public static string NotFound = " is not found.";
        public static string PasswordError = "Password is incorrect.";
        public static string LoginSuccessful = "Login is successful.";
        public static string AlreadyExists = " is already exists.";
        public static string AccessTokenCreated = "Access Token is successfully created.";
        public static string AuthorizationDenied ="Auth denied.";
    }
}
