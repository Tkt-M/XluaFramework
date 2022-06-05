using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathUtil
{
    //根目录，变量赋值防止GC
    public static readonly string AssetPath = Application.dataPath;

    //需要打bundle的目录
    public static readonly string BuildResourcesPath = AssetPath + "/BuildResources/";

    //bundle 输出目录
    public static readonly string BundleOutPath = Application.streamingAssetsPath;

    /// <summary>
    /// 获取Unity的相对路径
    /// </summary>
    /// <param name="path">绝对路径值</param>
    /// <returns></returns>
    public static string GetUnityPath(string path)
    {
        if (string.IsNullOrEmpty(path))
            return string.Empty;
        return path.Substring(path.IndexOf("Assets"));
    }

    /// <summary>
    /// 获取标准路径
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string GetStandardPath(string path)
    {
        if (string.IsNullOrEmpty(path))
            return string.Empty;
        return path.Trim().Replace("\\", "/");
    }
}
