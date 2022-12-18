using System;
using System.Reflection;
using Microsoft.AspNetCore.Http;

var httpContext = new DefaultHttpContext();
Console.WriteLine($"Old Response value: {httpContext.Response}");
var field = httpContext.GetType().GetField("_response", BindingFlags.Instance | BindingFlags.NonPublic);
if (field != null) field.SetValue(httpContext, null);
Console.WriteLine($"New Response value: {httpContext.Response}");