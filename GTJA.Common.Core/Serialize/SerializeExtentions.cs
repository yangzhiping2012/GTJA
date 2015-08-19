using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GTJA.Common.Core.Serialize
{
    public static class SerializeExtentions
    {
        #region JSON序列化和反序列化

        public static T FromJson<T>(this string str) 
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        public static string ToJson<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj,
                Formatting.None,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        } 
        #endregion

        #region XML序列化和反序列化

        public static T FromXml<T>(this string str)
        {
            var temp = Encoding.UTF8.GetBytes(str);
            using (var mstream = new MemoryStream(temp))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(mstream);
            }
        }


        public static string ToXml<T>(this T obj)
        {
            using (var mstream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(mstream, obj);
                return Encoding.UTF8.GetString(mstream.ToArray());
            }
        } 
        #endregion

        #region MemoryStream序列化和反序列化

        public static T FromStream<T>(this MemoryStream stream) where T : class
        {
            using (stream)
            {
                stream.Position = 0;
                var deserializer = new BinaryFormatter();
                var temp = deserializer.Deserialize(stream);
                return temp as T;
            }
        }
        public static MemoryStream ToStream<T>(this T obj)
        {
            var serializer = new BinaryFormatter();
            var stream = new MemoryStream();
            serializer.Serialize(stream, obj);
            return stream;
        } 
        #endregion

        #region Bytes序列化和反序列化

        public static byte[] ToBytes<T>(this T obj)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Flush();
                return stream.ToArray();
            }
        }

        public static T FromBytes<T>(this byte[] bytes) where T : class
        {
            using (var stream = new MemoryStream(bytes, 0, bytes.Length, false))
            {
                var formatter = new BinaryFormatter();
                var data = formatter.Deserialize(stream);
                stream.Flush();
                return data as T;
            }
        } 
        #endregion
    }
}
