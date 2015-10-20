﻿// Copyright (c) 2015 Feenux LLC, All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Xml;
using System.Reflection;

using TH_Configuration.Converter_Sub_Classes;

namespace TH_Configuration
{
    public static class Converter
    {

        public static DataTable XMLToTable(XmlDocument xml)
        {
            DataTable result = null;

            List<XmlToTable.TableInfo> infos = XmlToTable.XMLToTable_CreateData(xml);

            result = XmlToTable.XMLToTable_CreateTable(infos);

            return result;
        }

        public static XmlDocument TableToXML(DataTable table)
        {
            XmlDocument result = null;

            TableToXml.Create(table);

            return result;
        }

    }
}