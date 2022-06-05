using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class BuildTool : Editor
{
    [MenuItem("Tools/Build Windows Bundle")]
    static void BundleWindowsBuild()
    {
        Build(BuildTarget.StandaloneWindows);
    }

    [MenuItem("Tools/Build Android Bundle")]
    static void BundleAndrodBuild()
    {
        Build(BuildTarget.Android);
    }

    [MenuItem("Tools/Build IOS Bundle")]
    static void BundleIOSBuild()
    {
        Build(BuildTarget.iOS);
    }

    static void Build(BuildTarget buildTarget)
    {
        List<AssetBundleBuild> assetBundleBuilds = new List<AssetBundleBuild>();

        string[] files = Directory.GetFiles(Application.dataPath + "/BuildResources", "*", SearchOption.AllDirectories);
        
        for(int i =0;i<files.Length;i++)
        {
            //遍历的所有文件中meta文件不作为打包对象
            if (files[i].EndsWith(".meta"))
                continue;
            Debug.Log("file:" + files[i]);

            //创建一个AssetBundleBuild并收集名字信息
            AssetBundleBuild assetBundle = new AssetBundleBuild();

            string fileName = PathUtil.GetStandardPath(files[i]);
            string assetName = PathUtil.GetUnityPath(fileName);
            assetBundle.assetNames = new string[] {assetName};
            string bundleName = fileName.Replace(PathUtil.BuildResourcesPath, "").ToLower();
            assetBundle.assetBundleName = bundleName + ".ab";
            assetBundleBuilds.Add(assetBundle);
        }

        if (Directory.Exists(PathUtil.BundleOutPath))
            Directory.Delete(PathUtil.BundleOutPath, true);
        Directory.CreateDirectory(PathUtil.BundleOutPath);

        BuildPipeline.BuildAssetBundles(PathUtil.BundleOutPath, assetBundleBuilds.ToArray(), BuildAssetBundleOptions.None, buildTarget);
    }
}
