using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Xamarin.Forms;

namespace XamCustomEntry.Shared.Util
{
    public static class Utility
    {
        public static T GetParentControl<T>(this Element control) where T : class
        {
            // Parent is null return null
            if (control.Parent == null)
                return null;

            // Parent is desired control
            // Than return parent
            if (control.Parent is T)
                return control.Parent as T;

            // search for control
            return GetParentControl<T>(control.Parent);
        }

        public static string GetMemberName<T, TValue>(Expression<Func<T, TValue>> memberAccess)
        {
            return ((MemberExpression)memberAccess.Body).Member.Name;
        }

        public static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.ToLower().Substring(1);

            return str.ToUpper();
        }
        //public static string GetLocalizedKey(string key)
        //{
        //    if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.French), StringComparison.OrdinalIgnoreCase))
        //        return string.Format("{0}FR", key);
        //    else if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.Chinese), StringComparison.OrdinalIgnoreCase))
        //        return string.Format("{0}ZH", key);
        //    else if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.Amharic), StringComparison.OrdinalIgnoreCase))
        //        return string.Format("{0}AM", key);
        //    if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.Spanish), StringComparison.OrdinalIgnoreCase))
        //        return string.Format("{0}ES", key);
        //    else if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.Italiano), StringComparison.OrdinalIgnoreCase))
        //        return string.Format("{0}IT", key);
        //    else if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.Portuguese), StringComparison.OrdinalIgnoreCase))
        //        return string.Format("{0}PT", key);
        //    else if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.Tigrigna), StringComparison.OrdinalIgnoreCase))
        //        return string.Format("{0}TI", key);
        //    else if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.AfanOromo), StringComparison.OrdinalIgnoreCase))
        //        return string.Format("{0}OM", key);
        //    else
        //        return key;
        //}
        //public static string GetLocalizedLanguageCode(bool isForHeader = false)
        //{
        //    if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.French), StringComparison.OrdinalIgnoreCase))
        //        return isForHeader ? "FR" : "fr";
        //    else if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.Chinese), StringComparison.OrdinalIgnoreCase))
        //        return isForHeader ? "ZH" : "zh";
        //    else if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.Amharic), StringComparison.OrdinalIgnoreCase))
        //        return isForHeader ? "AM" : "am";
        //    else if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.Spanish), StringComparison.OrdinalIgnoreCase))
        //        return isForHeader ? "ES" : "es";
        //    else if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.Italiano), StringComparison.OrdinalIgnoreCase))
        //        return isForHeader ? "IT" : "it";
        //    else if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.Portuguese), StringComparison.OrdinalIgnoreCase))
        //        return isForHeader ? "PT" : "pt";
        //    else if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.Tigrigna), StringComparison.OrdinalIgnoreCase))
        //        return isForHeader ? "TI" : "ti";
        //    else if (string.Equals(Settings.Current.Language, Enum.GetName(typeof(Language), Language.AfanOromo), StringComparison.OrdinalIgnoreCase))
        //        return isForHeader ? "OM" : "om";
        //    else
        //        return isForHeader ? "EN" : "en";
        //}

        //public static void ErrorLog(Exception exception, string occuredMethod)
        //{
        //    try
        //    {
        //        IApiExceptionLogService apiExceptionLogService = new AppExceptionLogApi();
        //        IAppExceptionLogService appExceptionLogService = new AppExceptionLogService(apiExceptionLogService);

        //        var dictionary = new Dictionary<string, string>
        //        {
        //            { "Method", occuredMethod }
        //        };
        //        Crashes.TrackError(exception, dictionary);

        //        var appExceptionLogReq = new AppExceptionLogReq()
        //        {
        //            exception = exception,
        //            logtype = (Device.RuntimePlatform == Device.Android) ? Logtype.ANDROID_MOBILE : Logtype.IOS_MOBILE,
        //            severityLevel = SeverityLevel.Error,
        //            timeStamp = DateTime.Now,
        //            message = "MobileAppError-" + exception.Message,
        //            module = occuredMethod,
        //            postmessage = SharedGlobalVariables.GetGlobalVariablesInstance.HttpResponseResultBody,
        //            response = null
        //        };
        //        var resultTask = appExceptionLogService.AppExceptionLogAsync(Fusillade.Priority.UserInitiated, appExceptionLogReq, "Bearer OAUTH-TOKEN");

        //    }
        //    catch (Exception)
        //    {
        //    }
        //}
        //public static void ErrorLog<T>(Exception exception, string occuredMethod, T obj)
        //{
        //    try
        //    {
        //        IApiExceptionLogService apiExceptionLogService = new AppExceptionLogApi();
        //        IAppExceptionLogService appExceptionLogService = new AppExceptionLogService(apiExceptionLogService);

        //        var dictionary = new Dictionary<string, string>
        //        {
        //            { "Method", occuredMethod },
        //            //{ "Object", Newtonsoft.Json.JsonConvert.SerializeObject(obj).Length > 125 ? Newtonsoft.Json.JsonConvert.SerializeObject(obj).Substring(125) : Newtonsoft.Json.JsonConvert.SerializeObject(obj) }
        //        };
        //        Crashes.TrackError(exception, dictionary);

        //        string response = obj == null ? null : Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        //        var appExceptionLogReq = new AppExceptionLogReq()
        //        {
        //            exception = exception,
        //            logtype = (Device.RuntimePlatform == Device.Android) ? Logtype.ANDROID_MOBILE : Logtype.IOS_MOBILE,
        //            severityLevel = SeverityLevel.Error,
        //            timeStamp = DateTime.Now,
        //            message = "MobileAppError-" + exception.Message,
        //            module = occuredMethod,
        //            postmessage = SharedGlobalVariables.GetGlobalVariablesInstance.HttpResponseResultBody,
        //            response = Newtonsoft.Json.JsonConvert.SerializeObject(obj)
        //        };
        //        var resultTask = appExceptionLogService.AppExceptionLogAsync(Fusillade.Priority.UserInitiated, appExceptionLogReq, "Bearer OAUTH-TOKEN");

        //    }
        //    catch (Exception ex)
        //    {
        //        var dictionary = new Dictionary<string, string>
        //        {
        //            { "Method", occuredMethod },
        //            //{ "Object", obj.ToString().Length > 125 ? obj.ToString().Substring(125) : obj.ToString()  },
        //            //{ "ex", ex.ToString().Length > 125 ? ex.ToString().Substring(125) : ex.ToString()  }
        //        };
        //        Crashes.TrackError(exception, dictionary);
        //    }
        //}

    }

}
