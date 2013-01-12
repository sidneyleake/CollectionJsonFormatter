namespace CollectionJsonFormatter.Common
{
    using System;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public class Helpers
    {
        public static string FormatString(string value, StringFormat format)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            var formattedValue = value;
            switch (format)
            {
                case StringFormat.CamelCase:
                    formattedValue = char.ToLower(value[0]) + value.Substring(1);
                    break;

                case StringFormat.CapitalCase:
                    formattedValue = Regex.Replace(value, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToUpper(m.Value[1]));
                    break;

                case StringFormat.Hyphenated:
                    formattedValue = Regex.Replace(value, "[a-z][A-Z]", m => m.Value[0] + "-" + m.Value[1]);
                    break;

                case StringFormat.HyphenatedCapitalCase:
                    formattedValue = Regex.Replace(value, "[a-z][A-Z]", m => m.Value[0] + "-" + char.ToUpper(m.Value[1]));
                    break;

                case StringFormat.HyphenatedLowerCase:
                    formattedValue = Regex.Replace(value, "[a-z][A-Z]", m => m.Value[0] + "-" + char.ToLower(m.Value[1])).ToLower();
                    break;

                case StringFormat.HyphenatedUpperCase:
                    formattedValue = Regex.Replace(value, "[a-z][A-Z]", m => m.Value[0] + "-" + char.ToLower(m.Value[1])).ToUpper();
                    break;

                case StringFormat.LowerCase:
                    formattedValue = value.ToLower();
                    break;

                case StringFormat.PascalCase:
                    formattedValue = value;
                    break;

                case StringFormat.SentenceCase:
                    formattedValue = Regex.Replace(value, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
                    break;

                case StringFormat.UpperCase:
                    formattedValue = value.ToUpper();
                    break;

                default:
                    formattedValue = value;
                    break;
            }

            return formattedValue;
        }

        public static string ResolveTokens<T>(string uri, T entity)
        {
            var type = entity.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var formattedName = FormatString(property.Name, CollectionJsonConfiguration.PropertyNameFormat);
                var token = string.Format("{{{0}}}", formattedName);
                var propertyValue = property.GetValue(entity);
                var value = propertyValue != null ? propertyValue.ToString() : null;
                uri = uri.Replace(token, value);
            }

            return uri;
        }

        public static Uri ResolveTokens<T>(Uri uri, T entity)
        {
            return new Uri(ResolveTokens<T>(uri.ToString(), entity), UriKind.RelativeOrAbsolute);
        }
    }
}