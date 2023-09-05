using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace OpenUpmDependencyResolver.Editor
{
    [InitializeOnLoad]
    internal class Resolver
    {
        static Resolver()
        {
            EditorApplication.projectChanged += StartResolve;
            StartResolve();
        }

        private static void StartResolve()
        {
            var manifests = Directory.GetDirectories("./Library/PackageCache")
                .Where(dir => !dir.StartsWith("./Library/PackageCache\\com.unity"))
                .Concat(Directory.GetDirectories("./Packages"))
                .Select(dir => dir + "/package.json")
                .Select(manifest => Json.Deserialize(File.ReadAllText(manifest)) as Dictionary<string, object>)
                .ToArray();

            var installedPackageNames = manifests.Select(manifest => manifest["name"]);

            var resolvedNewPackages = false;
            foreach (var manifest in manifests)
            {
                if (manifest == null)
                {
                    continue;
                }

                if (manifest.ContainsKey("openUpmDependencies"))
                {
                    var openUpmDependencies = manifest["openUpmDependencies"] as Dictionary<string, object>;
                    var uninstalledDependencies = openUpmDependencies
                        .Where(kvp => !installedPackageNames.Contains(kvp.Key))
                        .ToList();
                    for (var i = 0; i < uninstalledDependencies.Count; i++)
                    {
                        var dependency = uninstalledDependencies[i];
                        Debug.Log($"Installing missing dependency: {dependency.Key}@{dependency.Value}");

                        EditorUtility.DisplayProgressBar("Install Package",
                            $"Installing {dependency.Key}@{dependency.Value}",
                            i / (float)uninstalledDependencies.Count);

                        if (!InstallOpenUpmPackage(dependency.Key, (string)dependency.Value))
                        {
                            Debug.LogError(
                                $"Encountered error while trying to install package '{dependency.Key}@{dependency.Value}' from OpenUPM.");
                        }
                        else
                        {
                            resolvedNewPackages = true;
                        }
                    }

                    EditorUtility.ClearProgressBar();
                }
            }

            if (resolvedNewPackages)
            {
                Client.Resolve();
            }
        }

        private static bool InstallOpenUpmPackage(string name, string version)
        {
            var args = version == "default" ? $"add {name}" : $"add {name}@{version}";

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "openupm",
                    Arguments = args,
                    WorkingDirectory = Directory.GetParent(Application.dataPath).ToString(),
                    WindowStyle = ProcessWindowStyle.Hidden,
                }
            };

            process.Start();
            process.WaitForExit();
            return process.ExitCode == 0;
        }
    }
}
