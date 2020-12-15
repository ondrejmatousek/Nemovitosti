using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Nemovitosti.Test.TestUtils
{
    public static class DeepCopyMaker
    {
        /// <summary>
        /// Vytvoří kopii objektu (deepcopy). Kopírovaný objekt musí být serializovatelný.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">Serializovatelný objekt</param>
        /// <returns></returns>
        public static T DeepCopy<T>(T obj)
        {

            if (!typeof(T).IsSerializable)
                throw new Exception("The source object must be serializable");

            if (Object.ReferenceEquals(obj, null))
                throw new Exception("The source object must not be null");

            T result = default(T);

            using (var memoryStream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, obj);
                memoryStream.Seek(0, SeekOrigin.Begin);
                result = (T)formatter.Deserialize(memoryStream);
            }

            return result;
        }
    }
}
