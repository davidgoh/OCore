﻿namespace XCore.Environment.Shell.Descriptor.Models
{
    public class ShellFeature
    {
        public ShellFeature()
        {
        }

        public ShellFeature(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
