﻿namespace XCore.Environment.Extensions.Loaders
{
    public interface IExtensionLoader
    {
        int Order { get; }
        ExtensionEntry Load(IExtensionInfo extensionInfo);
    }
}