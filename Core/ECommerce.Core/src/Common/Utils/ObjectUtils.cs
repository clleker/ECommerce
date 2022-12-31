

using System.Reflection;

namespace ECommerce.Core.Common.Utils
{
    public static class ObjectUtils
    {
        /// <summary>
        /// this method trim properties of as request sended object 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T TrimWhiteSpace<T>(T obj)
        {
            if (obj != null)
            {
                PropertyInfo[] properties = obj!.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {

                    if (property.PropertyType == typeof(string))
                    {
                        var o = property.GetValue(obj, null) ?? "";
                        string s = (string)o;
                        property.SetValue(obj, s.Trim());
                    }
                    else
                    {
                        TrimWhiteSpace(property.GetValue(obj));
                    }
                }

            }
            return obj;
        }
    }
}
