﻿using XCore.Environment.Shell.Models;
using System;
using System.Collections.Generic;

namespace XCore.Environment.Shell
{
    /// <summary>
    /// Represents the minimalistic set of fields stored for each tenant. This
    /// model is obtained from the IShellSettingsManager, which by default reads this
    /// from the App_Data settings.txt files.
    /// 表示存储每个Tenant的简单的字段集合，默认情况下这些字段存储在app_data/settings.txt文件中。
    /// 可从 IShellSettingsManager 获取这个模型。
    /// </summary>
    public class ShellSettings
    {
        private TenantState _tenantState;

        private readonly IDictionary<string, string> _values;

        public ShellSettings() : this(new Dictionary<string, string>()) { }

        public ShellSettings(IDictionary<string, string> configuration)
        {
            _values = configuration;

            if (!configuration.ContainsKey("State") || !Enum.TryParse(configuration["State"], true, out _tenantState))
            {
                _tenantState = TenantState.Invalid;
            }
        }

        public string this[string key]
        {
            get
            {
                string retVal;
                return _values.TryGetValue(key, out retVal) ? retVal : null;
            }
            set { _values[key] = value; }
        }

        public IDictionary<string, string> Configuration => _values;

        public string Name
        {
            get { return this["Name"] ?? ""; }
            set { this["Name"] = value; }
        }

        public string RequestUrlHost
        {
            get { return this["RequestUrlHost"]; }
            set { this["RequestUrlHost"] = value; }
        }

        public string RequestUrlPrefix
        {
            get { return this["RequestUrlPrefix"]; }
            set { _values["RequestUrlPrefix"] = value; }
        }

        public string DatabaseProvider
        {
            get { return this["DatabaseProvider"]; }
            set { _values["DatabaseProvider"] = value; }
        }

        public string TablePrefix
        {
            get { return this["TablePrefix"]; }
            set { _values["TablePrefix"] = value; }
        }

        public string ConnectionString
        {
            get { return this["ConnectionString"]; }
            set { _values["ConnectionString"] = value; }
        }

        public TenantState State
        {
            get => _tenantState;
            set
            {
                _tenantState = value;
                this["State"] = value.ToString();
            }
        }
    }
}
