// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Diagnostics.TestHelpers;
using System;

namespace Microsoft.Diagnostics.DebugServices.UnitTests
{
    [Command(Name = "writetestdata", Help = "Writes the test data xml file.")]
    public class WriteTestDataCommand : CommandBase
    {
        [ServiceImport]
        public IServiceProvider Services { get; set; }

        [Argument(Name = "FileName", Help = "Test data file path.")]
        public string FileName { get; set; }

        public override void Invoke()
        {
            if (string.IsNullOrEmpty(FileName))
            {
                throw new DiagnosticsException("Test data file parameter needed");
            }
            var testDataWriter = new TestDataWriter();
            testDataWriter.Build(Services);
            testDataWriter.Write(FileName);
            WriteLine($"Test data written to {FileName} successfully");
        }
    }
}
