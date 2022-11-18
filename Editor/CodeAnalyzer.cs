using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace HomaGames.CodeAnalyzer
{
    public static class CodeAnalyzer
    {
        public static List<MethodBase> FindUsageOfMethod(MethodInfo method, Assembly assembly)
        {
            List<MethodBase> methods = new List<MethodBase>();
            foreach (var type in assembly.GetTypes())
            {
                List<MethodBase> methodBases = new List<MethodBase>();
                methodBases.AddRange(type.GetMethods());
                methodBases.AddRange(type.GetConstructors());
                foreach (var bodyMethod in methodBases)
                {
                    try
                    {
                        FindMethodUsageInsideMethodBody(method, bodyMethod, methods);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }

            return methods;
        }

        /// <summary>
        /// Finds usage of a method inside another method
        /// </summary>
        /// <param name="method"></param>
        /// <param name="bodyMethod"></param>
        /// <param name="methodsUsingIt"></param>
        /// <returns></returns>
        public static void FindMethodUsageInsideMethodBody(MethodInfo method, MethodBase bodyMethod,
            List<MethodBase> methodsUsingIt, int depth = 0)
        {
            const int maxSearchDepth = 4;
            var instructions = MethodBodyReader.GetInstructions(bodyMethod);

            foreach (Instruction instruction in instructions)
            {
                MethodInfo methodInfo = instruction.Operand as MethodInfo;

                if (methodInfo != null)
                {
                    if (methodInfo == method)
                    {
                        methodsUsingIt.Add(bodyMethod);
                    }
                    // This is a lambda declaration
                    else if (methodInfo.Name.Contains('<') && depth < maxSearchDepth)
                    {
                        depth++;
                        FindMethodUsageInsideMethodBody(method, methodInfo, methodsUsingIt, depth);
                    }
                }
            }
        }
    }
}