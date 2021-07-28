using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cy_Configuration
{
    public class Config
    {
        public static bool CheckNotNull(object obj)
        {
            if (obj == null || Object.ReferenceEquals(obj, null))
            {
                throw new NullReferenceException("传入的文件名或节点名称为空");
            }
            else if (obj is string)
            {
                if (String.IsNullOrEmpty(obj.ToString()) || String.IsNullOrWhiteSpace(obj.ToString()))
                {
                    throw new NullReferenceException("传入的文件名或节点名称为空");
                }

            }
            return true;
        }

        public static T GetObj<T>(string fileName, string str)
        {
            CheckNotNull(fileName); CheckNotNull(str);

            IConfiguration configuration = new ConfigurationBuilder()
                                               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                               .AddJsonFile(fileName, optional: true, reloadOnChange: true).Build();

            return (T)configuration.GetSection(str);
        }

        public static string GetStr(string fileName, string str)
        {
            CheckNotNull(fileName); CheckNotNull(str);


            IConfiguration configuration = new ConfigurationBuilder()
                                               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                               .AddJsonFile(fileName, optional: true, reloadOnChange: true).Build();

            return configuration.GetSection(str).Value;
        }
    }
}
