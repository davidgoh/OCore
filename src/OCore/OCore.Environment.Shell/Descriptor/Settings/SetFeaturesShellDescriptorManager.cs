﻿using OCore.Environment.Shell.Descriptor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCore.Environment.Shell.Descriptor.Settings
{
    /// <summary>
    /// Implements <see cref="IShellDescriptorManager"/> by returning a single tenant with a specified set
    /// of features. This class can be registered as a singleton as its state never changes.
    /// </summary>
    public class SetFeaturesShellDescriptorManager : IShellDescriptorManager
    {
        private readonly IEnumerable<ShellFeature> _shellFeatures;
        private ShellDescriptor _shellDescriptor;

        public SetFeaturesShellDescriptorManager(IEnumerable<ShellFeature> shellFeatures)
        {
            _shellFeatures = shellFeatures;
        }

        public Task<ShellDescriptor> GetShellDescriptorAsync()
        {
            if (_shellDescriptor == null)
            {
                _shellDescriptor = new ShellDescriptor
                {
                    Features = _shellFeatures.ToList()
                };
            }

            return Task.FromResult(_shellDescriptor);
        }

        public Task UpdateShellDescriptorAsync(int priorSerialNumber, IEnumerable<ShellFeature> enabledFeatures, IEnumerable<ShellParameter> parameters)
        {
            return Task.CompletedTask;
        }
    }
}