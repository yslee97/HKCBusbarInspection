﻿using GlobalVariableModuleCs;
using System;
using System.Collections.Generic;
using System.Linq;
using VM.Core;

namespace HKCBusbarInspection.Schemas
{
    public class VmGlobals : List<VmVariable>
    {
        private GlobalVariableModuleTool Variables;
        private List<GlobalVarInfo> GlobalVarInfo;
        public void Init()
        {
            base.Clear(); //모델변경시 기존 변수들 초기화
            this.Variables = VmSolution.Instance["Global Variable1"] as GlobalVariableModuleTool;
            if (this.Variables == null) return;
            GlobalVarInfo = Variables.GetAllGlobalVar();

            foreach (GlobalVarInfo info in GlobalVarInfo)
            {
                //if (info.strValueType.ToLower() == typeof(String).Name.ToLower()) continue;
                //if (info.strValueName.Contains("calValue") || info.strValueName.Contains("offset")) continue;
                this.Add(new VmVariable(info));
            }
        }

        public List<VmVariable> 전체보정값불러오기()
        {
            List<GlobalVarInfo> lists = Variables.GetAllGlobalVar();
            List<VmVariable> calValueList = new List<VmVariable>();
            foreach (GlobalVarInfo info in lists)
            {
                if (info.strValueType.ToLower() != typeof(String).Name.ToLower()) continue;

                if (info.strValueName.Contains("CalValue"))
                    calValueList.Add(new VmVariable(info));
            }

            return calValueList;
        }

        public String 교정값불러오기(String 이름, Int32 셔틀위치)
        {
            이름 += "_CalValue";
            VmVariable info = this.Where(e => e.Name == 이름).FirstOrDefault();

            String[] arrStrValue = info.StringValue.Split(';');

            return arrStrValue[셔틀위치];
        }

        public void 교정값적용하기(검사항목 항목, Int32 셔틀위치, Decimal 교정값)
        {
            String 이름 = $"{항목}_CalValue";
            VmVariable info = this.Where(e => e.Name == 이름).FirstOrDefault();

            if (info == null) return;

            String value = info.StringValue;
            String[] arrStrValue = value.Split(';');

            arrStrValue[셔틀위치] = 교정값.ToString();
             
            value = String.Join(";", arrStrValue);

            this.SetValue(이름, value);
        }

        public String GetValue(string name)
        {
            VmVariable info = this.Where(e => e.Name == name).FirstOrDefault();
            return info.StringValue;
        }

        public void InspectUseSet(string Name, string Value)
        {
            if (this.Variables == null) return;

            List<GlobalVarInfo> lists = Variables.GetAllGlobalVar();

            foreach (GlobalVarInfo info in lists)
            {
                if (info.strValueName.Contains(Name))
                    this.Variables.SetGlobalVar(Name, Value);
            }
        }

        public void Set()
        {
            foreach (VmVariable v in this)
                this.Variables.SetGlobalVar(v.Name, v.StringValue);
        }

        public void SetValue(String name, String value)
        {
            this.Variables.SetGlobalVar(name, value);
        }
    }

    public class VmVariable
    {
        public String Name { get; private set; } = String.Empty;
        public String Description { get; private set; } = String.Empty;
        public Type Type { get; private set; } = null;
        public Object Value { get; set; } = null;
        public String StringValue
        {
            get { return this.Value == null ? String.Empty : Value.ToString(); }
            set { this.Set(value); }
        }

        public VmVariable() { }
        public VmVariable(GlobalVarInfo info)
        {
            this.Name = info.strValueName;
            this.Description = info.strRemark;
            if (info.strValueType == "float") this.Type = typeof(Single);
            else if (info.strValueType == "int") this.Type = typeof(Int32);
            else this.Type = typeof(String);
            this.Value = info.strValue;
        }

        public void Set(String value)
        {
            if (this.Type == typeof(Single)) this.Value = Convert.ToSingle(value);
            else if (this.Type == typeof(Int32)) this.Value = Convert.ToInt32(value);
            else this.Value = value;
        }
    }
}
