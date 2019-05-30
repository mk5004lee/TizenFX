using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml;
using Tizen.NUI.Xaml;
using Tizen.NUI.XamlBinding;

namespace Tizen.NUI.StyleSheets
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class StyleSheet : IStyle
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        StyleSheet()
        {
        }

        internal IDictionary<Selector, Style> Styles { get; set; } = new Dictionary<Selector, Style>();

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StyleSheet FromAssemblyResource(Assembly assembly, string resourceId, IXmlLineInfo lineInfo = null)
        {
            using (var stream = assembly.GetManifestResourceStream(resourceId)) {
                if (stream == null)
                    throw new XamlParseException($"No resource found for '{resourceId}'.", lineInfo);
                using (var reader = new StreamReader(stream)) {
                    return FromReader(reader);
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StyleSheet FromString(string stylesheet)
        {
            if (stylesheet == null)
                throw new ArgumentNullException(nameof(stylesheet));
            using (var reader = new StringReader(stylesheet))
                return FromReader(reader);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StyleSheet FromReader(TextReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            return Parse(new CssReader(reader));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static StyleSheet Parse(CssReader reader)
        {
            var sheet = new StyleSheet();

            Style style = null;
            var selector = Selector.All;

            int p;
            bool inStyle = false;
            reader.SkipWhiteSpaces();
            while ((p = reader.Peek()) > 0) {
                switch ((char)p) {
                case '@':
                    throw new NotSupportedException("AT-rules not supported");
                case '{':
                    reader.Read();
                    style = Style.Parse(reader, '}');
                    inStyle = true;
                    break;
                case '}':
                    reader.Read();
                    if (!inStyle)
                        throw new Exception();
                    inStyle = false;
                    sheet.Styles.Add(selector, style);
                    style = null;
                    selector = Selector.All;
                    break;
                default:
                    selector = Selector.Parse(reader, '{');
                    break;
                }
            }
            return sheet;
        }

        Type IStyle.TargetType
            => typeof(Element);

        void IStyle.Apply(BindableObject bindable)
        {
            var styleable = bindable as Element;
            if (styleable == null)
                return;
            Apply(styleable);
        }

        void Apply(Element styleable)
        {
            ApplyCore(styleable);
            foreach (var child in styleable.LogicalChildrenInternal)
                ((IStyle)this).Apply(child);
        }

        void ApplyCore(Element styleable)
        {
            var visualStylable = styleable as Element;
            if (visualStylable == null)
                return;
            foreach (var kvp in Styles) {
                var selector = kvp.Key;
                var style = kvp.Value;
                // if (!selector.Matches(styleable))
                // 	continue;
                style.Apply(visualStylable);
            }
        }

        void IStyle.UnApply(BindableObject bindable)
        {
            throw new NotImplementedException();
        }
    }
}