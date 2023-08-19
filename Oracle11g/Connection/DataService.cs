using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using Oracle11g.Connection;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace Oracle11g.Connection
{
    public abstract class DataService<T> 
    {
        public List<string> Create(List<T> list)
        {

            List<string> sqls = new List<string>();
            //bool hasLOB = false;
            foreach (T item in list)
            {
                string sql = GetCreateSQL(item); //, out hasLOB);
                sqls.Add(sql);
            }
            return sqls;
        }

        public  string Create(T item)
        {
            //bool hasLOB;
            string sql = GetCreateSQL(item); //, out hasLOB);
            return sql;
        }



        public List<string> Update(List<T> list, List<string> whereConditions)
        {
            List<string> sqls = new List<string>();

            for (int index = 0 ; index < list.Count ; index++)
            {
                string sql = GetUpdateSQL(list[index], whereConditions[index]); //, out hasLOB);
                sqls.Add(sql);
            }
            return sqls;
        }

        public string Update(T item, string whereCondition)
        {
            if (item == null)
                throw new NullReferenceException();

            string sql = GetUpdateSQL(item, whereCondition); //, out hasLOB);
            return sql;
        }

        public string GetSelectSQL(T item, string whereCondition)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE 1=1 {1}", item.GetType().Name, whereCondition);
            return sql.ToString();
        }

        public string GetCreateSQL(T instance) //, out bool hasLOB
        {
            string columnList = null;
            string valueList = null;

            if (instance == null)
                return null;

            int count = 0;
            Dictionary<string, PropertyInfo> propertyInfos = ReflectionFactory.GetInstance().GetPropertyInfos(instance.GetType());
            foreach (PropertyInfo propertyInfo in propertyInfos.Values)
            {
                if (count > 0)
                {
                    columnList += " ,";
                    valueList += " ,";
                }

                object value = propertyInfo.GetValue(instance, null);
                string valueString = null;

                if (value == null)
                {
                    valueString = "null";
                }
                else
                {
                    if (propertyInfo.PropertyType == typeof(string)
                        || propertyInfo.PropertyType == typeof(char))
                    {
                        valueString = string.Format("'{0}'", value.ToString()); // "'" + value.ToString() + "'";
                    }
                    else if (propertyInfo.PropertyType == typeof(DateTime)
                        || propertyInfo.PropertyType == typeof(Nullable<DateTime>))
                    {
                        DateTime dateTime = (DateTime)value;
                        string dateTimeString = dateTime.ToString("yyyyMMddHHmmssfff");
                        valueString = string.Format("TO_TIMESTAMP('{0}', '{1}')", dateTimeString, "YYYYMMDDHH24MISSFF");
                    }
                    else if (propertyInfo.PropertyType == typeof(byte[]))
                    {
                        throw new NotSupportedException(propertyInfo.PropertyType.Name);
                        //valueString = string.Format(":{0}", propertyInfo.Name);
                    }
                    else
                    {
                        valueString = value.ToString();
                    }
                }

                columnList += propertyInfo.Name;
                valueList += valueString;

                count++;
            }
            StringBuilder sql = new StringBuilder();
            sql.Remove(0, sql.Length);
            sql.AppendLine(" INSERT INTO  ");
            sql.AppendLine(string.Format(" {0} ({1})  ", typeof(T).Name, columnList));
            sql.AppendLine(string.Format(" VALUES ({0})  ", valueList));
            return sql.ToString();
        }

        public string GetUpdateSQL(T instance, string whereCondition) //, out bool hasLOB)
        {
            //hasLOB = false;

            string setStatement = null;

            if (instance == null)
                return null;

            int count = 0;
            Dictionary<string, PropertyInfo> propertyInfos = ReflectionFactory.GetInstance().GetPropertyInfos(instance.GetType());
            foreach (PropertyInfo propertyInfo in propertyInfos.Values)
            {
                if (count > 0)
                    setStatement += " ,";

                object value = propertyInfo.GetValue(instance, null);
                string valueString = null;

                if (value == null)
                {
                    valueString = "null";
                }
                else
                {
                    if (propertyInfo.PropertyType == typeof(string)
                        || propertyInfo.PropertyType == typeof(char))
                        valueString = string.Format("'{0}'", value.ToString()); // valueString = "'" + value.ToString() + "'";
                    else if (propertyInfo.PropertyType == typeof(DateTime)
                        || propertyInfo.PropertyType == typeof(Nullable<DateTime>))
                    {
                        DateTime dateTime = (DateTime)value;
                        string dateTimeString = dateTime.ToString("yyyyMMddHHmmssfff");
                        valueString = string.Format("TO_TIMESTAMP('{0}', '{1}')", dateTimeString, "YYYYMMDDHH24MISSFF");

                    }
                    else if (propertyInfo.PropertyType == typeof(byte[]))
                    {
                        throw new NotSupportedException(propertyInfo.PropertyType.Name);
                        //valueString = string.Format(":{0}", propertyInfo.Name);
                    }
                    else
                        valueString = value.ToString();
                }

                setStatement += string.Format("{0}={1}", propertyInfo.Name, valueString);

                count++;
            }

            StringBuilder sql = new StringBuilder();
            sql.Remove(0, sql.Length);
            sql.AppendLine(string.Format(" UPDATE {0} ", typeof(T).Name));
            sql.AppendLine(string.Format(" SET {0} ", setStatement));
            sql.AppendLine(string.Format(" WHERE {0} ", whereCondition));

            return sql.ToString();
        }

        public string GetDeleteSQL(T instance,string whereCondition)
        {
            StringBuilder sql = new StringBuilder();
            sql.Remove(0, sql.Length);
            sql.AppendLine(string.Format(" DELETE FROM {0} ", typeof(T).Name));
            sql.AppendLine(string.Format(" WHERE {0} ", whereCondition));

            return sql.ToString();
        }

        public string GetDatabaseTime()
        {
            string sql = string.Format("SELECT TO_CHAR(SYSDATE,'yyyymmddhh24miss') FROM DUAL", typeof(T).Name, "SYSDATE");
            return sql;
        }
    }
}
