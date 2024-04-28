global using System;
global using System.IO;
global using System.Security.Permissions;
global using System.Collections.Generic;
global using System.Linq;
global using System.Runtime.CompilerServices;
global using System.Reflection;
global using RWCustom;
global using UnityEngine;
global using Random = UnityEngine.Random;
global using Fisobs.Core;
global using Fisobs.Creatures;
global using Fisobs.Sandbox;
global using Fisobs.Items;
global using Fisobs.Properties;
global using CreatureType = CreatureTemplate.Type;
global using static PathCost.Legality;
global using BepInEx;
global using BepInEx.Logging;

#pragma warning disable CS0618 // Disabled Obsolet, and annonying warning
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]