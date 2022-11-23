﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Editor.Utilities.FileWriters
{
    public static class ScriptGenerator
    {
        private static readonly string PATH = Path.Combine(Application.dataPath, "Editor", "Custom Inspectors");
        
        //TODO Need to add this to get labels acting the way I want
        /*myInspector.Q<GroupBox>("Dynamic Group")
                .Q<Label>(null, "unity-group-box__label").bindingPath = "myDynamicLabel";*/
        
        //ScriptGenerator Functions
        //================================================================================================================//

        public static void TryCreateCustomEditor(in Type type, in IEnumerable<MethodInfo> buttons)
        {
            return;
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(PATH, type.Name));
            
            if(directoryInfo.Exists == false)
                directoryInfo.Create();

            string className;

            /*//If the file already exists, don't touch it
            if (directoryInfo.GetFiles(filename).Length > 0)
                return;*/

            string code;
            if (type.IsSubclassOf(typeof(Component)))
            {
                className = $"{type.Name}CustomInspector";
                //TODO Create Custom Editor
                code = GenerateCustomEditorCode(type, className, buttons);
            }
            else
            {
                className = $"{type.Name}PropertyDrawer";
                //TODO Create Property Drawer
                code = GenerateCustomPropertyDrawerCode(type, className, buttons);
            }

            string filename = $"{className}.cs";
            var path = Path.Combine(directoryInfo.FullName, filename);
            File.WriteAllText(path, code);
            
            Debug.Log($"Successfully Generated Custom Inspector for {type.Name}");

        }

        //Code Generation Functions
        //================================================================================================================//

        private static string GenerateCustomEditorCode(in Type type, in string className, in IEnumerable<MethodInfo> buttons)
        {
            var writer = new Writer
            {
                buffer = new StringBuilder()
            };
            
            var objectInstanceName = $"{type.Name}Instance";


            // Header.
            writer.WriteLine(WriterHelper.MakeAutoGeneratedCodeHeader("UXML Generator",
                new Version(0,0,1).ToString(),
                nameof(ScriptGenerator)));
            // Usings.
            writer.WriteLine("using System.Reflection;");
            writer.WriteLine("using UnityEditor;");
            writer.WriteLine("using UnityEngine.UIElements;");
            writer.WriteLine();
            
            writer.WriteLine($"[CustomEditor(typeof({type.Name}))]");
            
            // Begin class.
            writer.WriteLine($"public class @{className} : UnityEditor.Editor");
            writer.BeginBlock();
            
            // Default CreateInspectorGUI.
            writer.WriteLine("public override VisualElement CreateInspectorGUI()");
            writer.BeginBlock();
            writer.WriteLine($"var {objectInstanceName}= ({type.Name})target;");
            writer.WriteLine();
            writer.WriteLine("// Create a new VisualElement to be the root of our inspector UI");
            writer.WriteLine("VisualElement myInspector = new VisualElement();");
            writer.WriteLine("myInspector.Add(new Label(\"This is a custom inspector\"));");
            writer.WriteLine("// Load and clone a visual tree from UXML");
            writer.WriteLine($"VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(\"Assets/Editor/Custom Inspectors/{type.Name}/{type.Name}UXML.uxml\");");
            writer.WriteLine("visualTree.CloneTree(myInspector);");
            writer.WriteLine();

            //Button callbacks
            if (buttons.Any())
            {
                writer.WriteLine("//Button Attribute Calls");

                writer.WriteLine("//----------------------------------------------------------//");
                writer.WriteLine();
                writer.WriteLine($"var classType = {objectInstanceName}.GetType();");
                writer.WriteLine();
                
                foreach (var methodInfo in buttons)
                {
                    var methodVarName = $"{methodInfo.Name}Method";
                    
                    writer.WriteLine($"//{methodInfo.Name} Action Callback");
                    writer.WriteLine($"var {methodVarName} = classType.GetMethod(\"{methodInfo.Name}\", BindingFlags.NonPublic | BindingFlags.Instance);");
                    writer.WriteLine($"myInspector.Q<UnityEngine.UIElements.Button>(\"{methodInfo.Name}\").clickable.clicked += () =>");
                    writer.BeginBlock();
                    writer.WriteLine($"{methodVarName}.Invoke({objectInstanceName}, default);");
                    writer.EndBlock(';');
                    writer.WriteLine();
                }
                
                writer.WriteLine("//----------------------------------------------------------//");
                writer.WriteLine();

            }
            
            writer.WriteLine("// Return the finished inspector UI");
            writer.WriteLine("return myInspector;");
            //End Function
            writer.EndBlock();
            
            //End Class
            writer.EndBlock();
            
            return writer.buffer.ToString();
        }

        private static string GenerateCustomPropertyDrawerCode(in Type type, in string className, in IEnumerable<MethodInfo> buttons)
        {
            var writer = new Writer
            {
                buffer = new StringBuilder()
            };

            // Header.
            writer.WriteLine(WriterHelper.MakeAutoGeneratedCodeHeader("UXML Generator",
                new Version(0,0,1).ToString(),
                nameof(ScriptGenerator)));
            // Usings.
            writer.WriteLine("using System.Reflection;");
            writer.WriteLine("using UnityEditor;");
            writer.WriteLine("using UnityEngine.UIElements;");
            writer.WriteLine("");
            
            writer.WriteLine($"[CustomPropertyDrawer(typeof({type.Name}))]");
            
            // Begin class.
            writer.WriteLine($"public class @{className} : PropertyDrawer");
            writer.BeginBlock();
            
            // Default CreateInspectorGUI.
            writer.WriteLine("public override VisualElement CreatePropertyGUI(SerializedProperty property)");
            writer.BeginBlock();
            writer.WriteLine("// Create a new VisualElement to be the root of our inspector UI");
            writer.WriteLine("VisualElement myInspector = new VisualElement();");
            writer.WriteLine("myInspector.Add(new Label(\"This is a custom inspector\"));");
            writer.WriteLine("// Load and clone a visual tree from UXML");
            writer.WriteLine($"VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(\"Assets/Editor/Custom Inspectors/{type.Name}/{type.Name}UXML.uxml\");");
            writer.WriteLine("visualTree.CloneTree(myInspector);");
            writer.WriteLine("");
            //Button callbacks
            if (buttons.Any())
            {
                /*var valueTarget = fieldInfo.GetValue(property.serializedObject.targetObject);
        var classType = fieldInfo.FieldType;

        //TestButton Action Callback
        var TestButtonMethod = classType.GetMethod("TestButton", BindingFlags.NonPublic | BindingFlags.Instance);
        myInspector.Q<UnityEngine.UIElements.Button>("TestButton").clickable.clicked += () =>
        {
            TestButtonMethod.Invoke(valueTarget, default);
        };*/
                writer.WriteLine("//Button Attribute Calls");

                writer.WriteLine("//----------------------------------------------------------//");
                writer.WriteLine();
                writer.WriteLine("var valueTarget = fieldInfo.GetValue(property.serializedObject.targetObject);");
                writer.WriteLine("var classType = fieldInfo.FieldType;");
                writer.WriteLine();
                
                foreach (var methodInfo in buttons)
                {
                    var methodVarName = $"{methodInfo.Name}Method";
                    
                    writer.WriteLine($"//{methodInfo.Name} Action Callback");
                    writer.WriteLine($"var {methodVarName} = classType.GetMethod(\"{methodInfo.Name}\", BindingFlags.NonPublic | BindingFlags.Instance);");
                    writer.WriteLine($"myInspector.Q<UnityEngine.UIElements.Button>(\"{methodInfo.Name}\").clickable.clicked += () =>");
                    writer.BeginBlock();
                    writer.WriteLine($"{methodVarName}.Invoke(valueTarget, default);");
                    writer.EndBlock(';');
                    writer.WriteLine();
                }
                
                writer.WriteLine("//----------------------------------------------------------//");
                writer.WriteLine();

            }
            writer.WriteLine("// Return the finished inspector UI");
            writer.WriteLine("return myInspector;");
            //End Function
            writer.EndBlock();
            
            //End Class
            writer.EndBlock();
            
            return writer.buffer.ToString();
        }

        //================================================================================================================//
    }
}