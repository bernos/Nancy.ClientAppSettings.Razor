using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Nancy.ClientAppSettings;
using Nancy.ViewEngines.Razor;

namespace Nancy.ViewEngines.Razor
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Retrieves the ClientAppSettings object from the current NancyContext
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helpers"></param>
        /// <returns></returns>
        public static ClientAppSettings.ClientAppSettings ClientAppSettings<T>(this HtmlHelpers<T> helpers)
        {
            return helpers.RenderContext.Context.GetClientAppSettings();
        }

        /// <summary>
        /// Renders the client app settings javascript.
        /// </summary>
        /// <param name="includeScriptElement">Determines whether to render the app settings wrapped in an html script element or not. Defaults to True</param>
        /// <returns></returns>
        public static IHtmlString RenderClientAppSettings<T>(this HtmlHelpers<T> helpers, bool includeScriptElement = true)
        {
            var settings = helpers.RenderContext.Context.GetClientAppSettings();
            var js = string.Format("var {0} = {1};", settings.VariableName, settings.ToJson(helpers.RenderContext.Context));

            if (includeScriptElement)
            {
                js = string.Format("<script>{0}</script>", js);
            }

            return new NonEncodedHtmlString(js);
        }

        /// <summary>
        /// Provides access to app settings from razor views
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helpers"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string AppSetting<T>(this HtmlHelpers<T> helpers, string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
