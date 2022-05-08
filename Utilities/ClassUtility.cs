using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinUI.Utilities
{
    public class ClassUtility
    {
        public static Type? TypeOf(string ClassName)
        {
            Type? type = Type.GetType(ClassName);
            if (type != null)
                return type;
            foreach (var assemblies in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = assemblies.GetType(ClassName);
                if (type != null) return type;
            }
            return null;
        }
        public static dynamic? CreateInstance(string ClassName, string Namespace = "WinUI.Action")
        {
            var ClassFullName = $"{Namespace}.{ClassName}";
            Type? type = TypeOf(ClassFullName);

            if (type == null) return null;

            object? instance = Activator.CreateInstance(type);

            return instance;
        }

        public static void InvokeStaticMethod(string ClassName, string MethodName, params object[] args)
        {
            var ClassFullName = $"WinUI.Action.{ClassName}";
            Type? type = TypeOf(ClassFullName);
            if(type == null)
            {
                CommandlineHelper.PrintError($"Action not found {ClassName}");
                return;
            }

            var Method = type.GetMethod(MethodName);
            if (Method == null)
            {
                CommandlineHelper.PrintError($"Method not found: {MethodName}");
                return;
            }

            Method.Invoke(null, args);
        }
    }
}