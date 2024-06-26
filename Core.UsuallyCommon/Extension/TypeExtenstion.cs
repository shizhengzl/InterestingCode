﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public static class TypeExtenstion
    {
        public static void SetPropertyValue(this object instance, string propertyName, object value)
        {
            var propertyInfos = instance.GetType().GetProperties().ToList();
            var property = (propertyInfos.FirstOrDefault(x => x.Name == propertyName));
            if (property != null)
            {
                if (IsNullableType(property.PropertyType))
                    property.SetValue(instance, value, null);
                else
                    property.SetValue(instance, Convert.ChangeType(value, property.PropertyType), null);
            }

        }

        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }

        // 获取文件扩展名
        public static string GetFileExtension(this object obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.ToStringExtension()))
                return string.Empty;
            if (File.Exists(obj.ToStringExtension()))
                return Path.GetExtension(obj.ToStringExtension());
            else
                return obj.ToStringExtension().LastIndexOf(".") > 0 ? obj.ToStringExtension().Substring(obj.ToStringExtension().LastIndexOf('.')) : string.Empty;
        }
        public static string GetFileName(this object obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.ToStringExtension()))
                return string.Empty;
            if (File.Exists(obj.ToStringExtension()))
                return Path.GetFileNameWithoutExtension(obj.ToStringExtension());
            else
            {
                int index = obj.ToStringExtension().LastIndexOf('/');
                index = index < 0 ? obj.ToStringExtension().LastIndexOf('\\') + 1 : index;
                return (index < 0) ? obj.ToStringExtension().Replace(obj.GetFileExtension(), string.Empty) : obj.ToStringExtension().Substring(index).Replace(obj.GetFileExtension(), string.Empty);
            }
        }
        // 获取文件目录
        public static string GetFileDirectory(this object obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.ToStringExtension()))
                return string.Empty;
            string result = obj.ToStringExtension().Replace(obj.GetFileName() + obj.GetFileExtension(), string.Empty);
            return (result.Length > 0 ? result.Substring(0, result.Length - 1) : string.Empty);
        }

        public static bool ToBool(this object obj)
        {
            bool result = false;
            if (obj == null)
                return result;
            bool isparse = bool.TryParse(obj.ToStringExtension(), out result);
            return result;
        }


        public static Int32 ToInt32(this object obj)
        {
            Int32 result = 0;
            if (obj == null)
                return result;
            bool isparse = Int32.TryParse(obj.ToStringExtension(), out result);
            return result;
        }

        public static Double ToDouble(this object obj)
        {
            Double result = 0;
            if (obj == null)
                return result;
            bool isparse = Double.TryParse(obj.ToStringExtension(), out result);
            return result;
        }

        public static string ToStringExtension(this object obj)
        {
            string result = string.Empty;
            if (obj != null)
                result = obj.ToString();
            return result;
        }

        // guid trim
        public static Decimal ToDecimal(this object obj)
        {
            Decimal result = 0;
            if (obj != null)
                Decimal.TryParse(obj.ToString(), out result);
            return result;
        }

        // guid trim
        public static DateTime ToDateTime(this object obj)
        {
            DateTime result = DateTime.MaxValue;
            if (obj != null)
                DateTime.TryParse(obj.ToString(), out result);
            return result;
        }

        public static List<String> GetPropertyList(this object objects) 
        {
            PropertyInfo[] propertys = objects.GetType().GetProperties();

            return propertys.Select(x => x.Name).ToList<string>();
        }



        /// <summary>
        /// DataTable 转换为List 集合
        /// </summary>
        /// <typeparam name="TResult">类型</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dt) where T : class, new()
        {
            //创建一个属性的列表
            List<PropertyInfo> prlist = new List<PropertyInfo>();
            //获取TResult的类型实例  反射的入口
            Type t = typeof(T);
            //获得TResult 的所有的Public 属性 并找出TResult属性和DataTable的列名称相同的属性(PropertyInfo) 并加入到属性列表 
            Array.ForEach<PropertyInfo>(t.GetProperties(), p => { if (dt.Columns.IndexOf(p.Name) != -1) prlist.Add(p); });
            //创建返回的集合
            List<T> oblist = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                //创建TResult的实例
                T ob = new T();
                //找到对应的数据  并赋值
                prlist.ForEach(p => { if (row[p.Name] != DBNull.Value) p.SetValue(ob, row[p.Name], null); });
                //放入到返回的集合中.
                oblist.Add(ob);
            }
            return oblist;
        }
    }

    public static partial class Extensions
    {
        /// <summary>
        /// 把集合转成DataTable
        /// </summary>
        public static DataTable EnumToDataTable<T>(this IEnumerable<T> enumerable)
        {
            var dataTable = new DataTable();
            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(T)))
            {
                dataTable.Columns.Add(pd.Name, pd.PropertyType);
            }
            foreach (T item in enumerable)
            {
                var Row = dataTable.NewRow();

                foreach (PropertyDescriptor dp in TypeDescriptor.GetProperties(typeof(T)))
                {
                    Row[dp.Name] = dp.GetValue(item);
                }
                dataTable.Rows.Add(Row);
            }
            return dataTable;
        }

        /// <summary>
        /// 枚举转字典
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<string, string> EnumToDictionary(this Type enumType)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            foreach (int i in Enum.GetValues(enumType))
            {
                list.Add(i.ToString(), Enum.GetName(enumType, i));
            }
            return list;
        }

        public static Dictionary<string, string> EnumToDictionaryReverse(this Type enumType)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            foreach (int i in Enum.GetValues(enumType))
            {
                list.Add(Enum.GetName(enumType, i), i.ToString());
            }
            return list;
        }

        public static List<string> EnumToList<T>() where T : struct
        {
            List<string> list = new List<string>();
            foreach (int i in Enum.GetValues(typeof(T)))
            {
                list.Add(Enum.GetName(typeof(T), i));
            }
            return list;
        }

        public static List<string> EnumToList(Type type) 
        {
            List<string> list = new List<string>();
            foreach (int i in Enum.GetValues(type))
            {
                list.Add(Enum.GetName(type, i));
            }
            return list;
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            System.Reflection.FieldInfo field = value.GetType().GetField(value.ToString());

            System.ComponentModel.DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(System.ComponentModel.DescriptionAttribute)) as System.ComponentModel.DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static T EnumParse<T>(string value) where T : struct
        {
            return EnumParse<T>(value, false);
        }

        public static T EnumParse<T>(string value, bool ignoreCase) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enum type.");
            }

            var result = (T)Enum.Parse(typeof(T), value, ignoreCase);
            return result;
        }

        public static T ToEnum<T>(this string value) where T : struct
        {
            return EnumParse<T>(value);
        }

        public static T ToEnum<T>(this string value, bool ignoreCase) where T : struct
        {
            return EnumParse<T>(value, ignoreCase);
        }


        public static string GetPropertyValue(this object obj,string name)
        {
            return obj.GetType().GetProperty(name).GetValue(obj, null).ToStringExtension();
        }
    


        #region TypeConvert
        // dll .cs
        // xml 
        // json
        // sql sqladdress

        // data and constract
        // string file
       
        #endregion
    }
}
