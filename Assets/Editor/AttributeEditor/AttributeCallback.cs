using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Editor.AttributeEditor
{
    public static class AttributeCallback
    {
        //[UnityEditor.Callbacks.DidReloadScripts]
        private static void OnScriptsReloaded() {
            // do something
            Debug.Log("Compiled Scripts");
            
            //Based on: https://stackoverflow.com/a/607204
            var typesWithMyAttribute =
                from a in AppDomain.CurrentDomain.GetAssemblies()
                from t in a.GetTypes()
                from f in t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
                let attributes = f.GetCustomAttributes(typeof(CustomLabel), true)
                where attributes != null && attributes.Length > 0
                select new { Type = t, Field = f, Attributes = attributes.Cast<CustomLabel>() };

            foreach (var value in typesWithMyAttribute)
            {
                Debug.Log($"{value.Type.Name}.{value.Field.Name} = {string.Join(", ", value.Attributes.Select(x => x.GetText()))}");
            }
        }

    }
}