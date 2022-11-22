using System;
using System.Reflection;
using NUnit.Framework;
using UnityEditor.VersionControl;
using UnityEngine;

namespace HomaGames.CodeAnalyzer.Tests
{
    public class CodeAnalyzerTest
    {
        [Test]
        public void FindUsageOfSymbol()
        {
            var method = typeof(MyAwesomeAPI).GetMethod("MyAwesomeMethod",
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            var usages = CodeAnalyzer.FindUsageOfMethod(method,typeof(CodeAnalyzerTest).Assembly);
            
            Assert.AreEqual(6,usages.Count);
            string[] methodNames = new[]
            {
                "get_ThatProperty",
                "set_ThatProperty",
                "ThatMethodName",
                "<LambdaCalls>b__0",
                "<LambdaCalls>b__1",
                ".ctor"
            };
            for (int i = 0; i < usages.Count; i++)
            {
                Assert.True(methodNames[i] == usages[i].Name);
            }
        }
        
        [Test]
        public void ProjectWideTest()
        {
            var method = typeof(Debug).GetMethod("Log",
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
                Type.DefaultBinder,new []{typeof(object)},null);
            Assert.DoesNotThrow(() =>
            {
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    var usages = CodeAnalyzer.FindUsageOfMethod(method,assembly);
                }
            });
        }
    }
}