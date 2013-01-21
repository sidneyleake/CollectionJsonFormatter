namespace CollectionJsonFormatter
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using CollectionJsonFormatter.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class CollectionJsonMediaTypeFormatter : BufferedMediaTypeFormatter
    {
        public CollectionJsonConfiguration Configuration { get; set; }

        public CollectionJsonMediaTypeFormatter()
            :this(new CollectionJsonConfiguration())
        {
        }

        public CollectionJsonMediaTypeFormatter(CollectionJsonConfiguration config)
        {
            Configuration = config;
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/collection+json"));
        }

        public override bool CanReadType(Type type)
        {
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            return true;
        }

        public override void WriteToStream(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                var underlyingType = GetUnderlyingType(type);
                var collectionJson = new CollectionJsonDocument(underlyingType, HttpContext.Current.Request.Path);
                collectionJson.Initialize();
                if (value is CollectionJsonDocument)
                {
                    collectionJson = (CollectionJsonDocument)value;
                }
                else if (value is IEnumerable)
                {
                    foreach (var entity in (IEnumerable)value)
                    {
                        collectionJson.AddItem(entity);
                    }
                }
                else
                {
                    collectionJson.AddItem(value);
                }

                var json = JsonConvert.SerializeObject(
                    value: collectionJson,
                    formatting: Formatting.Indented,
                    settings: Configuration.SerializerSettings
                );

                writer.WriteLine(json);
            }

            writeStream.Close();
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
        }

        private Type GetUnderlyingType(Type type)
        {
            if (type.IsGenericType)
            {
                return type.GetGenericArguments()[0];
            }
            else if (type.HasElementType)
            {
                return type.GetElementType();
            }

            return type;
        }
    }
}
