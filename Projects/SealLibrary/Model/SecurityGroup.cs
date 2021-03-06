﻿//
// Copyright (c) Seal Report (sealreport@gmail.com), http://www.sealreport.org.
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. http://www.apache.org/licenses/LICENSE-2.0..
//
using DynamicTypeDescriptor;
using Seal.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace Seal.Model
{
    /// <summary>
    /// A SecurityGroup defines all the security applied to a user belonging to the group
    /// </summary>
    public class SecurityGroup : RootEditor
    {
        #region Editor
        protected override void UpdateEditorAttributes()
        {
            if (_dctd != null)
            {
                //Disable all properties
                foreach (var property in Properties) property.SetIsBrowsable(false);
                //Then enable
                GetProperty("Name").SetIsBrowsable(true);
                GetProperty("ViewType").SetIsBrowsable(true);
                GetProperty("Folders").SetIsBrowsable(true);
                GetProperty("Columns").SetIsBrowsable(true);
                GetProperty("SqlModel").SetIsBrowsable(true);
                GetProperty("WidgetPublication").SetIsBrowsable(true);
                GetProperty("Devices").SetIsBrowsable(true);
                GetProperty("Connections").SetIsBrowsable(true);
                GetProperty("Sources").SetIsBrowsable(true);
                GetProperty("DashboardFolders").SetIsBrowsable(true);
                GetProperty("PersonalDashboardFolder").SetIsBrowsable(true);
                GetProperty("ManageDashboards").SetIsBrowsable(true);
                
                GetProperty("Widgets").SetIsBrowsable(true);

                GetProperty("Culture").SetIsBrowsable(true);
                GetProperty("LogoName").SetIsBrowsable(true);
                GetProperty("PersFolderRight").SetIsBrowsable(true);
                GetProperty("ShowAllFolders").SetIsBrowsable(true);

                TypeDescriptor.Refresh(this);
            }
        }
        #endregion

        /// <summary>
        /// The security group name
        /// </summary>
        [Category("Definition"), DisplayName("\tName"), Description("The security group name."), Id(1, 1)]
        public string Name { get; set; } = "Group";

        /// <summary>
        /// The folder configurations for this group used for Web Publication of reports. By default, repository folders have no right.
        /// </summary>
        [Category("Definition"), DisplayName("Folders"), Description("The folder configurations for this group used for Web Publication of reports. By default, repository folders have no right."), Id(2, 1)]
        [Editor(typeof(EntityCollectionEditor), typeof(UITypeEditor))]
        public List<SecurityFolder> Folders { get; set; } = new List<SecurityFolder>();
        public bool ShouldSerializeFolders() { return Folders.Count > 0; }

        /// <summary>
        /// Define the right of the dedicated personal folder for each user of the group
        /// </summary>
        [Category("Definition"), DisplayName("Personal folder"), Description("Define the right of the dedicated personal folder for each user of the group."), Id(4, 1)]
        [TypeConverter(typeof(NamedEnumConverter))]
        [DefaultValue(PersonalFolderRight.None)]
        public PersonalFolderRight PersFolderRight { get; set; } = PersonalFolderRight.None;

        /// <summary>
        /// Define if the group can view Reports and Dashboards
        /// </summary>
        [Category("Definition"), DisplayName("Show all folders"), Description("If true, parent folder with no rights are also shown in the tree view."), Id(5, 1)]
        [DefaultValue(false)]
        public bool ShowAllFolders { get; set; } = false;

        /// <summary>
        /// Define if the group can view Reports and Dashboards
        /// </summary>
        [Category("Definition"), DisplayName("View type"), Description("Define if the group can view Reports and Dashboards."), Id(6, 1)]
        [TypeConverter(typeof(NamedEnumConverter))]
        [DefaultValue(ViewType.ReportsDashboards)]
        public ViewType ViewType { get; set; } = ViewType.ReportsDashboards;

        /// <summary>
        /// For the Web Report Designer: If true, SQL Models and Custom SQL for elements or restrictions can be edited through the Web Report Designer.
        /// </summary>
        [Category("Web Report Designer Security"), DisplayName("\t\t\tSQL Models"), Description("For the Web Report Designer: If true, SQL Models and Custom SQL for elements or restrictions can be edited through the Web Report Designer. Note that dynamic filters set for security purpose will not be applied."), Id(1, 2)]
        [DefaultValue(false)]
        public bool SqlModel { get; set; } = false;

        /// <summary>
        /// For the Web Report Designer: If true, SQL Models and Custom SQL for elements or restrictions can be edited through the Web Report Designer.
        /// </summary>
        [Category("Web Report Designer Security"), DisplayName("\t\t\tWidget Publication"), Description("For the Web Report Designer: If true, a report edited can be published as a Dashboard Widget. Note that a Logout/Login is required after a publication to refresh the list of Widgets available in the Dashboard Manager"), Id(2, 2)]
        [DefaultValue(true)]
        public bool WidgetPublication { get; set; } = true;

        /// <summary>
        /// For the Web Report Designer: Device rights for the group. Set rights to devices through their names. By default, all devices can be selected.
        /// </summary>
        [Category("Web Report Designer Security"), DisplayName("\t\tDevices"), Description("For the Web Report Designer: Device rights for the group. Set rights to devices through their names. By default, all devices can be selected."), Id(3, 2)]
        [Editor(typeof(EntityCollectionEditor), typeof(UITypeEditor))]
        public List<SecurityDevice> Devices { get; set; } = new List<SecurityDevice>();
        public bool ShouldSerializeDevices() { return Devices.Count > 0; }

        /// <summary>
        /// For the Web Report Designer: Data sources rights for the group. Set rights to data source through their names. By default, all sources can be selected.
        /// </summary>
        [Category("Web Report Designer Security"), DisplayName("\t\tSources"), Description("For the Web Report Designer: Data sources rights for the group. Set rights to data source through their names. By default, all sources can be selected."), Id(4, 2)]
        [Editor(typeof(EntityCollectionEditor), typeof(UITypeEditor))]
        public List<SecuritySource> Sources { get; set; } = new List<SecuritySource>();
        public bool ShouldSerializeSources() { return Sources.Count > 0; }

        /// <summary>
        /// For the Web Report Designer: Connections rights for the group. Set rights to connections through their names. By default, all connections can be selected.
        /// </summary>
        [Category("Web Report Designer Security"), DisplayName("\tConnections"), Description("For the Web Report Designer: Connections rights for the group. Set rights to connections through their names. By default, all connections can be selected."), Id(5, 2)]
        [Editor(typeof(EntityCollectionEditor), typeof(UITypeEditor))]
        public List<SecurityConnection> Connections { get; set; } = new List<SecurityConnection>();
        public bool ShouldSerializeConnections() { return Connections.Count > 0; }

        /// <summary>
        /// For the Web Report Designer: Columns rights for the group. Set rights to columns through the security tags or categories assigned. By default, all columns can be selected.
        /// </summary>
        [Category("Web Report Designer Security"), DisplayName("Columns"), Description("For the Web Report Designer: Columns rights for the group. Set rights to columns through the security tags or categories assigned. By default, all columns can be selected."), Id(6, 2)]
        [Editor(typeof(EntityCollectionEditor), typeof(UITypeEditor))]
        public List<SecurityColumn> Columns { get; set; } = new List<SecurityColumn>();
        public bool ShouldSerializeColumns() { return Columns.Count > 0; }

        /// <summary>
        /// If true, the user can modify his current dashboard view (e.g. add/remove dashboards in his view or change orders).
        /// </summary>
        [Category("Dashboards Security"), DisplayName("Manage Dashboards View"), Description("If true, the user can modify his current dashboard view (e.g. add/remove dashboards in his view or change orders)."), Id(1, 3)]
        [DefaultValue(true)]
        public bool ManageDashboards { get; set; } = true;

        /// <summary>
        /// If true, users of the group have a personal folder to create personal dashboards.
        /// </summary>
        [Category("Dashboards Security"), DisplayName("Personal Dashboard Folder"), Description("If true, users of the group have a personal folder to create personal dashboards."), Id(2, 3)]
        [DefaultValue(false)]
        public bool PersonalDashboardFolder { get; set; } = false;

        /// <summary>
        /// The dashboard folder configurations for this group used for Web Publication of dashboards. By default, repository dashboard folders have no right.
        /// </summary>
        [Category("Dashboards Security"), DisplayName("\tDashboard Folders"), Description("The dashboard folder configurations for this group used for Web Publication of dashboards. By default, repository dashboard folders have no right."), Id(3, 3)]
        [Editor(typeof(EntityCollectionEditor), typeof(UITypeEditor))]
        public List<SecurityDashboardFolder> DashboardFolders { get; set; } = new List<SecurityDashboardFolder>();
        public bool ShouldSerializeDashboardFolders() { return DashboardFolders.Count > 0; }

        /// <summary>
        /// For the Dashboard Manager: Widget rights for the group. Set rights to widgets through the security tags or names assigned. By default all widgets can be selected.
        /// </summary>
        [Category("Dashboards Security"), DisplayName("Widgets"), Description("For the Dashboard Manager: Widget rights for the group. Set rights to widgets through the security tags or names assigned. By default all widgets can be selected."), Id(4, 3)]
        [Editor(typeof(EntityCollectionEditor), typeof(UITypeEditor))]
        public List<SecurityWidget> Widgets { get; set; } = new List<SecurityWidget>();
        public bool ShouldSerializeWidgets() { return Widgets.Count > 0; }

        /// <summary>
        /// The culture used for users belonging to the group. If empty, the default culture is used.
        /// </summary>
        [Category("Options"), DisplayName("Culture"), Description("The culture used for users belonging to the group. If empty, the default culture is used."), Id(1, 5)]
        [TypeConverter(typeof(Seal.Forms.CultureInfoConverter))]
        public string Culture { get; set; }

        /// <summary>
        /// The logo file name used for to generate the reports. If empty, the default logo is used.
        /// </summary>
        [Category("Options"), DisplayName("Logo file name"), Description("The logo file name used for to generate the reports. If empty, the default logo is used."), Id(3, 5)]
        public string LogoName { get; set; }
    }
}
