// Copyright (c) 2026 Roger Brown.
// Licensed under the MIT License.

using System;
using System.Management.Automation;
using System.Reflection;
using System.Reflection.Emit;

namespace RhubarbGeekNz.DeAmsify
{
    sealed public class ModuleAssemblyInitializer : IModuleAssemblyInitializer
    {
        private static Type[] typesForDynamicMethod = new Type[] { typeof(object) };
        private static Type[] typesForLogger = new Type[] { typeof(string), typeof(string), typeof(object[]) };

        public void OnImport()
        {
            var field = typeof(PSObject).Assembly.GetType("System.Management.Automation.Language.CachedReflectionInfo").GetField("MemberInvocationLoggingOps_LogMemberInvocation", BindingFlags.Static | BindingFlags.NonPublic);
            var setter = new DynamicMethod("", null, typesForDynamicMethod, true);
            var il = setter.GetILGenerator();
            var logger = typeof(ModuleAssemblyInitializer).GetMethod(nameof(LogMemberInvocation), BindingFlags.Static | BindingFlags.NonPublic, null, typesForLogger, null);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Stsfld, field);
            il.Emit(OpCodes.Ret);
            setter.Invoke(null, new object[] { logger });
        }

        internal static void LogMemberInvocation(string a, string b, object[] args)
        {
        }
    }
}
