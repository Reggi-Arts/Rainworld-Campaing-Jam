/// </summary>
///The global function allows you to reuse the same 'usings' for all the CS project files you are using. 
///It can be used for convenience or to fix ambiguities
/// </summary>
// Most of the things you will use from system namespace
global using System;
global using System.IO;
global using System.Security.Permissions;
global using System.Collections.Generic;
global using System.Linq;
global using System.Runtime.CompilerServices;
global using System.Reflection;
global using RWCustom;
global using UnityEngine;
//Ambiguety with System.Random
global using Random = UnityEngine.Random;
//Fisobs
global using Fisobs.Core;
global using Fisobs.Creatures;
global using Fisobs.Sandbox;
global using Fisobs.Items;
global using Fisobs.Properties;
global using CreatureType = CreatureTemplate.Type;
global using static PathCost.Legality;
//Plugin and logger
global using BepInEx;
global using BepInEx.Logging;

#pragma warning disable CS0618 // This allows you to access private members of the game without any problem
                               // It's better to leave it as is, or you could encounter unexpected errors.
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]