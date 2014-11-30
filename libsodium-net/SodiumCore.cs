﻿using System;
using System.Runtime.InteropServices;
namespace Sodium
{
  /// <summary>
  /// libsodium core information.
  /// </summary>
  public static class SodiumCore
  {
    static SodiumCore()
    {
      SodiumLibrary.init();
    }

    /// <summary>Gets random bytes</summary>
    /// <param name="count">The count of bytes to return.</param>
    /// <returns>An array of random bytes.</returns>
    public static byte[] GetRandomBytes(int count)
    {
      var buffer = new byte[count];
      SodiumLibrary.randombytes_buff(buffer, count);

      return buffer;
    }

    /// <summary>
    /// Returns the version of libsodium in use.
    /// </summary>
    /// <returns>
    /// The sodium version string.
    /// </returns>
    public static string SodiumVersionString()
    {
      var ptr = SodiumLibrary.sodium_version_string();

      return Marshal.PtrToStringAnsi(ptr);
    }

    [Obsolete("Use SodiumLibrary.is64")]
    internal static bool Is64
    {
      get
      {
        return SodiumLibrary.Is64;
      }
    }

    [Obsolete("Use SodiumLibrary.isRunningOnMono")]
    internal static bool IsRunningOnMono()
    {
      return SodiumLibrary.IsRunningOnMono;
    }

    [Obsolete("Use SodiumLibrary.name")]
    internal static string LibraryName()
    {
      return SodiumLibrary.Name;
    }
  }
}
