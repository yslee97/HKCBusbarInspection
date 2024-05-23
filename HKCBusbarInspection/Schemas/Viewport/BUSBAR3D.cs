﻿using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HKCBusbarInspection.Schemas
{
    public class BUSBAR3D : Viewport
    {
        #region 초기화
        public override String StlPath => Global.환경설정.기본경로;
        public override String StlFile => Path.Combine(StlPath, $"{Global.환경설정.선택모델}.stl");
        public override Double Scale => 1;
        internal override void LoadStl()
        {
            if (!File.Exists(StlFile)) return;
            StLReader reader = new StLReader();
            Model3DGroup groups = reader.Read(StlFile);
            MainModel = groups.Children[0] as GeometryModel3D;
            //Debug.WriteLine(groups.Children.Count, "Groups Count");

            Point3D p = Center3D();
            Transform3DGroup transform = new Transform3DGroup();
            transform.Children.Add(new TranslateTransform3D(p.X * Scale, p.Y * Scale, 0 * Scale));
            transform.Children.Add(new ScaleTransform3D(Scale, Scale, Scale));
            MainModel.Transform = transform;
            MainModel.SetName(nameof(MainModel));
            MainModel.Material = FrontMaterial;
            MainModel.BackMaterial = BackMaterial;
            ModelGroup.Children.Add(MainModel);
        }
        #endregion

        #region 기본 설정
        List<Base3D> InspItems = new List<Base3D>();
        internal String InspectionName(검사항목 항목)
        {
            검사정보 정보 = Global.모델자료.선택모델.검사설정.GetItem(항목);
            if (정보 == null) return String.Empty;
            return 정보.검사명칭;
        }
        internal override void InitModel()
        {
            if (MainModel == null) return;
            Rect3D r = MainModel.Bounds;
            Debug.WriteLine($"{r.SizeY}, {r.SizeX}, {r.SizeZ}", "Rectangle3D");
            Double hx = r.SizeX / 2;
            Double hy = r.SizeY / 2;
            Double tz = 108.2;
            Double offset = 5;

            AddText3D(new Point3D(-hx - 60, 0, 55), "R", 48, MajorColors.FrameColor);
            AddText3D(new Point3D(+hx + 60, 0, 55), "F", 48, MajorColors.FrameColor);
            AddArrowLine(new Point3D(-hx, 0, tz + offset), new Point3D(hx, 0, tz + offset * 2), MajorColors.FrameColor); // Front ~ Rear Center
            AddArrowLine(new Point3D(0, -hy, tz + offset), new Point3D(0, hy, tz + offset * 2), MajorColors.FrameColor); // Width Center

            //InspItems.Add(new Label3D(검사항목.f1) { Point = new Point3D(-228.50, +108.5, tz), Origin = new Point3D(-228.50, +108.5 + 20, tz), Name = "f01", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Circle3D(검사항목.a1) { Point = new Point3D(-200, +105, tz), Name = "a1", LabelStyle = NamePrintType.Up });
            InspItems.ForEach(e => e.Create(Children));
        }
        #endregion

        public virtual Color GetColor(결과구분 결과) => 결과 == 결과구분.OK ? MajorColors.GoodColor : MajorColors.BadColor;
        public void SetResults(검사결과 결과)
        {
            foreach (Base3D 항목 in InspItems)
            {
                검사정보 정보 = 결과.GetItem(항목.Type);
                if (정보 == null) continue;
                //if (항목.Type == 검사항목.QrLegibility) 항목.Draw(Decimal.MinValue, 결과.큐알결과());
                else 항목.Draw(정보.결과값, 정보.측정결과);
            }
        }
    }
}