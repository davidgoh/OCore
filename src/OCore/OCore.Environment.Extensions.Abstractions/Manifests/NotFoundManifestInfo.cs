﻿using System;
using System.Collections.Generic;
using System.Linq;
using OCore.Modules.Manifest;

namespace OCore.Environment.Extensions
{
    public class NotFoundManifestInfo : IManifestInfo
    {
        public NotFoundManifestInfo(string subPath)
        {
        }

        public bool Exists => false;
        public string Name => null;
        public string Description => null;
        public string Type => null;
        public string Author => null;
        public string Website => null;
        public Version Version => null;
        public IEnumerable<string> Tags => Enumerable.Empty<string>();
        public ModuleAttribute ModuleInfo => null;
    }
}
