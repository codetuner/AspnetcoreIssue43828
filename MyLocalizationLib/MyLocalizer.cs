using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalizationLib
{
    /// <summary>
    /// Just a custom implementation of IHtmlLocalizer, IStringLocalizer and IViewLocalizer.
    /// </summary>
    public class MyLocalizer : IStringLocalizer, IHtmlLocalizer, IViewLocalizer
    {
        public MyLocalizer() : this(CultureInfo.CurrentUICulture)
        { }

        public MyLocalizer(CultureInfo culture)
        {
            this.Culture = culture;
        }

        public CultureInfo Culture { get; private set; }

        LocalizedString IStringLocalizer.this[string name] => this.GetLocalizedStringInternal(name);

        LocalizedString IStringLocalizer.this[string name, params object[] arguments] => this.GetLocalizedStringInternal(name);

        LocalizedHtmlString IHtmlLocalizer.this[string name] => this.GetLocalizedHtmlStringInternal(name);

        LocalizedHtmlString IHtmlLocalizer.this[string name, params object[] arguments] => this.GetLocalizedHtmlStringInternal(name);

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures) => throw new NotImplementedException();

        public LocalizedString GetString(string name) => this.GetLocalizedStringInternal(name);

        public LocalizedString GetString(string name, params object[] arguments) => this.GetLocalizedStringInternal(name);

        IHtmlLocalizer IHtmlLocalizer.WithCulture(CultureInfo culture) => new MyLocalizer(culture);

        IStringLocalizer IStringLocalizer.WithCulture(CultureInfo culture) => new MyLocalizer(culture);

        private LocalizedString GetLocalizedStringInternal(string name) => new LocalizedString(name, $"Localized:{name}");

        private LocalizedHtmlString GetLocalizedHtmlStringInternal(string name) => new LocalizedHtmlString(name, $"Localized:{name}");
    }
}
