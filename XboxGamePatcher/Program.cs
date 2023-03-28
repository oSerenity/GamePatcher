// Decompiled with JetBrains decompiler
// Type: XboxGamePatcher.Program
// Assembly: GamePatcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C11740F-8410-4FE6-AD26-6C5AD37054D8
// Assembly location: C:\Users\kelp\Downloads\GamePatcher.exe

using System;
using System.Windows.Forms;

namespace XboxGamePatcher
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1());
    }
  }
}
