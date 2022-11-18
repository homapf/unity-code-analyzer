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