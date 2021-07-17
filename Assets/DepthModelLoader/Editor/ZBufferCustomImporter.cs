using System.Linq;
using Live2D.Cubism.Core;
using Live2D.Cubism.Editor.Importers;
using Live2D.Cubism.Rendering;
using UnityEditor;
using UnityEngine;

internal static class ZBufferCustomImporter
{
    [InitializeOnLoadMethod]
    private static void RegisterModelImporter()
    {
        CubismImporter.OnDidImportModel += OnModelImport;
    }

    private static void OnModelImport(CubismModel3JsonImporter sender, CubismModel model)
    {
        // Lets pretend we want to change the vertex colors of all drawables to green...
        foreach (var renderer in model.Drawables.Select(d => d.GetComponent<CubismRenderer>()))
        { 
            renderer.Color = Color.white;
            renderer.MinXBuffer = sender.Model3Json.Textures[4];
            renderer.MaxBufferTexture = sender.Model3Json.Textures[3];
        }
    }
}
