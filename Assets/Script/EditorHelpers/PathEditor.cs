using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(Path))]
public class PathEditor : Editor
{

    private void OnSceneGUI()
    {
        Path p = target as Path;

        if (p != null && p._points.Count > 0)
        {
            List<Vector3> pts = new List<Vector3>();
            pts.Add(p._start);
            foreach (Vector3 pt in p._points) // dont do the last and first
            {
                pts.Add(pt);
                pts.Add(pt);
            }
            pts.Add(p._end);
            Handles.DrawLines(pts.ToArray());
        }


        EditorGUI.BeginChangeCheck();
        Vector3 newTargetPosition = Handles.PositionHandle(p._start, Quaternion.identity);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(p, "Change Look At Target Position");
            p._start = newTargetPosition;
        }
        for (var i = 0; i < p._points.Count; ++i)
        {
            EditorGUI.BeginChangeCheck();
            newTargetPosition = Handles.PositionHandle(p._points[i], Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(p, "Change Look At Target Position");
                p._points[i] = newTargetPosition;
            }
        }
        EditorGUI.BeginChangeCheck();
        newTargetPosition = Handles.PositionHandle(p._end, Quaternion.identity);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(p, "Change Look At Target Position");
            p._end = newTargetPosition;
        }
    }
}
