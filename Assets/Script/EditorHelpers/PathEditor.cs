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

        if (p != null && p._points.Count > 2)
        {
            List<Vector3> pts = new List<Vector3>();
            pts.Add(p.Start);
            Vector3 last_pt = p.Start;
            for (int i = 1; i < p._points.Count - 1; ++i) // dont do the last and first
            {
                DrawArrows(p._points[i], last_pt);
                pts.Add(p._points[i]);
                pts.Add(p._points[i]);
                last_pt = p._points[i];
            }
            pts.Add(p.End);
            DrawArrows(p.End, last_pt);
            Handles.DrawLines(pts.ToArray());


            for (var i = 0; i < p._points.Count; ++i)
            {
                EditorGUI.BeginChangeCheck();
                Vector3 newTargetPosition = Handles.PositionHandle(p._points[i], Quaternion.identity);
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(p, "Change Look At Target Position");
                    p._points[i] = newTargetPosition;
                }
            }
        }
    }

    public void  DrawArrows(Vector3 pt, Vector3 last_pt)
    {
        Vector3 pos = (pt + last_pt) / 2;
        Handles.ArrowHandleCap(0, pos, Quaternion.LookRotation(pt - last_pt), HandleUtility.GetHandleSize(pos), EventType.Repaint);
    }
}
