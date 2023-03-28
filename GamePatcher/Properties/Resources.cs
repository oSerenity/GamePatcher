// Decompiled with JetBrains decompiler
// Type: GamePatcher.Properties.Resources
// Assembly: GamePatcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C11740F-8410-4FE6-AD26-6C5AD37054D8
// Assembly location: C:\Users\kelp\Downloads\GamePatcher.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace GamePatcher.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (GamePatcher.Properties.Resources.resourceMan == null)
          GamePatcher.Properties.Resources.resourceMan = new ResourceManager("GamePatcher.Properties.Resources", typeof (GamePatcher.Properties.Resources).Assembly);
        return GamePatcher.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => GamePatcher.Properties.Resources.resourceCulture;
      set => GamePatcher.Properties.Resources.resourceCulture = value;
    }
  }
}
