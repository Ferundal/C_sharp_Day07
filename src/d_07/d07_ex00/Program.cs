using System;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Http;

var httpContext = new DefaultHttpContext();
var type = httpContext.GetType();
Console.WriteLine(
    $"Type: {type.FullName}{Environment.NewLine}" +
    $"Assembly: {type.Assembly.FullName}");
var baseType = type.BaseType;
if (baseType != null)
{
    Console.WriteLine($"Based on: {baseType.FullName}");
}

WriteFields();
WriteProperties();
WriteMethods();


void WriteMethods()
{
    var methods = type.GetMethods();
    if (methods.Length > 0)
    {
        Console.WriteLine($"{Environment.NewLine}Properties:");
        foreach (var method in methods)
        {
            var args = method.GetParameters();
            if (args.Length > 0)
            {
                var sb = new StringBuilder($"{method.ReturnType.Name} {method.Name} (");
                sb.Append($"{args[0].ParameterType.Name} {args[0].Name}");
                for (int index = 1; index < args.Length; index++)
                {
                    sb.Append($", {args[index].ParameterType.Name} {args[index].Name}");
                }
                sb.Append(")");
                Console.WriteLine(sb.ToString());
            }
            else
                Console.WriteLine($"{method.ReturnType.Name} {method.Name} ()");
        }
    }
}

void WriteProperties()
{
    var properties = type.GetProperties();
    if (properties.Length > 0)
    {
        Console.WriteLine($"{Environment.NewLine}Properties:");
        foreach (var property in properties)
        {
            Console.WriteLine($"{property.PropertyType} {property.Name}");
        }
    }
}

void WriteFields()
{
    var publicFields = type.GetFields(BindingFlags.Instance);
    var publicStaticFields = type.GetFields(BindingFlags.Static);

    var privateFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
    var privateStaticFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Static);
    if (publicFields.Length < 1
        && publicStaticFields.Length < 1
        && privateFields.Length < 1
        && privateStaticFields.Length < 1)
        return; 
    Console.WriteLine($"{Environment.NewLine}Fields:");
    if (publicFields.Length > 0) {
        Console.WriteLine($"{Environment.NewLine}Public:");
        foreach (var field in publicFields)
        {
            Console.WriteLine($"{field.FieldType} {field.Name}");
        }
    }
    if (publicStaticFields.Length > 0) {
        Console.WriteLine($"{Environment.NewLine}Public static:");
        foreach (var field in publicStaticFields)
        {
            Console.WriteLine($"{field.FieldType} {field.Name}");
        }
    }
    if (privateFields.Length > 0) {
        Console.WriteLine($"{Environment.NewLine}Private:");
        foreach (var field in privateFields)
        {
            Console.WriteLine($"{field.FieldType} {field.Name}");
        }
    }
    if (privateStaticFields.Length > 0) {
        Console.WriteLine($"{Environment.NewLine}Private static:");
        foreach (var field in privateStaticFields)
        {
            Console.WriteLine($"{field.FieldType} {field.Name}");
        }
    }
}
