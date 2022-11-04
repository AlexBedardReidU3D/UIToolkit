using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using Microsoft.CodeAnalysis;
using UnityEditor;

namespace Editor
{
    /*
<ui:UXML xmlns:ui="UnityEngine.UIElements" xmlns:uie="UnityEditor.UIElements" editor-extension-mode="True">
    <ui:Label text="Label" display-tooltip-when-elided="true" />
    <ui:TextField picking-mode="Ignore" label="Text Field" value="filler text" text="filler text" binding-path="bind_1" />
    <uie:IntegerField label="Int Field" value="42" binding-path="bind_2" />
    <uie:FloatField label="Float Field" value="42.2" binding-path="bind_3" />
    <uie:LongField label="Long Field" value="42" binding-path="bind_4" />
    <uie:Vector2Field label="Vec2 Field" />
    <uie:Vector3Field label="Vec3 Field" />
    <uie:Vector4Field label="Vec4 Field" />
    <uie:RectField label="Rect" />
    <uie:BoundsField label="Bounds" />
    <uie:Vector2IntField label="Vector2Int" />
    <uie:Vector3IntField label="Vector3Int" />
    <uie:RectIntField label="RectInt" />
    <uie:BoundsIntField label="BoundsInt" />
    <uie:ObjectField label="Object Field" type="UnityEngine.Texture2D, UnityEngine.CoreModule" />
</ui:UXML>
*/
    //TODO Take a look here: https://docs.unity3d.com/Manual/roslyn-analyzers.html
    public class UXMLGenerator
    {
        private static readonly string PATH = Path.Combine(Application.dataPath, "Editor", "Custom Inspectors");
        
        private static readonly string OPENER =
            "<ui:UXML xmlns:ui=\"UnityEngine.UIElements\" xmlns:uie=\"UnityEditor.UIElements\" editor-extension-mode=\"True\">";
        private static readonly string CLOSER = "</ui:UXML>";
        
        [UnityEditor.Callbacks.DidReloadScripts]
        private static void OnScriptsReloaded() {
            //Based on: https://stackoverflow.com/a/607204
            var typesWithMyAttribute =
                from a in AppDomain.CurrentDomain.GetAssemblies()
                from t in a.GetTypes()
                let attributes = t.GetCustomAttributes(typeof(GenerateUXML), true)
                where attributes != null && attributes.Length > 0
                select new { Type = t, Attributes = attributes.Cast<GenerateUXML>() };

            foreach (var value in typesWithMyAttribute)
            {

                try
                {
                    var filePath = Path.Combine(PATH, $"{value.Type.Name}UXML.uxml");
                    File.WriteAllText(filePath, GetUXML(value.Type));
                    
                    Debug.Log($"Successfully Generated UXML for {value.Type.Name}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            
            AssetDatabase.Refresh();
        }

        private static string GetUXML(in Type type)
        {
            var sb = new StringBuilder();
            sb.AppendLine(OPENER);
            
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            var indentCount = 1;

            for (int i = 0; i < fields.Length; i++)
            {
                if(fields[i].IsPrivate && fields[i].GetCustomAttributes(typeof(SerializeField), false).Length == 0)
                    continue;
                
                sb.AppendLine(RepeatString(indentCount, "\t") + GetFieldAsUXML(fields[i]));
            }

            sb.AppendLine(CLOSER);

            return sb.ToString();
        }

        private static string GetFieldAsUXML(in FieldInfo fieldInfo)
        {
            string uieType;
            var fieldName = fieldInfo.Name;
            var label = fieldName;

            if (fieldInfo.FieldType.IsClass && fieldInfo.FieldType.Namespace.Equals("UnityEngine"))
            {
                return $"<uie:ObjectField label=\"Object Field\" type=\"{fieldInfo.FieldType.FullName}, UnityEngine.CoreModule\" />";
            }
            
            switch (fieldInfo.FieldType.Name)
            {
                case nameof(Int32):
                    uieType = "IntegerField";
                    break;
                case nameof(Single):
                    uieType = "FloatField";
                    break;
                case nameof(Int64):
                    uieType = "LongField";
                    break;
                case nameof(Vector2):
                case nameof(Vector3):
                case nameof(Vector4):
                case nameof(Rect):
                case nameof(Bounds):
                case nameof(Vector2Int):
                case nameof(Vector3Int):
                    uieType = $"{fieldInfo.FieldType.Name}Field";
                    break;
                default:
                    throw new NotImplementedException();
                
            }

            return $"<uie:{uieType} label=\"{label}\" value=\"\" binding-path=\"{fieldInfo.Name}\" />";
        }

        //FIXME This needs to be more performant
        private static string RepeatString(in int count, in string toRepeat)
        {
            string outString = "";

            for (int i = 0; i < count; i++)
            {
                outString += toRepeat;
            }

            return outString;
        }
    }
}