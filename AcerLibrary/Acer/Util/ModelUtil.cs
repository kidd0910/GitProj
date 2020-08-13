using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//namespace LogicClass.Util
namespace Acer.Util
{
    public class ModelUtil
    {
        /// <summary>
        /// Model轉換<來源.目的>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<string> GetModelKeys<T>(T model)
            where T : new()
        {
            var keys = new List<string>();
            var type = new T().GetType();
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                // pass paginaiton
                if (!"paginaiton".Equals(prop.Name))
                    keys.Add(prop.Name);
            }
            return keys;
        }

        /// <summary>
        /// Model轉換<來源.目的>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static TM Conver<TR, TM>(TR ent)
            where TM : new()
            where TR : new()
        {
            if (ent == null)
            {
                return default(TM);
            }
            else
            {
                var typeM = new TM().GetType();
                var typeR = new TR().GetType();
                var propsM = typeM.GetProperties();

                var model = new TM();

                foreach (var propM in propsM)
                {
                    var propTypeM = propM.PropertyType;

                    var propR = typeR.GetProperty(propM.Name);

                    if (propR != null)
                    {
                        object value = propR.GetValue(ent);

                        if (typeof(string).Equals(propTypeM))
                        {
                            if (value == null)
                            {
                                propM.SetValue(model, "");
                            }
                            else
                            {
                                propM.SetValue(model, ModelUtil.GetValue(value));
                            }
                        }
                        else
                        {
                            if (value == null)
                            {
                                propM.SetValue(model, null);
                            }
                            else
                            {
                                propM.SetValue(model, value);
                            }
                        }
                    }
                }

                return model;
            }
        }

        public static List<TM> Conver<TR, TM>(List<TR> list)
            where TM : new()
            where TR : new()
        {
            if (list == null)
            {
                return null;
            }
            else
            {
                var typeM = new TM().GetType();
                var typeR = new TR().GetType();
                var propsM = typeM.GetProperties();

                var models = new List<TM>();

                foreach (var ent in list)
                {
                    var model = new TM();

                    foreach (var propM in propsM)
                    {
                        var propTypeM = propM.PropertyType;

                        var propR = typeR.GetProperty(propM.Name);

                        if (propR != null)
                        {
                            object value = propR.GetValue(ent);

                            if (typeof(string).Equals(propTypeM))
                            {
                                if (value == null)
                                {
                                    propM.SetValue(model, "");
                                }
                                else
                                {
                                    propM.SetValue(model, ModelUtil.GetValue(value));
                                }
                            }
                            else
                            {
                                if (value == null)
                                {
                                    propM.SetValue(model, "");
                                }
                                else
                                {
                                    propM.SetValue(model, value);
                                }
                            }
                        }
                    }

                    models.Add(model);
                }

                return models;
            }
        }

        public static T DataReaderToModel<T>(SqlDataReader sdr) where T : new()
        {
            var t = new T();

            var type = t.GetType();

            for (int i = 0; i < sdr.FieldCount; ++i)
            {
                string name = sdr.GetName(i);
                object value = sdr.GetValue(i);

                SetPropertyValue(type, name, t, value);
            }

            return t;
        }

        public static void SetPropertyValue(Type type, string name, object model, object value)
        {
            var prop = type.GetProperty(name);

            if (prop == null)
            {
                prop = type.GetProperty(name.ToUpper());
            }

            if (prop != null)
            {
                var propType = prop.PropertyType;

                if (typeof(string).Equals(propType))
                {
                    if (DBNull.Value.Equals(value))
                    {
                        prop.SetValue(model, "");
                    }
                    else
                    {
                        prop.SetValue(model, ModelUtil.GetValue(value));
                    }

                }
                else
                {
                    if (DBNull.Value.Equals(value))
                    {
                        prop.SetValue(model, "");
                    }
                    else
                    {
                        if (typeof(string).Equals(value.GetType()) || typeof(DateTime).Equals(value.GetType()))
                        {
                            prop.SetValue(model, ModelUtil.GetValue(value));
                        }
                        else
                        {
                            prop.SetValue(model, value);
                        }
                    }
                }
            }
        }

        public static string GetValue(object value)
        {
            if (value != null)
            {
                if (typeof(DateTime).Equals(value.GetType()))
                {
                    var dateTimeValue = (DateTime)value;
                    if (dateTimeValue.Year == 1900)
                    {
                        return "";
                    }
                    else
                    {
                        return dateTimeValue.ToString("yyyy/MM/dd HH:mm:ss");
                    }
                }
                else if (typeof(string).Equals(value.GetType()))
                {
                    return value.ToString().Trim();
                }
                else
                {
                    return value.ToString();
                }
            }
            else
            {
                return "";
            }
        }

        public static string GetParamterValue(object value)
        {
            var valueString = "";
            var valueFormate = "'{0}'";
            if (value != null && !DBNull.Value.Equals(value))
            {
                if (typeof(byte[]).Equals(value.GetType()))
                {
                    valueString = StringUtil.BytesToHexString(value as byte[]);
                }
                else if (typeof(DateTime).Equals(value.GetType()))
                {
                    var dateTimeValue = (DateTime)value;
                    if (dateTimeValue.Year == 1900)
                    {
                        valueString = string.Format(valueFormate, "");
                    }
                    else
                    {
                        valueString = string.Format(valueFormate, dateTimeValue.ToString("yyyy/MM/dd HH:mm:ss"));
                    }
                }
                else if (typeof(string).Equals(value.GetType()))
                {
                    valueString = string.Format(valueFormate, value.ToString().Trim());
                }
                else
                {
                    valueString = string.Format(valueFormate, value.ToString());
                }
            }
            else
            {
                valueString = "NULL";
            }

            return valueString;
        }

    }
}
