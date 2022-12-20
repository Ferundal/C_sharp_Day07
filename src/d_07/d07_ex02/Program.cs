using System;
using d07_ex02.ConsoleSetter;
using d07_ex02.Models;

ConsoleSetter<IdentityUser> consoleSetter = new ConsoleSetter<IdentityUser>();
IdentityUser identityUser = new IdentityUser();
consoleSetter.SetValues(identityUser);
Console.WriteLine(identityUser);
var identityRole = new IdentityRole();
ConsoleSetter<IdentityRole> consoleSetterRole = new ConsoleSetter<IdentityRole>();
consoleSetterRole.SetValues(identityRole);
Console.WriteLine(identityRole);