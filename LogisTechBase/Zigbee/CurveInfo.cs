using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ZedGraph;

namespace LogisTechBase
{
    public class CurveInfoList : List<CurveInfo>
    {
        public bool HasNodes()
        {
            bool bR = false;

            if (this.Count > 0)
            {
                bR = true;
            }
            return bR;
        }
        public void RemoveAllNodes()
        {
            this.Clear();
        }
        public CurveInfo getCurveInfoByNodeID(int nodeID)
        {
            CurveInfo ciR = null;

            foreach (CurveInfo ci in this)
            {
                if (ci.NodeID == nodeID)
                {
                    ciR = ci;
                    break;
                }
            }
            return ciR;
        }
        public void addNode(CurveInfo curveInfo)
        {
            if (this.IndexOf(curveInfo) == -1)
            {
                this.Add(curveInfo);
            }
        }
        public bool isNodeExists(int nodeID)
        {
            bool bR = false;

            foreach (CurveInfo ci in this)
            {
                if (ci.NodeID == nodeID)
                {
                    bR = true;
                    break;
                }
            }
            return bR;
        }
        public bool hasColor(Color color)
        {
            bool bR = false;

            foreach (CurveInfo ci in this)
            {
                if (ci.CurveColor.ToArgb() == color.ToArgb())
                {
                    bR = true;
                    break;
                }
            }
            return bR;
        }
        public static Color GetRadomColor(CurveInfoList infoList)
        {
            Color color = Color.Black;
            Random ran = new Random();
            bool bFinded = false;
            while (!bFinded)
            {
                int r = ran.Next(0, 255);
                int g = ran.Next(0, 255);
                int b = ran.Next(0, 255);
                color = Color.FromArgb(r, g, b);
                if (!infoList.hasColor(color))
                {
                    bFinded = true;
                }
            }
            return color;
        }
    }
    public class CurveInfo
    {
        int _nodeID;
        public int NodeID
        {
            get { return _nodeID; }
            set { _nodeID = value; }
        }
        string _curveName;
        public string CurveName
        {
            get { return _curveName; }
            set { _curveName = value; }
        }
        PointPairList _pointPairList;
        public PointPairList PointPairList
        {
            get { return _pointPairList; }
            set { _pointPairList = value; }
        }
        Color _curveColor;
        public System.Drawing.Color CurveColor
        {
            get { return _curveColor; }
            set { _curveColor = value; }
        }
        public CurveInfo(int nodeID,string name, Color curveColor)
        {
            this._curveName = name;
            this._curveColor = curveColor;
            this._nodeID = nodeID;
            _pointPairList = new PointPairList();
        }
        public void AddPoint(double x, double y)
        {
            _pointPairList.Add(x, y);
        }
        private CurveInfo()
        {
            this._curveName = "curve";
            this._curveColor = Color.Black;
        }

    }
}
